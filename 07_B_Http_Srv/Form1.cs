using _Log;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _07_B_Http_Srv
{
  public partial class Form1 : Form
  {
    Log log;

    public Form1()
    {
      InitializeComponent();
      log = new Log(textBox1);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      button1.Enabled = false;
      Run("localhost", 3003);
    }

    async void Run(string host, int port)
    {
      int requestCount = 0; //ilość żądań
      int pageViews = 0; //ilość odsłon strony
      bool stop = false; //hamulec
      HttpListener listener = new HttpListener();
      //listener.Prefixes.Clear();
      listener.Prefixes.Add($"http://{host}:{port}/");
      listener.Start();
      do
      {
        log.l($"Listening on port {port}...");
        HttpListenerContext ctx = await listener.GetContextAsync();
        //request info                
        if (cbxLogReq.Checked) LogRequestInfo(++requestCount, ctx.Request); else log.l($"REQUEST: {ctx.Request.HttpMethod} {ctx.Request.Url}");
        //favicon
        if (ctx.Request.Url.AbsolutePath.EndsWith("/favicon.ico"))
        {
          ReturnFile(@".\favicon.png", "image/png", ctx.Response);
          continue;
        }
        //download from server
        string fileName = ctx.Request.Url.AbsolutePath.Substring(1);
        if (ctx.Request.HttpMethod.ToLower() == "get" && File.Exists(fileName))
        {
          ReturnFile(fileName, "application/octet-stream", ctx.Response);
          continue;
        }
        //upload to server
        if (ctx.Request.HasEntityBody)
        {
          PrepareUpload(ctx.Request);
        }
        //return html page        
        stop = ctx.Request.RawUrl.Contains("stop");
        PreparePage(ctx.Response, stop, requestCount, ++pageViews);
      } while (!stop);
      log.l("server stopping...");
      listener.Close();
      log.l("server stopped");
      button1.Enabled = true;
    }

    void LogRequestInfo(int requestCount, HttpListenerRequest req)
    {
      log.l($@"REQUEST INFO
          nr: {requestCount}
          Method: {req.HttpMethod}
          Url: {req.Url}
          RawUrl: {req.RawUrl}
          QueryString: {string.Join(", ", req.QueryString.Keys.Cast<string>().Select(k => $"{k}: {req.QueryString[k]}"))}
          ProtocolVersion: {string.Join(", ", req.ProtocolVersion)}
          IsLocal: {string.Join(", ", req.IsLocal)}
          LocalEndPoint: {string.Join(", ", req.LocalEndPoint)}                   
          IsSecureConnection: {string.Join(", ", req.IsSecureConnection)}
          KeepAlive: {string.Join(", ", req.KeepAlive)}          
          AcceptTypes: {string.Join(", ", req.AcceptTypes)}
          ContentEncoding: {req.ContentEncoding}
          ContentLength64: {req.ContentLength64}
          ContentType: {req.ContentType}
          Cookies: {string.Join(", ", req.Cookies)}
          UserHostName: {req.UserHostName}
          UserAgent: {req.UserAgent}
          UserLanguages: {string.Join(", ", req.UserLanguages)}          
          Cookies: {string.Join(", ", req.Cookies)}
          Headers:{"\r\n\t\t"}{string.Join("\r\n\t\t", req.Headers.Keys.Cast<string>().Select(k => $"{k}: {req.Headers[k]}"))}");
    }

    void ReturnFile(string fn, string mime, HttpListenerResponse resp)
    {
      string fullPath = Path.GetFullPath(fn);
      string fileName = Path.GetFileName(fn);
      resp.ContentType = mime;
      resp.ContentLength64 = (new FileInfo(fullPath)).Length;
      resp.AddHeader("Content-Disposition", $"Attachment; filename={fileName}");
      FileStream fs = File.OpenRead(fullPath);
      fs.CopyTo(resp.OutputStream);
      fs.Close();
      resp.Close();
      log.l($"returned file: {fileName}");
    }

    void PrepareUpload(HttpListenerRequest req)
    {
      //dirty write to file (to comment)
      MemoryStream ms = new MemoryStream();
      req.InputStream.CopyTo(ms);
      byte[] contentBytes = ms.ToArray();
      //File.WriteAllBytes("plik.txt", contentBytes);
      //extract boundary // ContentType: multipart/form-data; boundary=----WebKitFormBoundaryWb8fCY0IyHjBByxx
      string boundary = "--" + req.ContentType.Split(';')[1].Split('=')[1];
      byte[] boundaryBytes = req.ContentEncoding.GetBytes(boundary);
      //boundary indexes
      List<int> bndLst = FindAllIndexes(contentBytes, boundaryBytes);
      //CRLF vs LF
      byte[] crlf = req.ContentEncoding.GetBytes("\r\n");
      int newLn = FindBoundaryIndex(contentBytes, crlf, 0) >= 0 ? 2 : 1;
      byte[] newLnBytes = newLn == 2 ? crlf : req.ContentEncoding.GetBytes("\n");
      //find parts
      List<byte[]> partLst = new List<byte[]>();
      for (int k = 1; k < bndLst.Count; k++)
        partLst.Add(GetPart(contentBytes, bndLst, k, boundaryBytes.Length, newLn));
      //process parts
      foreach (byte[] part in partLst)
      {
        List<int> lns = FindAllIndexes(part, newLnBytes);
        string fileName = null;
        bool nextIsFile = false;
        for (int k = 0; k <= lns.Count; k++)
        {
          byte[] line = null;
          if (nextIsFile)
          {
            if (!string.IsNullOrEmpty(fileName)) SaveFile(part, lns, k, newLn, fileName);
            break;
          }
          else
            line = GetPart2(part, lns, k, newLn);
          string s = req.ContentEncoding.GetString(line);
          if (s == "" && fileName != null)
            nextIsFile = true;
          if (s != "" && s.Contains("filename=")) // Content-Disposition: form-data; name="plik1"; filename="Mapping.png"
            fileName = s.Split(';').Where(it => it.Contains("filename=")).FirstOrDefault().Split('=')[1].Split('\"')[1];
        }
      }
    }

    int FindBoundaryIndex(byte[] workArr, byte[] toFind, int start)
    {
      for (int i = start; i <= workArr.Length - toFind.Length; i++)
      {
        bool bingo = true;
        for (int j = 0; j < toFind.Length && bingo; j++)
        {
          bingo = workArr[i + j] == toFind[j];
          if (!bingo) break;
        }
        if (bingo)
          return i;
      }
      return -1;
    }

    List<int> FindAllIndexes(byte[] workArr, byte[] toFind)
    {
      List<int> lst = new List<int>();
      int bi = 0;
      do
      {
        bi = FindBoundaryIndex(workArr, toFind, bi);
        if (bi >= 0)
        {
          lst.Add(bi);
          bi += toFind.Length;
        }
      } while (bi >= 0);
      return lst;
    }

    byte[] GetPart(byte[] bytes, List<int> lst, int k, int bound, int newLn)
    {
      int i0 = lst[k - 1] + bound + newLn;
      int i1 = lst[k] - 1;
      byte[] part = new byte[i1 - i0 + 1 - newLn];
      Array.Copy(bytes, i0, part, 0, part.Length);
      return part;
    }

    byte[] GetPart2(byte[] bytes, List<int> lst, int k, int newLn)
    {
      int i0 = k == 0 ? 0 : lst[k - 1] + newLn;
      int i1 = k < lst.Count ? lst[k] - 1 : bytes.Length - 1;
      byte[] part = new byte[i1 - i0 + 1];
      Array.Copy(bytes, i0, part, 0, part.Length);
      return part;
    }

    private void SaveFile(byte[] part, List<int> lns, int k, int newLn, string fileName)
    {
      int i0 = lns[k - 1] + newLn;
      int i1 = part.Length - 1;
      byte[] fileBytes = new byte[i1 - i0 + 1];
      Array.Copy(part, i0, fileBytes, 0, fileBytes.Length);
      File.WriteAllBytes(fileName, fileBytes);
      log.l($"Plik \"{fileName}\" załadowany!");
    }

    async void PreparePage(HttpListenerResponse response, bool stop, int requestCount, int pageViews)
    {
      string disableInputs = stop ? "disabled" : string.Empty;
      IEnumerable<string> files = Directory.GetFiles(".").Select(it => Path.GetFileName(it)).Select(it => $"<li><a href='{it}' {disableInputs}>{it}</a></li>");
      byte[] data = Encoding.UTF8.GetBytes(string.Format(pageTemplate, requestCount, pageViews, disableInputs, string.Join("\r\n", files)));
      response.ContentType = "text/html";
      response.ContentEncoding = Encoding.UTF8;
      response.ContentLength64 = data.LongLength;
      await response.OutputStream.WriteAsync(data, 0, data.Length);
      response.Close();
    }

    static string pageTemplate =
@"<!DOCTYPE html>
<html> 
<head>
    <title>07_B_Http_Srv</title>
    <meta charset='UTF-8'/>
    <style>
       body{{width:350px;}}
       form {{border:1px solid silver; padding:5px; border-radius: 10px;}}       
       input{{margin: 3px;}}
       button{{align:right;}}
       div{{text-align:right;}}
    </style>
  </head>
  <body>
    <hr/> 
    <p>Żądań: {0}</p>    
    <p>Odsłon: {1}</p>
    <hr/>    
    <form method='GET' action='stop' style=''>
      <div>Zatrzymaj serwer: <input type ='submit' value='stop' {2}></div>
    </form>    
    <hr/>
    <form enctype='multipart/form-data' method='POST'> 
     Wpisz tekst: <input name = 'txt' id='txt' type='text' {2}/> <br/>
     <input name = 'plik1' id='plik1' type='file' {2}/> <br/>
     Zaznacz lub nie: <input name = 'cbx' id='cbx' type='checkbox' {2}/> <br/> 
	   <input name = 'plik2' id='plik2' type='file' {2}/> <br/>
     <hr/>
	   <div><input type = 'submit' value='Wyślij' {2}/></div> 	
    </form> 
    <ul>
     {3}
    </ul>
    <hr/>
      <div><button onclick='location.href = location.origin;'>reload</button></div>
  </body>
</html>";

  }
}
