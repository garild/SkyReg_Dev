using ComponentFactory.Krypton.Toolkit;
using SkyReg.Common.Extensions;
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
    public partial class PaymentsForm : KryptonForm
    {
        


        public PaymentsForm()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {


            PaymentsAddEditForm = FormsOpened<PaymentsAddEditForm>.IsOpened(PaymentsAddEditForm);
            PaymentsAddEditForm.FormState = SkyRegEnums.FormState.Add;
            PaymentsAddEditForm.IdUser = default(int);
            if( PaymentsAddEditForm.ShowDialog() == DialogResult.OK)
            {
                //TODO tutaj ma być odswiezanie listy
            }
        }

        private PaymentsAddEditForm PaymentsAddEditForm = null;
    }
}
