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
using DataLayer.Entities.DBContext;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

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
            dtSurveyDate.Value = DateTime.Now;
            dateCertDate.Value = DateTime.Now;
            datInsuranceExpire.Value = DateTime.Now;
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
            using (SkyRegContext model = new SkyRegContext())
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

                foreach (var item in list)
                {
                    item.Date = item.Date.Date;
                    switch (item.Type)
                    {
                        case (int)PaymentsTypes.KP:
                            item.Description = string.Format("KP {0}", item.Description);
                            break;
                        case (int)PaymentsTypes.KW:
                            item.Description = string.Format("KW {0}", item.Description);
                            item.Value = -item.Value;
                            break;
                        case (int)PaymentsTypes.BP:
                            item.Description = string.Format("BP {0}", item.Description);
                            break;
                        case (int)PaymentsTypes.BW:
                            item.Description = string.Format("BW {0}", item.Description);
                            item.Value = -item.Value;
                            break;
                        case (int)PaymentsTypes.Pakiet:
                            item.Description = string.Format("Pakiet {0}", item.Description);
                            break;
                        case (int)PaymentsTypes.Naleznosc:
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
            using (SkyRegContext model = new SkyRegContext())
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
            using (var model = new SkyRegContextRepository<User>())
            {
                var usr = model.GetAll().Value?.Where(p => p.Id == IdUser).FirstOrDefault();
                if (usr != null)
                {
                    txtCertyfikate.Text = usr.Certificate;
                    txtCity.Text = usr.City;
                    txtEmail.Text = usr.Email;
                    txtFacebook.Text = usr.FaceBook;
                    txtLogin.Text = usr.Login;
                    //txtPassword.Text = usr.Password;

                    txtPassword.Text = DataLayer.Utils.Security.DecryptString(usr.Password);
                    
                    txtPhone.Text = usr.Phone;
                    txtStreet.Text = usr.Street;
                    txtStreetNr.Text = usr.StreetNr;
                    txtUserName.Text = usr.Name;
                    txtZipCode.Text = usr.ZipCode;
                    dateCertDate.Value = usr.CertDate.HasValue ? usr.CertDate.Value : DateTime.Now;
                    txtInsuranceNr.Text = usr.InsuranceNr;
                    datInsuranceExpire.Value = usr.InsuranceExpire != null  ? usr.InsuranceExpire : DateTime.Now;
                }
            }
        }

        private void LoadAllUsersTypes()
        {
            chkListUserTypes.Items.Clear();
            using (var _ctxUser = new SkyRegContextRepository<User>())
            using (var _ctxDefineUser = new SkyRegContextRepository<DefinedUserType>())
            {
                var allUserTypes = _ctxDefineUser.GetAll();
                var currentUserTypes = _ctxUser.GetAll(Tuple.Create(nameof(DefinedUserType), "", "")).Value.Where(p => p.Id == IdUser).FirstOrDefault();
                if (allUserTypes.IsSuccess)
                {
                    if (FormState == FormState.Edit)
                    {
                        allUserTypes.Value?.ForEach(item =>
                        {
                            if (currentUserTypes.DefinedUserType.Any(p => p.Id == item.Id))
                                chkListUserTypes.Items.Add(item.Name, true);
                            else
                                chkListUserTypes.Items.Add(item.Name, false);
                        });

                    }
                    else
                    {
                        allUserTypes.Value?.ForEach(p =>
                        {
                            chkListUserTypes.Items.Add(p.Name, false);
                        });

                    }
                }
            }
        }

        private void btnCheckLogin_Click(object sender, EventArgs e)
        {
            using (var model = new SkyRegContextRepository<User>())
            {
                var userExist = model.GetAll().Value?.Where(p => p.Name == txtUserName.Text).FirstOrDefault();
                if (userExist == null)
                {
                    KryptonMessageBox.Show("Login wolny.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                SaveUser();
        }

        private void SaveUser()
        {
            using (var _ctxUser = new SkyRegContextRepository<User>())
            using (var _ctxDefineUser = new SkyRegContextRepository<DefinedUserType>())
            {
                User usr = FormState == FormState.Add ? new User() : _ctxUser.GetAll(Tuple.Create(nameof(DefinedUserType), "", "")).Value?.FirstOrDefault(p => p.Id == IdUser);
                bool result = false;


                DefinedUserType dut;
                var listType = new List<DefinedUserType>();
                foreach (string item in chkListUserTypes.CheckedItems)
                {

                    dut = new DefinedUserType();
                    dut = _ctxUser.Model.DefinedUserType.Where(p => p.Name == item).FirstOrDefault();
                    listType.Add(dut);
                }

                if (txtCertyfikate.Text.HasValue())
                    usr.CertDate = dateCertDate.Value.Date;
                else
                    usr.CertDate = DateTime.Now.Date; ;

                usr.Certificate = txtCertyfikate.Text;
                usr.City = txtCity.Text;
                usr.Email = txtEmail.Text;
                usr.FaceBook = txtFacebook.Text;
                //usr.Group_Id = _ctxUser.Model.Group.Where(p => p.Id == UserGroup).FirstOrDefault().Id;
                usr.Login = txtLogin.Text;
                //usr.Password = txtPassword.Text;

                usr.Password = DataLayer.Utils.Security.EncryptString(txtPassword.Text);


                usr.Phone = txtPhone.Text;
                usr.Street = txtStreet.Text;
                usr.StreetNr = txtStreetNr.Text;
                usr.Name = txtUserName.Text;
                usr.ZipCode = txtZipCode.Text;
                usr.InsuranceNr = txtInsuranceNr.Text;
                usr.SurveyNr = txtSurveyNr.Text.Trim();
                usr.SurveyExpirateDate = dtSurveyDate.Value.Date;

                if (txtInsuranceNr.Text.HasValue())
                    usr.InsuranceExpire = datInsuranceExpire.Value.Date;
                else
                    usr.InsuranceExpire = DateTime.Now.Date;

                if (FormState == FormState.Add)
                {
                    usr.DefinedUserType = listType;
                    _ctxUser.InsertEntity(usr);
                }

                else // TODO UPDATE POPRAWIĆ
                {
                    usr.DefinedUserType.Clear();

                    string query = $"DELETE FROM [dbo].[UsersType] WHERE User_Id = {usr.Id}";
                    _ctxUser.Model.Database.ExecuteSqlCommand(query);

                    listType.ForEach(p =>
                    {
                        query = $"INSERT INTO [dbo].[UsersType] SELECT {p.Id},{usr.Id}";
                        _ctxUser.Model.Database.ExecuteSqlCommand(query);
                    });

                    _ctxUser.Update(usr);

                }
                this.Close();

            }
        }

       


        private bool ValidateAddEditUser()
        {
            errorProvider1.Clear();

            using (SkyRegContextRepository<User> _ctxUsr = new SkyRegContextRepository<User>())
            {
                var userList = _ctxUsr.GetAll();
                if (userList.IsSuccess)
                {
                    if (!txtUserName.Text.HasValue())
                    {
                        errorProvider1.SetError(txtUserName, "Pole nie może być puste!");
                        return false;
                    }
                    if (!txtUserName.Text.HasValue())
                    {
                        errorProvider1.SetError(txtUserName, "Pole nie może być puste!");
                        return false;
                    }

                    if (userList.Value.Where(p => p.Name == txtUserName.Text && p.Id != IdUser).FirstOrDefault() != null)
                    {
                        errorProvider1.SetError(txtUserName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
                        errorProvider1.SetError(txtUserName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
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
            txtUserName.Focus();
        }

        private void LoadBalance()
        {
            using (var _ctx = new SkyRegContextRepository<Payment>())
            {
                int userId = IdUser.Value;
                var dataFilter = _ctx.GetAll(Tuple.Create(nameof(User), nameof(PaymentsSetting), ""));
                var incomeMoney = dataFilter.Value?
                    .Where(p => p.User.Id == userId 
                    && p.Count == 0 
                    && (p.PaymentsSetting.Type == 0 || p.PaymentsSetting.Type == 2 || p.PaymentsSetting.Type == 6))
                    .ToList().Sum(p => p.Value);

                var outcomeMoney = dataFilter.Value?
                    .Where(p => p.User.Id == userId && p.Count == 0 && (p.PaymentsSetting.Type == 1 || p.PaymentsSetting.Type == 4 || p.PaymentsSetting.Type == 5))
                    .ToList().Sum(p => p.Value);

                var incomePackage = dataFilter.Value?
                    .Where(p => p.User.Id == userId 
                    && p.Count != 0 && (p.PaymentsSetting.Type == 0 || p.PaymentsSetting.Type == 2 || p.PaymentsSetting.Type == 6))
                    .ToList().Sum(p => p.Count);

                var outcomePackage = dataFilter.Value?
                    .Where(p => p.User.Id == userId 
                    && p.Count != 0 && (p.PaymentsSetting.Type == 1 || p.PaymentsSetting.Type == 4 || p.PaymentsSetting.Type == 5))
                    .ToList().Sum(p => p.Count);


                numBalanceMoney.Value = incomeMoney.Value - outcomeMoney.Value;
                numBalancePack.Value = incomePackage.Value - outcomePackage.Value;
            }
        }

    }
}
