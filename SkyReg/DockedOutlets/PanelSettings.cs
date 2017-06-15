using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockedOutlets
{
    public partial class PanelSettings : KryptonForm
    {
        public PanelSettings()
        {
            InitializeComponent();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            var result = fontDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Test");
            }
            else
                this.BringToFront();
        }
    }
}
