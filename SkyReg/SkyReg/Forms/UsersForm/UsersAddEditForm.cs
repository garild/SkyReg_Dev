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
using SkyRegEnums;

namespace SkyReg
{
    public partial class UsersAddEditForm : KryptonForm
    {
        public FormState FormState { get; set; }
        public int? IdUser { get; set; }
        public int UserGroup { get; set; }

        public EventHandler EventHandlerAddEditUser;

        public UsersAddEditForm()
        {
            InitializeComponent();
            dateCertDate.MaxDate = DateTime.Now.AddYears(2);
        }

        private void UsersAddEditForm_Load(object sender, EventArgs e)
        {
            LoadAllUsersTypes();

            if (FormState == FormState.Edit)
            {
                LoadEditedUserData();
                LoadJumpsList();
                LoadUsersFinancesList();
                LoadBalance();
            }
        }

        private void LoadUsersFinancesList()
        {
            using(DLModelContainer model =new DLModelContainer())
            {
                var list = model
                    .Payment
                    .Include("User")
                    .Include("FlightsElem")
                    .Include("Flight")
                    .AsNoTracking()
                    .Where(p => p.User.Id == IdUser)
                    .OrderBy(p => p.Date)
                    .Select(p => new UsersFinances
                    {
                        Date = p.Date.Value,
                        Type = p.PaymentsSetting.Type,
                        Description = p.Description,
                        Value = p.Value,
                        Count = p.Count.Value
                    })
                    .ToList();

                foreach(var item in list)
                {
                    item.Date = item.Date.Date;
                    switch ( item.Type)
                    {
                        case (int)SkyRegEnums.PaymentsTypes.KP:
                            item.Description = string.Format("KP {0}", item.Description);
                            break;
                        case (int)SkyRegEnums.PaymentsTypes.KW:
                            item.Description = string.Format("KW {0}", item.Description);
                            item.Value = -item.Value;
                            break;
                        case (int)SkyRegEnums.PaymentsTypes.BP:
                            item.Description = string.Format("BP {0}", item.Description);
                            break;
                        case (int)SkyRegEnums.PaymentsTypes.BW:
                            item.Description = string.Format("BW {0}", item.Description);
                            item.Value = -item.Value;
                            break;
                        case (int)SkyRegEnums.PaymentsTypes.Pakiet:
                            item.Description = string.Format("Pakiet {0}", item.Description);
                            break;
                        case (int)SkyRegEnums.PaymentsTypes.Naleznosc:
                            item.Value = -item.Value;
                            item.Count = -item.Count;
                            break;
                    }
                }
                grdFinances.DataSource = list;

                grdFinances.Columns["Type"].Visible = false;

                grdFinances.Columns["Date"].HeaderText = "Data";
                grdFinances.Columns["Description"].HeaderText = "Opis";
                grdFinances.Columns["Value"].HeaderText = "Wartość";
                grdFinances.Columns["Count"].HeaderText = "Pakiet";

                grdFinances.Columns["Date"].Width = 80;
                grdFinances.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdFinances.Columns["Value"].Width = 100;
                grdFinances.Columns["Count"].Width = 100;

                grdFinances.ReadOnly = true;
                grdFinances.RowHeadersVisible = false;
                grdFinances.AllowUserToResizeRows = false;
                grdFinances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grdFinances.MultiSelect = false;
            }
        }

        private void LoadJumpsList()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                var usersJumps = model
                    .FlightsElem
                    .Include("Flight")
                    .Include("User")
                    .AsNoTracking()
                    .Where(p => p.User.Id == IdUser)
                    .OrderBy(p => p.Flight.FlyDateTime)
                    .Select(p => new
                    {
                        Date = p.Flight.FlyDateTime,
                        FlyNr = "LOT " + p.Flight.FlyDateTime.Year + "/" + p.Flight.FlyDateTime.Month + "/" + p.Flight.FlyDateTime.Day + "/" + p.Flight.FlyNr,
                        Altitude = p.Flight.Altitude
                    })
                    .ToList();
                grdJumpsList.DataSource = usersJumps;

