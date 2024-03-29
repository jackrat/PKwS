using _Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_A_Http
{
  public partial class Form1 : Form
  {

    Random rnd;
    Log log;


    public Form1()
    {
      InitializeComponent();
      log = new Log(tbLogCli);
      rnd = new Random((int)DateTime.Now.Ticks);
    }



    //generowanie losowej nazwy pliku
    string getFN(string adr)
    {
      if (adr.EndsWith(".exe") || adr.EndsWith(".msi") || adr.EndsWith(".dll") || adr.EndsWith(".pdb"))
        return Path.GetFileName(adr);
      else
        return Path.GetFileName(Path.GetTempFileName()) + ".html";
    }


    void Vision(string fn)
    {
      log.l("Finished!");
      if (fn.EndsWith(".html"))
      {
        log.l("\r\n" + File.ReadAllText(fn));
        Process.Start(fn);
      }
      else
      {
        string ffn = Path.GetDirectoryName(Path.GetFullPath(fn));
        Process.Start("explorer.exe", $"/ select, \"{ffn}\"");
      }
    }



    private void btnWebClient_Click(object sender, EventArgs e)
    {
      tbLogCli.Clear();
      string adr = cbAddresses.Text;
      WebClient webClient = new WebClient();
      try
      {
        string fileName = getFN(adr);
        log.l($"Downloading to \"{fileName}\" ...");
        webClient.DownloadFile(adr, fileName);
        Vision(fileName);
      }
      catch (Exception ex)
      {
        log.l(ex.Message);
      }
      webClient.Dispose();
    }


    private void btnWebClient2_Click(object sender, EventArgs e)
    {
      tbLogCli.Clear();
      string adr = cbAddresses.Text;
      string fileName = getFN(adr);
      WebClient webClient = new WebClient();
      try
      {
        log.l($"Downloading to \"{fileName}\" ...");
        webClient.DownloadProgressChanged += (so, ea) =>
        {
          progressBar1.Value = ea.ProgressPercentage;
        };
        webClient.DownloadFileCompleted += (so, ea) =>
        {
          Vision(fileName);
        };
        webClient.DownloadFileAsync(new Uri(adr), fileName);
      }
      catch (WebException ex)
      {
        log.l(ex.Message);
      }

    }




    private void btnWebClient3_Click(object sender, EventArgs e)
    {
      tbLogCli.Clear();
      WebClient webClient = new WebClient();
      //NetworkCredential credentials = new NetworkCredential("STUDENT", "123456");
      //webClient.Credentials = credentials;
      string[] fs = Directory.GetFiles(".");
      string fn = fs[rnd.Next(fs.Length)];
      string adr = cbAddresses.Text;
      string fileName = getFN(adr);
      try
      {
        log.l($"Uploading {fn} ...");
        byte[] b = webClient.UploadFile(adr, "POST", fn);
        string res = Encoding.ASCII.GetString(b);
        File.WriteAllText(fileName, res);
        Vision(fileName);
      }
      catch (WebException ex)
      {
        log.l(ex.Message);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      tbLogCli.Clear();
      WebClient webClient = new WebClient();
      string[] fs = Directory.GetFiles(".");
      string fn = fs[rnd.Next(fs.Length)];
      string adr = cbAddresses.Text;
      string fileName = getFN(adr);
      try
      {
        log.l($"Uploading {fn} ...");
        webClient.UploadProgressChanged += (os, ea) =>
        {
          progressBar1.Value = ea.ProgressPercentage;
        };
        webClient.UploadFileCompleted += (os, ea) =>
        {
          string res = Encoding.ASCII.GetString(ea.Result);
          File.WriteAllText(fileName, res);
          Vision(fileName);
        };
        webClient.UploadFileAsync(new Uri(adr), "POST", fn);
      }
      catch (WebException ex)
      {
        log.l(ex.Message);
      }
    }


    //HttpClient is intended to be instantiated once per application,
    //rather than per-use. 
    static readonly HttpClient httpClient = new HttpClient();

    async private void btnHttpClient1_Click(object sender, EventArgs e)
    {
      string adr = cbAddresses.Text;
      string fileName = getFN(adr);
      log.l($"Downloading to \"{fileName}\" ...");
      try
      {
        HttpResponseMessage response = await httpClient.GetAsync(adr);
        log.l(response.StatusCode.ToString());
        string responseBody = await response.Content.ReadAsStringAsync();
        //string responseBody = await httpClient.GetStringAsync(adr);
        File.WriteAllText(fileName, responseBody);
        Vision(fileName);
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }

    async private void btnHttpClient2_Click(object sender, EventArgs e)
    {
      string adr = cbAddresses.Text;
      string fileName = getFN(adr);
      log.l($"Downloading to \"{fileName}\" ...");
      try
      {
        byte[] responseBytes = await httpClient.GetByteArrayAsync(adr);
        log.l($"Odebrano {responseBytes.Length/1024} kB");
        File.WriteAllBytes(fileName, responseBytes);
        Vision(fileName);
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }

    async private void btnHttpClientUpload_Click(object sender, EventArgs e)
    {
      tbLogCli.Clear();
      string[] fs = Directory.GetFiles(".");
      string fn = fs[rnd.Next(fs.Length)];
      string adr = cbAddresses.Text;
      string fileName = getFN(adr);
      try
      {
        log.l($"Uploading {fn} ...");

        byte[] buf = File.ReadAllBytes(fn);
        ByteArrayContent fileContent = new ByteArrayContent(buf);
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        MultipartFormDataContent form = new MultipartFormDataContent();
        form.Add(fileContent, "file", Path.GetFileName(fn));
        HttpResponseMessage resp = await httpClient.PostAsync(adr, form);
        log.l(resp.StatusCode.ToString());
        string res = await resp.Content.ReadAsStringAsync();
        File.WriteAllText(fileName, res);
        Vision(fileName);
      }
      catch (WebException ex)
      {
        log.l(ex.Message);
      }
    }

   async private void btnProgress_Click(object sender, EventArgs e)
    {
      string adr = cbAddresses.Text;
      string fileName = getFN(adr);
      log.l($"Downloading to \"{fileName}\" ...");
      try
      {

        HttpResponseMessage rm = await httpClient.GetAsync(adr);
        log.l($"StatusCode: {rm.StatusCode}");
        byte[] bytes = await rm.Content.ReadAsByteArrayAsync();
        log.l($"Odebrano {bytes.Length / 1024} kB");
        File.WriteAllBytes(fileName, bytes);
        Vision(fileName);
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }

    





  }


}
