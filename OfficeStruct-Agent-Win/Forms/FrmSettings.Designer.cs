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
            this.label5 = new System.Windows.Forms.Label();
            this.txtExclusions = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lv = new BrightIdeasSoftware.ObjectListView();
            this.colFolder = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnl = new System.Windows.Forms.Panel();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateOptions = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.chkUploadToWebservice = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.txtLogFolder = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            this.txtFolder = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            this.txtArchiveFolder = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            this.txtAuthorizationKey = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            this.txtApiEndpoint = new OfficeStruct_Agent_Win.Controls.CueTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lv)).BeginInit();
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Archive folder name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Authorization key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Api endpoint";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // udDelay
            // 
            this.udDelay.Location = new System.Drawing.Point(153, 33);
            this.udDelay.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.udDelay.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udDelay.Name = "udDelay";
            this.udDelay.Size = new System.Drawing.Size(64, 22);
            this.udDelay.TabIndex = 12;
            this.udDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seconds between checks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Folders to be monitored";
            // 
            // txtExclusions
            // 
            this.txtExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExclusions.Location = new System.Drawing.Point(153, 147);
            this.txtExclusions.Multiline = true;
            this.txtExclusions.Name = "txtExclusions";
            this.txtExclusions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExclusions.Size = new System.Drawing.Size(414, 63);
            this.txtExclusions.TabIndex = 10;
            this.tip.SetToolTip(this.txtExclusions, "Files to exclude (one each line).\r\nUse * to include generic patterns, eg\r\n*.tmp\r\n" +
        "~*\r\n*.exe");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Exclusions list";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnClear;
            this.btnClear.Location = new System.Drawing.Point(555, 84);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 27;
            this.tip.SetToolTip(this.btnClear, "Remove ALL folders");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnDelete;
            this.btnRemove.Location = new System.Drawing.Point(555, 54);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 24);
            this.btnRemove.TabIndex = 26;
            this.tip.SetToolTip(this.btnRemove, "Remove selected folder");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnAddFolder;
            this.btnAdd.Location = new System.Drawing.Point(555, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 23;
            this.tip.SetToolTip(this.btnAdd, "Add a new folder");
            this.btnAdd.UseMnemonic = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lv
            // 
            this.lv.AllColumns.Add(this.colFolder);
            this.lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFolder});
            this.lv.EmptyListMsg = "NO FOLDER TO MONITOR";
            this.lv.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.Location = new System.Drawing.Point(12, 25);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.ShowFilterMenuOnRightClick = false;
            this.lv.ShowGroups = false;
            this.lv.Size = new System.Drawing.Size(537, 123);
            this.lv.TabIndex = 24;
            this.lv.UseAlternatingBackColors = true;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.UseNotifyPropertyChanged = true;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SelectionChanged += new System.EventHandler(this.lv_SelectionChanged);
            // 
            // colFolder
            // 
            this.colFolder.AspectName = "Folder";
            this.colFolder.FillsFreeSpace = true;
            this.colFolder.Text = "Folder name";
            // 
            // pnl
            // 
            this.pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl.Controls.Add(this.cboLevel);
            this.pnl.Controls.Add(this.label9);
            this.pnl.Controls.Add(this.chkUploadToWebservice);
            this.pnl.Controls.Add(this.txtLogFolder);
            this.pnl.Controls.Add(this.label8);
            this.pnl.Controls.Add(this.btnAddFolder);
            this.pnl.Controls.Add(this.txtFolder);
            this.pnl.Controls.Add(this.label7);
            this.pnl.Controls.Add(this.btnSave);
            this.pnl.Controls.Add(this.txtExclusions);
            this.pnl.Controls.Add(this.label6);
            this.pnl.Controls.Add(this.txtArchiveFolder);
            this.pnl.Controls.Add(this.txtAuthorizationKey);
            this.pnl.Controls.Add(this.txtApiEndpoint);
            this.pnl.Controls.Add(this.label4);
            this.pnl.Controls.Add(this.label3);
            this.pnl.Controls.Add(this.label2);
            this.pnl.Controls.Add(this.udDelay);
            this.pnl.Controls.Add(this.label1);
            this.pnl.Location = new System.Drawing.Point(12, 154);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(584, 304);
            this.pnl.TabIndex = 25;
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFolder.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAddFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnFolder;
            this.btnAddFolder.Location = new System.Drawing.Point(545, 6);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(22, 22);
            this.btnAddFolder.TabIndex = 2;
            this.btnAddFolder.UseMnemonic = false;
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Folder to monitor";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnSave;
            this.btnSave.Location = new System.Drawing.Point(396, 263);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 36);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "SAVE FOLDER SETTINGS";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnDiscardAndClose;
            this.btnClose.Location = new System.Drawing.Point(289, 464);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(193, 72);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "DISCARD CHANGES AND EXIT";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdateOptions
            // 
            this.btnUpdateOptions.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdateOptions.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnUpdateOptions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdateOptions.Image = global::OfficeStruct_Agent_Win.Properties.Resources.btnUpdate;
            this.btnUpdateOptions.Location = new System.Drawing.Point(117, 464);
            this.btnUpdateOptions.Name = "btnUpdateOptions";
            this.btnUpdateOptions.Size = new System.Drawing.Size(138, 72);
            this.btnUpdateOptions.TabIndex = 9;
            this.btnUpdateOptions.Text = "UPDATE OPTIONS";
            this.btnUpdateOptions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdateOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdateOptions.UseVisualStyleBackColor = true;
            this.btnUpdateOptions.Click += new System.EventHandler(this.btnUpdateOptions_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Log folder name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkUploadToWebservice
            // 
            this.chkUploadToWebservice.AutoSize = true;
            this.chkUploadToWebservice.Location = new System.Drawing.Point(241, 36);
            this.chkUploadToWebservice.Name = "chkUploadToWebservice";
            this.chkUploadToWebservice.Size = new System.Drawing.Size(137, 17);
            this.chkUploadToWebservice.TabIndex = 16;
            this.chkUploadToWebservice.Text = "Upload to webservice";
            this.chkUploadToWebservice.UseVisualStyleBackColor = true;
            this.chkUploadToWebservice.CheckedChanged += new System.EventHandler(this.chkUploadToWebservice_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Log level";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboLevel
            // 
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Location = new System.Drawing.Point(153, 247);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(121, 21);
            this.cboLevel.TabIndex = 18;
            this.cboLevel.SelectedIndexChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogFolder.CueText = "";
            this.txtLogFolder.Location = new System.Drawing.Point(153, 217);
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.Size = new System.Drawing.Size(414, 22);
            this.txtLogFolder.TabIndex = 15;
            this.txtLogFolder.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.CueText = "";
            this.txtFolder.Location = new System.Drawing.Point(153, 6);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(384, 22);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtArchiveFolder
            // 
            this.txtArchiveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchiveFolder.CueText = "";
            this.txtArchiveFolder.Location = new System.Drawing.Point(153, 117);
            this.txtArchiveFolder.Name = "txtArchiveFolder";
            this.txtArchiveFolder.Size = new System.Drawing.Size(414, 22);
            this.txtArchiveFolder.TabIndex = 8;
            this.txtArchiveFolder.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtAuthorizationKey
            // 
            this.txtAuthorizationKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthorizationKey.CueText = "";
            this.txtAuthorizationKey.Location = new System.Drawing.Point(153, 89);
            this.txtAuthorizationKey.Name = "txtAuthorizationKey";
            this.txtAuthorizationKey.Size = new System.Drawing.Size(414, 22);
            this.txtAuthorizationKey.TabIndex = 6;
            this.txtAuthorizationKey.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // txtApiEndpoint
            // 
            this.txtApiEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiEndpoint.CueText = "";
            this.txtApiEndpoint.Location = new System.Drawing.Point(153, 61);
            this.txtApiEndpoint.Name = "txtApiEndpoint";
            this.txtApiEndpoint.Size = new System.Drawing.Size(414, 22);
            this.txtApiEndpoint.TabIndex = 4;
            this.txtApiEndpoint.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 538);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnUpdateOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lv)).EndInit();
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udDelay;
        private System.Windows.Forms.Label label1;
        private Controls.CueTextBox txtApiEndpoint;
        private Controls.CueTextBox txtAuthorizationKey;
        private Controls.CueTextBox txtArchiveFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExclusions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolTip tip;
        private BrightIdeasSoftware.ObjectListView lv;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddFolder;
        private Controls.CueTextBox txtFolder;
        private System.Windows.Forms.Label label7;
        private BrightIdeasSoftware.OLVColumn colFolder;
        private System.Windows.Forms.Button btnClose;
        private Controls.CueTextBox txtLogFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkUploadToWebservice;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.Label label9;
    }
}