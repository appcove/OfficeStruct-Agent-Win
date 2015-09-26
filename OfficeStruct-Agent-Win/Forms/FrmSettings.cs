using System;
using System.Linq;
using System.Windows.Forms;
using OfficeStruct_Agent_Win.Classes;

namespace OfficeStruct_Agent_Win.Forms
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

            var opt = Shared.Options;
            udDelay.Value = Math.Min(Math.Max(udDelay.Minimum, opt.DelayBetweenChecks), udDelay.Maximum);
            txtApiEndpoint.Text = opt.ApiEndpoint;
            txtAuthorizationKey.Text = opt.AuthorizationKey;
            txtArchiveFolder.Text = opt.ArchiveFolderName;
            chkNotifications.Checked = opt.ShowNotifications;
            txtFolders.Text = String.Join(Environment.NewLine, opt.FoldersToMonitor);
            txtExclusions.Text = String.Join(Environment.NewLine, opt.Exlusions);
        }

        private void DataChanged(object sender, EventArgs e)
        {
            btnSave.Enabled =
                !String.IsNullOrEmpty(txtApiEndpoint.Text)
                && !String.IsNullOrEmpty(txtAuthorizationKey.Text)
                && !String.IsNullOrEmpty(txtArchiveFolder.Text)
                && !String.IsNullOrEmpty(txtFolders.Text);
        }
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog
            {
                Description = @"Select folder to include",
                ShowNewFolderButton = true,
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;
                if (txtFolders.Text.Length > 0)
                    txtFolders.Text += Environment.NewLine;
                txtFolders.Text += dlg.SelectedPath;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var opt = Shared.Options;
            opt.ApiEndpoint = txtApiEndpoint.Text;
            opt.AuthorizationKey = txtAuthorizationKey.Text;
            opt.ArchiveFolderName = txtArchiveFolder.Text;
            opt.ShowNotifications = chkNotifications.Checked;
            opt.FoldersToMonitor = txtFolders.Lines.ToList();
            opt.Exlusions = txtExclusions.Lines.ToList();
            Shared.Options.Save();
        }
    }
}
