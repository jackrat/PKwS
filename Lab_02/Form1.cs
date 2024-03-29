using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_02
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      Width += 20;
      Height += 20;
      Left -= 10;
      Top -= 10;
    }

    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
      Width -= 20;
      Height -= 20;
      Left += 10;
      Top += 10;
    }


    Random rnd = new Random();

    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
      BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue >= 48 && e.KeyValue <= 57) // cyfra
      {
        Left = 0;
      }
      else if (e.KeyValue >= 65 && e.KeyValue <= 90) //litera
      {
        Left = Screen.PrimaryScreen.Bounds.Width - Width;
      }
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyValue >= 48 && e.KeyValue <= 57) // cyfra
      {
        Top = 0;
      }
      else if (e.KeyValue >= 65 && e.KeyValue <= 90) //litera
      {
        Top = Screen.PrimaryScreen.Bounds.Height - Height;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      double a = double.Parse(textBox1.Text);
      double b = double.Parse(textBox2.Text);
      double c = double.Parse(textBox3.Text);
      double delta = Math.Pow(b, 2) - 4 * a * c;
      if (delta < 0)
        label1.Text = "Brak pierwiastków!";
      else if (delta == 0)
      {
        double x0 = -b / (2 * a);
        label1.Text = $"x0 = {x0}";
      }
      else
      {
        double x1 = (-b - Math.Sqrt(delta))/ (2 * a);
        double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
        label1.Text = $"x1 = {x1}\r\nx2 = {x2}";
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Pierwiastki p = new Pierwiastki();
       p.a = double.Parse(textBox1.Text);
       p.b = double.Parse(textBox2.Text);
       p.c = double.Parse(textBox3.Text);
      p.Oblicz();
      label1.Text = string.Join(" ,", p.wyniki);
    }
  }
}
