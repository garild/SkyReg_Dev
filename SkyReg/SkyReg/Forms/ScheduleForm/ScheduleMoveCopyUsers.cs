using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using SkyRegEnums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using System.Windows.Forms;

namespace SkyReg.Forms.ScheduleForm
{
    public partial class ScheduleMoveCopyUsers : KryptonForm
    {
        public TransportData Type { get; set; } = TransportData.Copy;
        public List<int> UserIds { get; set; } = new List<int>();
        public int FlightId { get; set; }
        public ScheduleMoveCopyUsers()
        {
            InitializeComponent();


        }

        private void LoadCurrentFlights()
        {
            grdFlights.DataSource = null;

            using (var _ctx = new SkyRegContextRepository<Flight>())
            {
                var result = _ctx.GetAll(Tuple.Create(nameof(FlightsElem), nameof(Airplane), ""));
                if (result.IsSuccess)
                {

                    grdFlights.DataSource = result.Value
                       .Where(p => p.FlyDateTime >= datSinceFlights.Value.Date && p.FlyDateTime <= datToFlights.Value.Date)
                       .OrderBy(p => p.FlyNr)
                       .Select(p => new
                       {
                           Id = p.Id,
                           Number = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr,
                           Places = p.Airplane.Seats - p.FlightsElem.Count,
                           Status = p.FlyStatus
                       }).ToList();

                    DataGridColumnsMap();
                }

            }
        }

