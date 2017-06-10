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
using SkyReg.BLL.Services;
using DataLayer.Result.Repository;
using DataLayer.Utils;

namespace SkyReg
{
    public partial class PaymentsAddEditForm : KryptonForm
    {
        public SkyRegEnums.FormState FormState { get; set; }
        public int PayId { get; set; }

        public PaymentsAddEditForm()
        {
            InitializeComponent();
        }

        private void PaymentsAddEditForm_Load(object sender, EventArgs e)
        {
            LoadPayTypes();
        }

        private void LoadPayTypes()
        {
            using(DLModelRepository<PaymentsSetting> ctxPayment = new DLModelRepository<PaymentsSetting>())
            {
                var allPayments = ctxPayment.GetAll();
                if (allPayments.IsSuccess)
                {
                    cmbPayType.DataSource = allPayments;
                    cmbPayType.DisplayMember = "Name";
                    cmbPayType.ValueMember = "Id";
                    cmbPayType.SelectedIndex = 0;
                }
            }
        }
    }
}
