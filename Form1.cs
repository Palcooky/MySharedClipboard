using Microsoft.Graph;
using System;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySharedClipboard
{
    public partial class Form1 : Form
    {
        Onedrive onedrive = new Onedrive();
        Version myVersion;

        public Form1()
        {
            InitializeComponent();
            UpdateConnectedStateUx(false);
            if (ApplicationDeployment.IsNetworkDeployed)
                myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            label2.Text = string.Concat("v", myVersion);
        }


        // DO work progress bar
        private void ShowWork(bool working)
        {
            this.progressBar1.Visible = working;
        }
        // Changes UI to hide sign in and sign out based on status
        private void UpdateConnectedStateUx(bool connected)
        {
            oneDriveLoginToolStripMenuItem.Visible = !connected;
            signOutToolStripMenuItem.Visible = connected;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options_Form = new Options();
            options_Form.Show();
        }


        // OneDrive Login Setup


        // Sign into onedrive and get username
        private async void oneDriveLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await this.SignIn();
            getremotefilesbutton.PerformClick();
        }

        // Task for login into onedrive and get username
        private async Task SignIn()
        {
            try { onedrive.DoLogin(); }
            catch (ServiceException exception)
            {
                StaticHelpers.PresentServiceException(exception);
                checkBox1.Checked = false;
            }
            try
            {
                ShowWork(true);
                label1.Text = await onedrive.GetUserName();
                if (label1.Text != "")
                {
                    UpdateConnectedStateUx(true);
                }
                checkBox1.Checked = true;
                ShowWork(false);
            }
            catch (ServiceException exception)
            {
                StaticHelpers.PresentServiceException(exception);
                onedrive.setgraphClient();
            }
        }

        // Get Note
        private async void button4_Click(object sender, EventArgs e)
        {
            ShowWork(true);
            richTextBox1.Text = await onedrive.OnedriveFileText("Notes.txt");
            if (label1.Text.Equals(""))
            {
                StaticHelpers.Alert("Error Detected", "Not logged In");
            }
            ShowWork(false);
        }
        // Clear text box
        private void button5_Click(object sender, EventArgs e)
        {
            ShowWork(true);
            richTextBox1.Text = "";
            ShowWork(false);
        }
        // Save Notes
        private async void button3_Click(object sender, EventArgs e)
        {
            ShowWork(true);
            await onedrive.TextToOneDrive(richTextBox1.Text, "Notes.txt");
            if (label1.Text.Equals(""))
            {
                StaticHelpers.Alert("Error Detected", "Not logged In");
            }
            ShowWork(false);
        }

        // File Options bottom half of the form

        // Clipboard file paths
        private void getclipboardfilesbutton_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            var x = Clipboard.GetFileDropList();
            foreach (var items in x)
            {
                listBox1.Items.Add(items);
            }
        }

        private async void copyToRemotebutton_Click(object sender, EventArgs e)
        {
            ShowWork(true);
            if (listBox1.SelectedItem != null)
            {
                String FilePath = listBox1.SelectedItem.ToString(); // gets current FILE path as a string
                if (System.IO.File.Exists(FilePath)) // Make sure its a FILE
                {
                    long length = new System.IO.FileInfo(FilePath).Length;
                    if (length > 0) // Make sure it is not an empty FILE
                    {
                        await onedrive.transferDataToOnedrive(listBox1.SelectedItem.ToString()); // Do the upload
                    }
                    else
                    {
                        StaticHelpers.Alert("Error Detected", "No need to upload empty files");
                    }
                }
                else
                {
                    StaticHelpers.Alert("Error Detected", "Unable to upload files at this time");
                }
            }
            else
            {
                StaticHelpers.Alert("Error Detected", "No files copied to your clipboard");
            }


            ShowWork(false);
            getremotefilesbutton.PerformClick();
        }

        private async void getremotefilesbutton_Click(object sender, EventArgs e)
        {
            ShowWork(true);
            listBox2.Items.Clear();
            StringCollection filePaths = await onedrive.getremoteFilesOnedrive();
            foreach (string filePath in filePaths)
            {
                if (!filePath.Contains("Notes.txt"))
                {
                    listBox2.Items.Add(filePath);
                }

            }
            ShowWork(false);
        }

        // Open remote files only Netowrk drives
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void copyRemoteToLocalbutton_Click(object sender, EventArgs e)
        {
            ShowWork(true);

            String SelectedItem = listBox2?.SelectedItem?.ToString();
            if (SelectedItem != null)
            {
                if (System.IO.Directory.Exists((string)Properties.Settings.Default["SaveDownloadFilesLocation"]))
                {
                    Console.WriteLine("Tried4");
                    //await onedrive.fileCopyFromOnedrive(SelectedItem);
                    await onedrive.getDownload2(SelectedItem);

                }
            }
            ShowWork(false);
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {
            label3.Text = label4.Text;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onedrive.DoLogOut();
            UpdateConnectedStateUx(false); // Update UI Menu
            label1.Text = ""; // Update UI Name
            checkBox1.Checked = false; // Update UI TextBox
            StaticHelpers.Alert("OneDrive Status Changed", "You have now signed out.");

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallUpdateSyncWithInfo();
        }

        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }


                if (!info.UpdateAvailable)
                {
                    string message = "No update is availble at the moment.";
                    string caption = "Information";
                    var result = MessageBox.Show(message, caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            System.Windows.Forms.Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string messag = "THIS APP IS IN ALPHA !!!!!!!!!!!!!!!!!!!!!!!!";
            string message = "\r\n \r\nMySharedClipboard was created for shareing a clipboard and transfering files between 2 or more networked windows 10 devices.";
            string message1 = "\r\n \r\nUpdated Features listed below:";
            string message2 = "\r\n \r\nApp will check for updates on lanunch.";
            string message3 = "\r\n - Added download and upload progress.";
            string message4 = "\r\n - Added button to delete files saved on onedrive.";
            string caption = "About";
            var result = MessageBox.Show(messag + message + message2 + message3 + message4, caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Button Open Local File Save
        private void openLocalFilestorebutton_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists((string)Properties.Settings.Default["SaveDownloadFilesLocation"]))
            {
                System.Diagnostics.Process.Start((string)Properties.Settings.Default["SaveDownloadFilesLocation"]);
            }
            else
            {
                string message = "Folder does not exist check File > Options select a folder for SaveDownloadFilesLocation";
                string caption = "Information";
                var result = MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ShowWork(true);
            String SelectedItem = listBox2?.SelectedItem?.ToString();
            if (SelectedItem != null)
            {
                await onedrive.DeleteFile(SelectedItem);
            }
            ShowWork(false);
            getremotefilesbutton.PerformClick();
        }

        // Allow some right click options in text area

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }
        
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Text
                    += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }


    }
}
