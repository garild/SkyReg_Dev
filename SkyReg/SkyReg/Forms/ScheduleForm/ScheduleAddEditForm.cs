using ComponentFactory.Krypton.Toolkit;
using SkyRegEnums;
using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Result.Repository;
using DataLayer.Entities.DBContext;
using SkyReg.Common.Extensions;

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
            LoadParachutes();
            LoadUsers();            
        }

        private void SaveToBaseAdd()
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                int selUserType = (int)cmbUsersType.SelectedValue;
                int? selParachute = null;

                if (cmbParachute.SelectedValue != null && (int)cmbParachute.SelectedValue != 0)
                    selParachute = (int)cmbParachute.SelectedValue;
                bool assemblySelf = false;

                User usr = model.User.Where(p => p.Id == selectedUserId).FirstOrDefault();
                DefinedUserType usrType = model.DefinedUserType.Where(p => p.Id == selUserType).FirstOrDefault();
                Parachute parachute = model.Parachute.Where(p => p.Id == selParachute).FirstOrDefault();

                if (cmbAssemblyType.SelectedText == "Układam sam")
                    assemblySelf = true;

                decimal usersMoney = numBalanceMoney.Value + numCashIncome.Value;
                decimal usersPackages = numBalancePackage.Value;
                decimal? oneJumpPrice = model.DefinedUserType.Where(p => p.Id == (int)cmbUsersType.SelectedValue).Select(p => p.Value).FirstOrDefault();
                decimal? parachuteRentPrice = null;
                decimal? parachuteAssemblyPrice = null;
                if (selParachute != null)
                {
                    parachuteRentPrice = model.Parachute.Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.RentValue).FirstOrDefault();
                    parachuteAssemblyPrice = model.Parachute.AsNoTracking().Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.AssemblyValue).FirstOrDefault();
                }
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


                if (parachuteRentPrice == null)
                    parachuteRentPrice = 0;
                if (parachuteAssemblyPrice == null)
                    parachuteAssemblyPrice = 0;

                nrLotu = grdFlight.SelectedRows[0].Cells["Number"].Value.ToString();
                if (parachuteRentPrice.Value > 0)
                    payParachuteRent = SaveOneJump(usr.Id, parachuteRentPrice.Value, false, string.Format("Spadochron {0}", nrLotu), fe.Id,ChargesTypes.ParachuteRent);
                if (parachuteAssemblyPrice.Value > 0 && assemblySelf == false)
                    payAssembly = SaveOneJump(usr.Id, parachuteAssemblyPrice, false, string.Format("Układanie {0}", nrLotu), fe.Id, ChargesTypes.ParachuteAssembly);
                if (usersPackages > 0)
                {
                    packJump = SaveOneJump(usr.Id, 0, true, string.Format("Skok {0}", nrLotu), fe.Id, ChargesTypes.Jump);
                    usersPackages -= 1;
                }
                else
                {
                    payJump = SaveOneJump(usr.Id, oneJumpPrice, false, string.Format("Skok {0}", nrLotu), fe.Id, ChargesTypes.Jump);
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
                            payParachuteRent = SaveOneJump(usr.Id, parachuteRentPrice.Value, false, string.Format("Spadochron {0}", nrLotu), fe.Id, ChargesTypes.ParachuteRent);
                        if (parachuteAssemblyPrice.Value > 0 && assemblySelf == false)
                            payAssembly = SaveOneJump(usr.Id, parachuteAssemblyPrice, false, string.Format("Układanie {0}", nrLotu), fe.Id, ChargesTypes.ParachuteAssembly);
                        if (usersPackages > 0)
                        {
                            packJump = SaveOneJump(usr.Id, 0, true, string.Format("Skok {0}", nrLotu), fe.Id, ChargesTypes.Jump);
                            usersPackages -= 1;
                        }
                        else
                        {
                            payJump = SaveOneJump(usr.Id, oneJumpPrice, false, string.Format("Skok {0}", nrLotu), fe.Id, ChargesTypes.Jump);
                        }
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private FlightsElem SaveFlghtElemToDB(int flightId, int usrId)
        {
            using (var _ctx = new SkyRegContextRepository<FlightsElem>())
            {
                FlightsElem fe = new FlightsElem();

                fe.Flight_Id = flightId;

                if (cmbAssemblyType.Text == "Układam sam")
                    fe.AssemblySelf = true;
                else
                    fe.AssemblySelf = false;

                //TODO do POPRAWY
                fe.Lp = _ctx.Model.FlightsElem.Max(p => p.Lp).Value + 1;
                fe.Parachute.Add(_ctx.Model.Parachute.FirstOrDefault(p => p.Id == (int)cmbParachute.SelectedValue));
                fe.User_Id = usrId;
                fe.Color = btnColor.SelectedColor.ToArgb().ToString();
                fe.UsersTypeId = (int)cmbUsersType.SelectedValue;

                _ctx.InsertEntity(fe);
                return fe;
            }

        }



        private Payment SaveOneJump(int usrId, decimal? oneJumpPrice, bool count, string description, int flyElem,ChargesTypes chargeType)
        {

            //PaymentsSetting ps = model.PaymentsSetting.Where(p => p.Type == (short)SkyRegEnums.PaymentsTypes.Naleznosc).FirstOrDefault();
            Payment pay = null;
            using (var _paySettings = new SkyRegContextRepository<PaymentsSetting>())
            using (var _user = new SkyRegContextRepository<User>())
            using (var _pay = new SkyRegContextRepository<Payment>())
            using (var _FlyElem = new SkyRegContextRepository<FlightsElem>())
            {
                pay = new Payment();
                PaymentsSetting ps = _paySettings.Table.Where(p => p.Type == (short)SkyRegEnums.PaymentsTypes.Naleznosc).FirstOrDefault();
                var flightElem = _FlyElem.Table.Where(p => p.Id == flyElem).FirstOrDefault();
                var user = _user.Table.Where(p => p.Id == usrId).FirstOrDefault();

                pay.FlightsElem_Id = flightElem.Id;
                pay.Date = DateTime.Now;
                pay.Description = description;
                pay.IsBooked = true;
                pay.PaymentsSetting_Id = ps.Id;
                pay.User_Id = user.Id;
                pay.ChargeType = (int)chargeType;
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
            string errorMessage = default(string);

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
            if (result == true)
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

            if (result == true)
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
                    errorMessage += message + "\n";
                }
            }

            //Sprawdzanie czy użytkownik nie występuje na wybranych wylotach
            if (result == true)
            {
                List<int> idUsersOfSelectedFlights = new List<int>();

                using (SkyRegContext ctx = new SkyRegContext())
                {
                    //Bieżący lot
                    int? selFlightId = (int)grdFlight.SelectedRows[0].Cells["Id"].Value;

                    if (selFlightId != null)
                    {
                        idUsersOfSelectedFlights = ctx.FlightsElem
                            .Include("Flight")
                            .Include("User")
                            .Where(p => p.Flight.Id == selFlightId.Value)
                                .ToList().Where(p => p.User != null).Select(p => p.User.Id).ToList();
                         
                        //Wyloty z list na formatce dodawania
                        foreach (DataGridViewRow item in grdFlightsListSelectedForUser.Rows)
                        {
                            if (item.Cells["Check"].Value != null)
                            {
                                selFlightId = (int)item.Cells["Id"].Value;

                                idUsersOfSelectedFlights.AddRange(ctx.FlightsElem
                                        .Include("Flight")
                                        .Include("User")
                                        .Where(p => p.Flight.Id == selFlightId.Value)
                                        .Select(p => p.User.Id)
                                        .ToList());
                            }
                        }
                        if( idUsersOfSelectedFlights.Any(p=>p == idUser))
                        {
                            result = false;
                            errorMessage += "Wybrany użytkownik jest już dodany do wybranych wylotów!";
                        }
                    }
                }
            }

            if(result == false && errorMessage.HasValue())
            {
                KryptonMessageBox.Show(errorMessage, "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return result;
        }

        private bool checkBalances() // TODO Poprawić walidację Co jeśli nie wybiorę spadochron??!
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                decimal usersMoney = numBalanceMoney.Value + numCashIncome.Value;
                decimal usersPackages = numBalancePackage.Value;
                decimal? oneJumpPrice = model.DefinedUserType.Where(p => p.Id == (int)cmbUsersType.SelectedValue).Select(p => p.Value).FirstOrDefault();
                decimal? parachuteRentPrice = model.Parachute.Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.RentValue).FirstOrDefault();
                decimal? parachuteAssemblyPrice = model.Parachute.AsNoTracking().Where(p => p.Id == (int)cmbParachute.SelectedValue).Select(p => p.AssemblyValue).FirstOrDefault();

                if (cmbAssemblyType.Text == "Układam sam")//układa sam
                    parachuteAssemblyPrice = 0;

                int currentFlightId = (int)grdFlight.SelectedRows[0].Cells["Id"].Value;

                decimal needJumps = 1;
                foreach (DataGridViewRow item in grdFlightsListSelectedForUser.Rows)
                {
                    if (item.Cells["Check"].Value != null && (int)item.Cells["Id"].Value != currentFlightId)
                        needJumps += 1;
                }

                //muszą być zera gdy to brak spadochronu w przypadku pasażera tandemu
                if (parachuteRentPrice == null)
                    parachuteRentPrice = 0;
                if (parachuteAssemblyPrice == null)
                    parachuteAssemblyPrice = 0;

                //wypożyczenie liczę za wszystkie skoki przed pomniejszeniem za pakiety
                decimal needMoneyForRentPar = needJumps * parachuteRentPrice.Value;
                decimal needMoneyForAssembly = needJumps * parachuteAssemblyPrice.Value;


                if (usersPackages > needJumps)
                    needJumps = 0;
                else//pomniejszam o saldo z zakupionych pakietów
                    needJumps = needJumps - usersPackages;

                decimal needMoneyForJumps = needJumps * oneJumpPrice.Value;

                decimal needMoneyForAll = needMoneyForJumps + needMoneyForRentPar + needMoneyForAssembly;

                //if (numBalanceMoney.Value < needMoneyForAll)
                if (usersMoney < needMoneyForAll)
                {
                    if (KryptonMessageBox.Show($"Potrzeba {needMoneyForAll}, a saldo wynosi {usersMoney}. Czy zezwolić na kredyt?", "Kredyt?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        private void AddPaymentForUser(int idUser, decimal value)
        {
            using (var _pay = new SkyRegContextRepository<Payment>())
            using (var _ps = new SkyRegContextRepository<PaymentsSetting>())
            using (var _usr = new SkyRegContextRepository<User>())
            {
                Payment pay = new Payment();

                PaymentsSetting ps = _ps.Table.Where(p => p.Id == 1).FirstOrDefault();
                User usr = _usr.Table.Where(p => p.Id == idUser).FirstOrDefault();

                pay.Date = DateTime.Now;
                pay.Description = "Szybka wpłata";
                pay.IsBooked = false;
                pay.PaymentsSetting = ps;
                pay.User_Id = usr.Id;
                pay.Value = value;
                pay.Count = 0;

                _pay.InsertEntity(pay);
            }
        }

        private int AddNewUserToBase()
        {
            int userId = 0;

            using(var _groupsCtx = new SkyRegContextRepository<Group>())
            using (var _ctx = new SkyRegContextRepository<User>())
            {
                var jumperGroup = _groupsCtx.Model.Group.Where(p => p.Name == "Skoczkowie").FirstOrDefault();

                User usr = new User();
                usr.Name = cmbName.Text;
                if (jumperGroup != null)
                    usr.Group_Id = jumperGroup.Id;

                var result = _ctx.InsertEntity(usr);

                if (result.IsSuccess)
                    userId = result.Value.Id;
            }
            return userId;
        }

        private void LoadParachutes()
        {
            using (var _contexFlightEl = new SkyRegContextRepository<FlightsElem>())
            using (var _contextParachute = new SkyRegContextRepository<Parachute>())
            {
                if (grdFlight.SelectedRows.Count > 0)
                {
                    int curFlightsIndex = grdFlight.SelectedRows[0].Cells["Id"].RowIndex;
                    int curFlightId = (int)grdFlight.SelectedRows[0].Cells["Id"].Value;
                    List<Parachute> parachuteNotAvaliable = new List<Parachute>();
                    parachuteNotAvaliable.AddRange(_contexFlightEl.Table.Where(p => p.Flight.Id == curFlightId).SelectMany(p => p.Parachute).ToList());
                    if (curFlightsIndex > 0)
                    {
                        int prevFlightId = (int)grdFlight.Rows[curFlightsIndex - 1].Cells["Id"].Value;
                        parachuteNotAvaliable.AddRange(_contexFlightEl.Table.Where(p => p.Flight.Id == prevFlightId).SelectMany(p => p.Parachute).ToList());
                    }
                    if (curFlightsIndex < grdFlight.Rows.Count - 1)
                    {
                        int nextFlightId = (int)grdFlight.Rows[curFlightsIndex + 1].Cells["Id"].Value;
                        parachuteNotAvaliable.AddRange(_contexFlightEl.Table.Where(p => p.Flight.Id == nextFlightId).SelectMany(p => p.Parachute).ToList());
                    }

                    var allParachutes = _contextParachute.Table.OrderBy(p => p.IdNr).ToList();
                    List<Parachute> avaliableParachutes = new List<Parachute>();
                    Parachute par = new Parachute();
                    par.IdNr = "Brak";
                    avaliableParachutes.Add(par);
                    foreach (var item in allParachutes)
                    {
                        if (!parachuteNotAvaliable.Any(p => p.Id == item.Id))
                            avaliableParachutes.Add(item);
                    }

                    if (avaliableParachutes?.Count > 0)
                    {
                        cmbParachute.DataSource = avaliableParachutes;
                        cmbParachute.DisplayMember = "IdNr";
                        cmbParachute.ValueMember = "Id";
                        cmbParachute.SelectedValueChanged += CmbParachute_SelectedValueChanged;
                        LoadAssemblyType();
                    }

                }
            }

        }

        private void CmbParachute_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadAssemblyType();
        }

        private void LoadUserTypes()
        {
            using (var _ctx = new SkyRegContextRepository<User>())
            {
                var result = _ctx.GetAll(Tuple.Create(nameof(DefinedUserType), "", ""));
                if (result.IsSuccess)
                {
                    int selectedUser = 0;
                    if (cmbName.SelectedValue != null)
                        selectedUser = (int)cmbName.SelectedValue;

                    List<DefinedUserType> usersTypesList = null;
                    if (selectedUser > 0)
                    {
                        var user = result.Value.Where(p => p.Id == selectedUser).FirstOrDefault();
                        if (user.DefinedUserType?.Count > 0)
                            usersTypesList = new List<DefinedUserType>(user.DefinedUserType);
                        else
                            usersTypesList = _ctx.Model.DefinedUserType.OrderBy(p => p.Name).ToList();
                    }

                    if (usersTypesList?.Count > 0)
                    {
                        cmbUsersType.DataSource = usersTypesList;
                        cmbUsersType.DisplayMember = "Name";
                        cmbUsersType.ValueMember = "Id";
                    }
                }
            }
        }

        private void LoadUsers()
        {
            using (var _ctx = new SkyRegContextRepository<User>())
            {
                var users = _ctx.Table
                    .OrderBy(p => p.Name)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Id = p.Id
                    }).ToList();

                if (users.Count > 0)
                {
                    cmbName.DataSource = users;
                    cmbName.DisplayMember = "Name";
                    cmbName.ValueMember = "Id";
                    cmbName.SelectedIndexChanged += cmbName_SelectedIndexChanged;
                    LoadUserTypes();
                    LoadBalance();
                }

            }
        }

        private void LoadFlightsOnGrid()
        {
            using (var _ctx = new SkyRegContextRepository<Flight>())
            {
                DateTime dateNow = DateTime.Now.Date;

                var flightsList = _ctx.Table
                    .Where(p => p.FlyDateTime == dateNow
                    && (p.FlyStatus == (int)FlightsStatus.Opened
                    || p.FlyStatus == (int)FlightsStatus.Closed))
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

        private void LoadAssemblyType() // TODO Chujowy kod -> Układam sam ?? 
        {
            cmbAssemblyType.Items.Clear();
            using (var _ctx = new SkyRegContextRepository<Parachute>())
            {
                cmbParachute.DisplayMember = "IdNr";
                cmbParachute.ValueMember = "Id";

                if (cmbParachute.SelectedValue != null && (int)cmbParachute.SelectedValue != 0)
                {
                    var parachute = _ctx.GetAll(Tuple.Create(nameof(User), "", "")).Value?.Where(p => p.Id == (int)cmbParachute.SelectedValue).FirstOrDefault();
                    if (parachute.User != null)
                    {
                        cmbAssemblyType.Items.Add("Układam sam");
                        cmbAssemblyType.Items.Add("Układalnia");
                    }
                    else
                        cmbAssemblyType.Items.Add("Układalnia");
                }
            }

            cmbAssemblyType.SelectedItem = "Układalnia";
        }

        private void SetFlightsUserView()
        {

            grdFlightsListSelectedForUser.Columns["Nr"].Width = 250;
            grdFlightsListSelectedForUser.Columns["Id"].Visible = false;
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
            using (var _ctx = new SkyRegContextRepository<Payment>())
            {
                if (cmbName.SelectedValue != null)
                {
                    int userId = (int)cmbName.SelectedValue;

                    var dataUser = _ctx.GetAll(Tuple.Create(nameof(User), nameof(PaymentsSetting), "")).Value?.Where(p => p.User_Id == userId).ToList();

                    var incomeM = dataUser
                        .Where(p => p.Count == 0
                        && (p.PaymentsSetting.Type == 0
                        || p.PaymentsSetting.Type == 2
                        || p.PaymentsSetting.Type == 6))
                        .ToList();
                    var incomeMoney = incomeM.Sum(p => p.Value);

                    var outcomeM = dataUser
                        .Where(p => p.Count == 0
                        && (p.PaymentsSetting.Type == 1
                        || p.PaymentsSetting.Type == 4
                        || p.PaymentsSetting.Type == 5))
                        .ToList();
                    var outcomeMoney = outcomeM.Sum(p => p.Value);

                    var incomeP = dataUser
                        .Where(p => p.Count != 0
                        && (p.PaymentsSetting.Type == 0
                        || p.PaymentsSetting.Type == 2
                        || p.PaymentsSetting.Type == 6))
                        .ToList();
                    var incomePackage = incomeP.Sum(p => p.Count);

                    var outcomeP = dataUser
                        .Where(p => p.Count != 0
                        && (p.PaymentsSetting.Type == 1
                        || p.PaymentsSetting.Type == 4
                        || p.PaymentsSetting.Type == 5))
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
            DialogResult = DialogResult.OK;
        }

        private void grdFlightsListSelectedForUser_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && grdFlightsListSelectedForUser.SelectedRows.Count == 1)
            {
                bool state = false;
                if (grdFlightsListSelectedForUser.SelectedRows[0].Cells[0].Value != null)
                {
                    state = (bool)grdFlightsListSelectedForUser.SelectedRows[0].Cells[0].Value;

                    if (state)
                        grdFlightsListSelectedForUser.SelectedRows[0].Cells[0].Value = false;
                    else
                        grdFlightsListSelectedForUser.SelectedRows[0].Cells[0].Value = true;
                }
                else
                    grdFlightsListSelectedForUser.SelectedRows[0].Cells[0].Value = true;

            }
        }


        private void grdFlightsForGroup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && grdFlightsForGroup.SelectedRows.Count == 1)
            {
                bool state = false;
                if (grdFlightsForGroup.SelectedRows[0].Cells[0].Value != null)
                {
                    state = (bool)grdFlightsForGroup.SelectedRows[0].Cells[0].Value;

                    if (state)
                        grdFlightsForGroup.SelectedRows[0].Cells[0].Value = false;
                    else
                        grdFlightsForGroup.SelectedRows[0].Cells[0].Value = true;
                }
                else
                    grdFlightsForGroup.SelectedRows[0].Cells[0].Value = true;

            }
        }

        private void cmbName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbName.ValueMember = "Id";
            if (cmbParachute.SelectedItem != null && cmbName.SelectedItem != null)
            {
                using (SkyRegContext ctx = new SkyRegContext())
                {
                    int? userId = (int)cmbName.SelectedValue;

                    if (userId != null)
                    {
                        var parach = ctx.Parachute.Include("User").Where(p => p.User.Id == userId.Value).FirstOrDefault();
                        if (parach != null)
                        {

                            foreach (Parachute item in cmbParachute.Items)
                            {
                                if (item.Id == parach.Id)
                                    cmbParachute.SelectedIndex = cmbParachute.Items.IndexOf(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
