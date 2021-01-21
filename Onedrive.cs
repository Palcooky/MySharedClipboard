using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Graph;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Diagnostics;
using Extensions;
using System.Net.Http;

// Need to adjust to increase download/upload speeds, when using found pretty slow

namespace MySharedClipboard
{
    class Onedrive
    {
        private enum ClientType
        {
            Consumer,
            Business
        }
        private const int UploadDownloadChunkSize = 1 * 640 * 1024;       // 10 MB
        private const int DownloadDownloadChunkSize = 1 * 640 * 1024;       // 10 MB


        private GraphServiceClient graphClient { get; set; }
        private ClientType clientType { get; set; }
        private DriveItem CurrentFolder { get; set; }


        public void DoLogin()
        {
            this.graphClient = AuthenticationHelper.GetAuthenticatedClient();
        }

        public void setgraphClient()
        {
            this.graphClient = null;
        }


        // Gets current Username returns String
        public async Task<String> GetUserName()
        {
            if (null == this.graphClient) return null;
            try
            {
                var user = await graphClient.Me
                .Request()
                .GetAsync();

                return user.DisplayName;
            }

            catch (Exception exception)
            {
                PresentServiceException(exception);
            }
            return "";
        }

        /// <summary>
        /// Notes Test 
        /// </summary>

        // Clipboard text to onedrive file Currently set to root/ClipboardShare/clipboardText.txt MAx Size 4mb
        public async Task TextToOneDrive(String MyText, String Filename)
        {
            if (null == this.graphClient) return;

            using var stream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(MyText));

            try
            {
                await graphClient.Me.Drive.Root
                .ItemWithPath("ClipboardShare/" + Filename)
                .Content
                .Request()
                .PutAsync<DriveItem>(stream);

            }
            catch (Exception ex)
            {
                PresentServiceException(ex);
            }
        }

