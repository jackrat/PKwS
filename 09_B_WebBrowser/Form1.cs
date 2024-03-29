using _Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_B_WebBrowser
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      log = new Log(textBox1);
    }

    Form2 f2;
    WebBrowser wb;
    Log log;

    private void btnOpen_Click(object sender, EventArgs e)
    {
      if (f2 == null)
      {
        f2 = new Form2();
        wb = f2.webBrowser1;
        f2.FormClosed += F2_FormClosed;
        wb.DocumentCompleted += Wb_DocumentCompleted;
        f2.Show();
      }
    }

    private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      log.l($"Wb_DocumentCompleted: {e.Url}");
    }

    private void F2_FormClosed(object sender, FormClosedEventArgs e)
    {
      f2 = null;
      wb = null;
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
      f2.Close();
      f2 = null;
      wb = null;
    }

    private void btnNavigate_Click(object sender, EventArgs e)
    {
      wb.Navigate("https://www.google.pl");
    }

    private void btnLogoSrc_Click(object sender, EventArgs e)
    {
      HtmlElement img = wb.Document.GetElementById("hplogo");
      img.SetAttribute("src", "http://212.87.228.200:3000/img/favicon.png");
    }

    private void btnLogoRemove_Click(object sender, EventArgs e)
    {
      HtmlElement img = wb.Document.GetElementById("hplogo");
      img.OuterHtml = "";

    }

    private void btnInput_Click(object sender, EventArgs e)
    {
      HtmlElementCollection coll = wb.Document.GetElementsByTagName("input");
      foreach (var o in coll)
      {
        HtmlElement el = o as HtmlElement;
        if (el.Name == "q")
        {
          el.SetAttribute("value", "Ala ma kota");
          el.Focus();
          break;
        }
      }
    }

    private void btnClick_Click(object sender, EventArgs e)
    {
      HtmlElementCollection coll = wb.Document.GetElementsByTagName("input");
      foreach (var o in coll)
      {
        HtmlElement el = o as HtmlElement;
        if (el.Name == "btnG")
        {
          el.Focus();
          el.InvokeMember("Click");
          break;
        }
      }
    }

    private void btnAppendChild_Click(object sender, EventArgs e)
    {
      HtmlElement h1 = wb.Document.CreateElement("h1");
      h1.InnerHtml = "WITAJCIE!!!";
      HtmlElementCollection coll = wb.Document.GetElementsByTagName("input");
      foreach (var o in coll)
      {
        HtmlElement el = o as HtmlElement;
        if (el.Name == "btnG")
        {
          el.Parent.AppendChild(h1);
          break;
        }
      }

    }

    private void btnNavigate2_Click(object sender, EventArgs e)
    {
      wb.Navigate("http://212.87.228.200:3000/user/login");
    }

    private void btnInputs_Click(object sender, EventArgs e)
    {
      wb.Document.GetElementById("user_name").SetAttribute("value", "student");
      wb.Document.GetElementById("password").SetAttribute("value", "123456");

    }

    private void btnClick2_Click(object sender, EventArgs e)
    {
      HtmlElementCollection coll = wb.Document.GetElementsByTagName("button");      
      foreach (var o in coll)
      {
        HtmlElement el = o as HtmlElement;        
        if (el.OuterHtml.Contains("ui green button"))
        {
          el.InvokeMember("Click");
          break;
        }
      }
    }
  }
}
