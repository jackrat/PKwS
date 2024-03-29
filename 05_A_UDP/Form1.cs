using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_A_UDP
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }



    private void Form1_Load(object sender, EventArgs e)
    {
      IPHostEntry he = Dns.GetHostEntry("");
      cbxBroIP.Items.AddRange(he.AddressList);
      cbxBroIP.Items.Add(IPAddress.Broadcast);
      cbxBroIP.Items.Add(IPAddress.Loopback);
      cbxBroIP.SelectedIndex = 1;

      cbxLstIP.Items.AddRange(he.AddressList);
      cbxLstIP.Items.Add(IPAddress.Broadcast);
      cbxLstIP.Items.Add(IPAddress.Loopback);
      cbxLstIP.SelectedIndex = 1;
    }

    //Skalowanie formularza
    private void Form1_Resize(object sender, EventArgs e)
    {
      tbLogBro.Width = (Width / 2) - 15;
      tbLogLst.Width = tbLogBro.Width;
      tbLogLst.Left = tbLogBro.Bounds.Right + 5;

      panel1.Width = tbLogBro.Width;
      panel2.Width = panel1.Width;
      panel2.Left = panel1.Bounds.Right + 5;
    }


    //narzędzia logowania
    delegate void del(TextBox tb, string s);
    static void L(TextBox tb, string s)
    {
      tb.AppendText("\r\n");
      tb.AppendText($"{DateTime.Now:HH:mm:ss} - {s}");
    }
    static readonly del d = new del(L);

    void Log(TextBox tb, string s)
    {
      if (this.InvokeRequired)
        this.Invoke(d, tb, s);
      else
        L(tb, s);
    }
    void LogB(string s)
    {
      Log(tbLogBro, s);
    }
    void LogL(string s)
    {
      Log(tbLogLst, s);
    }



    private void Btn255_Click(object sender, EventArgs e)
    {
      int k = cbxBroIP.Text.LastIndexOf('.');
      cbxBroIP.Text = cbxBroIP.Text.Substring(0, k + 1) + "255";
    }


    Socket broSocket;
    Socket lstSocket;
    UdpClient udpBroClient;
    byte[] buf = new byte[1024];

    private void btnBroSend_Click(object sender, EventArgs e)
    {
      try
      {
        broSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(cbxBroIP.Text), (int)nudPort.Value);
        byte[] b = Encoding.ASCII.GetBytes(tbBroMsg.Text);
        LogB("sending...");
        broSocket.SendTo(b, ep);
        LogB($"sended: {tbBroMsg.Text}");
      }
      catch (Exception exc)
      {
        LogB(exc.Message);
      }
    }

    private void btnLstStart_Click(object sender, EventArgs e)
    {
      try
      {
        lstSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(cbxLstIP.Text), (int)nudPort.Value);
        lstSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
        lstSocket.Bind(ep);
        Receive();
      }
      catch (Exception exc)
      {
        LogL(exc.Message);
      }
    }


    void Receive()
    {
      try
      {
        string rec;
        do
        {
          LogL("receiving...");
          int rb = lstSocket.Receive(buf);
          LogL($"received {rb} bytes.!");
          rec = Encoding.ASCII.GetString(buf, 0, rb);
          LogL($"\r\n**********\r\n{rec}\r\n**********");
        } while (rec != "<EOF>");
        LogL("<EOF>");
      }
      catch (Exception exc)
      {
        LogL(exc.Message);
      }
    }


    private void btnLstRec_Click(object sender, EventArgs e)
    {
      Receive();
    }

    private void btnLstStartA_Click(object sender, EventArgs e)
    {
      try
      {
        lstSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, (int)nudPort.Value);
        lstSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
        lstSocket.Bind(ep);
        ReceiveAsync();
      }
      catch (Exception exc)
      {
        LogL(exc.Message);
      }
    }


    void ReceiveAsync()
    {
      try
      {
        LogL("receiving...");
        SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
        saea.SetBuffer(buf, 0, buf.Length);
        saea.Completed += SAEA_Completed;
        lstSocket.ReceiveAsync(saea);
      }
      catch (Exception exc)
      {
        LogL(exc.Message);
      }
    }

    private void SAEA_Completed(object sender, SocketAsyncEventArgs e)
    {
      LogL($"received {e.BytesTransferred} bytes.!");
      string rec = Encoding.ASCII.GetString(e.Buffer, 0, e.BytesTransferred);
      LogL($"\r\n**********\r\n{rec}\r\n**********");
      if (rec != "<EOF>")
        ReceiveAsync();
    }

    private void btnLstRecA_Click(object sender, EventArgs e)
    {
      ReceiveAsync();
    }

    private void btnUBroSend_Click(object sender, EventArgs e)
    {
      try
      {
        udpBroClient = new UdpClient();
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(cbxBroIP.Text), (int)nudPort.Value);
        byte[] b = Encoding.ASCII.GetBytes(tbBroMsg.Text);
        LogB("sending...");
        udpBroClient.Send(b, b.Length, ep);
        LogB($"sended: {tbBroMsg.Text}");
        udpBroClient.Close();
      }
      catch (Exception exc)
      {
        LogB(exc.Message);
      }
    }

    private void btnULstStart_Click(object sender, EventArgs e)
    {
      try
      {
        UdpClient udpLstClient = new UdpClient((int)nudPort.Value);
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, (int)nudPort.Value);
        LogL("receiving...");
        string rec;
        do
        {
          byte[] b = udpLstClient.Receive(ref ep);
          LogL($"received {b.Length} bytes");
          rec = Encoding.ASCII.GetString(b, 0, b.Length);
          LogL($"\r\n**********\r\n{rec}\r\n**********");
        } while (rec != "<EOF>");
        udpLstClient.Close();
        udpLstClient.Dispose();
        udpLstClient = null;
      }
      catch (Exception exc)
      {
        LogL(exc.Message);
      }
    }



    private void btnULstStartA_Click(object sender, EventArgs e)
    {

      Task.Run(() =>
      {
        try
        {
          IPEndPoint ep = new IPEndPoint(IPAddress.Any, (int)nudPort.Value);
          UdpClient udpLstClient = new UdpClient(ep);
          LogL("receiving...");
          string rec;
          do
          {
            //Task<UdpReceiveResult> t = udpLstClient.ReceiveAsync();
            //t.Wait();
            //albo
            byte[] b = udpLstClient.Receive(ref ep);

            LogL($"received {b.Length} bytes");
            rec = Encoding.ASCII.GetString(b, 0, b.Length);
            LogL($"\r\n**********\r\n{rec}\r\n**********");
          } while (rec != "<EOF>");
          udpLstClient.Close();
          udpLstClient.Dispose();
        }
        catch (Exception exc)
        {
          LogL(exc.Message);
        }
      });
    }

    private void btnULstStartAT_Click(object sender, EventArgs e)
    {
      try
      {
        ReceiveAsyncProc(new UdpClient(new IPEndPoint(IPAddress.Any, (int)nudPort.Value)));
      }
      catch (Exception exc)
      {
        LogL(exc.Message);
      }
    }


    void ReceiveAsyncProc(UdpClient udpLstClient)
    {
      LogL("receiving...");

      Task<UdpReceiveResult> t = udpLstClient.ReceiveAsync();
      t.ContinueWith(
        (a) =>
        {
          if (t.Status == TaskStatus.Faulted)
            LogL($"ERROR: {t.Exception.Message}");
          else
          {
            LogL($"received {t.Result.Buffer.Length} bytes");
            string rec = Encoding.ASCII.GetString(t.Result.Buffer, 0, t.Result.Buffer.Length);
            LogL($"\r\n**********\r\n{rec}\r\n**********");
            if (rec == "<EOF>")
            {
              LogL("<EOF>");
              udpLstClient.Close();
              udpLstClient.Dispose();
            }
            else
              ReceiveAsyncProc(udpLstClient);
          }
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
    }


  }
}
