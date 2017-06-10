using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Result.Repository;
using SkyReg.Common.Extensions;

namespace SkyReg
{
    public partial class FrmPaymentAdd : KryptonForm
    {
        #region EventHandler


        #endregion

        #region Konstruktory

        public FrmPaymentAdd()
        {
            InitializeComponent();
        }

        #endregion

        #region Metody prywatne

        private void EnableDisableControls()
        {
            if (cmbBoxTypes.SelectedIndex == (int)PaymentsTypes.Pakiet)
            {
                numPrice.Enabled = true;
                numCount.Enabled = true;
            }
            else
            {
                numPrice.Enabled = false;
                numCount.Enabled = false;
            }
        }

        private bool DoValitate()
        {
            bool txtBoxNameError = false;
            bool result = true;

            if (!txtBoxName.Text.HasValue())
            {
                errorProvider1.SetError(txtBoxName, "Pole nie może być puste!");
                txtBoxNameError = true;
                result = false;
            }

            using (DLModelContainer model = new DLModelContainer())
            {
                if ((model.PaymentsSetting.Any(p => p.Name == txtBoxName.Text)) == true)
                {
                    errorProvider1.SetError(txtBoxName, "Płatność lub pakiet o tej nazwie już istnieje!");
                    txtBoxNameError = true;
                    result = false;
                }
            }

            if (cmbBoxTypes.SelectedIndex == (int)PaymentsTypes.Pakiet)
            {
                if (numCount.Value == default(decimal))
                {
                    errorProvider1.SetError(numCount, "Wartość nie może być równa 0!");
                    result = false;
                }
                else
                {
                    errorProvider1.SetError(numCount, string.Empty);
                }

                if (numPrice.Value == default(decimal))
                {
                    errorProvider1.SetError(numPrice, "Wartość nie może być równa 0!");
                    result = false;
                }
                else
                    errorProvider1.SetError(numPrice, string.Empty);
            }
            else
            {
                errorProvider1.SetError(numPrice, string.Empty);
                errorProvider1.SetError(numCount, string.Empty);
            }

            if (txtBoxNameError == false)
                errorProvider1.SetError(txtBoxName, string.Empty);

            return result;
        }

        private void AddPymentSet()
        {
            PaymentsTypes type;
            Enum.TryParse(cmbBoxTypes.Text, out type);
            using (var _paySetting = new DLModelRepository<PaymentsSetting>())
            {
                var ps = new PaymentsSetting();
                ps.Count = numCount.Value;
                ps.Name = txtBoxName.Text;
                ps.Type = (short)cmbBoxTypes.SelectedIndex;
                ps.Value = numPrice.Value;
                var result = _paySetting.Insert(ps);
                if (result.IsSuccess)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        #endregion

        #region Zdarzenia

        private void FrmPaymentAdd_Load(object sender, EventArgs e)
        {
            cmbBoxTypes.DataSource = SkyRegEnums.EnumExtensions.GetDescriptions(typeof(PaymentsTypes));

            
            EnableDisableControls();
           
        }
        
        private void cmbBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DoValitate())
            {
                AddPymentSet();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
