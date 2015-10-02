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
            Shared.Options.Folders.ForEach(f => f.Stop());
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
            if (Shared.Options != null)
                Shared.Options.Folders.ForEach(f => f.Stop());
            Shared.Options = Options.Load(optName);

            nic.Text = Text;
            nic.Icon = Icon;
            nic.Visible = true;

            mnuCheckNow.Enabled = Shared.Options.Folders.Any(f => f.IsValid);
            Shared.Options.Folders.ForEach(f => f.Start());
        }
        private void ShowNotification(ToolTipIcon icon, string msg, params string[] args)
        {
            if (Shared.Options.ShowNotifications)
                nic.ShowBalloonTip(200, Text, String.Format(msg, args), icon);
        }
        private void PerformCheck()
        {
            var fs = Shared.Options.Folders;
            if (!fs.Any(f => f.IsValid))
            {
                ShowNotification(ToolTipIcon.Error, "There's no folder with valid settings!");
                return;
            }
            if (!fs.Any(f => f.UploadEnabled))
            {
                ShowNotification(ToolTipIcon.Error, "All folders have upload disabled!");
                return;
            }
            fs.ForEach(f => f.PerformCheck());
        }

        private void mnuOpenOptions_Click(object sender, EventArgs e)
        {
            actEditOptions();
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
            PerformCheck();
        }
    }
}
