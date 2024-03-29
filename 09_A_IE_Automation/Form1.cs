using _Log;
using mshtml;
using SHDocVw;
using System;
using System.Windows.Forms;

namespace _09_A_IE_Automation
{
  public partial class Form1 : Form
  {

    /*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    Jeśli jest Edge, konieczne: Edge->Ustawienia->Przegladarka domyślna->Zgodność programu Inernet Explorer->Umożliwia otwieranie witryn (...)->Nigdy

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/


    Log log;
    InternetExplorer IE;
    IHTMLDocument2 document;

    public Form1()
    {
      InitializeComponent();
      log = new Log(textBox1);
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      if (IE == null)
      {
        IE = new InternetExplorer();
        IE.DocumentComplete += IE_DocumentComplete;
      }
      IE.Visible = true;
    }

    private void IE_DocumentComplete(object pDisp, ref object URL)
    {
      log.l($"IE_DocumentComplete... {URL}");
      document = IE.Document as IHTMLDocument2;
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
      if (IE != null)
      {
        IE.Quit();
        IE = null;
      }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (IE != null)
      {
        IE.Quit();
        IE = null;
      }
    }

    private void btnNavigate_Click(object sender, EventArgs e)
    {
      IE.Navigate("https://www.google.pl/");
    }

    private void btnLogoSrc_Click(object sender, EventArgs e)
    {
      IHTMLElement logo = (document as HTMLDocument).getElementById("hplogo");
      IHTMLImgElement img = logo as IHTMLImgElement;
      img.src = "http://212.87.228.200:3000/img/favicon.png";

    }

    private void btnLogoRemove_Click(object sender, EventArgs e)
    {
      IHTMLElement logo = (document as HTMLDocument).getElementById("hplogo");
      (logo as IHTMLDOMNode).removeNode();
    }

    private void btnInput_Click(object sender, EventArgs e)
    {
      HTMLInputElement input = document.all.item("q");
      input.value = "Ala ma kota";
    }

    private void btnIterates_Click(object sender, EventArgs e)
    {
      IHTMLElementCollection col = document.all;
      int i = 0;
      foreach (IHTMLElement el in col)
      {
        if (el.tagName == "INPUT")
        {
          log.l($"{++i} name: {el.getAttribute("name")} type: {el.getAttribute("type")}  {el.outerHTML}");
        }
      }

    }

    private void btnClick_Click(object sender, EventArgs e)
    {
      HTMLInputButtonElement btn = document.all.item("btnG");
      HTMLInputElement input = document.all.item("q");
      input.select();
      btn.focus();
      btn.click();
    }

    private void btnAppendChild_Click(object sender, EventArgs e)
    {
      IHTMLElement nowy = document.createElement("h1");
      nowy.innerHTML = "WITAJ ŚWIECIE!!!";
      HTMLInputButtonElement btn = document.all.item("btnG");
      (btn.parentElement as IHTMLDOMNode).appendChild(nowy as IHTMLDOMNode);
    }

    private void btnNavigate2_Click(object sender, EventArgs e)
    {
      IE.Navigate("http://212.87.228.200:3000/user/login");
    }

    private void btnInputs_Click(object sender, EventArgs e)
    {
      IHTMLInputElement user = document.all.item("user_name");
      user.value = "student";
      IHTMLInputElement pass = document.all.item("password");
      pass.value = "123456";
    }

    private void btnClick2_Click(object sender, EventArgs e)
    {
      var buttons = (IE.Document as HTMLDocument).getElementsByTagName("BUTTON");
      foreach (HTMLInputButtonElement b in buttons)
      {
        if (b.className == "ui green button")
        {
          b.click();
          break;
        }
      }

    }
  }
}
