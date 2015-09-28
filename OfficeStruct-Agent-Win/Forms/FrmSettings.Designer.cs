namespace OfficeStruct_Agent_Win.Forms
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.udDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApiEndpoint = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            this.txtAuthorizationKey = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            this.txtArchiveFolder = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            this.chkNotifications = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFolders = new System.Windows.Forms.TextBox();
            this.txtExclusions = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Archive folder name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Authorization key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Api endpoint";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // udDelay
            // 
            this.udDelay.Location = new System.Drawing.Point(160, 7);
            this.udDelay.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.udDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDelay.Name = "udDelay";
            this.udDelay.Size = new System.Drawing.Size(64, 22);
            this.udDelay.TabIndex = 11;
            this.udDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Seconds between checks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtApiEndpoint
            // 
            this.txtApiEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiEndpoint.CueText = "";
            this.txtApiEndpoint.Location = new System.Drawing.Point(159, 35);
            this.txtApiEndpoint.Name = "txtApiEndpoint";
            this.txtApiEndpoint.Size = new System.Drawing.Size(424, 22);
            this.txtApiEndpoint.TabIndex = 15;
            this.txtApiEndpoint.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtAuthorizationKey
            // 
            this.txtAuthorizationKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthorizationKey.CueText = "";
            this.txtAuthorizationKey.Location = new System.Drawing.Point(160, 63);
            this.txtAuthorizationKey.Name = "txtAuthorizationKey";
            this.txtAuthorizationKey.Size = new System.Drawing.Size(424, 22);
            this.txtAuthorizationKey.TabIndex = 16;
            this.txtAuthorizationKey.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtArchiveFolder
            // 
            this.txtArchiveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchiveFolder.CueText = "";
            this.txtArchiveFolder.Location = new System.Drawing.Point(160, 91);
            this.txtArchiveFolder.Name = "txtArchiveFolder";
            this.txtArchiveFolder.Size = new System.Drawing.Size(424, 22);
            this.txtArchiveFolder.TabIndex = 17;
            this.txtArchiveFolder.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // chkNotifications
            // 
            this.chkNotifications.AutoSize = true;
            this.chkNotifications.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNotifications.Location = new System.Drawing.Point(51, 119);
            this.chkNotifications.Name = "chkNotifications";
            this.chkNotifications.Size = new System.Drawing.Size(123, 17);
            this.chkNotifications.TabIndex = 18;
            this.chkNotifications.Text = "Show notifications";
            this.chkNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNotifications.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Folders to be monitored";
            // 
            // txtFolders
            // 
            this.txtFolders.Location = new System.Drawing.Point(14, 173);
            this.txtFolders.Multiline = true;
            this.txtFolders.Name = "txtFolders";
            this.txtFolders.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFolders.Size = new System.Drawing.Size(342, 74);
            this.txtFolders.TabIndex = 20;
            this.tip.SetToolTip(this.txtFolders, "One folder each line");
            this.txtFolders.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtExclusions
            // 
            this.txtExclusions.Location = new System.Drawing.Point(375, 173);
            this.txtExclusions.Multiline = true;
            this.txtExclusions.Name = "txtExclusions";
            this.txtExclusions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExclusions.Size = new System.Drawing.Size(204, 74);
            this.txtExclusions.TabIndex = 22;
            this.tip.SetToolTip(this.txtExclusions, "Files to exclude (one each line).\r\nUse * to include generic patterns, eg\r\n*.tmp\r\n" +
        "~*\r\n*.exe");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(373, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Exclusions list";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnUpdate;
            this.btnSave.Location = new System.Drawing.Point(218, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 72);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "UPDATE OPTIONS";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAddFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnAddFolder;
            this.btnAddFolder.Location = new System.Drawing.Point(14, 253);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(31, 23);
            this.btnAddFolder.TabIndex = 23;
            this.btnAddFolder.UseMnemonic = false;
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 339);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.txtExclusions);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFolders);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkNotifications);
            this.Controls.Add(this.txtArchiveFolder);
            this.Controls.Add(this.txtAuthorizationKey);
            this.Controls.Add(this.txtApiEndpoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.udDelay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udDelay;
        private System.Windows.Forms.Label label1;
        private Controls.CueTextBox txtApiEndpoint;
        private Controls.CueTextBox txtAuthorizationKey;
        private Controls.CueTextBox txtArchiveFolder;
        private System.Windows.Forms.CheckBox chkNotifications;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFolders;
        private System.Windows.Forms.TextBox txtExclusions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.ToolTip tip;
    }
}