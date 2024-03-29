using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_A_Sockets_Async
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      tbLogCli.Width = (Width / 2) - 15;
      tbLogSrv.Width = tbLogCli.Width;
      tbLogSrv.Left = tbLogCli.Bounds.Right + 5;

      panel1.Width = tbLogCli.Width;
      panel2.Width = panel1.Width;
      panel2.Left = panel1.Bounds.Right + 5;
    }

    delegate void del(TextBox tb, string s);
    static void l(TextBox tb, string s)
    {
      tb.AppendText("\r\n");
      tb.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} - {s}");
    }
    static del d = new del(l);

    void log(TextBox tb, string s)
    {
      if (this.InvokeRequired)
        this.Invoke(d, tb, s);
      else
        l(tb, s);
    }

    void logC(string s)
    {
      log(tbLogCli, s);
    }
    void logS(string s)
    {
      log(tbLogSrv, s);
    }

    delegate void logd(string s);

    private void Send(string msg, logd log, Socket socket)
    {
      try
      {
        SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
        byte[] b = Encoding.ASCII.GetBytes(msg);
        saea.SetBuffer(b, 0, b.Length);
        saea.Completed += (os, oe) =>
        {
          if (oe.SocketError == SocketError.Success)
          {
            if (log != null) log($"SendAsync: {oe.SocketError}!");
            if (log != null) log($"SendAsync: sended - '{msg}'");
          }
          else
            if (log != null) log($"SendAsync: SocketError - {oe.SocketError}!");
        };
        socket.SendAsync(saea);
        if (log != null) log($"SendAsync: in progress...)");
      }
      catch (Exception exc)
      {
        if (log != null) log(exc.Message);
      }
    }



    private void SendT(string msg, logd log, Socket socket)
    {
      try
      {
        SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
        byte[] b = Encoding.ASCII.GetBytes(msg);
        //saea.SetBuffer(b, 0, b.Length);
        //saea.Completed += (os, oe) =>
        //{
        //  if (oe.SocketError == SocketError.Success)
        //  {      
        //    if (log != null) log($"SendAsync: sended - '{msg}'");
        //  }
        //  else
        //    if (log != null) log($"SendAsync: SocketError - {oe.SocketError}!");
        //};
        Task<int> t1 = socket.SendToAsync(new ArraySegment<byte>(b), SocketFlags.None,socket.RemoteEndPoint);
        if (log != null) log($"SendAsync: in progress...)");
        t1.ContinueWith(new Action<Task<int>>(
          (t2) => 
          {
            if (t2.Exception == null)
            {              
              if (log != null) log($"SendAsync: sended - '{msg}'");
            }
            else
              if (log != null) log($"SendAsync: SocketError - {t2.Exception.Message}!");
          }
          ),TaskContinuationOptions.OnlyOnRanToCompletion);
      }
      catch (Exception exc)
      {
        if (log != null) log(exc.Message);
      }
    }



    private void button3_Click(object sender, EventArgs e)
    {


    }

    private void Receive(logd log, Socket socket)
    {
      StringBuilder sb = new StringBuilder();
      try
      {
        SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
        saea.SetBuffer(new byte[16], 0, 16);
        saea.Completed += (os, oe) =>
        {
          if (sb.Length > 1000 && log != null)
          {
            log($"ReceiveAsync: BIG DATA!!!!");
            log = null;
          }

          if (oe.SocketError == SocketError.Success)
          {
            if (log != null) log($"ReceiveAsync: {oe.SocketError}!");
            if (log != null) log($"ReceiveAsync: {oe.BytesTransferred} bytes transferred!");
            sb.Append(Encoding.ASCII.GetString(oe.Buffer, 0, oe.BytesTransferred));

            //"<EOF>" - koniec transferu
            if (EndsWithEOF(sb))
            {
              if (log != null) log($"ReceiveAsync: EOF");
              if (log != null) log($"\r\n*************\r\n{sb.ToString()}\r\n***********");
              //SERVER
              if (socket == srvSocket)
              {
                string sreq = sb.ToString();
                sreq = sreq.Substring(0, sreq.Length - 5);
                if (sreq == "FILES")
                {
                  string[] files = Directory.GetFiles(@"e:\pict");
                  string s = string.Join("\r\n", files) + "<EOF>";
                  Send(s, null, srvSocket);
                  Receive(log, socket);
                }
                else
                {
                  byte[] pic = File.ReadAllBytes(sreq);
                  string spic = Convert.ToBase64String(pic) + "<EOF>";
                  Send(spic, null, srvSocket);
                  Receive(log, socket);
                }
              }
              //CLIENT
              if (socket == cliSocket && sb.Length > 1000)
              {
                sb.Remove(sb.Length - 5, 5);
                string sbs = sb.ToString();
                byte[] bsb = Convert.FromBase64String(sbs);
                string fn = $@"e:\pict\{Path.GetFileName(Path.GetTempFileName())}.jpg";
                File.WriteAllBytes(fn, bsb);
                Process.Start(fn);
              }

            }
            else
            {
              saea.SetBuffer(0, 16);
              socket.ReceiveAsync(saea);
              if (log != null) log($"ReceiveAsync: in progress...)");
            }
          }
          else
           if (log != null) log($"ReceiveAsync: SocketError - {oe.SocketError}!");
        };
        socket.ReceiveAsync(saea);
        if (log != null) log($"ReceiveAsync: in progress...)");
      }
      catch (Exception exc)
      {
        if (log != null) log(exc.Message);
      }
    }

    /**********************************************************************
     *                              Client                                *
     **********************************************************************/

    Socket cliSocket;


    private void btnCliConn_Click(object sender, EventArgs e)
    {
      cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      IPEndPoint ep = new IPEndPoint(IPAddress.Parse(cbxSrvIP.Text), (int)nudSrvPort.Value);
      SocketAsyncEventArgs saev = new SocketAsyncEventArgs();
      saev.RemoteEndPoint = ep;
      saev.Completed += (os, oe) =>
      {
        if (oe.SocketError == SocketError.Success)
        {
          logC($"ConnectAsync: Success :)");
          if (cliSocket.Connected)
          {
            logC($"ConnectAsync: connected :)");
            //...
          }
          else
            logC($"ConnectAsync: not connected ! :(");
        }
        else
          logC($"ConnectAsync: SocketError - {oe.SocketError}!");
      };
      cliSocket.ConnectAsync(saev);
      logC($"ConnectAsync: in progress...)");
    }


    private void btnCliConn2_Click(object sender, EventArgs e)
    {
      try
      {
        cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        logC($"ConnectAsync: in progress...)");
        Task t1 = cliSocket.ConnectAsync(cbxSrvIP.Text, (int)nudSrvPort.Value);
        t1.ContinueWith(new Action<Task>((t2) =>
        {
          if (t2.Exception == null)
          {
            logC($"ConnectAsync: Success :)");
            if (cliSocket.Connected)
            {
              logC($"ConnectAsync: connected :)");
              //...
            }
            else
              logC($"ConnectAsync: not connected ! :(");
          }
          else
            logC($"ConnectAsync: SocketError - {t2.Exception.Message}!");
        }), TaskContinuationOptions.OnlyOnRanToCompletion);
      }
      catch (Exception exc) { logC(exc.Message); }
    }


    private void btnCliSend_Click(object sender, EventArgs e)
    {
      //Send(tbCliMsg.Text, logC, cliSocket);
      SendT(tbCliMsg.Text, logC, cliSocket);
    }


    private void btnCliRec_Click(object sender, EventArgs e)
    {
      Receive(logC, cliSocket);
    }


    private void btnCliEnd_Click(object sender, EventArgs e)
    {
      cliSocket.Shutdown(SocketShutdown.Both);
      cliSocket.Close();
    }


    /**********************************************************************
     *                              Server                                *
     **********************************************************************/

    Socket lstSocket, srvSocket;

    private void bnSrvIni_Click(object sender, EventArgs e)
    {
      try
      {
        lstSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(cbxSrvIP.Text), (int)nudSrvPort.Value);
        lstSocket.Bind(ep);
        logS($"Socket Bind to {ep}");
        lstSocket.Listen(10);
        SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
        saea.Completed += (os, oe) =>
        {
          if (oe.SocketError == SocketError.Success)
          {
            logS($"AcceptAsync: Success :)!");
            srvSocket = oe.AcceptSocket;
            if (srvSocket != null && srvSocket.Connected)
            {
              logS($"Socket connected :)");
              //...
            }
            else
              logS($"Socket not connected :(");
          }
          else
            logS($"AcceptAsync: SocketError - {oe.SocketError}!");
        };
        lstSocket.AcceptAsync(saea);
        logS($"AcceptAsync: in progress...)");
      }
      catch (Exception exc)
      {
        logS(exc.Message);
      }
    }



    bool EndsWithEOF(StringBuilder sb)
    {
      if (sb.Length < 5)
        return false;
      else
      {
        int n = sb.Length;
        return
           sb[n - 5] == '<' &&
           sb[n - 4] == 'E' &&
           sb[n - 3] == 'O' &&
           sb[n - 2] == 'F' &&
           sb[n - 1] == '>';
      }
    }



    private void btnSrvRec_Click(object sender, EventArgs e)
    {
      Receive(logS, srvSocket);
    }


    private void btnSrvSend_Click(object sender, EventArgs e)
    {
      Send(tbSrvMsg.Text, logS, srvSocket);
    }

    private void btnSrvStart_Click(object sender, EventArgs e)
    {
      try
      {
        lstSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(cbxSrvIP.Text), (int)nudSrvPort.Value);
        lstSocket.Bind(ep);
        logS($"Socket Bind to {ep}");
        lstSocket.Listen(10);
        SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
        saea.Completed += (os, oe) =>
        {
          if (oe.SocketError == SocketError.Success)
          {
            logS($"AcceptAsync: Success :)!");
            srvSocket = oe.AcceptSocket;
            if (srvSocket != null && srvSocket.Connected)
            {
              logS($"Socket connected :)");
              Receive(logS, srvSocket);
            }
            else
              logS($"Socket not connected :(");
          }
          else
            logS($"AcceptAsync: SocketError - {oe.SocketError}!");
        };
        lstSocket.AcceptAsync(saea);
        logS($"AcceptAsync: in progress...)");
      }
      catch (Exception exc)
      {
        logS(exc.Message);
      }
    }



    private void btnSrvEnd_Click(object sender, EventArgs e)
    {
      srvSocket.Shutdown(SocketShutdown.Both);
      srvSocket.Close();
    }
  }
}
