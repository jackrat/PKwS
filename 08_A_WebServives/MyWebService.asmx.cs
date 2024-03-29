using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _08_A_WebServives
{
  /// <summary>
  /// Summary description for MyWebService
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class MyWebService : System.Web.Services.WebService
  {

    [WebMethod]
    public string HelloWorld()
    {
      return "Hello World";
    }

    [WebMethod]
    public string HelloWorld2(string name)
    {
      return "Hello " + name;
    }


    Random rnd = new Random();

    [WebMethod]
    public double[] GetRandomArray(int n)
    {
      double[] res = new double[n];
      for (int i = 0; i < n; i++)
        res[i] = Math.Round(1000 * rnd.NextDouble()) / 10;
      return res;
    }


    [WebMethod]
    public ResultClass GetResult()
    {
      ResultClass res = new ResultClass();
      res.Count = 5 + rnd.Next(5);
      res.LstStr = new List<string>();
      Dictionary<string, int> d = new Dictionary<string, int>();
      for (int i = 0; i < res.Count; i++)
      {
        res.LstStr.Add($"Ala ma {i} kotów!");
        d.Add($"abc{i:0000}", rnd.Next(100));
      }
      res.Dict = new MyDict(d);
      string[] files = Directory.GetFiles(@"D:\Documents\bmp");
      res.Bmp = new MyBmp(files[rnd.Next(files.Length)]);
      return res;
    }


    [WebMethod]
    public ResultClass GetResult2(DataClass data)
    {
      ResultClass res = new ResultClass();
      res.Count = data.Len + rnd.Next(5);
      res.LstStr = data.Bytes.Select(b => $"Bajt nr: {b}").ToList();
      res.Dict = new MyDict();
      for (int i = 0; i < res.Count; i++)
      {
        res.Dict.Add($"abc{i:0000}", rnd.Next(100));
      }
      string[] files = Directory.GetFiles(@"D:\Documents\bmp", "*" + data.BmpType);
      res.Bmp = new MyBmp(files[rnd.Next(files.Length)]);
      return res;
    }


  }
}
