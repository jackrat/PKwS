using _Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_03
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      log = new Log(tbLog);
    }
    Log log;




    private async void button1_Click(object sender, EventArgs e)
    {
      try
      {

        IPHostEntry srvIPHostEntry = Dns.GetHostEntry("ntp.task.gda.pl");
        Socket cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(srvIPHostEntry.AddressList[0], 13);
        log.l($"ConnectAsync: in progress...)");
        await cliSocket.ConnectAsync(ep);
        if (cliSocket.Connected)
        {
          log.l($"Połączony!");

          byte[] buf = new byte[100];
          ArraySegment<byte> abuf = new ArraySegment<byte>(buf);
          int rb = 0;
          do
          {
            log.l($"receving....!");
            rb = await cliSocket.ReceiveAsync(abuf, SocketFlags.None);
            log.l($"received!");
            if (rb > 0)
            {
              string s = Encoding.ASCII.GetString(buf, 0, rb);
              log.l(s);
            }

          } while (rb > 0);


          cliSocket.Shutdown(SocketShutdown.Both);
          cliSocket.Disconnect(false);
        }
        else
        {
          log.l($"BRAK połączenia!");
        }
      }
      catch (Exception exc)
      {
        log.l($"Error\r\n{exc.Message}");
      }

    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {

        IPHostEntry srvIPHostEntry = Dns.GetHostEntry("ntp.task.gda.pl");
        Socket cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ep = new IPEndPoint(srvIPHostEntry.AddressList[0], 13);
        log.l($"Connect sync: in progress...)");
        cliSocket.Connect(ep);
        if (cliSocket.Connected)
        {
          log.l($"Połączony!");
          byte[] sbuf = new byte[1];
          sbuf[0] = 27;//0x1B czyli Esc
          log.l($"sending Esc...!");
          cliSocket.Send(sbuf);
          byte[] buf = new byte[100];
          log.l($"sended and... receving....!");
          int rb = cliSocket.Receive(buf);
          log.l($"received {rb} bytes!");
          if (rb > 0)
          {
            string s = Encoding.ASCII.GetString(buf, 0, rb);
            log.l(s);
          }
          cliSocket.Shutdown(SocketShutdown.Both);
          cliSocket.Close();
        }
        else
        {
          log.l($"BRAK połączenia!");
        }
      }
      catch (Exception exc)
      {
        log.l($"Error\r\n{exc.Message}");
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      {
        try
        {

          IPHostEntry srvIPHostEntry = Dns.GetHostEntry("ntp.task.gda.pl");
          Socket cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
          IPEndPoint ep = new IPEndPoint(srvIPHostEntry.AddressList[0], 123);
          log.l($"Connect sync: in progress...)");
          cliSocket.Connect(ep);
          if (cliSocket.Connected)
          {
            log.l($"Połączony!");
            byte[] sbuf = new byte[48];
            sbuf[0] = 26;//0x1B czyli Esc
            log.l($"sending Esc...!");
            cliSocket.Send(sbuf);
            byte[] buf = new byte[48];
            log.l($"sended and... receving....!");
            int rb = cliSocket.Receive(buf);
            log.l($"received {rb} bytes!");
            if (rb > 0)
            {
              ulong u1 = BitConverter.ToUInt32(buf, 40);
              ulong u2 = BitConverter.ToUInt32(buf, 44);
              //przedostatnie 8 bajtów
              ulong intPart = 0; uint mno = 1;
              for (int i = 43; i >= 40; i--) { intPart += buf[i] * mno; mno *= 256; }
              ulong fractPart = 0; mno = 1;
              for (int i = 47; i >= 44; i--) { fractPart += buf[i] * mno; mno *= 256; }
              //ostatnie 8 bajtów
              ulong milliseconds = intPart * 1000 + (fractPart * 1000) / 0x100000000L;
              var currentTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(milliseconds);
              log.l($"{currentTime.ToLocalTime()}");
            }
            cliSocket.Shutdown(SocketShutdown.Both);
            cliSocket.Close();
          }
          else
          {
            log.l($"BRAK połączenia!");
          }
        }
        catch (Exception exc)
        {
          log.l($"Error\r\n{exc.Message}");
        }
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      string fmt = "yyyyMMddHHmmssffff";
      log.l($"{DateTime.Now.ToString(fmt)}");
    }

    private void button5_Click(object sender, EventArgs e)
    {
      var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
      log.l($"{Timestamp}");
    }
  }
}
