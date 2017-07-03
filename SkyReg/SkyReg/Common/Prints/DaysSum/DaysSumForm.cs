using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg.Common.Prints.DaysSum
{
    public partial class DaysSumForm : Form
    {
        string HtmlTemplate = default(string);

        public DaysSumForm(string html)
        {
            InitializeComponent();
            this.HtmlTemplate = html;
            LoadHtml();
        }

        private void LoadHtml()
        {
            webBrowser1.DocumentText = HtmlTemplate;
        }
    }
}