        private void DataGridColumnsMap()
        {
            grdFlights.Columns["Checked"].Visible = Type == TransportData.Move ? false : true;
            grdFlights.Columns["Id"].Visible = false;
            grdFlights.Columns["Status"].Visible = false;
            grdFlights.RowHeadersVisible = false;

            grdFlights.Columns["Places"].Width = 50;
            grdFlights.Columns["Number"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            grdFlights.Columns["Number"].HeaderText = "Numer lotu";
            grdFlights.Columns["Places"].HeaderText = "Wolne";

        }

        private void btnRefreshFlights_Click(object sender, EventArgs e)
        {
            LoadCurrentFlights();
        }

        private void grdFlights_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && grdFlights.SelectedRows.Count == 1)
            {
                bool state = false;
                if (grdFlights.SelectedRows[0].Cells[0].Value != null)
                {
                    state = (bool)grdFlights.SelectedRows[0].Cells[0].Value;

                    if (state)
                        grdFlights.SelectedRows[0].Cells[0].Value = false;
                    else
                        grdFlights.SelectedRows[0].Cells[0].Value = true;
                }
                else
                    grdFlights.SelectedRows[0].Cells[0].Value = true;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) //TODO KOPIOWANIE 
        {
            if (Type == TransportData.Move)
            {
                int? fligthId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
                int? seats = (int)grdFlights.SelectedRows[0].Cells["Places"].Value;
                if (fligthId > 0)
                {
                    if (UserIds.Count <= seats)
                        using (var _ctx = new SkyRegContextRepository<FlightsElem>())
                        {
                            var fe = _ctx.GetAll().Value;
                            var result = (from p in fe
                                          join u in UserIds on p.User_Id equals u
                                          where p.Flight_Id == FlightId
                                          select p).ToList();

                            result?.ForEach(x => x.Flight_Id = fligthId);

                            _ctx.UpdateMany(result);

                            this.Close();
                        }
                    else
                        Msg.Show("Wybrany LOT nie ma wystarczająco wolnych miejsc", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            else
            {
                int userId = UserIds[0];
                foreach (DataGridViewRow item in grdFlights.Rows)
                {
                    if (item.Cells["Checked"].Value != null && (int)item.Cells["Id"].Value != FlightId)
                    {
                        //Zaznaczony LOT
                        int? fligthId = (int)item.Cells["Id"].Value;
                        //Iliość miejsca
                        int? seats = (int)item.Cells["Places"].Value;
                        //Nr lotu
                        string flightNumber = $"{item.Cells["Number"].Value}";
                        //Nr FlightElem dla bieżącego LOTU
                        int Elem_Id = 0;

                        FlightsElem Elem = new FlightsElem();
                        Payment Pay = new Payment();
                        Flight Flight = new Flight();

                        if (fligthId > 0)
                        {
                            if (UserIds.Count <= seats)
                            {
                                // Szukam FlightElem dla danego usera i nr lotu
                                using (var _ctx = new SkyRegContextRepository<FlightsElem>())
                                {

                                    var IsExists = _ctx.Table.Where(p => p.Flight_Id == fligthId && p.User_Id == userId).FirstOrDefault();

                                    if (IsExists != null)
                                    {
                                        KryptonMessageBox.Show($"Wybrany użytkownik jets już zarezerwowany w wylocie o nr {flightNumber.ToUpper()}", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        continue;
                                    }

                                    var fe = _ctx.GetAll().Value;
                                    Elem = (from p in fe
                                            join u in UserIds on p.User_Id equals u
                                            where p.Flight_Id == FlightId
                                            select p).FirstOrDefault();

                                    Elem_Id = Elem.Id;
                                    Elem.Flight_Id = fligthId;

                                    _ctx.InsertEntity(Elem);
                                }

                                //Sprawdzam jakie Payment ma ten FlightElem
                                using (var _ctxPay = new SkyRegContextRepository<Payment>())
                                {
                                    var payList = _ctxPay.Table.Where(p => p.FlightsElem_Id == Elem_Id).ToList();
                                    var pakage = _ctxPay.Table.Where(p => p.User_Id == userId && p.Count.Value > default(decimal)).FirstOrDefault();
                                  

                                    foreach (Payment p in payList)
                                    {
                                        var counFlyFromPakage = _ctxPay.GetAll().Value.Where(x => x.Count.Value > 0 && x.User_Id == userId && x.Value == default(decimal)).ToList().Sum(x => x.Count.Value);
                                      
                                        //jeśli posiada jakiś wolny pakiet
                                        if ((pakage?.Count.Value - counFlyFromPakage) > 0)
                                        {
                                            Pay = new Payment();
                                            Pay.IsBooked = true;
                                            Pay.Date = DateTime.Now;
                                            Pay.PaymentsSetting_Id = payList[0].PaymentsSetting_Id; // Czy ma być stały paymentSettingId ??
                                            Pay.User_Id = pakage.User_Id;
                                            Pay.Value = 0;
                                            Pay.FlightsElem_Id = Elem.Id;
                                            Pay.Description = "Skok " + flightNumber;
                                            Pay.ChargeType = (int)ChargesTypes.Jump;
                                            Pay.Count = 1;
                                            _ctxPay.InsertEntity(Pay);

                                            continue;
                                        }
                                        if (p.ChargeType.HasValue)
                                            {
                                                Pay = new Payment();
                                                Pay.IsBooked = p.IsBooked;
                                                Pay.Date = DateTime.Now;
                                                Pay.PaymentsSetting_Id = p.PaymentsSetting_Id;
                                                Pay.User_Id = p.User_Id;
                                                Pay.Value = p.Value;
                                                Pay.FlightsElem_Id = Elem.Id;
                                                Pay.Count = 0;
                                                switch (p.ChargeType.Value)
                                                {
                                                    case (int)ChargesTypes.Jump:

                                                        Pay.Description = "Skok " + flightNumber;
                                                        Pay.ChargeType = (int)ChargesTypes.Jump;
                                                        _ctxPay.InsertEntity(Pay);
                                                        break;
                                                    case (int)ChargesTypes.ParachuteAssembly:

                                                        Pay.Description = "Układanie " + flightNumber;
                                                        Pay.ChargeType = (int)ChargesTypes.ParachuteAssembly;
                                                        _ctxPay.InsertEntity(Pay);
                                                        break;
                                                    case (int)ChargesTypes.ParachuteRent:
                                                        {
                                                            var sqlQuery = $"INSERT INTO [dbo].[FlightsElemParachutes] SELECT {Elem.Id},[Parachute_Id]  FROM [SkyRegDB].[dbo].[FlightsElemParachutes] WHERE FlightsElem_Id = {Elem_Id}";

                                                            Pay.Description = "Spadochron " + flightNumber;
                                                            Pay.ChargeType = (int)ChargesTypes.ParachuteRent;
                                                            _ctxPay.InsertEntity(Pay);

                                                            _ctxPay.Model.Database.ExecuteSqlCommand(sqlQuery);
                                                        }
                                                        break;
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ScheduleMoveCopyUsers_Load(object sender, EventArgs e)
        {
            LoadCurrentFlights();
        }
    }
}
