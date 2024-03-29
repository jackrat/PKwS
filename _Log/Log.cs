using System;
using System.Threading;
using System.Windows.Forms;

namespace _Log
{
    public class Log
    {
        TextBox tbLog;

        public Log(TextBox aTbLog)
        {
            tbLog = aTbLog;
        }

        public void l(string s, string from = null)
        {
            string s2 = Thread.CurrentThread.IsBackground ? "background" : "UI thread";
            s = $"{DateTime.Now.ToString("HH:mm:ss")}{" " + from} ({s2}) {s}\r\n";
            if (!tbLog.InvokeRequired)
                tbLog.AppendText(s);
            else
                tbLog.Invoke(new Action(() => { tbLog.AppendText(s); }));
        }

        public void Srv(string s)
        {
            l(s, "SRV");
        }
        public void Cli(string s)
        {
            l(s, "CLI");
        }


        public string Msg
        {
            set
            {
                l(value);
            }

        }




        private static Log cli, srv;
        public Log(TextBox aTbLogSrv, TextBox aTbLogCli)
        {
            srv = new Log(aTbLogSrv);
            cli = new Log(aTbLogCli);
        }


        public static void S(string s)
        {
            srv?.l(s);
        }

        public void Clear()
        {
            tbLog.Clear();
        }

        public static void C(string s)
        {
            cli?.l(s);
        }

        public static readonly string HR = $"\r\n{new string('—', 100)} ";
    }
}