                grdJumpsList.Columns["FlyNr"].HeaderText = "Nr lotu";
                grdJumpsList.Columns["Altitude"].HeaderText = "Pułap";
                grdJumpsList.Columns["Date"].HeaderText = "Data";

                grdJumpsList.Columns["Date"].Width = 100;
                grdJumpsList.Columns["FlyNr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdJumpsList.Columns["Altitude"].Width = 80;

                grdJumpsList.ReadOnly = true;
                grdJumpsList.RowHeadersVisible = false;
                grdJumpsList.AllowUserToResizeRows = false;
                grdJumpsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grdJumpsList.MultiSelect = false;
            }
        }

        private void LoadEditedUserData()
        {
            using(var model =  new DLModelRepository<User>())
            {
                var usr = model.GetAll().Value?.Where(p => p.Id == IdUser).FirstOrDefault();
                if (usr != null)
                {
                    txtCertyfikate.Text = usr.Certificate;
                    txtCity.Text = usr.City;
                    txtEmail.Text = usr.Email;
                    txtFacebook.Text = usr.FaceBook;
                    txtFirstName.Text = usr.FirstName;
                    txtLogin.Text = usr.Login;
                    txtPassword.Text = usr.Password;
                    txtPhone.Text = usr.Phone;
                    txtStreet.Text = usr.Street;
                    txtStreetNr.Text = usr.StreetNr;
                    txtSurName.Text = usr.SurName;
                    txtZipCode.Text = usr.ZipCode;
                    dateCertDate.Value = usr.CertDate.HasValue ? usr.CertDate.Value : dateCertDate.MaxDate;
                }
            }
        }

        private void LoadAllUsersTypes()
        {
            chkListUserTypes.Items.Clear();
            using(var model = new DLModelContainer())
            {
                var allUserTypes = model.UsersType.ToList();
                if (FormState == FormState.Edit)
                {
                    var currentUserTypes = model.User.Where(p => p.Id == IdUser).SelectMany(p => p.UsersType).ToList();
                    allUserTypes?.ForEach(item =>
                    {
                        if (currentUserTypes.Any(p => p.Id == item.Id))
                            chkListUserTypes.Items.Add(item.Name, true);
                        else
                            chkListUserTypes.Items.Add(item.Name, false);
                    });
                    
                }
                else
                {
                    allUserTypes?.ForEach(p=>
                    {
                        chkListUserTypes.Items.Add(p.Name, false);
                    });
                   
                }
            }
        }

