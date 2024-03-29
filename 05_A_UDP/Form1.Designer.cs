
namespace _05_A_UDP
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
      this.btnUBroSend = new System.Windows.Forms.Button();
      this.btn255 = new System.Windows.Forms.Button();
      this.cbxBroIP = new System.Windows.Forms.ComboBox();
      this.tbLogLst = new System.Windows.Forms.TextBox();
      this.tbLogBro = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.nudPort = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.btnBroSend = new System.Windows.Forms.Button();
      this.tbBroMsg = new System.Windows.Forms.TextBox();
      this.btnULstStartAT = new System.Windows.Forms.Button();
      this.btnULstStartA = new System.Windows.Forms.Button();
      this.btnULstStart = new System.Windows.Forms.Button();
      this.btnLstStartA = new System.Windows.Forms.Button();
      this.cbxLstIP = new System.Windows.Forms.ComboBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnLstRecA = new System.Windows.Forms.Button();
      this.btnLstStart = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.btnLstRec = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnUBroSend
      // 
      this.btnUBroSend.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnUBroSend.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnUBroSend.Location = new System.Drawing.Point(4, 102);
      this.btnUBroSend.Name = "btnUBroSend";
      this.btnUBroSend.Size = new System.Drawing.Size(192, 44);
      this.btnUBroSend.TabIndex = 64;
      this.btnUBroSend.Text = "UdpClient.Send(...)";
      this.btnUBroSend.UseVisualStyleBackColor = false;
      this.btnUBroSend.Click += new System.EventHandler(this.btnUBroSend_Click);
      // 
      // btn255
      // 
      this.btn255.Location = new System.Drawing.Point(374, 6);
      this.btn255.Name = "btn255";
      this.btn255.Size = new System.Drawing.Size(36, 23);
      this.btn255.TabIndex = 63;
      this.btn255.Text = ".255";
      this.btn255.UseVisualStyleBackColor = true;
      this.btn255.Click += new System.EventHandler(this.Btn255_Click);
      // 
      // cbxBroIP
      // 
      this.cbxBroIP.FormattingEnabled = true;
      this.cbxBroIP.Location = new System.Drawing.Point(203, 6);
      this.cbxBroIP.Name = "cbxBroIP";
      this.cbxBroIP.Size = new System.Drawing.Size(165, 21);
      this.cbxBroIP.TabIndex = 61;
      // 
      // tbLogLst
      // 
      this.tbLogLst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbLogLst.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbLogLst.Location = new System.Drawing.Point(425, 192);
      this.tbLogLst.Multiline = true;
      this.tbLogLst.Name = "tbLogLst";
      this.tbLogLst.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLogLst.Size = new System.Drawing.Size(409, 383);
      this.tbLogLst.TabIndex = 62;
      this.tbLogLst.WordWrap = false;
      // 
      // tbLogBro
      // 
      this.tbLogBro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.tbLogBro.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbLogBro.Location = new System.Drawing.Point(8, 192);
      this.tbLogBro.Multiline = true;
      this.tbLogBro.Name = "tbLogBro";
      this.tbLogBro.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLogBro.Size = new System.Drawing.Size(409, 383);
      this.tbLogBro.TabIndex = 61;
      this.tbLogBro.WordWrap = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnUBroSend);
      this.panel1.Controls.Add(this.btn255);
      this.panel1.Controls.Add(this.nudPort);
      this.panel1.Controls.Add(this.cbxBroIP);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.btnBroSend);
      this.panel1.Controls.Add(this.tbBroMsg);
      this.panel1.Location = new System.Drawing.Point(8, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(411, 174);
      this.panel1.TabIndex = 63;
      // 
      // nudPort
      // 
      this.nudPort.Location = new System.Drawing.Point(203, 32);
      this.nudPort.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
      this.nudPort.Name = "nudPort";
      this.nudPort.Size = new System.Drawing.Size(45, 20);
      this.nudPort.TabIndex = 62;
      this.nudPort.Value = new decimal(new int[] {
            3003,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(4, 5);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(193, 25);
      this.label1.TabIndex = 50;
      this.label1.Text = "UDP Broadcaster";
      // 
      // btnBroSend
      // 
      this.btnBroSend.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnBroSend.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnBroSend.Location = new System.Drawing.Point(4, 56);
      this.btnBroSend.Name = "btnBroSend";
      this.btnBroSend.Size = new System.Drawing.Size(192, 40);
      this.btnBroSend.TabIndex = 47;
      this.btnBroSend.Text = "Socket.SendTo(...)";
      this.btnBroSend.UseVisualStyleBackColor = false;
      this.btnBroSend.Click += new System.EventHandler(this.btnBroSend_Click);
      // 
      // tbBroMsg
      // 
      this.tbBroMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbBroMsg.BackColor = System.Drawing.SystemColors.Window;
      this.tbBroMsg.Location = new System.Drawing.Point(203, 58);
      this.tbBroMsg.Multiline = true;
      this.tbBroMsg.Name = "tbBroMsg";
      this.tbBroMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbBroMsg.Size = new System.Drawing.Size(204, 113);
      this.tbBroMsg.TabIndex = 45;
      this.tbBroMsg.Text = "Hello datagram!";
      // 
      // btnULstStartAT
      // 
      this.btnULstStartAT.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnULstStartAT.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnULstStartAT.Location = new System.Drawing.Point(328, 56);
      this.btnULstStartAT.Name = "btnULstStartAT";
      this.btnULstStartAT.Size = new System.Drawing.Size(74, 103);
      this.btnULstStartAT.TabIndex = 68;
      this.btnULstStartAT.Text = "start\r\n\r\n UdpClient \r\n\r\nAsync Task\r\n";
      this.btnULstStartAT.UseVisualStyleBackColor = false;
      this.btnULstStartAT.Click += new System.EventHandler(this.btnULstStartAT_Click);
      // 
      // btnULstStartA
      // 
      this.btnULstStartA.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnULstStartA.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnULstStartA.Location = new System.Drawing.Point(248, 56);
      this.btnULstStartA.Name = "btnULstStartA";
      this.btnULstStartA.Size = new System.Drawing.Size(74, 103);
      this.btnULstStartA.TabIndex = 67;
      this.btnULstStartA.Text = "start \r\n\r\nUdpClient\r\n\r\n Sync in Task\r\n";
      this.btnULstStartA.UseVisualStyleBackColor = false;
      this.btnULstStartA.Click += new System.EventHandler(this.btnULstStartA_Click);
      // 
      // btnULstStart
      // 
      this.btnULstStart.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnULstStart.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnULstStart.Location = new System.Drawing.Point(168, 56);
      this.btnULstStart.Name = "btnULstStart";
      this.btnULstStart.Size = new System.Drawing.Size(74, 103);
      this.btnULstStart.TabIndex = 66;
      this.btnULstStart.Text = "start\r\n\r\nUdpClient\r\n\r\nSync";
      this.btnULstStart.UseVisualStyleBackColor = false;
      this.btnULstStart.Click += new System.EventHandler(this.btnULstStart_Click);
      // 
      // btnLstStartA
      // 
      this.btnLstStartA.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnLstStartA.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnLstStartA.Location = new System.Drawing.Point(88, 62);
      this.btnLstStartA.Name = "btnLstStartA";
      this.btnLstStartA.Size = new System.Drawing.Size(74, 52);
      this.btnLstStartA.TabIndex = 65;
      this.btnLstStartA.Text = "start SockAsync";
      this.btnLstStartA.UseVisualStyleBackColor = false;
      this.btnLstStartA.Click += new System.EventHandler(this.btnLstStartA_Click);
      // 
      // cbxLstIP
      // 
      this.cbxLstIP.FormattingEnabled = true;
      this.cbxLstIP.Location = new System.Drawing.Point(160, 9);
      this.cbxLstIP.Name = "cbxLstIP";
      this.cbxLstIP.Size = new System.Drawing.Size(165, 21);
      this.cbxLstIP.TabIndex = 63;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnULstStartAT);
      this.panel2.Controls.Add(this.btnULstStartA);
      this.panel2.Controls.Add(this.btnULstStart);
      this.panel2.Controls.Add(this.btnLstStartA);
      this.panel2.Controls.Add(this.btnLstRecA);
      this.panel2.Controls.Add(this.cbxLstIP);
      this.panel2.Controls.Add(this.btnLstStart);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.btnLstRec);
      this.panel2.Location = new System.Drawing.Point(425, 12);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(409, 174);
      this.panel2.TabIndex = 64;
      // 
      // btnLstRecA
      // 
      this.btnLstRecA.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnLstRecA.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnLstRecA.Location = new System.Drawing.Point(90, 123);
      this.btnLstRecA.Name = "btnLstRecA";
      this.btnLstRecA.Size = new System.Drawing.Size(72, 36);
      this.btnLstRecA.TabIndex = 64;
      this.btnLstRecA.Text = "Receive()";
      this.btnLstRecA.UseVisualStyleBackColor = false;
      this.btnLstRecA.Click += new System.EventHandler(this.btnLstRecA_Click);
      // 
      // btnLstStart
      // 
      this.btnLstStart.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnLstStart.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnLstStart.Location = new System.Drawing.Point(8, 62);
      this.btnLstStart.Name = "btnLstStart";
      this.btnLstStart.Size = new System.Drawing.Size(74, 52);
      this.btnLstStart.TabIndex = 62;
      this.btnLstStart.Text = "start SockSync";
      this.btnLstStart.UseVisualStyleBackColor = false;
      this.btnLstStart.Click += new System.EventHandler(this.btnLstStart_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.Location = new System.Drawing.Point(3, 5);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(151, 25);
      this.label2.TabIndex = 58;
      this.label2.Text = "UDP Listener";
      // 
      // btnLstRec
      // 
      this.btnLstRec.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnLstRec.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnLstRec.Location = new System.Drawing.Point(8, 120);
      this.btnLstRec.Name = "btnLstRec";
      this.btnLstRec.Size = new System.Drawing.Size(72, 39);
      this.btnLstRec.TabIndex = 52;
      this.btnLstRec.Text = "Receive()";
      this.btnLstRec.UseVisualStyleBackColor = false;
      this.btnLstRec.Click += new System.EventHandler(this.btnLstRec_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(842, 587);
      this.Controls.Add(this.tbLogLst);
      this.Controls.Add(this.tbLogBro);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Location = new System.Drawing.Point(500, 300);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnUBroSend;
    private System.Windows.Forms.Button btn255;
    private System.Windows.Forms.ComboBox cbxBroIP;
    private System.Windows.Forms.TextBox tbLogLst;
    private System.Windows.Forms.TextBox tbLogBro;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.NumericUpDown nudPort;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnBroSend;
    private System.Windows.Forms.TextBox tbBroMsg;
    private System.Windows.Forms.Button btnULstStartAT;
    private System.Windows.Forms.Button btnULstStartA;
    private System.Windows.Forms.Button btnULstStart;
    private System.Windows.Forms.Button btnLstStartA;
    private System.Windows.Forms.ComboBox cbxLstIP;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnLstRecA;
    private System.Windows.Forms.Button btnLstStart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnLstRec;
  }
}

