namespace OfficeStruct_Agent_Win.Forms
{
    partial class FrmStatus
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
            this.lv = new BrightIdeasSoftware.ObjectListView();
            this.colDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lv)).BeginInit();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.AllColumns.Add(this.colDate);
            this.lv.AllColumns.Add(this.colMessage);
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colMessage});
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.EmptyListMsg = "";
            this.lv.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.ShowFilterMenuOnRightClick = false;
            this.lv.ShowGroups = false;
            this.lv.Size = new System.Drawing.Size(976, 391);
            this.lv.TabIndex = 25;
            this.lv.UseAlternatingBackColors = true;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.UseNotifyPropertyChanged = true;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.AspectName = "Date";
            this.colDate.Text = "Date/Time";
            this.colDate.Width = 140;
            // 
            // colMessage
            // 
            this.colMessage.AspectName = "Message";
            this.colMessage.FillsFreeSpace = true;
            this.colMessage.Text = "Message";
            // 
            // FrmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 391);
            this.Controls.Add(this.lv);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "FrmStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            ((System.ComponentModel.ISupportInitialize)(this.lv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView lv;
        private BrightIdeasSoftware.OLVColumn colDate;
        private BrightIdeasSoftware.OLVColumn colMessage;
    }
}