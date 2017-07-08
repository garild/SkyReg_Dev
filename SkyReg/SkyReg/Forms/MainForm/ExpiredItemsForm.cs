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
    public partial class ExpiredItemsForm : KryptonForm
    {
        public List<ExpiredItem> UsersExpiredList { get; set; }
        public List<ExpiredItem> SupervisorsExpiredList { get; set; }

        public ExpiredItemsForm()
        {
            InitializeComponent();
        }
    }
}
