namespace OfficeStruct_Agent_Win.Forms
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.nic = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCheckNow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // nic
            // 
            this.nic.ContextMenuStrip = this.mnu;
            this.nic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nic_MouseClick);
            this.nic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nic_MouseDoubleClick);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenOptions,
            this.mnuEnabled,
            this.mnuCheckNow,
            this.mnuViewStatus,
            this.mnuExit});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(167, 136);
            // 
            // mnuOpenOptions
            // 
            this.mnuOpenOptions.Image = global::OfficeStruct_Agent_Win.Properties.Resources.edit;
            this.mnuOpenOptions.Name = "mnuOpenOptions";
            this.mnuOpenOptions.Size = new System.Drawing.Size(166, 22);
            this.mnuOpenOptions.Text = "Change settings";
            this.mnuOpenOptions.Click += new System.EventHandler(this.mnuOpenOptions_Click);
            // 
            // mnuCheckNow
            // 
            this.mnuCheckNow.Image = ((System.Drawing.Image)(resources.GetObject("mnuCheckNow.Image")));
            this.mnuCheckNow.Name = "mnuCheckNow";
            this.mnuCheckNow.Size = new System.Drawing.Size(166, 22);
            this.mnuCheckNow.Text = "Check now";
            this.mnuCheckNow.Click += new System.EventHandler(this.mnuCheckNow_Click);
            // 
            // mnuViewStatus
            // 
            this.mnuViewStatus.Name = "mnuViewStatus";
            this.mnuViewStatus.Size = new System.Drawing.Size(166, 22);
            this.mnuViewStatus.Text = "View status";
            this.mnuViewStatus.Click += new System.EventHandler(this.mnuViewStatus_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(166, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuEnabled
            // 
            this.mnuEnabled.CheckOnClick = true;
            this.mnuEnabled.Name = "mnuEnabled";
            this.mnuEnabled.Size = new System.Drawing.Size(166, 22);
            this.mnuEnabled.Text = "Enabled/Disabled";
            this.mnuEnabled.Click += new System.EventHandler(this.mnuEnabled_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Uploader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nic;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckNow;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuViewStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuEnabled;
    }
}

