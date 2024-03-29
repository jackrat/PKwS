
namespace _04_A_Sockets_Async
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
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.tbLogCli = new System.Windows.Forms.TextBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.tbLogSrv = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnCliConn2 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.btnCliEnd = new System.Windows.Forms.Button();
      this.btnCliRec = new System.Windows.Forms.Button();
      this.btnCliSend = new System.Windows.Forms.Button();
      this.btnCliConn = new System.Windows.Forms.Button();
      this.tbCliMsg = new System.Windows.Forms.TextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnSrvStart = new System.Windows.Forms.Button();
      this.cbxSrvIP = new System.Windows.Forms.ComboBox();
      this.nudSrvPort = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSrvEnd = new System.Windows.Forms.Button();
      this.btnSrvRec = new System.Windows.Forms.Button();
      this.btnSrvSend = new System.Windows.Forms.Button();
      this.tbSrvMsg = new System.Windows.Forms.TextBox();
      this.bnSrvIni = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrvPort)).BeginInit();
      this.SuspendLayout();
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(196, -21);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
      this.numericUpDown1.TabIndex = 29;
      this.numericUpDown1.Value = new decimal(new int[] {
            3003,
            0,
            0,
            0});
      // 
      // tbLogCli
      // 
      this.tbLogCli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.tbLogCli.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbLogCli.Location = new System.Drawing.Point(4, 174);
      this.tbLogCli.Multiline = true;
      this.tbLogCli.Name = "tbLogCli";
      this.tbLogCli.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLogCli.Size = new System.Drawing.Size(409, 401);
      this.tbLogCli.TabIndex = 27;
      this.tbLogCli.WordWrap = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(356, -25);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(109, 23);
      this.button2.TabIndex = 25;
      this.button2.Text = "Dns.GetHostEntry()";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(260, -25);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(95, 23);
      this.button1.TabIndex = 24;
      this.button1.Text = "Dns.Resolve()";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // tbLogSrv
      // 
      this.tbLogSrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbLogSrv.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbLogSrv.Location = new System.Drawing.Point(421, 174);
      this.tbLogSrv.Multiline = true;
      this.tbLogSrv.Name = "tbLogSrv";
      this.tbLogSrv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLogSrv.Size = new System.Drawing.Size(409, 401);
      this.tbLogSrv.TabIndex = 46;
      this.tbLogSrv.WordWrap = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnCliConn2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.btnCliEnd);
      this.panel1.Controls.Add(this.btnCliRec);
      this.panel1.Controls.Add(this.btnCliSend);
      this.panel1.Controls.Add(this.btnCliConn);
      this.panel1.Controls.Add(this.tbCliMsg);
      this.panel1.Location = new System.Drawing.Point(4, 9);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(411, 159);
      this.panel1.TabIndex = 52;
      // 
      // btnCliConn2
      // 
      this.btnCliConn2.BackColor = System.Drawing.SystemColors.Control;
      this.btnCliConn2.Location = new System.Drawing.Point(150, 35);
      this.btnCliConn2.Name = "btnCliConn2";
      this.btnCliConn2.Size = new System.Drawing.Size(60, 23);
      this.btnCliConn2.TabIndex = 51;
      this.btnCliConn2.Text = "2.Socket.ConnectAsync(...)";
      this.btnCliConn2.UseVisualStyleBackColor = false;
      this.btnCliConn2.Click += new System.EventHandler(this.btnCliConn2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(4, 5);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 25);
      this.label1.TabIndex = 50;
      this.label1.Text = "CLI";
      // 
      // btnCliEnd
      // 
      this.btnCliEnd.BackColor = System.Drawing.SystemColors.Control;
      this.btnCliEnd.Location = new System.Drawing.Point(4, 123);
      this.btnCliEnd.Name = "btnCliEnd";
      this.btnCliEnd.Size = new System.Drawing.Size(206, 23);
      this.btnCliEnd.TabIndex = 49;
      this.btnCliEnd.Text = "Socket.Shutdown() && .Close();";
      this.btnCliEnd.UseVisualStyleBackColor = false;
      this.btnCliEnd.Click += new System.EventHandler(this.btnCliEnd_Click);
      // 
      // btnCliRec
      // 
      this.btnCliRec.BackColor = System.Drawing.SystemColors.Control;
      this.btnCliRec.Location = new System.Drawing.Point(4, 94);
      this.btnCliRec.Name = "btnCliRec";
      this.btnCliRec.Size = new System.Drawing.Size(205, 23);
      this.btnCliRec.TabIndex = 48;
      this.btnCliRec.Text = "Socket.ReceiveAsync(...)";
      this.btnCliRec.UseVisualStyleBackColor = false;
      this.btnCliRec.Click += new System.EventHandler(this.btnCliRec_Click);
      // 
      // btnCliSend
      // 
      this.btnCliSend.BackColor = System.Drawing.SystemColors.Control;
      this.btnCliSend.Location = new System.Drawing.Point(4, 62);
      this.btnCliSend.Name = "btnCliSend";
      this.btnCliSend.Size = new System.Drawing.Size(205, 23);
      this.btnCliSend.TabIndex = 47;
      this.btnCliSend.Text = "Socket.SendAsync(...)";
      this.btnCliSend.UseVisualStyleBackColor = false;
      this.btnCliSend.Click += new System.EventHandler(this.btnCliSend_Click);
      // 
      // btnCliConn
      // 
      this.btnCliConn.BackColor = System.Drawing.SystemColors.Control;
      this.btnCliConn.Location = new System.Drawing.Point(4, 33);
      this.btnCliConn.Name = "btnCliConn";
      this.btnCliConn.Size = new System.Drawing.Size(140, 23);
      this.btnCliConn.TabIndex = 46;
      this.btnCliConn.Text = "Socket.ConnectAsync(...)";
      this.btnCliConn.UseVisualStyleBackColor = false;
      this.btnCliConn.Click += new System.EventHandler(this.btnCliConn_Click);
      // 
      // tbCliMsg
      // 
      this.tbCliMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbCliMsg.BackColor = System.Drawing.SystemColors.Control;
      this.tbCliMsg.Location = new System.Drawing.Point(216, 33);
      this.tbCliMsg.Multiline = true;
      this.tbCliMsg.Name = "tbCliMsg";
      this.tbCliMsg.Size = new System.Drawing.Size(191, 113);
      this.tbCliMsg.TabIndex = 45;
      this.tbCliMsg.Text = "Hello socket!";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnSrvStart);
      this.panel2.Controls.Add(this.cbxSrvIP);
      this.panel2.Controls.Add(this.nudSrvPort);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.btnSrvEnd);
      this.panel2.Controls.Add(this.btnSrvRec);
      this.panel2.Controls.Add(this.btnSrvSend);
      this.panel2.Controls.Add(this.tbSrvMsg);
      this.panel2.Controls.Add(this.bnSrvIni);
      this.panel2.Location = new System.Drawing.Point(421, 9);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(409, 159);
      this.panel2.TabIndex = 53;
      // 
      // btnSrvStart
      // 
      this.btnSrvStart.Location = new System.Drawing.Point(283, 9);
      this.btnSrvStart.Name = "btnSrvStart";
      this.btnSrvStart.Size = new System.Drawing.Size(123, 23);
      this.btnSrvStart.TabIndex = 61;
      this.btnSrvStart.Text = "start";
      this.btnSrvStart.UseVisualStyleBackColor = true;
      this.btnSrvStart.Click += new System.EventHandler(this.btnSrvStart_Click);
      // 
      // cbxSrvIP
      // 
      this.cbxSrvIP.FormattingEnabled = true;
      this.cbxSrvIP.Items.AddRange(new object[] {
            "127.0.0.1",
            "212.87.228.200"});
      this.cbxSrvIP.Location = new System.Drawing.Point(67, 9);
      this.cbxSrvIP.Name = "cbxSrvIP";
      this.cbxSrvIP.Size = new System.Drawing.Size(121, 21);
      this.cbxSrvIP.TabIndex = 60;
      this.cbxSrvIP.Text = "127.0.0.1";
      // 
      // nudSrvPort
      // 
      this.nudSrvPort.Location = new System.Drawing.Point(203, 10);
      this.nudSrvPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
      this.nudSrvPort.Name = "nudSrvPort";
      this.nudSrvPort.Size = new System.Drawing.Size(57, 20);
      this.nudSrvPort.TabIndex = 59;
      this.nudSrvPort.Value = new decimal(new int[] {
            3003,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.Location = new System.Drawing.Point(3, 5);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(58, 25);
      this.label2.TabIndex = 58;
      this.label2.Text = "SRV";
      // 
      // btnSrvEnd
      // 
      this.btnSrvEnd.BackColor = System.Drawing.SystemColors.Control;
      this.btnSrvEnd.Location = new System.Drawing.Point(-1, 123);
      this.btnSrvEnd.Name = "btnSrvEnd";
      this.btnSrvEnd.Size = new System.Drawing.Size(206, 23);
      this.btnSrvEnd.TabIndex = 57;
      this.btnSrvEnd.Text = "Socket.Shutdown() && .Close();";
      this.btnSrvEnd.UseVisualStyleBackColor = false;
      this.btnSrvEnd.Click += new System.EventHandler(this.btnSrvEnd_Click);
      // 
      // btnSrvRec
      // 
      this.btnSrvRec.BackColor = System.Drawing.SystemColors.Control;
      this.btnSrvRec.Location = new System.Drawing.Point(0, 62);
      this.btnSrvRec.Name = "btnSrvRec";
      this.btnSrvRec.Size = new System.Drawing.Size(205, 23);
      this.btnSrvRec.TabIndex = 56;
      this.btnSrvRec.Text = "Socket.ReceiveAsync(...)";
      this.btnSrvRec.UseVisualStyleBackColor = false;
      this.btnSrvRec.Click += new System.EventHandler(this.btnSrvRec_Click);
      // 
      // btnSrvSend
      // 
      this.btnSrvSend.BackColor = System.Drawing.SystemColors.Control;
      this.btnSrvSend.Location = new System.Drawing.Point(0, 94);
      this.btnSrvSend.Name = "btnSrvSend";
      this.btnSrvSend.Size = new System.Drawing.Size(205, 23);
      this.btnSrvSend.TabIndex = 55;
      this.btnSrvSend.Text = "Socket.SendAsync(...)";
      this.btnSrvSend.UseVisualStyleBackColor = false;
      this.btnSrvSend.Click += new System.EventHandler(this.btnSrvSend_Click);
      // 
      // tbSrvMsg
      // 
      this.tbSrvMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSrvMsg.BackColor = System.Drawing.SystemColors.Control;
      this.tbSrvMsg.Location = new System.Drawing.Point(218, 35);
      this.tbSrvMsg.Multiline = true;
      this.tbSrvMsg.Name = "tbSrvMsg";
      this.tbSrvMsg.Size = new System.Drawing.Size(188, 111);
      this.tbSrvMsg.TabIndex = 54;
      this.tbSrvMsg.Text = "Hello socket!";
      // 
      // bnSrvIni
      // 
      this.bnSrvIni.BackColor = System.Drawing.SystemColors.Control;
      this.bnSrvIni.Location = new System.Drawing.Point(0, 33);
      this.bnSrvIni.Name = "bnSrvIni";
      this.bnSrvIni.Size = new System.Drawing.Size(205, 23);
      this.bnSrvIni.TabIndex = 52;
      this.bnSrvIni.Text = "Socket.Bind()|.Listen()|.AcceptAsync()";
      this.bnSrvIni.UseVisualStyleBackColor = false;
      this.bnSrvIni.Click += new System.EventHandler(this.bnSrvIni_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(842, 587);
      this.Controls.Add(this.tbLogSrv);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.tbLogCli);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Resize += new System.EventHandler(this.Form1_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSrvPort)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.TextBox tbLogCli;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox tbLogSrv;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnCliEnd;
    private System.Windows.Forms.Button btnCliRec;
    private System.Windows.Forms.Button btnCliSend;
    private System.Windows.Forms.Button btnCliConn;
    private System.Windows.Forms.TextBox tbCliMsg;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSrvEnd;
    private System.Windows.Forms.Button btnSrvRec;
    private System.Windows.Forms.Button btnSrvSend;
    private System.Windows.Forms.TextBox tbSrvMsg;
    private System.Windows.Forms.Button bnSrvIni;
    private System.Windows.Forms.ComboBox cbxSrvIP;
    private System.Windows.Forms.NumericUpDown nudSrvPort;
    private System.Windows.Forms.Button btnSrvStart;
    private System.Windows.Forms.Button btnCliConn2;
  }
}

