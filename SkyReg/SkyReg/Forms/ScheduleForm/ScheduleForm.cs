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
using SkyRegEnums;
using SkyReg.Common.Extensions;
using DataLayer.Result.Repository;
using DataLayer.Entities.DBContext;
using DataLayer.Models;
using SkyReg.Forms.ScheduleForm;
using SkyReg.Common.Prints.LoadingList;
using SkyRegHtml;
using SkyReg.Utils;
using SkyReg.Forms.HtmlDocker;

namespace SkyReg
{
    public partial class ScheduleForm : KryptonForm
    {
        private ScheduleAddEditForm ScheduleAddEditForm = null;


        public ScheduleForm()
        {
            InitializeComponent();
        }


        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            RefreshFlightsList();
            RefreshDataList();

        }

        private void RefreshPlanerList()
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                if (grdFlights.SelectedRows.Count > 0)
                {
                    var flyId = grdFlights.SelectedRows[0].Cells["Id"].Value;
                    grdPlaner.DataSource = model
                        .FlightsElem.Where(p => p.Flight.Id == (int)flyId)
                        .OrderBy(p => p.Lp)
                        .Select(p => new
                        {
                            Id = p.Id,
                            UserId = p.User_Id,
                            Lp = p.Lp,
                            UserName = p.User == null ? p.TeamName : p.User.Name,
                            //Type = p.User.DefinedUserType.Name,
                            Parachute = p.Parachute.FirstOrDefault().IdNr + " " + p.Parachute.FirstOrDefault().Name,
                            AssemblyType = p.AssemblySelf == true ? "Układa sam" : "Układalnia",
                            Color = p.Color
                        })
                        .ToList();

                    SetPlanerListView();

                }
            }
        }

        private void SetPlanerListView()
        {
            //grdPlaner.Columns["Name"].Visible = false;
            grdPlaner.Columns["Id"].Visible = false;
            grdPlaner.Columns["Color"].Visible = false;
            grdPlaner.Columns["UserId"].Visible = false;

            grdPlaner.Columns["Lp"].Width = 40;
            //grdPlaner.Columns["Type"].Width = 200;
            grdPlaner.Columns["Parachute"].Width = 200;
            grdPlaner.Columns["AssemblyType"].Width = 90;
            grdPlaner.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //grdPlaner.Columns["Type"].HeaderText = "Typ skoczka";
            grdPlaner.Columns["Parachute"].HeaderText = "Spadochron";
            grdPlaner.Columns["AssemblyType"].HeaderText = "Typ układania";
            grdPlaner.Columns["UserName"].HeaderText = "Nazwisko i imię";

            grdPlaner.AllowUserToResizeRows = false;
            grdPlaner.ReadOnly = true;
            grdPlaner.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grdPlaner.RowHeadersVisible = false;

            if (grdPlaner.Rows.Count > 0)
                foreach (DataGridViewRow item in grdPlaner.Rows)
                {
                    if (item != null)
                    {
                        //item.DefaultCellStyle.BackColor = Color.FromName(item.Cells["Color"].Value.ToString());
                        if (item.Cells["Color"].Value != null)
                            item.DefaultCellStyle.BackColor = Color.FromArgb(int.Parse(item.Cells["Color"].Value.ToString()));

                    }
                }

        }


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in grdPlaner.SelectedRows)
                    {
                        int flightId = (int)item.Cells["Id"].Value;
                        var flyElem = model.FlightsElem.Where(p => p.Id == flightId).FirstOrDefault();
                        if (flyElem != null)
                        {
                            flyElem.Color = colorDialog1.Color.ToArgb().ToString();
                            model.Entry(flyElem).State = System.Data.Entity.EntityState.Modified;
                            model.SaveChanges();
                        }
                    }
                }


                RefreshPlanerList();
            }
        }

        private void RefreshFlightsList()
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                grdFlights.DataSource = model
                    .Flight
                    .Include("FlightsElem")
                    .Include("Airplanes")
                    .AsNoTracking()
                    .Where(p => p.FlyDateTime >= datSinceFlights.Value.Date && p.FlyDateTime <= datToFlights.Value.Date)
                    .OrderBy(p => p.FlyNr)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Number = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr,
                        Places = p.Airplane.Seats - p.FlightsElem.Count,
                        Status = p.FlyStatus
                    }).ToList();

                grdFlights.Refresh();
                SetFlightsListView();
                UpdatePasagerList();
            }
        }

        private void SetFlightsListView()
        {
            if (grdFlights.Rows.Count > 0)
            {
                grdFlights.Columns["Id"].Visible = false;
                grdFlights.Columns["Status"].Visible = false;
                grdFlights.RowHeadersVisible = false;

                grdFlights.Columns["Places"].Width = 50;
                grdFlights.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                grdFlights.Columns["Number"].HeaderText = "Numer lotu";
                grdFlights.Columns["Places"].HeaderText = "Wolne";

                grdFlights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grdFlights.MultiSelect = false;
                grdFlights.AllowUserToResizeRows = false;

                foreach (DataGridViewRow item in grdFlights.Rows)
                {
                    if (int.Parse(item.Cells["Status"].Value.ToString()) == (int)FlightsStatus.Executed)
                        item.DefaultCellStyle.BackColor = Color.LightGreen;
                    if (int.Parse(item.Cells["Status"].Value.ToString()) == (int)FlightsStatus.Canceled)
                        item.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }

        }

        private void btnRefreshFlights_Click(object sender, EventArgs e)
        {
            RefreshFlightsList();
            RefreshPlanerList();
        }

        private void grdFlights_SelectionChanged(object sender, EventArgs e)
        {
            LoadAirplaneAndAltitude();
            RefreshPlanerList();
        }

        private void LoadAirplaneAndAltitude()
        {
            if (grdFlights.SelectedRows.Count > 0)
            {
                int idFlight = int.Parse(grdFlights.SelectedRows[0].Cells["Id"].Value.ToString());
                using (SkyRegContext model = new SkyRegContext())
                {
                    var flight = model
                        .Flight
                        .Include("Airplane")
                        .AsNoTracking()
                        .Where(p => p.Id == idFlight)
                        .FirstOrDefault();
                    if (flight != null)
                    {
                        txtAirplane.Text = string.Format("{0} {1}", flight.Airplane.Name, flight.Airplane.RegNr);
                        txtAltitude.Text = flight.Altitude.ToString();
                    }
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MoveSelectFlight(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MoveSelectFlight(1);
        }

        private void MoveSelectFlight(int value)
        {
            int currentSelectIndex = grdFlights.SelectedRows[0].Index;
            int allFlightsRows = grdFlights.Rows.Count - 1;
            if (value == -1 && currentSelectIndex > 0)
                grdFlights.Rows[currentSelectIndex - 1].Selected = true;
            if (value == 1 && currentSelectIndex < allFlightsRows)
                grdFlights.Rows[currentSelectIndex + 1].Selected = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (grdFlights.SelectedRows.Count > 0)
            {
                int flyStatus = int.Parse(grdFlights.SelectedRows[0].Cells["Status"].Value.ToString());
                bool allowShowForm = true;

                if (flyStatus == (int)FlightsStatus.Executed || flyStatus == (int)FlightsStatus.Canceled)
                {
                    allowShowForm = false;
                    if (KryptonMessageBox.Show("Zaznaczony lot posiada status zrealizowany lub anulowany.\nCzy kontynuować?", "Kontynuować?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        allowShowForm = true;
                    }
                }

                if (allowShowForm == true)
                {
                    ScheduleAddEditForm = FormsOpened<ScheduleAddEditForm>.IsOpened(ScheduleAddEditForm);
                    ScheduleAddEditForm.FormState = FormState.Add;
                    ScheduleAddEditForm.IdScheduleElem = default(int);

                    //TOTO Kod Janusza - przekazywanie obiektu jako grida bardzo inteligentnie
                    ScheduleAddEditForm.grdFlight = grdFlights;
                    ScheduleAddEditForm.grdPlaner = grdPlaner;

                    if (ScheduleAddEditForm.ShowDialog() == DialogResult.OK)
                    {
                        int lastSelectedFlight = grdFlights.SelectedRows[0].Index;

                        RefreshFlightsList();
                        grdFlights.Rows[lastSelectedFlight].Selected = true;
                       
                    }
                }
            }
        }

        private void UpdatePasagerList()
        {
            if (Application.OpenForms["PassangerList"] != null)
            {
                (Application.OpenForms["PassangerList"] as PassangerList).GenerateDynamicControls();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e) //TODO USUWANIE FlightElemParachute
        {
            using (var _ctx = new SkyRegContextRepository<FlightsElem>())
            using (var _ctxPayment = new SkyRegContextRepository<Payment>())
            {
                if (grdPlaner.SelectedRows.Count > 0)
                {
                    if (KryptonMessageBox.Show("Czy usunąć zaznaczony element?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idFlightElem = (int)grdPlaner.SelectedRows[0].Cells["Id"].Value;

                        List<int> paysId = _ctx.Model.Payment.Include("FlightsElem").Include("PaymentsSetting").Include("User").AsNoTracking().Where(p => p.FlightsElem.Id == idFlightElem).Select(p => p.Id).ToList();

                        foreach (int idPay in paysId)
                        {
                            Payment pay = _ctx.Model.Payment.Where(p => p.Id == idPay).FirstOrDefault();
                            if (pay != null)
                            {
                                _ctxPayment.Delete(pay);
                            }
                        }

                        FlightsElem fe = _ctx.GetById(idFlightElem);
                        _ctx.Delete(fe);

                        string query = $"DELETE FROM [dbo].[FlightsElemParachutes] WHERE FlightsElem_Id = {idFlightElem}";
                        _ctx.Model.Database.ExecuteSqlCommand(query);

                    }
                }

                int flySelectedIndex = grdFlights.SelectedRows[0].Index;

                RefreshFlightsList();
                RefreshPlanerList();

                grdFlights.Rows[flySelectedIndex].Selected = true;
            }
        }

        #region Test
        private void GetLoadData()
        {
            grdReportedUser.Columns.Add("name", "Name");
            grdPlaner.Columns.Add("name", "Name");
            grdReportedUser.Rows.Add(5);
            grdReportedUser.Rows[0].Cells[0].Value = "Garib";
            grdReportedUser.Rows[1].Cells[0].Value = "Paweł";
            grdReportedUser.Rows[2].Cells[0].Value = "Wojtek";
            grdReportedUser.Rows[3].Cells[0].Value = "Aneta";
            grdReportedUser.Rows[4].Cells[0].Value = "Jasio";
        }

        int rowToDelete;
        List<DataGridViewRow> rw = new List<DataGridViewRow>();

        private void grdPlaner_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdPlaner_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
            {
                int rowCount = 0;
                rw.ForEach(p =>
                {
                    rowCount = grdPlaner.Rows.Count;
                    grdPlaner.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value); //TODO otworzyć formatkę i dodać dane
                    grdReportedUser.Rows.RemoveAt(p.Index);

                });

            }
        }

        private void grdOrders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowToDelete = (int)e.RowIndex;
            rw = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in grdReportedUser.SelectedRows)
            {
                rw.Add(grdReportedUser.Rows[item.Index]);

            }
            grdReportedUser.DoDragDrop(rw, DragDropEffects.Copy);
        }

        #endregion

        private void btnCopyRecord_Click(object sender, EventArgs e)
        {
            //if (grdReportedUser.SelectedRows.Count > 0)
            //{
            //    int rowCount = 0;
            //    foreach (DataGridViewRow p in grdReportedUser.SelectedRows)
            //    {
            //        rowCount = grdPlaner.Rows.Count;
            //        grdPlaner.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value);
            //        grdReportedUser.Rows.RemoveAt(p.Index);
            //    }
            //}
        }

        private void btnRightCopyRecord_Click(object sender, EventArgs e)
        {
            //if (grdPlaner.SelectedRows.Count > 0)
            //{
            //    int rowCount = 0;
            //    foreach (DataGridViewRow p in grdPlaner.SelectedRows)
            //    {
            //        rowCount = grdReportedUser.Rows.Count;
            //        grdReportedUser.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value);
            //        grdPlaner.Rows.RemoveAt(p.Index);
            //    }
            //}
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                if (grdFlights.SelectedRows.Count > 0)
                {
                    int flyId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
                    int flySelectedIndex = grdFlights.SelectedRows[0].Index;

                    Flight fly = model.Flight.Where(p => p.Id == flyId).FirstOrDefault();
                    if (fly != null)
                    {
                        if (KryptonMessageBox.Show("Zmienić status lotu na zrealizowany?", "Zmienić?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fly.FlyStatus = (int)FlightsStatus.Executed;
                            model.Entry(fly).State = System.Data.Entity.EntityState.Modified;
                            model.SaveChanges();

                            RefreshFlightsList();
                            RefreshPlanerList();

                            grdFlights.Rows[flySelectedIndex].Selected = true;

                            PrintDataAndForm();
                        }
                    }

                }
            }
        }

        private void PrintDataAndForm()
        {
            using (var _ctxFly = new SkyRegContextRepository<Flight>())
            using (var _ctx = new SkyRegContextRepository<FlightsElem>())
            {

                int flyId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
                var result = _ctx.GetAll(Tuple.Create(nameof(User), nameof(Flight), ""));
                if (result.IsSuccess)
                {
                    var fly = _ctxFly.GetAll(Tuple.Create(nameof(Airplane), "", "")).Value.Where(p => p.Id == flyId).FirstOrDefault();
                    GlobalSetting gs = _ctx.Model.GlobalSetting.Where(p => p.Id == 1).FirstOrDefault();

                    LoadingListForm llf = new LoadingListForm();
                    LLHeader llh = new LLHeader();
                    llh.Airplane = string.Format("{0} {1}", fly.Airplane.Name, fly.Airplane.RegNr);
                    if (gs != null)
                        llh.Airport = gs.AirportsName;
                    else
                        llh.Airport = default(string);
                    llh.Date = fly.FlyDateTime.ToString("yyyy-MM-dd");
                    llh.FlightNr = fly.FlyNr;
                    llh.Organizer = "Skyvan Service";
                    llf.Header = llh;

                    try
                    {
                        llf.Items = result.Value.Where(p => p.Flight_Id == flyId)
                            .Select(p => new LLItems
                            {
                                Lp = p.Lp.ToString(),
                                Name = p.User.Name,
                                JumpNr = default(string),//TODO do ustalenia co tu ma być
                            Status = _ctx.Model.Database.SqlQuery<string>("select Name from DefinedUserType where Id = {0}", p.UsersTypeId).FirstOrDefault(),
                                ParachuteType = _ctx.Model.Database.SqlQuery<string>("select Parachute.Name from FlightsElemParachutes join Parachute on Parachute.Id = FlightsElemParachutes.Parachute_Id where FlightsElem_Id = {0}", p.Id).FirstOrDefault(),
                                ParachuteId = _ctx.Model.Database.SqlQuery<string>("select Parachute.IdNr from FlightsElemParachutes join Parachute on Parachute.Id = FlightsElemParachutes.Parachute_Id where FlightsElem_Id = {0}", p.Id).FirstOrDefault(),
                                Altitude = p.Flight.Altitude.ToString()
                            })
                            .OrderBy(p => p.Lp)
                            .ToList();
                        llf.ShowDialog();
                    }
                    catch
                    {
                        KryptonMessageBox.Show("Nie można drukować listy załądunkowej gdy na liście są anonimowe elementy grupy", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }


                    llf.ShowDialog();

                    //TEST Print HTML
                    GenerateHtml(llh);

                }
            }
        }

        private void GenerateHtml(LLHeader header)
        {
            var htmlBuilder = new StringBuilder();
            
            if(header != new LLHeader())
            {
                var userList = new { Name = "Garib Tigranyan", Parachute = "Saber #0003", Typ = "Instruktor" };
                string userData = "";

                for (int i = 1; i <= 5; i++)
                {
                    userData += HtmlTemplate.singleRow.FormatWith(new
                    {
                        Lp = $"{i}",
                        UserName = userList.Name,
                        ParachuteType = userList.Parachute,
                        UserType = userList.Typ
                    });
                }

                htmlBuilder.AppendLine(
                    HtmlTemplate.TempalteHtml.FormatWith(new
                    {
                        FlightNr = header.FlightNr,
                        Airplane = header.Airplane,
                        Airport = header.Airport,
                        FlyDate = header.Date,
                        singleRow = userData
                    }
                    ));

                htmlBuilder.AppendLine(HtmlTemplate.style);

                PrintPreview prntView = new PrintPreview(htmlBuilder.ToString());
                prntView.ShowDialog();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Zgłoszenia


        private void RefreshDataList()
        {
            grdReportedUser.DataSource = null;
            using (var _ctx = new SkyRegContextRepository<ReportedUsers>())
            {
                var userList = _ctx.Table.OrderByDescending(p => p.Id).Select(p => new
                {
                    Name = p.UserName,
                    ReportedByUser = p.ReportByUser,
                    Id = p.Id
                }).ToList();

                grdReportedUser.DataSource = userList;
                MapCollumns();
            }
        }

        private void MapCollumns()
        {
            grdReportedUser.Columns["Id"].Visible = false;

            grdReportedUser.Columns["Name"].HeaderText = "Osoba oczekująca";
            grdReportedUser.Columns["ReportedByUser"].HeaderText = "Zgłoszony przez";
            grdReportedUser.Columns["Name"].Width = 150;
            grdReportedUser.Columns["ReportedByUser"].Width = 150;

        }

        #endregion

      

        private void btnTransport_Click(object sender, EventArgs e)
        {
            _scheduleMoveCopyUsers = FormsOpened<ScheduleMoveCopyUsers>.IsShowDialog(_scheduleMoveCopyUsers);
            _scheduleMoveCopyUsers.FormClosed += _scheduleMoveCopyUsers_FormClosed;
            _scheduleMoveCopyUsers.Type = TransportData.Move;
            _scheduleMoveCopyUsers.FlightId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
            if (grdPlaner.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grdPlaner.SelectedRows)
                {
                    if (row.Cells["UserId"].Value != null)
                        _scheduleMoveCopyUsers.UserIds.Add((int)row.Cells["UserId"].Value);
                }
                _scheduleMoveCopyUsers.ShowDialog();
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            _scheduleMoveCopyUsers = FormsOpened<ScheduleMoveCopyUsers>.IsShowDialog(_scheduleMoveCopyUsers);
            _scheduleMoveCopyUsers.FormClosed += _scheduleMoveCopyUsers_FormClosed;
            _scheduleMoveCopyUsers.Type = TransportData.Copy;
            _scheduleMoveCopyUsers.FlightId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
            if (grdPlaner.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grdPlaner.SelectedRows)
                {
                    if (row.Cells["UserId"].Value != null)
                        _scheduleMoveCopyUsers.UserIds.Add((int)row.Cells["UserId"].Value);
                }
                _scheduleMoveCopyUsers.ShowDialog();
            }
        }

        private void _scheduleMoveCopyUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            _scheduleMoveCopyUsers = null;
            RefreshFlightsList();
            RefreshPlanerList();
        }

        private ScheduleMoveCopyUsers _scheduleMoveCopyUsers = null;

        private void btnUp_Click(object sender, EventArgs e)
        {
            using (var _ctx = new SkyRegContextRepository<FlightsElem>())
            {

                if (grdPlaner.SelectedRows.Count > 0)
                {
                    int? userId = default(int);
                    int? flightId = (int)grdFlights.SelectedRows[0]?.Cells["Id"].Value;
                    if (grdPlaner.SelectedRows[0].Cells["UserId"]?.Value != null)
                        userId = (int)grdPlaner.SelectedRows[0].Cells["UserId"].Value;

                    if (userId.Value > 0 && flightId > 0)
                    {
                        var allFlightElems = _ctx.Table.Where(p => p.Flight_Id == flightId).OrderBy(p => p.Lp).ToList();
                        var userFlightElem = _ctx.Table.Where(p => p.Flight_Id == flightId && p.User_Id == userId).FirstOrDefault();
                        if (allFlightElems.Count > 1)
                        {
                            var userIndex = allFlightElems.IndexOf(userFlightElem);
                            if (userIndex > 0 && allFlightElems.Count >= userIndex)
                            {
                                int userLp = userFlightElem.Lp.Value;
                                var moveTo = userIndex - 1;
                                var moveItem = allFlightElems[moveTo];

                                userFlightElem.Lp = moveItem.Lp;
                                moveItem.Lp = userLp;

                                _ctx.Update(userFlightElem);
                                _ctx.Update(moveItem);
                                RefreshFlightsList();

                                grdFlights.Rows[grdFlights.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["Id"].Value != null && (int)p.Cells["Id"].Value == flightId).Select(p => p.Index).FirstOrDefault()].Selected = true;
                            }
                        }
                        grdPlaner.Rows[grdPlaner.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["UserId"].Value != null && (int)p.Cells["UserId"].Value == userId).Select(p => p.Index).FirstOrDefault()].Selected = true;
                    }
                    
                }
            }
        }


        private void btnDown_Click(object sender, EventArgs e)
        {
            if (grdPlaner.SelectedRows?.Count > 0)
            {
                using (var _ctx = new SkyRegContextRepository<FlightsElem>())
                {
                    if (grdPlaner.SelectedRows.Count > 0)
                    {
                        int? userId = default(int);
                        var flightId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
                       
                        if (grdPlaner.SelectedRows[0].Cells["UserId"]?.Value != null)
                            userId = (int)grdPlaner.SelectedRows[0].Cells["UserId"].Value;

                        if (userId.Value > 0 && flightId > 0)
                        {
                            var allFlightElems = _ctx.Table.Where(p => p.Flight_Id == flightId).OrderBy(p => p.Lp).ToList();
                            var userFlightElem = _ctx.Table.Where(p => p.Flight_Id == flightId && p.User_Id == userId).FirstOrDefault();

                            if (allFlightElems.Count > 1)
                            {
                                var userIndex = allFlightElems.IndexOf(userFlightElem);
                                if (userIndex >= 0 && allFlightElems.Count >= userIndex)
                                {
                                    int userLp = userFlightElem.Lp.Value;
                                    var moveTo = userIndex + 1;
                                    var moveItem = allFlightElems[moveTo];

                                    userFlightElem.Lp = moveItem.Lp;
                                    moveItem.Lp = userLp;

                                    _ctx.Update(userFlightElem);
                                    _ctx.Update(moveItem);
                                    RefreshFlightsList();

                                   
                                    grdFlights.Rows[grdFlights.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["Id"].Value != null && (int)p.Cells["Id"].Value == flightId).Select(p => p.Index).FirstOrDefault()].Selected = true;
                                }
                            }
                            grdPlaner.Rows[grdPlaner.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["UserId"].Value != null && (int)p.Cells["UserId"].Value == userId).Select(p => p.Index).FirstOrDefault()].Selected = true;
                        }
                    }
                }
            }
        }

        private void ScheduleForm_Shown(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in grdFlights.Rows)
            {
                if (int.Parse(item.Cells["Status"].Value.ToString()) == (int)FlightsStatus.Executed)
                    item.DefaultCellStyle.BackColor = Color.LightGreen;
                if (int.Parse(item.Cells["Status"].Value.ToString()) == (int)FlightsStatus.Canceled)
                    item.DefaultCellStyle.BackColor = Color.LightPink;
            }
        }
    }
}