        // Read text from onedrive file
        public async Task<string> OnedriveFileText(String File)
        {
            if (null == this.graphClient) return "";
            try
            {
                var contentsFile = await graphClient.Me.Drive.Root
                .ItemWithPath("ClipboardShare/" + File)
                .Content
                .Request()
                .GetAsync();


                using var sr = new StreamReader(contentsFile);

                if (sr == null)
                {
                    Console.WriteLine("Error");
                }
                return sr.ReadToEnd();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            return "";
        }


        // Upload File to Onedrive
        public async Task<string> transferDataToOnedrive(String FilePath)
        {

            var fileName = Path.GetFileName(FilePath);
            if (null == this.graphClient) return "";

            Label lb = (Label)System.Windows.Forms.Application.OpenForms["Form1"].Controls.Find("label4", false).FirstOrDefault();

            using (var fileStream = System.IO.File.OpenRead(FilePath))
            {
                // Use properties to specify the conflict behavior
                // in this case, replace
                var uploadProps = new DriveItemUploadableProperties
                {
                    ODataType = null,
                    AdditionalData = new Dictionary<string, object>
                    {
                        { "@microsoft.graph.conflictBehavior", "replace" }
                    }
                };

                // Create the upload session
                // itemPath does not need to be a path to an existing item
                var uploadSession = await graphClient.Me.Drive.Root
                    .ItemWithPath("ClipboardShare/" + fileName)
                    .CreateUploadSession(uploadProps)
                    .Request()
                    .PostAsync();

                // Max slice size must be a multiple of 320 KiB

                int maxSliceSize = UploadDownloadChunkSize; //320 * 1024;
                var fileUploadTask =
                    new LargeFileUploadTask<DriveItem>(uploadSession, fileStream, maxSliceSize);

                // Create a callback that is invoked after each slice is uploaded
                IProgress<long> progress = new Progress<long>(progress =>
                {
                    Console.WriteLine($"Uploaded {progress} bytes of {fileStream.Length} bytes");
                    lb.Text = StaticHelpers.BytesToString(progress) + " " + ($" from { StaticHelpers.BytesToString(fileStream.Length) }");
                });

                try
                {
                    // Upload the file
                    var uploadResult = await fileUploadTask.UploadAsync(progress);

                    if (uploadResult.UploadSucceeded)
                    {
                        // The ItemResponse object in the result represents the
                        // created item.
                        Console.WriteLine($"Upload complete, item ID: {uploadResult.ItemResponse.Id}");
                    }
                    else
                    {
                        Console.WriteLine("Upload failed");
                    }
                }
                catch (ServiceException ex)
                {
                    Console.WriteLine($"Error uploading: {ex.ToString()}");
                }
            }
            lb.Text = "";
            return "";
        }


        // Download File from Onedrive
        // Using this to get items from a specific folder
        public async Task<IList<DriveItem>> GetOnedriveFileList()
        {
            if (null == this.graphClient) return null;

            IList<DriveItem> returnList = new List<DriveItem>();
            String path = "ClipboardShare";

            try
            {
                DriveItem folder;

                var expandValue = this.clientType == ClientType.Consumer
                    ? "thumbnails,children($expand=thumbnails)"
                    : "thumbnails,children";

                folder =
                    await
                        this.graphClient.Me.Drive.Root.ItemWithPath("/" + path)
                            .Request()
                            .Expand(expandValue)
                            .GetAsync();

                this.CurrentFolder = folder;
                return folder.Children.CurrentPage;
            }


            catch (Exception)
            {

            }

            return returnList;
        }

        public async Task getDownload2(String SelectedItem)
        {
            // Based on question by Pavan Tiwari, 11/26/2012, and answer by Simon Mourier
            // https://stackoverflow.com/questions/13566302/download-large-file-in-small-chunks-in-c-sharp
            if (null == this.graphClient) return;

            long ChunkSize = DownloadDownloadChunkSize;
            long offset = 0;         // cursor location for updating the Range header.
            byte[] bytesInStream;


            int BufferSize = 4096;

            byte[] byteBuffer = new byte[4096];
            long Progress = 0;
            Label lb = (Label)System.Windows.Forms.Application.OpenForms["Form1"].Controls.Find("label4", false).FirstOrDefault();


            // Get the collection of drive items. We'll only use one.
            IList<DriveItem> driveItems = await GetOnedriveFileList(); // get a list of items ogjects from onedrive from specific folder

            foreach (DriveItem item in driveItems)
            {
                if (item.Name.Equals(SelectedItem))
                {// Item name to the selected item
                 // Let's download the first file we get in the response.
                    if (item.File != null)
                    {
                        Console.WriteLine(item.Name);
                        // We'll use the file metadata to determine size and the name of the downloaded file
                        // and to get the download URL.
                        var driveItemInfo = await graphClient.Me.Drive.Items[item.Id].Request().GetAsync();

                        // Get the download URL. This URL is preauthenticated and has a short TTL.
                        object downloadUrl;
                        driveItemInfo.AdditionalData.TryGetValue("@microsoft.graph.downloadUrl", out downloadUrl);

                        // Get the number of bytes to download. calculate the number of chunks and determine
                        // the last chunk size.
                        long size = (long)driveItemInfo.Size;
                        int numberOfChunks = Convert.ToInt32(size / ChunkSize);
                        // We are incrementing the offset cursor after writing the response stream to a file after each chunk. 
                        // Subtracting one since the size is 1 based, and the range is 0 base. There should be a better way to do
                        // this but I haven't spent the time on that.
                        int lastDownloadChunkSize = Convert.ToInt32(size % ChunkSize) - numberOfChunks - 1;
                        if (lastDownloadChunkSize > 0) { numberOfChunks++; }

                        Console.WriteLine("File Name = " + item.Name + "| Size = " + item.Size);
                        var FileName = (string)Properties.Settings.Default["SaveDownloadFilesLocation"] + "\\" + driveItemInfo.Name;

                        // Create a file stream to contain the downloaded file.
                        using (FileStream fileStream = System.IO.File.Create((@FileName)))
                        {
                            for (int i = 0; i < numberOfChunks; i++)
                            {
                                // Setup the last chunk to request. This will be called at the end of this loop.
                                if (i == numberOfChunks - 1)
                                {
                                    ChunkSize = lastDownloadChunkSize;
                                }

                                // Create the request message with the download URL and Range header.
                                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, (string)downloadUrl);
                                req.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(offset, ChunkSize + offset);

                                // We can use the the client library to send this although it does add an authentication cost.
                                // HttpResponseMessage response = await graphClient.HttpProvider.SendAsync(req);
                                // Since the download URL is preauthenticated, and we aren't deserializing objects, 
                                // we'd be better to make the request with HttpClient.
                                var client = new HttpClient();
                                HttpResponseMessage response = await client.SendAsync(req);
                                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                                {
                                    //Console.WriteLine("bytesInStream : " + Progress);
                                    bytesInStream = new byte[ChunkSize];
                                    int read;

                                    do
                                    {

                                        read = responseStream.Read(bytesInStream, 0, (int)bytesInStream.Length);
                                        if (read > 0)
                                            fileStream.Write(bytesInStream, 0, read);
                                    }
                                    while (read > 0);
                                    //Console.WriteLine(StaticHelpers.BytesToString(responseStream.Length));
                                    Progress += responseStream.Length;
                                    //Console.WriteLine(StaticHelpers.BytesToString(Progress));
                                    lb.Text = StaticHelpers.BytesToString(Progress) + " " + ($" from { StaticHelpers.BytesToString(size) }");
                                }

                                offset += DownloadDownloadChunkSize + 1; // Move the offset cursor to the next chunk.
                            }
                        }
                        return;
                    }
                }
            }
        }

        // Delete a file onedrive
        public async Task DeleteFile(String SelectedItem)
        {
            IList<DriveItem> driveItems = await GetOnedriveFileList(); // get a list of items ogjects from onedrive from specific folder

            foreach (DriveItem item in driveItems)
            {
                if (item.Name.Equals(SelectedItem)) { 
                 await graphClient.Me.Drive.Items[item.Id]
                .Request()
                .DeleteAsync();
                }
            }

        }




        public async Task<StringCollection> getremoteFilesOnedrive()
        {
            try
            {
                StringCollection filePaths = new StringCollection();

                IList<DriveItem> OneDriveList = await GetOnedriveFileList();
                if (OneDriveList != null)
                {
                    foreach (DriveItem itemx in OneDriveList)
                    {
                        if (itemx.Folder == null)
                        {
                            //Console.WriteLine("Files");
                            //Console.WriteLine("Name: " + itemx.Name);
                            //Console.WriteLine("ID: " + itemx.Id);
                            filePaths.Add(itemx.Name);
                        }
                    }
                }

                return filePaths;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UICoord error: " + ex);
            }
            return null;
        }

        /// OneDrive Error messages:
        private static void PresentServiceException(Exception exception)
        {
            string message = null;
            var oneDriveException = exception as ServiceException;
            if (oneDriveException == null)
            {
                message = exception.Message;
            }
            else
            {
                message = string.Format("{0}{1}", Environment.NewLine, oneDriveException.ToString());
            }

            MessageBox.Show(string.Format("OneDrive reported the following error: {0}", message));
        }

        public void DoLogOut()
        {
            this.graphClient = null;
        }


   















    }
}
