﻿
namespace httpscrap
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
      this.button1 = new System.Windows.Forms.Button();
      this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.button2 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(24, 23);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(120, 50);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // monthCalendar1
      // 
      this.monthCalendar1.Location = new System.Drawing.Point(774, 285);
      this.monthCalendar1.Name = "monthCalendar1";
      this.monthCalendar1.TabIndex = 1;
      // 
      // webBrowser1
      // 
      this.webBrowser1.Location = new System.Drawing.Point(65, 330);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new System.Drawing.Size(655, 117);
      this.webBrowser1.TabIndex = 2;
      this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(24, 118);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(120, 50);
      this.button2.TabIndex = 3;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(168, 23);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(845, 330);
      this.textBox1.TabIndex = 4;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1144, 450);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.webBrowser1);
      this.Controls.Add(this.monthCalendar1);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.MonthCalendar monthCalendar1;
    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox1;
  }
}

