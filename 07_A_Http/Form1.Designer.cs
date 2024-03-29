
namespace _07_A_Http
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
      this.tbLogCli = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnProgress = new System.Windows.Forms.Button();
      this.btnHttpClientUpload = new System.Windows.Forms.Button();
      this.btnHttpClient2 = new System.Windows.Forms.Button();
      this.btnHttpClient1 = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.button3 = new System.Windows.Forms.Button();
      this.btnWebClient3 = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.btnWebClient2 = new System.Windows.Forms.Button();
      this.btnWebClient = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cbAddresses = new System.Windows.Forms.ComboBox();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbLogCli
      // 
      this.tbLogCli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbLogCli.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbLogCli.Location = new System.Drawing.Point(182, 35);
      this.tbLogCli.Multiline = true;
      this.tbLogCli.Name = "tbLogCli";
      this.tbLogCli.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbLogCli.Size = new System.Drawing.Size(596, 525);
      this.tbLogCli.TabIndex = 59;
      this.tbLogCli.WordWrap = false;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.panel1.Controls.Add(this.btnProgress);
      this.panel1.Controls.Add(this.btnHttpClientUpload);
      this.panel1.Controls.Add(this.btnHttpClient2);
      this.panel1.Controls.Add(this.btnHttpClient1);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.button3);
      this.panel1.Controls.Add(this.btnWebClient3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.btnWebClient2);
      this.panel1.Controls.Add(this.btnWebClient);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(0, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(176, 574);
      this.panel1.TabIndex = 60;
      // 
      // btnProgress
      // 
      this.btnProgress.Location = new System.Drawing.Point(9, 277);
      this.btnProgress.Name = "btnProgress";
      this.btnProgress.Size = new System.Drawing.Size(164, 21);
      this.btnProgress.TabIndex = 62;
      this.btnProgress.Text = "4) .GetAsync";
      this.btnProgress.UseVisualStyleBackColor = true;
      this.btnProgress.Click += new System.EventHandler(this.btnProgress_Click);
      // 
      // btnHttpClientUpload
      // 
      this.btnHttpClientUpload.Location = new System.Drawing.Point(9, 250);
      this.btnHttpClientUpload.Name = "btnHttpClientUpload";
      this.btnHttpClientUpload.Size = new System.Drawing.Size(164, 21);
      this.btnHttpClientUpload.TabIndex = 61;
      this.btnHttpClientUpload.Text = "3) .PostAsync()";
      this.btnHttpClientUpload.UseVisualStyleBackColor = true;
      this.btnHttpClientUpload.Click += new System.EventHandler(this.btnHttpClientUpload_Click);
      // 
      // btnHttpClient2
      // 
      this.btnHttpClient2.Location = new System.Drawing.Point(9, 223);
      this.btnHttpClient2.Name = "btnHttpClient2";
      this.btnHttpClient2.Size = new System.Drawing.Size(164, 21);
      this.btnHttpClient2.TabIndex = 60;
      this.btnHttpClient2.Text = "2) .GetByteArrayAsync()";
      this.btnHttpClient2.UseVisualStyleBackColor = true;
      this.btnHttpClient2.Click += new System.EventHandler(this.btnHttpClient2_Click);
      // 
      // btnHttpClient1
      // 
      this.btnHttpClient1.Location = new System.Drawing.Point(9, 196);
      this.btnHttpClient1.Name = "btnHttpClient1";
      this.btnHttpClient1.Size = new System.Drawing.Size(164, 21);
      this.btnHttpClient1.TabIndex = 59;
      this.btnHttpClient1.Text = "1) .GetStringAsync()";
      this.btnHttpClient1.UseVisualStyleBackColor = true;
      this.btnHttpClient1.Click += new System.EventHandler(this.btnHttpClient1_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 180);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(127, 13);
      this.label3.TabIndex = 58;
      this.label3.Text = "\"HttpClient - recommend\"";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(9, 144);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(164, 23);
      this.button3.TabIndex = 57;
      this.button3.Text = "4. WebClient.UploadFileAsync()\r\n";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // btnWebClient3
      // 
      this.btnWebClient3.Location = new System.Drawing.Point(9, 115);
      this.btnWebClient3.Name = "btnWebClient3";
      this.btnWebClient3.Size = new System.Drawing.Size(164, 23);
      this.btnWebClient3.TabIndex = 55;
      this.btnWebClient3.Text = "3. WebClient.UploadFile()\r\n";
      this.btnWebClient3.UseVisualStyleBackColor = true;
      this.btnWebClient3.Click += new System.EventHandler(this.btnWebClient3_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(148, 13);
      this.label2.TabIndex = 54;
      this.label2.Text = "\"WebClient - not recommend\"";
      // 
      // btnWebClient2
      // 
      this.btnWebClient2.Location = new System.Drawing.Point(9, 86);
      this.btnWebClient2.Name = "btnWebClient2";
      this.btnWebClient2.Size = new System.Drawing.Size(164, 23);
      this.btnWebClient2.TabIndex = 53;
      this.btnWebClient2.Text = "2) .DownloadFileAsync\r\n()\r\n";
      this.btnWebClient2.UseVisualStyleBackColor = true;
      this.btnWebClient2.Click += new System.EventHandler(this.btnWebClient2_Click);
      // 
      // btnWebClient
      // 
      this.btnWebClient.Location = new System.Drawing.Point(9, 59);
      this.btnWebClient.Name = "btnWebClient";
      this.btnWebClient.Size = new System.Drawing.Size(164, 21);
      this.btnWebClient.TabIndex = 51;
      this.btnWebClient.Text = "1) .DownloadFile()";
      this.btnWebClient.UseVisualStyleBackColor = true;
      this.btnWebClient.Click += new System.EventHandler(this.btnWebClient_Click);
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
      // cbAddresses
      // 
      this.cbAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbAddresses.FormattingEnabled = true;
      this.cbAddresses.Items.AddRange(new object[] {
            "http://zuig.el.pcz.czest.pl:3000",
            "https://we.pcz.pl/",
            "http://zuig.el.pcz.czest.pl:3000/jackrat/PKwS_stac/src/master/03_A_Sockets_Sync/F" +
                "orm1.cs",
            "https://github.com/git-for-windows/git/releases/download/v2.34.0.windows.1/Git-2." +
                "34.0-64-bit.exe",
            "https://download.tortoisegit.org/tgit/2.12.0.0/TortoiseGit-2.12.0.0-64bit.msi",
            "http://212.87.228.200/jackrat/upload/index.php"});
      this.cbAddresses.Location = new System.Drawing.Point(182, 8);
      this.cbAddresses.Name = "cbAddresses";
      this.cbAddresses.Size = new System.Drawing.Size(586, 21);
      this.cbAddresses.TabIndex = 61;
      // 
      // progressBar1
      // 
      this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar1.Location = new System.Drawing.Point(182, 566);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(596, 17);
      this.progressBar1.TabIndex = 62;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(780, 589);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.cbAddresses);
      this.Controls.Add(this.tbLogCli);
      this.Controls.Add(this.panel1);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbLogCli;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnWebClient;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnWebClient2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbAddresses;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Button btnWebClient3;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button btnHttpClient1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnHttpClient2;
    private System.Windows.Forms.Button btnHttpClientUpload;
    private System.Windows.Forms.Button btnProgress;
  }
}

