using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg.Forms.HtmlDocker
{
    public partial class PrintPreview : KryptonForm
    {
        public string htmlTemplate;

        public PrintPreview(string html)
        {
            InitializeComponent();
            this.htmlTemplate = html;
            LoadHtml();
        }

        private void LoadHtml()
        {
            webBrowser1.DocumentText = htmlTemplate;
        }
    }
}
