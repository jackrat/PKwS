using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_A_Sockets_Sync
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }


    void log(string s)
    {
      textBox1.Invoke(new Action(
        () =>
        {
          textBox1.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} - {s}\r\n");
        }));
    }


    Socket cliSocket, srvListSocket, srvSocket;
    IPHostEntry srvIPHostEntry;
    IPEndPoint srvIPEndPoint;



    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        srvIPHostEntry = Dns.Resolve(comboBox1.Text);
        log($"resolved: {srvIPHostEntry.HostName}, {string.Join<IPAddress>(", ", srvIPHostEntry.AddressList)}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        srvIPHostEntry = Dns.GetHostEntry(comboBox1.Text);
        log($"resolved: {srvIPHostEntry.HostName}, {string.Join<IPAddress>(", ", srvIPHostEntry.AddressList)}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button3_Click(object sender, EventArgs e)
    {
      try
      {
        srvIPEndPoint = new IPEndPoint(srvIPHostEntry.AddressList[0], Convert.ToInt32(numericUpDown1.Value));
        log($"new EndPoint: {srvIPEndPoint.Address}:{srvIPEndPoint.Port}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button4_Click(object sender, EventArgs e)
    {
      try
      {
        cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        log("new Socket");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button5_Click(object sender, EventArgs e)
    {

      try
      {
        log("connecting...");
        cliSocket.Connect(srvIPEndPoint);
        log("connected");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button6_Click(object sender, EventArgs e)
    {
      try
      {
        IPHostEntry iPHostEntry = Dns.Resolve(comboBox1.Text);
        srvListSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint iPEndPoint = new IPEndPoint(iPHostEntry.AddressList[0], Convert.ToInt32(numericUpDown1.Value));
        srvListSocket.Bind(iPEndPoint);
        srvListSocket.Listen(10);
        log($"Socket.Listen()");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button7_Click(object sender, EventArgs e)
    {
      try
      {
        log("accepting...");
        srvSocket = srvListSocket.Accept();
        log("accepted");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button8_Click(object sender, EventArgs e)
    {
      try
      {
        byte[] buf = Encoding.UTF8.GetBytes(textBox2.Text);
        log("cli sending...");
        cliSocket.Send(buf);
        log($"cli sended: {textBox2.Text}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }

    private void button9_Click(object sender, EventArgs e)
    {
      try
      {
        byte[] buf = new byte[1024];
        log("cli receiving...");
        int readedBytes;
        int totalReadedBytes = 0;
        StringBuilder sb = new StringBuilder();
        do
        {
          readedBytes = cliSocket.Receive(buf);
          totalReadedBytes += readedBytes;
          if (readedBytes > 0)
          {
            string s = Encoding.UTF8.GetString(buf, 0, readedBytes);
            sb.Append(s);
          }
        }
        while (readedBytes == buf.Length);
        log($"cli received: {readedBytes} bytes\r\ntotal: {totalReadedBytes} bytes\r\n****************\r\n{sb.ToString()}\r\n****************\r\n");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button10_Click(object sender, EventArgs e)
    {
      try
      {
        byte[] buf = new byte[1024];
        log("srv receiving...");
        int readedBytes = srvSocket.Receive(buf);
        string s = Encoding.UTF8.GetString(buf, 0, readedBytes);
        log($"srv received: {readedBytes} bytes, {s}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button11_Click(object sender, EventArgs e)
    {
      try
      {
        byte[] buf = Encoding.UTF8.GetBytes(textBox2.Text);
        log("srv sending...");
        srvSocket.Send(buf);
        log($"srv sended: {textBox2.Text}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }



    private void button12_Click(object sender, EventArgs e)
    {
      string Get = $"GET / HTTP/1.1\r\nHost: {comboBox1.Text}\r\nConnection: close\r\n\r\n";
      try
      {
        byte[] buf = Encoding.UTF8.GetBytes(Get);
        log("cli sending...");
        cliSocket.Send(buf);
        log($"cli sended:\r\n{Get}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }

    private void button15_Click(object sender, EventArgs e)
    {

      Thread thr = new Thread(
        () =>
        {
          do
          {
            try
            {
              byte[] buf = new byte[1024];
              log("cliT receiving...");
              int readedBytes;
              int totalReadedBytes = 0;
              StringBuilder sb = new StringBuilder();
              do
              {
                readedBytes = cliSocket.Receive(buf);
                totalReadedBytes += readedBytes;
                if (readedBytes > 0)
                {
                  string s = Encoding.UTF8.GetString(buf, 0, readedBytes);
                  sb.Append(s);
                }
              }
              while (readedBytes == buf.Length);
              log($"cliT received: {readedBytes} bytes\r\ntotal: {totalReadedBytes} bytes\r\n****************\r\n{sb.ToString()}\r\n****************\r\n");
            }
            catch (Exception exc)
            {
              log($"BŁĄD: {exc.Message}");
            }
          }
          while (true);
        }
        );
      thr.Start();

    }

    private void button13_Click(object sender, EventArgs e)
    {
      try
      {
        log("cli: shutdowning");
        cliSocket.Shutdown(SocketShutdown.Both);
        log("cli: shutdowned");
        log("cli: closing...");
        cliSocket.Close();
        log("cli: closed");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }


    private void button14_Click(object sender, EventArgs e)
    {
      try
      {
        log("accepting...");
        SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
        saea.Completed += (os, oe) =>
        {
          srvSocket = oe.AcceptSocket;
          log("accepted");
        };
        bool res = srvListSocket.AcceptAsync(saea);
        log($"res = {res}");
      }
      catch (Exception exc)
      {
        log($"BŁĄD: {exc.Message}");
      }
    }

  }
}