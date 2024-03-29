using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkStreamingClientApp
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
      TcpClient socketForServer;
      try
      {
        socketForServer = new TcpClient("localHost", 65000);
      }
      catch
      {
        log.WriteLine("Failed to connect to server at {0}:65000", "localhost");
        return;
      }

      NetworkStream networkStream = socketForServer.GetStream();
      StreamReader streamReader = new StreamReader(networkStream);
      try
      {
        string outputString;
        do
        {
          outputString = streamReader.ReadLine();
          if (outputString != null)
          {
            log.WriteLine(outputString);
          }
        }
        while (outputString != null);
      }
      catch
      {
        log.WriteLine("Exception reading from Server");
      }
      networkStream.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      TcpClient socketForServer;
      try
      {
        socketForServer = new TcpClient("localHost", 65001);
      }
      catch
      {
        log.WriteLine("Failed to connect to server at {0}:65001", "localhost");
        return;
      }

      NetworkStream networkStream = socketForServer.GetStream();
      StreamWriter streamWriter = new StreamWriter(networkStream);
      try
      {
        log.WriteLine("posting: " + textBox2.Text);
        streamWriter.WriteLine(textBox2.Text);
        log.WriteLine("posted...");
        streamWriter.Close();
        log.WriteLine("disconnected");
      }
      catch
      {
        log.WriteLine("Exception reading from Server");
      }
      networkStream.Close();
      socketForServer.Close();
    }


    void send(string txt)
    {
      TcpClient socketForServer;
      try
      {
        socketForServer = new TcpClient("localHost", 65001);
      }
      catch
      {
        log.WriteLine("Failed to connect to server at {0}:65001", "localhost");
        return;
      }

      NetworkStream networkStream = socketForServer.GetStream();
      StreamWriter streamWriter = new StreamWriter(networkStream);
      try
      {
        streamWriter.WriteLine(txt);
        log.WriteLine("posted: " + txt);
        streamWriter.Close();
      }
      catch
      {
        log.WriteLine("Exception reading from Server");
      }
      networkStream.Close();
      socketForServer.Close();
    }


    private void button3_Click(object sender, EventArgs e)
    {
      //for (int i = 1; i <= 100; i++)
      //{
      //  Thread t = new Thread(
      //    (j) => { send(j.ToString() + " " + textBox2.Text); }
      //    );
      //  t.Start(i);
      //}

      Parallel.For(1, 100, val =>
       {
         Task.Run(
           () =>
           {
             send(val.ToString() + " " + textBox2.Text);
           });
       }
      );

    }
  }
}

