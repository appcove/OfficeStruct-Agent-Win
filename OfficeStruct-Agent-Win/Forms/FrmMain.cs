using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using OfficeStruct_Agent_Win.Classes;

namespace OfficeStruct_Agent_Win.Forms
{
    public partial class FrmMain : Form
    {
        private string optName;
        private bool checking;

        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            // This window must be hidden (only notification item must be visible)
            Visible = false;

            // Options are loaded/created from default folders
#if DEBUG
            // In debug mode the folder is thee same of the app
            var optDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#else
            // Customers will find options file in %localappdata%\SalonCloudsPlus folder
            var optDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "FileUploader");
            Directory.CreateDirectory(optDir);

#endif
            // Options are loaded/created
            optName = Path.Combine(optDir, "options.xml");
            // After options are updated we must update app behaviour
            actReloadOptions();
            // Ok, let's check webservice immediately
            PerformCheck();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // We have a timer ebaled to perform webservice checks at scheduled times.
            // If timer remains active when the app is closing we could get an error.
            tmr.Enabled = false;
            // Notification icon must be removed from traybar
            nic.Visible = false;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_ONLYONEINSTANCE)
                nic.ShowBalloonTip(200, Text, "Another instance is already running", ToolTipIcon.Warning);
            base.WndProc(ref m);
        }
        private void actEditOptions()
        {
            // Opening settings window
            using (var frm = new FrmSettings())
                // If user used the save button...
                if (frm.ShowDialog() == DialogResult.Yes)
                    // ...then we must update app behaviour
                    actReloadOptions();
        }
        private void actReloadOptions()
        {
            tmr.Enabled = false;
            Shared.Options = Options.Load(optName);
            mnuUpload.Checked = Shared.Options.UploadEnabled;

            nic.Text = Text;
            nic.Icon = Icon;
            nic.Visible = true;

            mnuCheckNow.Enabled = Shared.Options.IsValid;
            tmr.Interval = 1000 * Shared.Options.DelayBetweenChecks;
            tmr.Enabled = true;
        }
        private static string GetFileToUpload(string folder)
        {
            return Directory.GetFiles(folder)
                .FirstOrDefault(fname =>
                {
                    var name = Path.GetFileName(fname);
                    return Shared.Options.Exlusions.TrueForAll(e => !name.IsLike(e));
                });
        }
        private bool UploadFile(string upFile)
        {
            if (!Shared.Options.UploadEnabled) return true;
            try
            {
                var sha = upFile.ToSha256();
                // 1. Call API to get upload URL
                ShowNotification(ToolTipIcon.Info, "Uploading file:\n{0}", upFile);
                // 2. Upload file (if needed)
                // 3. Move file
                var dt = DateTime.Now;
                var folder = Path.Combine(Path.GetDirectoryName(upFile),
                    Shared.Options.ArchiveFolderName,
                    dt.ToString("yyyy-MM"));
                Directory.CreateDirectory(folder);
                File.Move(upFile, Path.Combine(folder,
                    String.Format("{0} {1}", dt.ToString("yyyy-MM-dd-HH-mm-ss"), Path.GetFileName(upFile))));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        private void ShowNotification(ToolTipIcon icon, string msg, params string[] args)
        {
            if (Shared.Options.ShowNotifications)
                nic.ShowBalloonTip(200, Text, String.Format(msg, args), icon);
        }
        private void PerformCheck()
        {
            // If an old check is still in progress we skip this new one
            if (checking) return;
            if (!Shared.Options.UploadEnabled) return;
            // App is notified the check is in progress
            checking = true;
            try
            {
                // notification icon shows the user a check is in progress
                //nic.Icon = Resources.nicUpdate;

                // If webservice settings are not valid the app shows the user an error.
                // If user clicks on the bubble, settings window is shown!
                if (!Shared.Options.IsValid)
                {
                    //nic.Icon = Resources.nicError;
                    ShowNotification(ToolTipIcon.Error, "Invalid settings");
                    tmr.Enabled = false;
                    return;
                }

                // Let's perform the check here
                Shared.Options.FoldersToMonitor.ForEach(folder =>
                {
                    if (!Shared.Options.UploadEnabled) return;
                    var upFile = GetFileToUpload(folder);
                    while (upFile != null)
                    {
                        if (UploadFile(upFile))
                            ShowNotification(ToolTipIcon.Info, "File uploaded successfully:\n{0}", upFile);
                        else
                            ShowNotification(ToolTipIcon.Error, "Cannot upload file:\n{0}", upFile);
                        Thread.Sleep(200);
                        upFile = GetFileToUpload(folder);
                    }
                });

                // Notification icon is changed to valid one 
                //nic.Icon = Resources.nicOk;
            }
            catch (Exception ex)
            {
                // If something goes wrong notification icon is changed into an error one
                //nic.Icon = Resources.nicError;
            }
            finally
            {
                // Whatever happens, we must notify the app that check is finished
                // so we can perform a new one
                checking = false;
            }
        }

        private void mnuOpenOptions_Click(object sender, EventArgs e)
        {
            actEditOptions();
        }
        private void mnuUpload_Click(object sender, EventArgs e)
        {
            Shared.Options.UploadEnabled = mnuUpload.Checked;
            Shared.Options.Save();
        }
        private void mnuCheckNow_Click(object sender, EventArgs e)
        {
            PerformCheck();
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void nic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            PerformCheck();
        }
    }
}
