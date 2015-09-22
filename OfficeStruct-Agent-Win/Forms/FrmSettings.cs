using System;
using System.Windows.Forms;
using OfficeStruct_Agent_Win.Classes;

namespace OfficeStruct_Agent_Win.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly Options opt;

        public FrmSettings(Options opt)
        {
            InitializeComponent();

            this.opt = opt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            opt.Save();
        }
    }
}
