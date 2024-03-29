using _Log;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_Mailing
{
    public partial class Form1 : Form
    {
        class Konto
        {
            public string Name;
            public string Address;

            public string SmtpHost;
            public int SmtpPort;

            public string ImapHost;
            public int ImapPort;

            public string Pop3Host;
            public int Pop3Port;

            public string Login;
            public string Pass;
            public override string ToString() { return Name; }
        }

        Log log;
        Konto[] konta;
        Konto account;
        Konto recipient;
        SecureSocketOptions security;

        public Form1()
        {
            InitializeComponent();
            log = new Log(tbLog);

            konta = new Konto[]
            {
                new Konto()
                {
                  Name = "Student A (gmail)",
                  Address="student.pkws.a@gmail.com",
                  Login="student.pkws.a@gmail.com",
                  Pass="Student1@3$",
                  ImapHost="imap.gmail.com", ImapPort=993,
                  Pop3Host="pop.gmail.com",  Pop3Port=995,
                  SmtpHost="smtp.gmail.com", SmtpPort=465
                },
                new Konto()
                {
                  Name = "Student B (wp)",
                  Address="student.pkws.b@wp.pl",
                  Login="student.pkws.b",
                  Pass="1@3$Student",
                  ImapHost="imap.wp.pl", ImapPort=993,
                  Pop3Host="pop3.wp.pl",  Pop3Port=995,
                  SmtpHost="smtp.wp.pl", SmtpPort=465
                },
                new Konto()
                {
                  Name = "Student B (interia)",
                  Address="student.pkws.b@interia.pl",
                  Login="student.pkws.b",
                  Pass="1@3$Student",
                  ImapHost="poczta.interia.pl", ImapPort=993,
                  Pop3Host="poczta.interia.pl", Pop3Port=995,
                  SmtpHost="poczta.interia.pl", SmtpPort=465
                }
            };

            cbFrom.DataSource = konta;
            cbTo.DataSource = konta.Clone();
            cbSecurity.DataSource = Enum.GetValues(typeof(SecureSocketOptions));
            //new SecureSocketOptions[] { SecureSocketOptions.Auto, SecureSocketOptions.None, SecureSocketOptions.SslOnConnect, SecureSocketOptions.StartTls, SecureSocketOptions.StartTlsWhenAvailable };
            cbSecurity.SelectedIndex = 2;

        }

        private void cbFrom_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            account = cbFrom.SelectedItem as Konto;
        }

        private void cbTo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            recipient = cbTo.SelectedItem as Konto;
        }

        private void cbSecurity_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            security = (SecureSocketOptions)cbSecurity.SelectedItem;
        }


        private async void fileSystemWatcher1_Changed_1(object sender, FileSystemEventArgs e)
        {
            FileStream logFileStream = new FileStream(@".\log.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader logFileReader = new StreamReader(logFileStream);
            tbLogTxt.Text = await logFileReader.ReadToEndAsync();
            logFileReader.Close();
            logFileStream.Close();
            tbLogTxt.SelectionStart = tbLogTxt.Text.Length;
            tbLogTxt.ScrollToCaret();
        }

        void ClearLogs()
        {
            tbLog.Clear();
            File.WriteAllText(@".\log.txt", "");
        }

        void LogMsg(MimeMessage msg)
        {
            log.l($"Subject: {msg.Subject}  From: {msg.From}  MsgID: {msg.MessageId}");
            log.l($"Atts: {msg.Attachments.Count()}{Log.HR}");
            log.l($"Body: {msg.Body}");
            msg.WriteTo($"{msg.MessageId}.eml");
            foreach (MimeEntity at in msg.Attachments)
            {
                if (at is MimePart)
                {
                    MimePart mp = at as MimePart;
                    using (var stream = File.Create(mp.FileName))
                        mp.Content.DecodeTo(stream);
                }
            }
        }

        private async void btnSmtp_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClearLogs();
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(account.Name, account.Address));
                message.To.Add(new MailboxAddress(recipient.Name, recipient.Address));
                message.Subject = tbSubject.Text;
                message.Body = new TextPart("plain") { Text = tbBody.Text };
                LogMsg(message);
                using (SmtpClient SMTP = new SmtpClient(new ProtocolLogger("log.txt")))
                {
                    await SMTP.ConnectAsync(account.SmtpHost, account.SmtpPort, security);
                    await SMTP.AuthenticateAsync(account.Login, account.Pass);
                    string res = await SMTP.SendAsync(message);
                    log.l($"Sended: {res}");
                    await SMTP.DisconnectAsync(true);
                }
            }
            catch (Exception exc)
            {
                log.l($"ERROR: {exc.Message}");
            }
        }

        private async void btnPop_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClearLogs();
                using (Pop3Client POP = new Pop3Client(new ProtocolLogger("log.txt")))
                {
                    await POP.ConnectAsync(account.Pop3Host, account.Pop3Port, security);
                    await POP.AuthenticateAsync(account.Login, account.Pass);
                    log.l($"Messages count: {POP.Count}");
                    for (int i = 0; i < POP.Count; i++)
                    {
                        MimeMessage msg = await POP.GetMessageAsync(i);
                        LogMsg(msg);
                        //POP.DeleteMessage(i);
                    }
                    await POP.DisconnectAsync(true);
                }
            }
            catch (Exception exc)
            {
                log.l($"ERROR: {exc.Message}");
            }
        }

        private async void btnImap_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClearLogs();
                using (ImapClient IMAP = new ImapClient(new ProtocolLogger("log.txt")))
                {
                    await IMAP.ConnectAsync(account.ImapHost, account.ImapPort, security);
                    await IMAP.AuthenticateAsync(account.Login, account.Pass);
                    await IMAP.Inbox.OpenAsync(FolderAccess.ReadOnly);
                    log.l($"Messages count: {IMAP.Inbox.Count}");

                    //for (int i = 0; i < IMAP.Inbox.Count; i++)
                    //{
                    //    MimeMessage msg = await IMAP.Inbox.GetMessageAsync(i);
                    //    LogMsg(msg);
                    //    //IMAP.Inbox.AddFlags(i,MessageFlags.Deleted,true);
                    //}

                    IList<UniqueId> uids = await IMAP.Inbox.SearchAsync(SearchQuery.All);
                    foreach (UniqueId id in uids)
                    {
                        MimeMessage message = await IMAP.Inbox.GetMessageAsync(id);
                        LogMsg(message);
                    }
                    await IMAP.DisconnectAsync(true);
                }
            }
            catch (Exception exc)
            {
                log.l($"ERROR: {exc.Message}");
            }
        }

        private async void btnSmtpMult_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClearLogs();
                BodyBuilder body = new BodyBuilder();

                body.TextBody = tbBody.Text;
                body.HtmlBody = tbBody2.Text;

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "jpg|*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fn = Path.GetFullPath(ofd.FileName);
                    var att = new MimePart("image", "jpg")
                    {
                        Content = new MimeContent(File.OpenRead(fn), ContentEncoding.Default),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = Path.GetFileName(fn)
                    };
                    body.Attachments.Add(att);
                }

                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(account.Name, account.Address));
                foreach (Konto k in konta)
                    message.To.Add(new MailboxAddress(k.Name, k.Address));
                message.Subject = tbSubject.Text;
                message.Body = body.ToMessageBody();
                LogMsg(message);
                using (SmtpClient SMTP = new SmtpClient(new ProtocolLogger("log.txt")))
                {
                    await SMTP.ConnectAsync(account.SmtpHost, account.SmtpPort, security);
                    await SMTP.AuthenticateAsync(account.Login, account.Pass);
                    string res = await SMTP.SendAsync(message);
                    log.l($"Sended: {res}");
                    await SMTP.DisconnectAsync(true);
                }
            }
            catch (Exception exc)
            {
                log.l($"ERROR: {exc.Message}");
            }

        }
    }
}
