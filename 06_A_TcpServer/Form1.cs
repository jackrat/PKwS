using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkStreamingServerApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      log.Init(textBox1);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      NetworkIOServer srv = new NetworkIOServer();
      (new Thread(srv.RunToSend)).Start();
      ;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      NetworkIOServer srv = new NetworkIOServer();
      srv.Run_ReceiveFromSocket();
    }

    private void button3_Click(object sender, EventArgs e)
    {


      NetworkIOServer srv = new NetworkIOServer();
      Task.Run(() => { srv.Run_ReceiveFromClient(); });

    }

    private void button4_Click(object sender, EventArgs e)
    {
      NetworkIOServer srv = new NetworkIOServer();
      srv.StartAsync();
    }
  }
}
