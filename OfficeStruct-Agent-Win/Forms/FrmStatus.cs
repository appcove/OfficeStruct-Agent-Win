using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeStruct_Agent_Win.Classes;

namespace OfficeStruct_Agent_Win.Forms
{
    public partial class FrmStatus : Form
    {
        public FrmStatus()
        {
            InitializeComponent();
        }

        public void Update(IEnumerable<LogItem> items, int max = 100)
        {
            lv.ClearObjects();
            lv.SetObjects(items
                .OrderByDescending(i => i.Date)
                .Take(max)
                .ToList());
        }
    }
}
