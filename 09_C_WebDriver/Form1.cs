using _Log;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Windows.Forms;

namespace _09_C_WebDriver
{
  public partial class Form1 : Form
  {


    Log log;
    IWebDriver driver;
    IJavaScriptExecutor js;

    public Form1()
    {
      InitializeComponent();
      log = new Log(textBox1);
    }

    private void btnOpen_Click(object sender, System.EventArgs e)
    {
      if (driver == null)
      {
        //driver = new ChromeDriver(".");
        driver = new ChromeDriver();
        js = driver as IJavaScriptExecutor;
      }
    }

    private void btnQuit_Click(object sender, System.EventArgs e)
    {
      if (driver != null)
      {
        driver.Quit();
        driver = null;
      }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (driver != null)
      {
        driver.Quit();
        driver = null;
      }
    }

    private void btnNavigate_Click(object sender, System.EventArgs e)
    {
      driver.Navigate().GoToUrl("https://www.google.pl/");

      //WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
      //waiter.Until(d => d.FindElement(By.XPath("//input[@name='q']")));
      //log.l($"completed: {driver.Url}");
      ////IWebElement inp = driver.FindElement(By.XPath("//input[@name='q']"));

      //IWebElement inp = driver.FindElement(By.Name("q"));
      ////inp.SendKeys("Ola ma psa" + OpenQA.Selenium.Keys.Enter);
      //inp.SendKeys("Ola ma psa");
    }

    private void btnLogoSrc_Click(object sender, EventArgs e)
    {
      //IWebElement logo = driver.FindElement(By.Id("hplogo"));
      //logo.??? nie ma możliwości modyfikacji tą drogą!
      js.ExecuteScript(@"
        //var logo = document.getElementById('hplogo');
        var logo = document.querySelector('.lnXdpd');
        logo.src = 'http://212.87.228.200:3000/img/gogs-hero.png';
      ");
    }

    private void btnLogoRemove_Click(object sender, EventArgs e)
    {
      js.ExecuteScript(@"
        //var logo = document.getElementById('hplogo');
        var logo = document.querySelector('.lnXdpd');
        logo.remove();
      ");
    }

    private void btnInput_Click(object sender, EventArgs e)
    {
      IWebElement inp = driver.FindElement(By.Name("q"));
      inp.SendKeys(
        string.Join("", 
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace,
        OpenQA.Selenium.Keys.Backspace)
        +
        "Ala ma kota"); ;
    }

    private void btnClick_Click(object sender, EventArgs e)
    {
      IWebElement btn = driver.FindElement(By.Name("btnK"));
      //IWebElement btn = driver.FindElement(By.CssSelector(".gNO89b"));
      btn.Click();
    }

    private void btnIterates_Click(object sender, EventArgs e)
    {
      var inps = driver.FindElements(By.TagName("input"));
      int i = 0;
      foreach (var el in inps)
      {
        log.l($"{++i} tag: {el.TagName}  name: {el.GetAttribute("name")} text:{el.Text}");
      }    
    }

    private void btnAppendChild_Click(object sender, EventArgs e)
    {
      IWebElement inp = driver.FindElement(By.Name("q"));

      js.ExecuteScript(
        @"
          var h1 = document.createElement('h1');
          h1.innerHTML = 'WITAJ ŚWIECIE!!!!'; 
          //var div = document.querySelector('input[name=\'q\']').parentElement;
          var div = document.getElementsByName('q')[0].parentElement;
          div.appendChild(h1); 
         ");
    }

    private void btnNavigate2_Click(object sender, EventArgs e)
    {
      driver.Navigate().GoToUrl("http://212.87.228.200:3000/user/login/");
    }

    private void btnInputs_Click(object sender, EventArgs e)
    {
      driver.FindElement(By.Id("user_name")).SendKeys("student");
      driver.FindElement(By.Id("password")).SendKeys("123456");
    }

    private void btnClick2_Click(object sender, EventArgs e)
    {
      driver.FindElement(By.CssSelector("button.ui.green.button")).Click();
    }
  }
}
