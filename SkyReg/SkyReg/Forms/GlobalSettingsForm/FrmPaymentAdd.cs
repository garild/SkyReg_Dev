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

namespace SkyReg
{
    public partial class FrmPaymentAdd : KryptonForm
    {
        #region EventHandler

        public EventHandler FormaAccept;

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
            if (cmbBoxTypes.SelectedIndex == (int)Enum_paymentsTypes.Package)
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

            if (txtBoxName.Text == string.Empty)
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

            if (cmbBoxTypes.SelectedIndex == (int)Enum_paymentsTypes.Package)
            {
                if (numCount.Value == 0)
                {
                    errorProvider1.SetError(numCount, "Wartość nie może być równa 0!");
                    result = false;
                }
                else
                {
                    errorProvider1.SetError(numCount, string.Empty);
                }

                if (numPrice.Value == 0)
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
            using(DLModelContainer model = new DLModelContainer())
            {
                PaymentsSetting ps = new PaymentsSetting();
                ps.Count = numCount.Value;
                ps.Name = txtBoxName.Text;
                ps.Type = (short)cmbBoxTypes.SelectedIndex;
                ps.Value = numPrice.Value;
                model.PaymentsSetting.Add(ps);
                model.SaveChanges();
            }
        }

        #endregion

        #region Zdarzenia

        private void FrmPaymentAdd_Load(object sender, EventArgs e)
        {
            cmbBoxTypes.SelectedIndex = (int)Enum_paymentsTypes.Income;
            EnableDisableControls();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        
        private void cmbBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if( DoValitate() == true)
            {
                AddPymentSet();
                FormaAccept.Invoke(this, null);
                this.Close();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
