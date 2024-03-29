using _08_B_WebServiceClient.MyWebServiceReference;
using _Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08_B_WebServiceClient
{
  public partial class Form1 : Form
  {

    Log log;
    public Form1()
    {
      InitializeComponent();
      log = new Log(textBox1);
    }

    private async void button1_Click(object sender, EventArgs e)
    {
      try
      {
        MyWebServiceSoapClient cli = new MyWebServiceSoapClient("MyWebServiceSoap");
        string res = cli.HelloWorld();
        log.l(res);
        res = cli.HelloWorld2("Jacek");
        log.l(res);
        res = (await cli.HelloWorldAsync()).Body.HelloWorldResult;
        log.l(res);
        res = (await cli.HelloWorld2Async("Stanisław")).Body.HelloWorld2Result;
        log.l(res);
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }


    Random rnd = new Random((int)DateTime.Now.Ticks);

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        MyWebServiceSoapClient cli = new MyWebServiceSoapClient("MyWebServiceSoap");
        ArrayOfDouble tab = cli.GetRandomArray(5 + rnd.Next(100));
        string res = "double[]:  " + string.Join("; ", tab);
        log.l(res);
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      try
      {
        MyWebServiceSoapClient cli = new MyWebServiceSoapClient("MyWebServiceSoap");
        ResultClass res = cli.GetResult();
        log.l($@"cli.GetResult() => Count = {res.Count}
LstStr: {string.Join("; ", res.LstStr)}
Dict: {    string.Join("; ", res.Dict.Keys.Select(k => $"key={k}, value={res.Dict.Values[res.Dict.Keys.IndexOf(k)]}"))}
BmpExt: {res.Bmp.BmpExt}
BmpAsBase64: {res.Bmp.BmpAsBase64}
");
        byte[] bytes = Convert.FromBase64String(res.Bmp.BmpAsBase64);
        string fn = Path.GetTempFileName() + res.Bmp.BmpExt;
        File.WriteAllBytes(fn, bytes);
        label1.Text = fn;
        Bitmap bmp = new Bitmap(fn);
        pictureBox1.Image = bmp;
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }



    string[] exts = { ".bmp", ".png", ".jpg", ".tiff" };

    private void button4_Click(object sender, EventArgs e)
    {
      try
      {
        MyWebServiceSoapClient cli = new MyWebServiceSoapClient("MyWebServiceSoap");
        DataClass data = new DataClass();
        data.BmpType = exts[rnd.Next(exts.Length)];
        data.Bytes = new byte[rnd.Next(10)];
        data.Len = 5 + rnd.Next(5);
        ResultClass res = cli.GetResult2(data);
        log.l($@"cli.GetResult() => Count = {res.Count}
LstStr: {string.Join("; ", res.LstStr)}
Dict: {    string.Join("; ", res.Dict.Keys.Select(k => $"key={k}, value={res.Dict.Values[res.Dict.Keys.IndexOf(k)]}"))}
BmpExt: {res.Bmp.BmpExt}
BmpAsBase64: {res.Bmp.BmpAsBase64}
");
        byte[] bytes = Convert.FromBase64String(res.Bmp.BmpAsBase64);
        string fn = Path.GetTempFileName() + res.Bmp.BmpExt;
        File.WriteAllBytes(fn, bytes);
        label1.Text = fn;
        Bitmap bmp = new Bitmap(fn);
        pictureBox1.Image = bmp;
      }
      catch (Exception exc)
      {
        log.l(exc.Message);
      }
    }
  }
}
