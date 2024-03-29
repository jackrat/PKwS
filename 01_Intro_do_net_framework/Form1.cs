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

namespace _01_Intro_b
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      button1.BackColor = Color.Khaki;
      button1.Width = 123;
      button1.Height = 123;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      button1.BackColor = Color.FromArgb(0, 0, 255);
      button1.Left = 50;
      button1.Top = 150;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      MessageBox.Show(textBox1.Text);
      textBox1.Text = textBox1.Text + "  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    private void button4_Click(object sender, EventArgs e)
    {
      DialogResult res = openFileDialog1.ShowDialog();
      if(res == DialogResult.OK)
        textBox2.Text = File.ReadAllText(openFileDialog1.FileName);
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      //this.Text = listBox1.SelectedItem.ToString();
      //this.Text = (string)listBox1.SelectedItem;
      this.Text = Convert.ToString(listBox1.SelectedItem);
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      textBox2.Text += "\r\n" + comboBox1.Text;
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButton1.Checked)
        this.BackColor = Color.Red;
      else if (radioButton2.Checked)
        this.BackColor = Color.Green;
      else if (radioButton3.Checked)
        this.BackColor = Color.Blue;
    }

    private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
    {
      textBox1.Text = monthCalendar1.SelectionStart.ToString("yy-M-dd ddd dddd");
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      button5.Height = (int)numericUpDown1.Value;
    }
  }
}
