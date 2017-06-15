using ComponentFactory.Krypton.Toolkit;
using SkyRegEnums;
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

namespace SkyReg
{
    public partial class ScheduleAddEditForm : KryptonForm
    {
        public FormState FormState { get; set; }
        public int IdScheduleElem { get; set; }
        public KryptonDataGridView grdFlight { get; set; }
        public KryptonDataGridView grdPlaner { get; set; }

        private int selectedUserId = default(int);

        public ScheduleAddEditForm()
        {
            InitializeComponent();
        }

        private void ScheduleAddEditForm_Load(object sender, EventArgs e)
        {
            LoadFlightsOnGrid();
            LoadFlightsOnGridGroup();
            LoadUsers();
            LoadParachutes();

            if (FormState == FormState.Edit)
            {
                //TODO do zrobienia ps
            }
        }

        private void SaveToBaseAdd()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                int selUserType = (int)cmbUsersType.SelectedValue;
                int selParachute = (int)cmbParachute.SelectedValue;
                bool assemblySelf = false;

                User usr = model.User.Where(p => p.Id == selectedUserId).FirstOrDefault();
                UsersType usrType = model.UsersType.Where(p => p.Id == selUserType).FirstOrDefault();
                Parachute parachute = model.Parachute.Where(p => p.Id == selParachute).FirstOrDefault();
                if (cmbAssemblyType.SelectedText == "Układam sam")
                    assemblySelf = true;
                decimal usersMoney = numBalanceMoney.Value + numCashIncome.Value;
                decimal usersPackages = numBalancePackage.Value;
                decimal? oneJumpPrice = model.UsersType.Where(p => p.Id == (int)cmbUsersType.SelectedValue).Select(p => p.Value).FirstOrDefault();
                decimal? parachuteRentPrice = model.Parachute.Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.RentValue).FirstOrDefault();
                decimal? parachuteAssemblyPrice = model.Parachute.AsNoTracking().Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.AssemblyValue).FirstOrDefault();
                int currentFlightId = (int)grdFlight.SelectedRows[0].Cells["Id"].Value;

                //TODO dodać bieżący skok

                Payment payJump = null;
                Payment packJump = null;
                Payment payParachuteRent = null;
                Payment payAssembly = null;
                string nrLotu = default(string);
                int flightId = default(int);


                //Bieżący skok
                flightId = (int)grdFlight.SelectedRows[0].Cells["Id"].Value;
                FlightsElem fe = SaveFlghtElemToDB(flightId, usr.Id);
                
                nrLotu = grdFlight.SelectedRows[0].Cells["Number"].Value.ToString();
                if (parachuteRentPrice.Value > 0)
                    payParachuteRent = SaveOneJump(usr.Id, parachuteRentPrice.Value, false, string.Format("Spadochron {0}", nrLotu), fe.Id);
                if (parachuteAssemblyPrice.Value > 0 && assemblySelf == false)
                    payAssembly = SaveOneJump(usr.Id, parachuteAssemblyPrice, false, string.Format("Układanie {0}", nrLotu), fe.Id);
                if (usersPackages > 0)
                {
                    packJump = SaveOneJump(usr.Id, 0, true, string.Format("Skok {0}", nrLotu), fe.Id);
                    usersPackages -= 1;
                }
                else
                {
                    payJump = SaveOneJump(usr.Id, oneJumpPrice, false, string.Format("Skok {0}", nrLotu), fe.Id);
                }


                //skoki z listy formatki dodawania FlightsElem inne niż bieżący
                foreach (DataGridViewRow item in grdFlightsListSelectedForUser.Rows)
                {
                    if (item.Cells["Check"].Value != null && (int)item.Cells["Id"].Value != currentFlightId)
                    {
                        nrLotu = item.Cells["Nr"].Value.ToString();
                        flightId = (int)item.Cells["Id"].Value;
                        fe = SaveFlghtElemToDB(flightId, usr.Id);

                        if (parachuteRentPrice.Value > 0)
                            payParachuteRent = SaveOneJump(usr.Id, parachuteRentPrice.Value, false, string.Format("Spadochron {0}", nrLotu), fe.Id);
                        if (parachuteAssemblyPrice.Value > 0 && assemblySelf == false)
                            payAssembly = SaveOneJump(usr.Id, parachuteAssemblyPrice, false, string.Format("Układanie {0}", nrLotu), fe.Id);
                        if (usersPackages > 0)
                        {
                            packJump = SaveOneJump(usr.Id, 0, true, string.Format("Skok {0}", nrLotu), fe.Id);
                            usersPackages -= 1;
                        }
                        else
                        {
                            payJump = SaveOneJump(usr.Id, oneJumpPrice, false, string.Format("Skok {0}", nrLotu), fe.Id);
                        }
                    }         
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private FlightsElem SaveFlghtElemToDB(int flightId, int usrId)
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                Flight fly = model.Flight.Where(p => p.Id == flightId).FirstOrDefault();

                FlightsElem fe = new FlightsElem();
                fe.Flight = fly;
                if (cmbAssemblyType.Text == "Układam sam")
                    fe.AssemblySelf = true;
                else
                    fe.AssemblySelf = false;
                fe.Lp = model.FlightsElem.Where(p=>p.Flight.Id == flightId).ToList().Count + 1;
                fe.Parachute = model.Parachute.Where(p => p.Id == (int)cmbParachute.SelectedValue).ToList();
                fe.User = model.User.Where(p => p.Id == usrId).FirstOrDefault();
                fe.Color = btnColor.SelectedColor.Name;
                model.FlightsElem.Attach(fe);
                model.FlightsElem.Add(fe);
                model.SaveChanges();
                return fe;
            }
            
        }



        private Payment SaveOneJump(int usrId, decimal? oneJumpPrice, bool count, string description, int flyElem)
        {

            //PaymentsSetting ps = model.PaymentsSetting.Where(p => p.Type == (short)SkyRegEnums.PaymentsTypes.Naleznosc).FirstOrDefault();
            Payment pay = null;
            using (var _paySettings = new DLModelRepository<PaymentsSetting>())
            using (var _user = new DLModelRepository<User>())
            using (var _pay = new DLModelRepository<Payment>())
            using( var _FlyElem = new DLModelRepository<FlightsElem>())
            {
                pay = new Payment();
                PaymentsSetting ps = _paySettings.Table.Where(p => p.Type == (short)SkyRegEnums.PaymentsTypes.Naleznosc).FirstOrDefault();
                var flightElem = _FlyElem.Table.Where(p => p.Id == flyElem).FirstOrDefault();
                var user = _user.Table.Where(p => p.Id == usrId).FirstOrDefault();

                pay.FlightsElem = flightElem;
                pay.Date = DateTime.Now;
                pay.Description = description;
                pay.IsBooked = true;
                pay.PaymentsSetting = ps;
                pay.User = user;
                pay.Value = oneJumpPrice.Value;
                if (count == false)
                    pay.Count = 0;
                else
                    pay.Count = 1;

                _pay.InsertEntity(pay);

                return pay;
            }
        }

        private bool ValidateAdd()
        {
            bool result = true;
            int idUser = default(int);

            errorProvider1.Clear();

            if (cmbUsersType.SelectedValue == null)
            {
                errorProvider1.SetError(cmbUsersType, "Wartość nie może być pusta!");
                result = false;
            }

            if (result == true)
            {
                //Obsługa szybkiego dodawania użytkownika
                if (cmbName.SelectedValue == null)
                {
                    if (KryptonMessageBox.Show(string.Format("Czy dodać nowego użytkownika {0} ?", cmbName.Text), "Dodać?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        idUser = AddNewUserToBase();
                        selectedUserId = idUser;
                    }
                    else
                    {
                        errorProvider1.SetError(cmbName, "Dodaj nowego użytkownika lub wybierz z listy");
                        result = false;
                    }
                }
                else
                {
                    idUser = (int)cmbName.SelectedValue;
                    selectedUserId = idUser;
                }
            }
            if(result == true)
            {
                if (checkBalances() == false)
                    result = false;
            }


            if (result == true)//czy wszystko OK z użytkownikiem
            {
                //obsługa szybkiej wpłaty
                if (numCashIncome.Value > 0)
                {
                    AddPaymentForUser(idUser, numCashIncome.Value);
                }
            }

            //Sprawdzam wolne miejsca
            string message = default(string);

            if(result == true)
            {
                if (FormState == FormState.Add)
                {
                    //zaznaczony wylot
                    if ((int)grdFlight.SelectedRows[0].Cells["Places"].Value < 1)
                    {
                        message += string.Format("W wylocie {0} brak miejsc!\n", grdFlight.SelectedRows[0].Cells["Number"].Value.ToString());
                        result = false;
                    }

                    //Wyloty z list na formatce dodawania
                    foreach (DataGridViewRow item in grdFlightsListSelectedForUser.Rows)
                    {
                        if (item.Cells["Check"].Value != null)
                        {
                            if ((int)item.Cells["AllSeats"].Value - (int)item.Cells["BusySeats"].Value < 1)
                            {
                                message += string.Format("W wylocie {0} brak miejsc!\n", item.Cells["Nr"].Value.ToString());
                                result = false;
                            }
                        }
                    }
                    if (message != default(string))
                        KryptonMessageBox.Show(message, "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            return result;
        }

        private bool checkBalances()
        {
            bool result = true;

            using (DLModelContainer model = new DLModelContainer())
            {
                decimal usersMoney = numBalanceMoney.Value + numCashIncome.Value;
                decimal usersPackages = numBalancePackage.Value;
                decimal? oneJumpPrice = model.UsersType.Where(p => p.Id == (int)cmbUsersType.SelectedValue).Select(p => p.Value).FirstOrDefault();
                decimal? parachuteRentPrice = model.Parachute.Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.RentValue).FirstOrDefault();
                decimal? parachuteAssemblyPrice = model.Parachute.AsNoTracking().Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.AssemblyValue).FirstOrDefault();
                if (cmbAssemblyType.Text == "Układam sam")//układa sam
                    parachuteAssemblyPrice = 0;

                int currentFlightId = (int)grdFlight.SelectedRows[0].Cells["Id"].Value;

                decimal needJumps = 1;
                foreach(DataGridViewRow item in grdFlightsListSelectedForUser.Rows)
                {
                    if (item.Cells["Check"].Value != null && (int)item.Cells["Id"].Value != currentFlightId)
                        needJumps += 1;
                }

                //wypożyczenie liczę za wszystkie skoki przed pomniejszeniem za pakiety
                decimal needMoneyForRentPar = needJumps * parachuteRentPrice.Value;
                decimal needMoneyForAssembly = needJumps * parachuteAssemblyPrice.Value;


                if (usersPackages > needJumps)
                    needJumps = 0;
                else//pomniejszam o saldo z zakupionych pakietów
                    needJumps = needJumps - usersPackages;

                decimal needMoneyForJumps = needJumps * oneJumpPrice.Value;

                decimal needMoneyForAll = needMoneyForJumps + needMoneyForRentPar + needMoneyForAssembly;

                if(numBalanceMoney.Value < needMoneyForAll)
                {
                    if(KryptonMessageBox.Show(string.Format("Potrzeba {0}, a saldo wynosi {1}. Czy zezwolić na kredyt?", needMoneyForAll, usersMoney), "Kredyt?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        result = false;
                    }
                }

            }

            return result;
        }

        private void AddPaymentForUser(int idUser, decimal value)
        {
            using (var _pay = new DLModelRepository<Payment>())
            using (var _ps = new DLModelRepository<PaymentsSetting>())
            using (var _usr = new DLModelRepository<User>())
            {
                Payment pay = new Payment();

                PaymentsSetting ps = _ps.Table.Where(p => p.Id == 1).FirstOrDefault();
                User usr = _usr.Table.Where(p => p.Id == idUser).FirstOrDefault();

                pay.Date = DateTime.Now;
                pay.Description = "Szybka wpłata";
                pay.IsBooked = false;
                pay.PaymentsSetting = ps;
                pay.User = usr;
                pay.Value = value;
                pay.Count = 0;

                _pay.InsertEntity(pay);
            }
        }

        private int AddNewUserToBase()
        {
            int result = default(int);

            using(DLModelContainer model = new DLModelContainer())
            {
                string[] userName = cmbName.Text.Split(' ');
                string firstName = default(string);
                string surName = default(string);
                if(userName.Count() == 2)
                {
                    surName = userName[0];
                    firstName = userName[1];
                }
                else
                {
                    surName = cmbName.Text;
                    firstName = cmbName.Text;
                }
                User usr = new User();
                usr.SurName = surName;
                usr.FirstName = firstName;
                model.User.Add(usr);
                model.SaveChanges();
                result = usr.Id;
            }
            return result;
        }

        private void LoadParachutes()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                if (grdFlight.SelectedRows.Count > 0)
                {
                    int curFlightsIndex = grdFlight.SelectedRows[0].Cells["Id"].RowIndex;
                    int curFlightId = (int)grdFlight.SelectedRows[0].Cells["Id"].Value;
                    List<Parachute> parachuteNotAvaliable = new List<Parachute>();
                    parachuteNotAvaliable.AddRange(model.FlightsElem.Where(p => p.Flight.Id == curFlightId).SelectMany(p => p.Parachute).ToList());
                    if (curFlightsIndex > 0)
                    {
                        int prevFlightId = (int)grdFlight.Rows[curFlightsIndex - 1].Cells["Id"].Value;
                        parachuteNotAvaliable.AddRange(model.FlightsElem.Where(p => p.Flight.Id == prevFlightId).SelectMany(p => p.Parachute).ToList());
                    }
                    if (curFlightsIndex < grdFlight.Rows.Count - 1)
                    {
                        int nextFlightId = (int)grdFlight.Rows[curFlightsIndex + 1].Cells["Id"].Value;
                        parachuteNotAvaliable.AddRange(model.FlightsElem.Where(p => p.Flight.Id == nextFlightId).SelectMany(p => p.Parachute).ToList());
                    }

                    var allParachutes = model.Parachute.OrderBy(p => p.IdNr).ToList();
                    List<Parachute> avaliableParachutes = new List<Parachute>();
                    foreach (var item in allParachutes)
                    {
                        if (!parachuteNotAvaliable.Any(p => p.Id == item.Id))
                            avaliableParachutes.Add(item);
                    }

                    cmbParachute.DataSource = avaliableParachutes;
                    cmbParachute.DisplayMember = "IdNr";
                    cmbParachute.ValueMember = "Id";
                }
            }

        }

        private void LoadUserTypes()
        {
            using (DLModelContainer model = new DLModelContainer())
            {

                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Id";

                int? selectedUser = null;
                if (cmbName.SelectedValue != null)
                    selectedUser = (int)cmbName.SelectedValue;
                List<UsersType> usersTypesList = null;
                if (selectedUser != null)
                {
                    var user = model.User.Where(p => p.Id == selectedUser).FirstOrDefault();
                    if (user != null)
                    {
                        usersTypesList = model.User.Where(p => p.Id == selectedUser).SelectMany(p => p.UsersType).ToList();
                    }
                }
                else
                {
                    usersTypesList = model
                        .UsersType
                        .OrderBy(p => p.Name)
                        .ToList();
                }
                cmbUsersType.DataSource = usersTypesList;
                cmbUsersType.DisplayMember = "Name";
                cmbUsersType.ValueMember = "Id";
            }
        }

        private void LoadUsers()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                var users = model.User
                    .OrderBy(p => p.SurName)
                    .ThenBy(p => p.FirstName)
                    .Select(p => new
                    {
                        Name = p.SurName + " " + p.FirstName,
                        Id = p.Id
                    }).ToList();
                cmbName.DataSource = users;
                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Id";
            }
        }

        private void LoadFlightsOnGrid()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                DateTime dateNow = DateTime.Now.Date;

                var flightsList = model
                    .Flight
                    .Where(p => p.FlyDateTime == dateNow && (p.FlyStatus == (int)FlightsStatus.Opened || p.FlyStatus == (int)FlightsStatus.Closed))
                    .OrderBy(p => p.FlyNr)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Nr = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr,
                        AllSeats = p.Airplane.Seats,
                        BusySeats = p.FlightsElem.Count
                    })
                    .ToList();
                if (flightsList != null)
                {
                    grdFlightsListSelectedForUser.DataSource = flightsList;
                    SetFlightsUserView();
                }

            }
        }

        private void LoadAssemblyType()
        {
            cmbAssemblyType.Items.Clear();
            using (DLModelContainer model = new DLModelContainer())
            {
                cmbParachute.DisplayMember = "IdNr";
                cmbParachute.ValueMember = "Id";

                if (cmbParachute.SelectedValue != null)
                {
                    var parachute = model.Parachute.Include("User").Where(p => p.Id == (int)cmbParachute.SelectedValue).FirstOrDefault();
                    if (parachute.User != null)
                    {
                        cmbAssemblyType.Items.Add("Układam sam");
                        cmbAssemblyType.Items.Add("Układalnia");
                    }
                    else
                    {
                        cmbAssemblyType.Items.Add("Układalnia");
                    }
                }
            }
            cmbAssemblyType.SelectedIndex = 0;
        }

        private void SetFlightsUserView()
        {
            grdFlightsListSelectedForUser.ReadOnly = false;
            grdFlightsListSelectedForUser.Columns["Id"].Visible = false;
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.ReadOnly = false;
            col.Name = "Check";
            col.HeaderText = "Wybór";
            col.Width = 50;
            grdFlightsListSelectedForUser.Columns.Add(col);
            grdFlightsListSelectedForUser.Columns["Nr"].HeaderText = "Numer";
            grdFlightsListSelectedForUser.Columns["Nr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grdFlightsListSelectedForUser.ReadOnly = false;
            grdFlightsListSelectedForUser.AllowUserToResizeRows = false;
            grdFlightsListSelectedForUser.RowHeadersVisible = false;

            grdFlightsListSelectedForUser.Columns["Check"].DisplayIndex = 0;
            grdFlightsListSelectedForUser.Columns["Nr"].DisplayIndex = 1;

            grdFlightsListSelectedForUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdFlightsListSelectedForUser.MultiSelect = false;

            grdFlightsListSelectedForUser.Columns["AllSeats"].Visible = false;
            grdFlightsListSelectedForUser.Columns["BusySeats"].Visible = false;

        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbName.SelectedValue != null)
                selectedUserId = (int)cmbName.SelectedValue;


            LoadUserTypes();
            LoadBalance();
        }

        private void LoadBalance()
        {
            using (var model = new DLModelContainer())
            {
                if (cmbName.SelectedValue != null)
                {
                    int userId = (int)cmbName.SelectedValue;
                    var incomeM = model
                        .Payment
                        .Include("User")
                        .Include("PaymentsSetting")
                        .AsNoTracking()
                        .Where(p => p.User.Id == userId && p.Count == 0 && (p.PaymentsSetting.Type == 0 || p.PaymentsSetting.Type == 2 || p.PaymentsSetting.Type == 6) )
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
                    numBalancePackage.Value = incomePackage.Value - outcomePackage.Value;

                }
                else
                {
                    numBalanceMoney.Value = 0;
                    numBalancePackage.Value = 0;
                }
            }
        }

        private void cmbParachute_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssemblyType();
        }

        private void cmbName_TextChanged(object sender, EventArgs e)
        {
            LoadUserTypes();
        }

        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            if (kryptonTabControl1.SelectedTab == tabPage1)
            {
                if (ValidateAdd() == true)
                {
                    if (FormState == FormState.Add)
                        SaveToBaseAdd();
                }
            }
            else
            {
                TryAddGroup();
            }
        }

    }
}
