using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace _08_A_WebServives
{
  public class DataClass
  {
    public int Len;
    public string BmpType;
    public byte[] Bytes;
  }

  public class ResultClass
  {
    public int Count;
    public List<string> LstStr;
    public MyDict Dict { get => dct; set => dct = value; }
    private MyDict dct;
    public MyBmp Bmp;
  }

  public class MyDict
  {
    public List<string> Keys = new List<string>();
    public List<int> Values = new List<int>();
    public void Add(string k, int v)
    {
      Keys.Add(k);
      Values.Add(v);
    }
    public MyDict() { }
    public MyDict(Dictionary<string, int> par)
    {
      foreach (KeyValuePair<string, int> el in par)
      {
        Add(el.Key, el.Value);
      }
    }
  }

  public class MyBmp
  {
    public string BmpAsBase64;
    public string BmpExt;
    public MyBmp() { }
    public MyBmp(string fn)
    {
      byte[] bytes = File.ReadAllBytes(fn);
      BmpAsBase64 = Convert.ToBase64String(bytes);
      BmpExt = Path.GetExtension(fn);
    }
  }


}