        private void btnCheckLogin_Click(object sender, EventArgs e)
        {
            using(var model = new DLModelRepository<User>())
            {
                var isUser = model.GetAll().Value?.Any(p => p.Login == txtLogin.Text);
                if (!isUser.HasValue)
                {
                    KryptonMessageBox.Show("Login wolny.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    KryptonMessageBox.Show("Ten login jest już w użyciu!", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateAddEditUser())
            {
                SaveUser();
            }
        }

        private void SaveUser()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                User usr = new User();

                if (FormState != FormState.Add)
                {
                    usr = model.User.Include("UsersType").AsNoTracking().Where(p => p.Id == IdUser).FirstOrDefault();
                }

                var listUsersTypes = new List<UsersType>();
              
                foreach (var item in chkListUserTypes.CheckedItems)
                {
                    listUsersTypes.Add(model.UsersType.Where(p => p.Name == item.ToString()).FirstOrDefault());
                }

                if (txtCertyfikate.Text.HasValue())
                    usr.CertDate = dateCertDate.Value.Date;
                else
                    usr.CertDate = dateCertDate.MaxDate;

                usr.Certificate = txtCertyfikate.Text;
                usr.City = txtCity.Text;
                usr.Email = txtEmail.Text;
                usr.FaceBook = txtFacebook.Text;
                usr.FirstName = txtFirstName.Text;
                usr.Group = model.Group.Where(p => p.Id == UserGroup).First();
                usr.Login = txtLogin.Text;
                usr.Password = txtPassword.Text;
                usr.Phone = txtPhone.Text;
                usr.Street = txtStreet.Text;
                usr.StreetNr = txtStreetNr.Text;
                usr.SurName = txtSurName.Text;
                usr.ZipCode = txtZipCode.Text;
                usr.UsersType = listUsersTypes;

                if (FormState == FormState.Add)
                {
                    model.User.Add(usr);
                }
                else
                {
                    model.User.Include("UsersType").AsNoTracking();
                    model.Entry<User>(usr).State = System.Data.Entity.EntityState.Modified;
                }
                model.SaveChanges();

                if(FormState == FormState.Edit)
                {
                    string qry = "delete from dbo.userUsersType ";
                    qry += string.Format("where User_Id = {0}", usr.Id);
                    model.Database.ExecuteSqlCommand(qry);

                    foreach( UsersType ut in listUsersTypes)
                    {
                        qry = "insert into dbo.UserUsersType (User_Id, UsersType_Id)";
                        qry += string.Format("values ({0}, {1})", usr.Id, ut.Id);
                        model.Database.ExecuteSqlCommand(qry);
                    }
                }     
                this.Close();
            }
        }

        private bool ValidateAddEditUser()
        {
            errorProvider1.Clear();

            using(DLModelRepository<User> _ctxUsr = new DLModelRepository<User>())
            {
                var userList = _ctxUsr.GetAll();
                if (userList.IsSuccess)
                {
                    if (!txtFirstName.Text.HasValue())
                    {
                        errorProvider1.SetError(txtFirstName, "Pole nie może być puste!");
                        return false;
                    }
                    if (!txtSurName.Text.HasValue())
                    {
                        errorProvider1.SetError(txtSurName, "Pole nie może być puste!");
                        return false;
                    }
                
                    if (userList.Value.Where(p => p.FirstName == txtFirstName.Text && p.SurName == txtSurName.Text && p.Id != IdUser).FirstOrDefault() != null)
                    {
                        errorProvider1.SetError(txtFirstName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
                        errorProvider1.SetError(txtSurName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
                        return false;
                    }
                    if (userList.Value.Any(p => p.Login == txtLogin.Text && p.Id != IdUser && p.Login != string.Empty))
                    {
                        errorProvider1.SetError(txtLogin, "Ten login jest już w użyciu!");
                        return false;
                    }

                }
            }

            return true;
        }

        private void UsersAddEditForm_Shown(object sender, EventArgs e)
        {
            txtFirstName.Focus();
        }

        private void LoadBalance()
        {
            using (var model = new DLModelContainer())
            {
                int userId = IdUser.Value;
                var incomeM = model
                    .Payment
                    .Include("User")
                    .Include("PaymentsSetting")
                    .AsNoTracking()
                    .Where(p => p.User.Id == userId && p.Count == 0 && (p.PaymentsSetting.Type == 0 || p.PaymentsSetting.Type == 2 || p.PaymentsSetting.Type == 6))
                    .ToList();
                var incomeMoney = incomeM.Sum(p => p.Value);

                var outcomeM = model
                    .Payment
                    .Include("User")
                    .Include("PaymentsSetting")
                    .AsNoTracking()
                    .Where(p => p.User.Id == userId && p.Count == 0 && (p.PaymentsSetting.Type == 1 || p.PaymentsSetting.Type == 4 || p.PaymentsSetting.Type == 5))
                    .ToList();
                var outcomeMoney = outcomeM.Sum(p => p.Value);

                var incomeP = model
                    .Payment
                    .Include("User")
                    .Include("PaymentsSetting")
                    .AsNoTracking()
                    .Where(p => p.User.Id == userId && p.Count != 0 && (p.PaymentsSetting.Type == 0 || p.PaymentsSetting.Type == 2 || p.PaymentsSetting.Type == 6))
                    .ToList();
                var incomePackage = incomeP.Sum(p => p.Count);

                var outcomeP = model
                    .Payment
                    .Include("User")
                    .Include("PaymentsSetting")
                    .AsNoTracking()
                    .Where(p => p.User.Id == userId && p.Count != 0 && (p.PaymentsSetting.Type == 1 || p.PaymentsSetting.Type == 4 || p.PaymentsSetting.Type == 5))
                    .ToList();
                var outcomePackage = outcomeP.Sum(p => p.Count);

                numBalanceMoney.Value = incomeMoney - outcomeMoney;
                numBalancePack.Value = incomePackage.Value - outcomePackage.Value;
            }
        }

    }
}
