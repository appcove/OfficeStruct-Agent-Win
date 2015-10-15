using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeStruct_Agent_Win.Classes;

namespace OfficeStruct_Agent_Win.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly List<MonitoredFolder> items = new List<MonitoredFolder>();

        public FrmSettings()
        {
            InitializeComponent();

            var opt = Shared.Options;
            items = Xml.Deserialize<List<MonitoredFolder>>(Xml.Serialize(opt.Folders));
            UpdateList();
            cboLevel.DataSource = Enum.GetValues(typeof (LogLevel));
        }

        private void UpdateButtons()
        {
            var item = lv.SelectedObject as MonitoredFolder;
            btnAdd.Enabled = true;
            btnRemove.Enabled = item != null;
            btnClear.Enabled = items.Any();
            btnSave.Enabled = items.Any();
        }
        private void UpdateList(MonitoredFolder item = null)
        {
            lv.SetObjects(items);
            pnl.Enabled = item != null;
            if (item != null) lv.EnsureModelVisible(item);
        }
        private void ClearItemData()
        {
            txtFolder.Text = "";
            udDelay.Value = 5;
            chkUploadToWebservice.Enabled = true;
            txtApiEndpoint.Text = "";
            txtAuthorizationKey.Text = "";
            txtArchiveFolder.Text = @"ARCHIVE";
            txtExclusions.Text = String.Join(Environment.NewLine,
                "Thumbs.db",
                "desktop.ini",
                "*.tmp");
            txtLogFolder.Text = @"LOG";
            cboLevel.SelectedValue = LogLevel.Off;
        }
        private void NewItem()
        {
            lv.SelectedObject = null;
            pnl.Enabled = true;
            ClearItemData();

            txtFolder.Focus();
        }

        private void lv_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
            ClearItemData();
            var item = lv.SelectedObject as MonitoredFolder;
            pnl.Enabled = item != null;
            if (item == null) return;

            txtFolder.Text = item.Folder;
            udDelay.Value = Math.Min(Math.Max(udDelay.Minimum, item.DelayBetweenChecks), udDelay.Maximum);
            chkUploadToWebservice.Checked = item.UploadToWebservice;
            txtApiEndpoint.Text = item.ApiEndpoint;
            txtAuthorizationKey.Text = item.AuthorizationKey;
            txtArchiveFolder.Text = item.ArchiveFolderName;
            txtExclusions.Text = String.Join(Environment.NewLine, item.Exclusions);
            txtLogFolder.Text = item.LogFolderName;
            cboLevel.SelectedValue = item.LogLevel;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewItem();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            var item = lv.SelectedObject as MonitoredFolder;
            if (item == null) return;
            items.Remove(item);
            UpdateList();
            lv.SelectedObject = items.FirstOrDefault();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                @"Are you sure you want to clear all items?", Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            items.Clear();
            UpdateList();
        }

        private void DataChanged(object sender, EventArgs e)
        {
            btnSave.Enabled =
                !String.IsNullOrEmpty(txtFolder.Text)
                && Directory.Exists(txtFolder.Text)
                && (!chkUploadToWebservice.Checked ||
                    (!String.IsNullOrEmpty(txtApiEndpoint.Text)
                     && (txtApiEndpoint.Text.StartsWith("http://") || txtApiEndpoint.Text.StartsWith("https://"))
                && !String.IsNullOrEmpty(txtAuthorizationKey.Text)))
                && txtArchiveFolder.Text.IsValidFilename()
                && ((LogLevel)cboLevel.SelectedItem == LogLevel.Off || txtLogFolder.Text.IsValidFilename());
        }
        private void chkUploadToWebservice_CheckedChanged(object sender, EventArgs e)
        {
            txtApiEndpoint.Enabled = chkUploadToWebservice.Checked;
            txtAuthorizationKey.Enabled = chkUploadToWebservice.Checked;
            DataChanged(sender, e);
        }
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog
            {
                Description = @"Select folder to monitor",
                ShowNewFolderButton = true,
                SelectedPath = txtFolder.Text,
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;
                txtFolder.Text = dlg.SelectedPath;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = lv.SelectedObject as MonitoredFolder;
            if (item == null)
            {
                item = new MonitoredFolder();
                items.Add(item);
                UpdateList(item);
                UpdateButtons();
            }

            item.Folder = txtFolder.Text;
            item.DelayBetweenChecks = (int)udDelay.Value;
            item.ApiEndpoint = txtApiEndpoint.Text;
            item.AuthorizationKey = txtAuthorizationKey.Text;
            item.ArchiveFolderName = txtArchiveFolder.Text;
            item.Exclusions = txtExclusions.Lines
                .Where(l => !String.IsNullOrEmpty(l))
                .ToList();
            //NewItem();
        }

        private void btnUpdateOptions_Click(object sender, EventArgs e)
        {
            var opt = Shared.Options;
            opt.Folders.ForEach(f => f.Stop());
            opt.Folders.Clear();
            opt.Folders.AddRange(items);
            Shared.Options.Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
