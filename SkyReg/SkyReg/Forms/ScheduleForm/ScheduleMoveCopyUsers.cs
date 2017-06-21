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
        public List<int> IdList { get; set; } = new List<int>();
        public int Flight_Id { get; set; }
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
                    if (IdList.Count <= seats)
                        using (var _ctx = new SkyRegContextRepository<FlightsElem>())
                        {
                            var fe = _ctx.GetAll().Value;
                            var result = (from p in fe
                                          join u in IdList on p.User_Id equals u
                                          where p.Flight_Id == Flight_Id
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
                var addFlights = new Tuple<List<int>,List<string>>(null,null);
                FlightsElem flyElem = null;
                Payment pay = null;
                using (var _ctxPay = new SkyRegContextRepository<Payment>())
                using (var _ctxFe = new SkyRegContextRepository<FlightsElem>())
                {
                    var fe = _ctxFe.GetAll().Value;
                    var result = (from p in fe
                                  join u in IdList on p.User_Id equals u
                                  where p.Flight_Id == Flight_Id
                                  select p).ToList();

                    foreach (DataGridViewRow item in grdFlights.Rows)
                    {
                        if (item.Cells["Checked"].Value != null && (bool)item.Cells["Checked"].Value)
                        {
                            addFlights.Item1.Add((int)item.Cells["Id"].Value);
                            addFlights.Item2.Add($"{item.Cells["Number"].Value}");
                        }
                    }

                     foreach (var item in addFlights)

                    fe.ForEach(p =>
                    {
                        // 1. Dodać FlightElement 
                        // 2. Na Podstawinie starego Id z Item1 wyciągnąć Payments i zrobić inserta z nowym FE id
                        // 3. Przepisać Opisy Skok,Układalnia itp. zmienić nazwy lotów - Item2
                        // 4. Zrobić inserta do [dbo].[FlightsElemParachutes]

                        //addFlights.ForEach(x =>
                        //{
                        //    flyElem = new FlightsElem();
                        //    flyElem = p;
                        //    flyElem.Flight_Id = x;

                        //    if(_ctxFe.InsertEntity(flyElem).IsSuccess)
                        //    {
                        //        pay = new Payment();
                        //        pay
                        //    }
                        //});


                    });
                }
            }
        }

        private void ScheduleMoveCopyUsers_Load(object sender, EventArgs e)
        {
            LoadCurrentFlights();
        }
    }
}
