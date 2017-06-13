using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyReg
{
    public partial class Examples2 : KryptonForm
    {
        public Examples2()
        {
            InitializeComponent();
        }

        private void Examples2_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles[0].Width = 0;
            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.AutoSize;
        }
    }
}
