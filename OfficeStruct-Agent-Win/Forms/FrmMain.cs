using System;
using System.IO;
using System.Reflection;
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

#if !DEBUG
            // There's a reload context menu item I used in debug time.
            // If we're not using Debug compilation mode then it's hidden
            mnuReloadOptions.Visible = false;
#endif
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

            nic.Text = Text;
            nic.Visible = true;

            mnuCheckNow.Enabled = Shared.Options.IsValid;
            tmr.Interval = 1000 * Shared.Options.DelayBetweenChecks;
            tmr.Enabled = true;
        }
        private void PerformCheck()
        {
            // If an old check is still in progress we skip this new one
            if (checking) return;
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
                    nic.ShowBalloonTip(500, Text, "Invalid settings", ToolTipIcon.Error);
                    return;
                }

                // Let's perform the check here
                // do something

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
