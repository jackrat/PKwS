using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStreamingServerApp
{
  public class NetworkIOServer
  {



    public void RunToSend()
    {
      IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      TcpListener tcpListener = new TcpListener(localAddr, 65000);
      tcpListener.Start();
      while (true)
      {
        Socket socketForClient = tcpListener.AcceptSocket();
        log.WriteLine("Client connected: " + socketForClient.RemoteEndPoint);
        SendFileToClient(socketForClient);
        log.WriteLine("Disconnecting from client...");
        socketForClient.Close();
        log.WriteLine("Exiting...");
      }

    }






    private void SendFileToClient(Socket socketForClient)
    {
      NetworkStream networkStream = new NetworkStream(socketForClient);
      StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);

      // create a stream reader for the file
      System.IO.StreamReader streamReader = new System.IO.StreamReader(@"myTest.txt");
      string theString;
      do
      {
        theString = streamReader.ReadLine();
        if (theString != null)
        {
          log.WriteLine("Sending {0}", theString);
          streamWriter.WriteLine(theString);
          streamWriter.Flush();
        }
      }
      while (theString != null);
      streamReader.Close();
      networkStream.Close();
      streamWriter.Close();
    }


    public void Run_ReceiveFromSocket()
    {
      IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      TcpListener tcpListener = new TcpListener(localAddr, 65001);
      tcpListener.Start();
      while (true)
      {
        Socket socketForClient = tcpListener.AcceptSocket();
        try
        {
          byte[] buf = new byte[1024];
          int ib = -1;
          do
          {
            ib = socketForClient.Receive(buf, SocketFlags.None);
            string s = Encoding.UTF8.GetString(buf, 0, ib);
            log.WriteLine(s);
          } while (ib > 0);
        }
        catch
        {
          log.WriteLine("Exception reading from Server");
        }
        socketForClient.Close();

      }

    }



    internal void Run_ReceiveFromClient()
    {
      IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      TcpListener tcpListener = new TcpListener(localAddr, 65001);
      tcpListener.Start();
      while (true)
      {
        TcpClient client = tcpListener.AcceptTcpClient();
        try
        {
          NetworkStream inputStream = client.GetStream();
          StreamReader streamReader = new StreamReader(inputStream);
          string inputString;
          do
          {
            inputString = streamReader.ReadLine();
            if (inputString != null)
            {
              log.WriteLine(inputString);
            }
          }
          while (inputString != null);
          streamReader.Close();
          client.Close();
        }
        catch
        {
          log.WriteLine("Exception reading from Server");
        }
      }
    }



    TcpListener tcpListener;
    internal void StartAsync()
    {
      IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      tcpListener = new TcpListener(localAddr, 65001);
      tcpListener.Start();
      tcpListener.AcceptTcpClientAsync()
        .ContinueWith(AcceptComplet,
        TaskContinuationOptions.OnlyOnRanToCompletion
        );
    }


    void AcceptComplet(Task<TcpClient> t)
    {
      try
      {
        tcpListener.AcceptTcpClientAsync()
        .ContinueWith(AcceptComplet,
        TaskContinuationOptions.OnlyOnRanToCompletion
        );
        NetworkStream inputStream = t.Result.GetStream();
        StreamReader streamReader = new StreamReader(inputStream);
        string inputString;
        do
        {
          inputString = streamReader.ReadLine();
          if (inputString != null)
            log.WriteLine(inputString);
        }
        while (inputString != null);
        streamReader.Close();
        t.Result.Close();
      }
      catch (Exception exc)
      {
        log.WriteLine($"Błąd serwera: {exc.Message}");
      }
    }


  }
}
