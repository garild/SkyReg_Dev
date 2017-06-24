using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg.Common.Prints.LoadingList
{
    public partial class LoadingListForm : Form
    {
        public LLHeader Header { get; set; }
        public List<LLItems> Items { get; set; }


        public LoadingListForm()
        {
            InitializeComponent();
        }

        private void LoadingListForm_Load(object sender, EventArgs e)
        {
            LLHeaderBindingSource.DataSource = Header;
            LLItemsBindingSource.DataSource = Items;

            this.rvLoadingList.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.rvLoadingList.RefreshReport();
        }
    }
}
