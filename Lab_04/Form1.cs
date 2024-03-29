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

namespace WindowsFormsApp5
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    void log(string s)
    {
      string s2 = "background thread: " + Thread.CurrentThread.IsBackground.ToString();
      if (Thread.CurrentThread.IsBackground)
        tbLog.Invoke(new Action(() =>
        {
          tbLog.AppendText($"{DateTime.Now:HH:mm:ss} - {s}  {s2}\r\n");
        }));
      else
        tbLog.AppendText($"{DateTime.Now:HH:mm:ss} - {s}  {s2}\r\n");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      Task t1 = client.ConnectAsync(comboBox1.Text, 13);
      t1.ContinueWith(new Action<Task>(
        (t2) =>
        {

          byte[] buf = new byte[1024];
          int rb = client.Receive(buf);
          string s = Encoding.ASCII.GetString(buf, 0, rb);
          log(s);
          client.Shutdown(SocketShutdown.Both);
          client.Close();
        }
        ), TaskContinuationOptions.OnlyOnRanToCompletion);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      Task t1 = client.ConnectAsync(comboBox1.Text, 13);
      t1.ContinueWith(new Action<Task>(
        (t2) =>
        {
          byte[] buf = new byte[1024];
          Task<int> t3 = client.ReceiveAsync(new ArraySegment<byte>(buf), SocketFlags.None);
          t3.ContinueWith(new Action<Task>(
          (t4) =>
          {
            string s = Encoding.ASCII.GetString(buf, 0, t3.Result);
            log(s);
            client.Shutdown(SocketShutdown.Both);
            client.Close();
          }), TaskContinuationOptions.OnlyOnRanToCompletion);
        }
        ), TaskContinuationOptions.OnlyOnRanToCompletion);
    }



    async Task<string> ConnectAndReceiveAsync(string strIP, int port)
    {
      string res = null;
      try
      {
        log("client instanciating ...");
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        log("client instanciated");
        log("client connecting...");
        await client.ConnectAsync(strIP, port);
        log("client connected");
        byte[] buf = new byte[1024];
        log("client receiving...");
        int rb = await client.ReceiveAsync(new ArraySegment<byte>(buf), SocketFlags.None);
        res = Encoding.ASCII.GetString(buf, 0, rb);
        log($"client received: {res}");
        client.Shutdown(SocketShutdown.Both);
        client.Close();
      }
      catch (Exception exc)
      {
        log(exc.Message);
      }
      return res;
    }

    async private void button3_Click(object sender, EventArgs e)
    {
      string s = await ConnectAndReceiveAsync(comboBox1.Text, 13);
      log($"Result: {s}");
    }


    Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    async private void button4_Click(object sender, EventArgs e)
    {
      server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3003));
      log("listen...");
      server.Listen(10);
      while (true)
      {
        log("accepting...");
        Socket cli = await server.AcceptAsync();
        log("accepted...");
        byte[] buf = Encoding.ASCII.GetBytes($"Jest: {DateTime.Now:dddd,yyyy MMMM dd HH:mm:ss.fff}");
        log("sending...");
        await cli.SendAsync(new ArraySegment<byte>(buf), SocketFlags.None);
        log("sended...");
      }
    }

    async private void button5_Click(object sender, EventArgs e)
    {
      string s = await ConnectAndReceiveAsync("127.0.0.1", 3003);
      log($"Przyjęto: {s}");
    }
  }
}
