using Microsoft.Graph;
using System;
using System.Windows.Forms;

namespace MySharedClipboard
{
    public static class StaticHelpers
    {
        // Message box errors for PresentServiceException
        public static void PresentServiceException(Exception exception)
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

        public static void Alert(String TheCaption, String TheMessage)
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            string message = TheMessage;
            string caption = TheCaption;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);


            // MessageBox.Show(string.Format("OneDrive reported the following error: {0}", TheMessage));
        }

        public static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}
