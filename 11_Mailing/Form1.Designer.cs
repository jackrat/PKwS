
using System;
using System.IO;

namespace _11_Mailing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label6 = new System.Windows.Forms.Label();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.btnSmtp = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnPop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbLogTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImap = new System.Windows.Forms.Button();
            this.cbSecurity = new System.Windows.Forms.ComboBox();
            this.btnSmtpMult = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBody2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(29, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "body";
            // 
            // tbBody
            // 
            this.tbBody.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBody.Location = new System.Drawing.Point(80, 132);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbBody.Size = new System.Drawing.Size(394, 131);
            this.tbBody.TabIndex = 14;
            this.tbBody.Text = "Szanowni Państwo,\r\nOto treść wiadomości testowej.\r\nLorem ipsum dolor sit amet, co" +
    "nsectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore " +
    "magna aliqua.\r\nPozdrowienia\r\nJŁ";
            this.tbBody.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(2, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "subject";
            // 
            // tbSubject
            // 
            this.tbSubject.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSubject.Location = new System.Drawing.Point(80, 96);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(394, 26);
            this.tbSubject.TabIndex = 12;
            this.tbSubject.Text = "Temat wiadomości testowej";
            // 
            // cbFrom
            // 
            this.cbFrom.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(80, 16);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(394, 27);
            this.cbFrom.TabIndex = 17;
            this.cbFrom.SelectedIndexChanged += new System.EventHandler(this.cbFrom_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(2, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "account";
            // 
            // cbTo
            // 
            this.cbTo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(80, 54);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(394, 27);
            this.cbTo.TabIndex = 19;
            this.cbTo.SelectedIndexChanged += new System.EventHandler(this.cbTo_SelectedIndexChanged_1);
            // 
            // btnSmtp
            // 
            this.btnSmtp.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSmtp.Location = new System.Drawing.Point(515, 12);
            this.btnSmtp.Name = "btnSmtp";
            this.btnSmtp.Size = new System.Drawing.Size(106, 61);
            this.btnSmtp.TabIndex = 21;
            this.btnSmtp.Text = "SMTP";
            this.btnSmtp.UseVisualStyleBackColor = true;
            this.btnSmtp.Click += new System.EventHandler(this.btnSmtp_Click_1);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "log.txt";
            this.fileSystemWatcher1.Path = ".\\";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed_1);
            // 
            // btnPop
            // 
            this.btnPop.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPop.Location = new System.Drawing.Point(782, 12);
            this.btnPop.Name = "btnPop";
            this.btnPop.Size = new System.Drawing.Size(106, 61);
            this.btnPop.TabIndex = 23;
            this.btnPop.Text = "POP";
            this.btnPop.UseVisualStyleBackColor = true;
            this.btnPop.Click += new System.EventHandler(this.btnPop_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "recip";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 291);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbLog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbLogTxt);
            this.splitContainer1.Size = new System.Drawing.Size(1047, 391);
            this.splitContainer1.SplitterDistance = 522;
            this.splitContainer1.TabIndex = 26;
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(522, 391);
            this.tbLog.TabIndex = 16;
            this.tbLog.WordWrap = false;
            // 
            // tbLogTxt
            // 
            this.tbLogTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogTxt.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLogTxt.Location = new System.Drawing.Point(0, 0);
            this.tbLogTxt.Multiline = true;
            this.tbLogTxt.Name = "tbLogTxt";
            this.tbLogTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLogTxt.Size = new System.Drawing.Size(521, 391);
            this.tbLogTxt.TabIndex = 15;
            this.tbLogTxt.WordWrap = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(982, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "log.txt";
            // 
            // btnImap
            // 
            this.btnImap.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnImap.Location = new System.Drawing.Point(903, 12);
            this.btnImap.Name = "btnImap";
            this.btnImap.Size = new System.Drawing.Size(106, 61);
            this.btnImap.TabIndex = 28;
            this.btnImap.Text = "IMAP";
            this.btnImap.UseVisualStyleBackColor = true;
            this.btnImap.Click += new System.EventHandler(this.btnImap_Click_1);
            // 
            // cbSecurity
            // 
            this.cbSecurity.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSecurity.FormattingEnabled = true;
            this.cbSecurity.Location = new System.Drawing.Point(570, 95);
            this.cbSecurity.Name = "cbSecurity";
            this.cbSecurity.Size = new System.Drawing.Size(241, 27);
            this.cbSecurity.TabIndex = 30;
            this.cbSecurity.SelectedIndexChanged += new System.EventHandler(this.cbSecurity_SelectedIndexChanged_1);
            // 
            // btnSmtpMult
            // 
            this.btnSmtpMult.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSmtpMult.Location = new System.Drawing.Point(637, 12);
            this.btnSmtpMult.Name = "btnSmtpMult";
            this.btnSmtpMult.Size = new System.Drawing.Size(123, 61);
            this.btnSmtpMult.TabIndex = 31;
            this.btnSmtpMult.Text = "SMTP mult";
            this.btnSmtpMult.UseVisualStyleBackColor = true;
            this.btnSmtpMult.Click += new System.EventHandler(this.btnSmtpMult_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(483, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "security";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(501, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 34;
            this.label7.Text = "body 2";
            // 
            // tbBody2
            // 
            this.tbBody2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBody2.Location = new System.Drawing.Point(570, 132);
            this.tbBody2.Multiline = true;
            this.tbBody2.Name = "tbBody2";
            this.tbBody2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbBody2.Size = new System.Drawing.Size(484, 134);
            this.tbBody2.TabIndex = 35;
            this.tbBody2.Text = resources.GetString("tbBody2.Text");
            this.tbBody2.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 694);
            this.Controls.Add(this.tbBody2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSmtpMult);
            this.Controls.Add(this.cbSecurity);
            this.Controls.Add(this.btnImap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPop);
            this.Controls.Add(this.btnSmtp);
            this.Controls.Add(this.cbTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSubject);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSmtpMult_Click(object sender, EventArgs e)
        {

        }

        private void cbSecurity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnImap_Click(object sender, EventArgs e)
        {

        }

        private void cbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPop_Click(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void btnSmtp_Click(object sender, EventArgs e)
        {

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbBody;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label konto;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Button btnSmtp;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnPop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbLogTxt;
        private System.Windows.Forms.Button btnImap;
        private System.Windows.Forms.ComboBox cbSecurity;
        private System.Windows.Forms.Button btnSmtpMult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbBody2;
    }
}

