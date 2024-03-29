using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace httpscrap
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DateTime dt = monthCalendar1.SelectionStart;

       string s = $"https://tge.pl/energia-elektryczna-rdn?dateShow={dt:dd-MM-yyyy}&dateAction=";

      WebClient wc = new WebClient();
      wc.DownloadFile(s, dt.ToString("yyyy-MM-dd.txt"));
      wc.Dispose();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      DateTime dt = monthCalendar1.SelectionStart;

      string s = $"https://tge.pl/energia-elektryczna-rdn?dateShow={dt:dd-MM-yyyy}&dateAction=";

      webBrowser1.Navigate(s);
    }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
     HtmlElement el = webBrowser1.Document.GetElementById("footable_kontrakty_godzinowe");
      textBox1.Text = el.InnerText;
    }
  }
}
