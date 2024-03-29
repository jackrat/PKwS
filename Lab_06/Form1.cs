using _Log;
using Lab_06.WebSrv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_06
{
  public partial class Form1 : Form
  {
    Log log;
    public Form1()
    {
      InitializeComponent();
      log = new Log(tbLog);
    }

    private async void button1_Click(object sender, EventArgs e)
    {
      SelectSoapClient cli = new SelectSoapClient("SelectSoap");
      DataTable tab = await cli.XmlDevicesAsync();
      dataGridView1.DataSource = tab;
    }

    private async void button2_Click(object sender, EventArgs e)
    {
      SelectSoapClient cli = new SelectSoapClient("SelectSoap");
      DataTable tab = await cli.XmlProfilesFromToAsync(7858, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, "1-1:1.5.0");
      dataGridView1.DataSource = tab;
    }
  }
}
