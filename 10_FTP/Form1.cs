using _Log;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _10_Ftp
{
  public partial class Form1 : Form
  {

    Log log;

    public Form1()
    {
      InitializeComponent();
      log = new Log(tbLog);
    }

    private void rb_CheckedChanged(object sender, EventArgs e)
    {
      tbLogin.Enabled = rbLoginPass.Checked;
      tbPass.Enabled = rbLoginPass.Checked;
    }

    NetworkCredential GetCredential()
    {
      if (rbAnonymous.Checked)
        return new NetworkCredential("anonymous", "anonymous@anonymous.com");
      else
        return new NetworkCredential(tbLogin.Text, tbPass.Text);
    }


    private void btnListDirectory_Click(object sender, EventArgs e)
    {
      try
      {
        FtpWebRequest request = WebRequest.Create($"ftp://{cbHost.Text}/") as FtpWebRequest;
        if (cbDetailedList.Checked)
          request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        else
          request.Method = WebRequestMethods.Ftp.ListDirectory;
        request.Credentials = GetCredential();
        FtpWebResponse response = request.GetResponse() as FtpWebResponse;
        log.l($"Status\r\n{ response.StatusDescription}");
        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);
        string respString = reader.ReadToEnd();
        log.l($"DIR:\r\n{respString}");
        if (!cbDetailedList.Checked)
        {
          string[] fnlines = respString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
          lbFiles.DataSource = fnlines;
        }
        response.Close();
        reader.Close();
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }

    private async void btnRETR_Click(object sender, EventArgs e)
    {
      try
      {
        string FN = (string)lbFiles.SelectedItem;
        Uri uri = new Uri($"ftp://{cbHost.Text}/{FN}");
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
        request.Credentials = GetCredential();
        FtpWebResponse response = request.GetResponse() as FtpWebResponse;
        log.l($"Status\r\n{ response.StatusDescription}");
        Stream responseStream = response.GetResponseStream();

        //StreamReader reader = new StreamReader(responseStream);
        //string respString = reader.ReadToEnd();
        //log.l($"TEXTFILE:\r\n{respString}");
        //File.WriteAllText(LocFN, respString);

        string LocFN = Path.GetFullPath($@".\{FN}");
        FileStream fs = new FileStream(LocFN, FileMode.Create);
        await responseStream.CopyToAsync(fs);
        fs.Close();

        responseStream.Close();
        response.Close();
        log.l($"Pobrano plik: {FN}");
        Process.Start(LocFN);
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }

    private void btnRETR2_Click(object sender, EventArgs e)
    {
      try
      {
        string FN = (string)lbFiles.SelectedItem;
        string LocFN = Path.GetFullPath($@".\{FN}");
        Uri uri = new Uri($"ftp://{cbHost.Text}/{FN}");
        WebClient client = new WebClient();
        client.DownloadFileCompleted += (os, oe) =>
        {
          log.l($"File {FN} DOWNLOADED!");
        };
        client.Credentials = GetCredential();
        //client.DownloadFile(uri, LocFN);
        client.DownloadFileAsync(uri, LocFN);
        if (File.Exists(LocFN))
        {
          log.l($"File {FN} DOWNLOADED!");
          Process.Start(LocFN);
        }
        else
          log.l($"File {FN} NOT DOWNLOADED!");
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }

    private void btnSTOR_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          string fullFN = Path.GetFullPath(ofd.FileName);
          string FN = Path.GetFileName(fullFN);
          Uri uri = new Uri($"ftp://{cbHost.Text}/{FN}");
          FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
          request.Credentials = GetCredential();
          request.Method = WebRequestMethods.Ftp.UploadFile;
          FileStream fs = new FileStream(fullFN, FileMode.Open);
          Stream reqStream = request.GetRequestStream();
          fs.CopyTo(reqStream);
          fs.Close();
          reqStream.Close();
          FtpWebResponse response = request.GetResponse() as FtpWebResponse;
          log.l($"Status\r\n{ response.StatusDescription}");
          response.Close();
        }
        catch (Exception exc)
        {
          log.l(exc.Message);
        }
      }
    }

    private void btnDELE_Click(object sender, EventArgs e)
    {
      try
      {
        string FN = (string)lbFiles.SelectedItem;
        Uri uri = new Uri($"ftp://{cbHost.Text}/{FN}");
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
        request.Credentials = GetCredential();
        request.Method = WebRequestMethods.Ftp.DeleteFile;
        FtpWebResponse response = request.GetResponse() as FtpWebResponse;
        log.l($"Status\r\n{ response.StatusDescription}");
        response.Close();
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }
  }
}
