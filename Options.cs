using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySharedClipboard
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            // When using network share we need a path for saving the clipboard and files
            textBox1.Text = (string)Properties.Settings.Default["SaveDownloadFilesLocation"];
            if (textBox1.Text.Equals("null"))
            {
                textBox1.Text = "Select a Network share.";
            }
        }

        // Button Select Local network Folder
        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        // Button SAVE
        private void save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["SaveDownloadFilesLocation"] = textBox1.Text;
            Properties.Settings.Default["EncryptionKey"] = textBox1.Text.ToString();
            Properties.Settings.Default.Save();
        }

        // Button CLOSE
        private void closeOptions_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
