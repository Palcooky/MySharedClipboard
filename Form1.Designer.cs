namespace MySharedClipboard
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.copyToRemotebutton = new System.Windows.Forms.Button();
            this.openLocalFilestorebutton = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.copyRemoteToLocalbutton = new System.Windows.Forms.Button();
            this.getremotefilesbutton = new System.Windows.Forms.Button();
            this.getclipboardfilesbutton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneDriveLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            this.label4.TextChanged += new System.EventHandler(this.label4_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 76;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(577, 7);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(92, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 75;
            this.progressBar1.Value = 100;
            this.progressBar1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.copyToRemotebutton);
            this.panel1.Controls.Add(this.openLocalFilestorebutton);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.copyRemoteToLocalbutton);
            this.panel1.Controls.Add(this.getremotefilesbutton);
            this.panel1.Controls.Add(this.getclipboardfilesbutton);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 378);
            this.panel1.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "                                 ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 23);
            this.button3.TabIndex = 59;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(92, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 23);
            this.button5.TabIndex = 61;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 23);
            this.button4.TabIndex = 60;
            this.button4.Text = "Get";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "label2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(637, 179);
            this.richTextBox1.TabIndex = 58;
            this.richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(543, 1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 17);
            this.checkBox1.TabIndex = 70;
            this.checkBox1.Text = "Using Onedrive";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(557, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 69;
            this.button1.Text = "Open Remote";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // copyToRemotebutton
            // 
            this.copyToRemotebutton.Location = new System.Drawing.Point(120, 215);
            this.copyToRemotebutton.Name = "copyToRemotebutton";
            this.copyToRemotebutton.Size = new System.Drawing.Size(102, 23);
            this.copyToRemotebutton.TabIndex = 68;
            this.copyToRemotebutton.Text = "Copy To Remote";
            this.copyToRemotebutton.UseVisualStyleBackColor = true;
            this.copyToRemotebutton.Click += new System.EventHandler(this.copyToRemotebutton_Click);
            // 
            // openLocalFilestorebutton
            // 
            this.openLocalFilestorebutton.Location = new System.Drawing.Point(491, 347);
            this.openLocalFilestorebutton.Margin = new System.Windows.Forms.Padding(4);
            this.openLocalFilestorebutton.Name = "openLocalFilestorebutton";
            this.openLocalFilestorebutton.Size = new System.Drawing.Size(151, 28);
            this.openLocalFilestorebutton.TabIndex = 67;
            this.openLocalFilestorebutton.Text = "Open local file store";
            this.openLocalFilestorebutton.UseVisualStyleBackColor = true;
            this.openLocalFilestorebutton.Click += new System.EventHandler(this.openLocalFilestorebutton_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(351, 244);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(291, 95);
            this.listBox2.TabIndex = 66;
            // 
            // copyRemoteToLocalbutton
            // 
            this.copyRemoteToLocalbutton.Location = new System.Drawing.Point(351, 347);
            this.copyRemoteToLocalbutton.Margin = new System.Windows.Forms.Padding(4);
            this.copyRemoteToLocalbutton.Name = "copyRemoteToLocalbutton";
            this.copyRemoteToLocalbutton.Size = new System.Drawing.Size(131, 28);
            this.copyRemoteToLocalbutton.TabIndex = 65;
            this.copyRemoteToLocalbutton.Text = "Copy Remote To Local";
            this.copyRemoteToLocalbutton.UseVisualStyleBackColor = true;
            this.copyRemoteToLocalbutton.Click += new System.EventHandler(this.copyRemoteToLocalbutton_Click);
            // 
            // getremotefilesbutton
            // 
            this.getremotefilesbutton.Location = new System.Drawing.Point(351, 215);
            this.getremotefilesbutton.Name = "getremotefilesbutton";
            this.getremotefilesbutton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.getremotefilesbutton.Size = new System.Drawing.Size(106, 23);
            this.getremotefilesbutton.TabIndex = 63;
            this.getremotefilesbutton.Text = "Get Remote Files";
            this.getremotefilesbutton.UseVisualStyleBackColor = true;
            this.getremotefilesbutton.Click += new System.EventHandler(this.getremotefilesbutton_Click);
            // 
            // getclipboardfilesbutton
            // 
            this.getclipboardfilesbutton.Location = new System.Drawing.Point(3, 215);
            this.getclipboardfilesbutton.Name = "getclipboardfilesbutton";
            this.getclipboardfilesbutton.Size = new System.Drawing.Size(110, 23);
            this.getclipboardfilesbutton.TabIndex = 62;
            this.getclipboardfilesbutton.Text = "Get Clipboard Files";
            this.getclipboardfilesbutton.UseVisualStyleBackColor = true;
            this.getclipboardfilesbutton.Click += new System.EventHandler(this.getclipboardfilesbutton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 244);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(290, 95);
            this.listBox1.TabIndex = 64;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 73;
            this.menuStrip1.Text = "                          ";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneDriveLoginToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.updateToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // oneDriveLoginToolStripMenuItem
            // 
            this.oneDriveLoginToolStripMenuItem.Name = "oneDriveLoginToolStripMenuItem";
            this.oneDriveLoginToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.oneDriveLoginToolStripMenuItem.Text = "Sign In...";
            this.oneDriveLoginToolStripMenuItem.Click += new System.EventHandler(this.oneDriveLoginToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(117, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 74;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 411);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button copyToRemotebutton;
        private System.Windows.Forms.Button openLocalFilestorebutton;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button copyRemoteToLocalbutton;
        private System.Windows.Forms.Button getremotefilesbutton;
        private System.Windows.Forms.Button getclipboardfilesbutton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneDriveLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}

