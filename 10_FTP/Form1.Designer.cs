
namespace _10_Ftp
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
      this.tbLog = new System.Windows.Forms.TextBox();
      this.btnRETR = new System.Windows.Forms.Button();
      this.btnSTOR = new System.Windows.Forms.Button();
      this.btnListDirectory = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tbLogin = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbPass = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.rbAnonymous = new System.Windows.Forms.RadioButton();
      this.rbLoginPass = new System.Windows.Forms.RadioButton();
      this.label4 = new System.Windows.Forms.Label();
      this.cbHost = new System.Windows.Forms.ComboBox();
      this.lbFiles = new System.Windows.Forms.ListBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnDELE = new System.Windows.Forms.Button();
      this.cbDetailedList = new System.Windows.Forms.CheckBox();
      this.btnRETR2 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tbLog
      // 
      this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbLog.Location = new System.Drawing.Point(458, 12);
      this.tbLog.Multiline = true;
      this.tbLog.Name = "tbLog";
      this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLog.Size = new System.Drawing.Size(758, 330);
      this.tbLog.TabIndex = 54;
      this.tbLog.WordWrap = false;
      // 
      // btnRETR
      // 
      this.btnRETR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnRETR.Location = new System.Drawing.Point(12, 201);
      this.btnRETR.Name = "btnRETR";
      this.btnRETR.Size = new System.Drawing.Size(99, 52);
      this.btnRETR.TabIndex = 55;
      this.btnRETR.Text = "RETR - download txt";
      this.btnRETR.UseVisualStyleBackColor = true;
      this.btnRETR.Click += new System.EventHandler(this.btnRETR_Click);
      // 
      // btnSTOR
      // 
      this.btnSTOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnSTOR.Location = new System.Drawing.Point(12, 259);
      this.btnSTOR.Name = "btnSTOR";
      this.btnSTOR.Size = new System.Drawing.Size(209, 33);
      this.btnSTOR.TabIndex = 56;
      this.btnSTOR.Text = "STOR - upload";
      this.btnSTOR.UseVisualStyleBackColor = true;
      this.btnSTOR.Click += new System.EventHandler(this.btnSTOR_Click);
      // 
      // btnListDirectory
      // 
      this.btnListDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnListDirectory.Location = new System.Drawing.Point(12, 162);
      this.btnListDirectory.Name = "btnListDirectory";
      this.btnListDirectory.Size = new System.Drawing.Size(140, 33);
      this.btnListDirectory.TabIndex = 57;
      this.btnListDirectory.Text = "ListDirectory - dir";
      this.btnListDirectory.UseVisualStyleBackColor = true;
      this.btnListDirectory.Click += new System.EventHandler(this.btnListDirectory_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(14, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 58;
      this.label1.Text = "Host FTP";
      // 
      // tbLogin
      // 
      this.tbLogin.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbLogin.Location = new System.Drawing.Point(49, 95);
      this.tbLogin.Name = "tbLogin";
      this.tbLogin.Size = new System.Drawing.Size(172, 23);
      this.tbLogin.TabIndex = 61;
      this.tbLogin.Text = "ftp_user";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(14, 99);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 60;
      this.label2.Text = "login";
      // 
      // tbPass
      // 
      this.tbPass.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbPass.Location = new System.Drawing.Point(49, 122);
      this.tbPass.Name = "tbPass";
      this.tbPass.Size = new System.Drawing.Size(172, 23);
      this.tbPass.TabIndex = 63;
      this.tbPass.Text = "FU123$%^";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(14, 125);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(29, 13);
      this.label3.TabIndex = 62;
      this.label3.Text = "pass";
      // 
      // rbAnonymous
      // 
      this.rbAnonymous.AutoSize = true;
      this.rbAnonymous.Location = new System.Drawing.Point(17, 69);
      this.rbAnonymous.Name = "rbAnonymous";
      this.rbAnonymous.Size = new System.Drawing.Size(80, 17);
      this.rbAnonymous.TabIndex = 64;
      this.rbAnonymous.Text = "Anonymous";
      this.rbAnonymous.UseVisualStyleBackColor = true;
      this.rbAnonymous.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
      // 
      // rbLoginPass
      // 
      this.rbLoginPass.AutoSize = true;
      this.rbLoginPass.Checked = true;
      this.rbLoginPass.Location = new System.Drawing.Point(103, 69);
      this.rbLoginPass.Name = "rbLoginPass";
      this.rbLoginPass.Size = new System.Drawing.Size(100, 17);
      this.rbLoginPass.TabIndex = 65;
      this.rbLoginPass.TabStop = true;
      this.rbLoginPass.Text = "Login-Password";
      this.rbLoginPass.UseVisualStyleBackColor = true;
      this.rbLoginPass.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label4.Location = new System.Drawing.Point(12, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(80, 13);
      this.label4.TabIndex = 66;
      this.label4.Text = "Logowanie...";
      // 
      // cbHost
      // 
      this.cbHost.FormattingEnabled = true;
      this.cbHost.Items.AddRange(new object[] {
            "212.87.228.200",
            "10.111.114.252",
            "ftp.icm.edu.pl",
            "ftp.icm.edu.pl/pub/Linux/distributions/almalinux"});
      this.cbHost.Location = new System.Drawing.Point(72, 10);
      this.cbHost.Name = "cbHost";
      this.cbHost.Size = new System.Drawing.Size(370, 21);
      this.cbHost.TabIndex = 67;
      // 
      // lbFiles
      // 
      this.lbFiles.FormattingEnabled = true;
      this.lbFiles.Location = new System.Drawing.Point(256, 59);
      this.lbFiles.Name = "lbFiles";
      this.lbFiles.Size = new System.Drawing.Size(196, 277);
      this.lbFiles.TabIndex = 68;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(253, 43);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(93, 13);
      this.label5.TabIndex = 69;
      this.label5.Text = "ListDirectory result";
      // 
      // btnDELE
      // 
      this.btnDELE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnDELE.Location = new System.Drawing.Point(12, 303);
      this.btnDELE.Name = "btnDELE";
      this.btnDELE.Size = new System.Drawing.Size(209, 33);
      this.btnDELE.TabIndex = 70;
      this.btnDELE.Text = "DELE- delete";
      this.btnDELE.UseVisualStyleBackColor = true;
      this.btnDELE.Click += new System.EventHandler(this.btnDELE_Click);
      // 
      // cbDetailedList
      // 
      this.cbDetailedList.AutoSize = true;
      this.cbDetailedList.Location = new System.Drawing.Point(158, 171);
      this.cbDetailedList.Name = "cbDetailedList";
      this.cbDetailedList.Size = new System.Drawing.Size(63, 17);
      this.cbDetailedList.TabIndex = 71;
      this.cbDetailedList.Text = "detailed";
      this.cbDetailedList.UseVisualStyleBackColor = true;
      // 
      // btnRETR2
      // 
      this.btnRETR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnRETR2.Location = new System.Drawing.Point(117, 201);
      this.btnRETR2.Name = "btnRETR2";
      this.btnRETR2.Size = new System.Drawing.Size(104, 52);
      this.btnRETR2.TabIndex = 72;
      this.btnRETR2.Text = "RETR - download file";
      this.btnRETR2.UseVisualStyleBackColor = true;
      this.btnRETR2.Click += new System.EventHandler(this.btnRETR2_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1228, 354);
      this.Controls.Add(this.btnRETR2);
      this.Controls.Add(this.cbDetailedList);
      this.Controls.Add(this.btnDELE);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.lbFiles);
      this.Controls.Add(this.cbHost);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.rbLoginPass);
      this.Controls.Add(this.rbAnonymous);
      this.Controls.Add(this.tbPass);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.tbLogin);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnListDirectory);
      this.Controls.Add(this.btnSTOR);
      this.Controls.Add(this.btnRETR);
      this.Controls.Add(this.tbLog);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbLog;
    private System.Windows.Forms.Button btnRETR;
    private System.Windows.Forms.Button btnSTOR;
    private System.Windows.Forms.Button btnListDirectory;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbLogin;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbPass;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.RadioButton rbAnonymous;
    private System.Windows.Forms.RadioButton rbLoginPass;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbHost;
    private System.Windows.Forms.ListBox lbFiles;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnDELE;
    private System.Windows.Forms.CheckBox cbDetailedList;
    private System.Windows.Forms.Button btnRETR2;
  }
}

