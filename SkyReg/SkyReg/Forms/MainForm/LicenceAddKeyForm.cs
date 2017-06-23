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

namespace SkyReg
{
    public partial class LicenceAddKeyForm : KryptonForm
    {
        public LicenceAddKeyForm()
        {
            InitializeComponent();
        }

        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtLicenceKey.Text == "0okm)OKM" || txtLicenceKey.Text == "ZAQ12wsx")
            {
                Settings.Default.LicenceKey = txtLicenceKey.Text;
                Settings.Default.Save();
                KryptonMessageBox.Show("Zapisano klucz.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                errorProvider1.SetError(txtLicenceKey, "Wprowadzony klucz nie jest poprawny!");
            }
        }
    }
}
