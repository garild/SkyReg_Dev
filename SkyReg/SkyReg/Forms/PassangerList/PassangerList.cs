using AC.StdControls.Toolkit.LBox;
using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using SkyReg.Common;
using SkyReg.Common.Extensions;
using SkyRegEnums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkyReg
{
    public partial class PassangerList : KryptonForm
    {
        public static BasicSettings settings = null;
        private Timer _timer = new Timer();
         
        public PassangerList()
        {

            InitializeComponent();
           
        }

        private void GenerateDynamicControls()
        {
            if (settings != null)
            {
                _timer.Interval =  4000 * settings.RefreshTimer; //4h
                _timer.Tick += _timer_Tick;
                _timer.Start();
            }
           
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            int index = 0;
            List<Flight> toDayFlights = new List<Flight>();
            FlightsElem users = null;

            flowLayoutPanel1.Controls.Clear();

            using (var _cxtFlight = new SkyRegContextRepository<Flight>())
            using (var _cxtFlightEl = new SkyRegContextRepository<FlightsElem>())
            {
                var flights = _cxtFlight.GetAll(Tuple.Create(nameof(FlightsElem), nameof(Airplane),""));
                var items = new ListViewItem();
                
                if (flights.IsSuccess)
                {
                    //1 - Loty danego dnia - FlyDateTime -  opened & closed
                    var flightsOpenClose = flights.Value.Where(p => p.FlyStatus == (int)FlightsStatus.Closed || p.FlyStatus == (int)FlightsStatus.Opened).ToList();

                    toDayFlights = flightsOpenClose.Where(p => p.FlyDateTime.Date == DateTime.Now.Date).OrderBy(p => p.FlyDateTime).Take(8).ToList();
                }

                KryptonVirtualListBox controls = null;
                if (toDayFlights.Count > 0)
                {
                    var headerString = "";
                    var itemString = "";
                    toDayFlights.ForEach(p =>
                    {
                        headerString = $"Nr: {p.Airplane.RegNr} Lotu: {p.FlyNr} {p.Altitude}m Wolnych: {p.Airplane.Seats - p.FlightsElem.Count}";

                        controls = new KryptonVirtualListBox();
                        controls.BackStyle = PaletteBackStyle.ControlGroupBox;
                        controls.BorderStyle = PaletteBorderStyle.ButtonStandalone;
                        controls.Count = 0;
                        controls.Dock = DockStyle.Fill;
                        controls.DrawMode = DrawMode.OwnerDrawFixed;
                        controls.HorizontalScrollbar = true;
                        controls.ImeMode = ImeMode.NoControl;
                        controls.ItemStyle = settings.ListItemsStyle;
                        controls.Location = new Point(0, 0);
                        controls.Margin = settings.ListItemsMargin;
                        controls.PaletteMode = settings.ListItemsPaletteMode;
                        controls.SelectionMode = SelectionMode.None;
                        controls.Size = settings.ListItemsSize;
                        controls.StateCommon.Item.Content.ShortText.Color1 = settings.ListItemTextColor;
                        controls.StateCommon.Item.Content.ShortText.Font = settings.ListItemsFont;
                        controls.TabIndex = 0;
                        controls.Padding = settings.ListItemsPadding;
                        controls.Name = $"virtualListBox{index++}";

                        var group = new KryptonHeaderGroup();
                        group.AutoSizeMode = AutoSizeMode.GrowOnly;
                        group.GroupBackStyle = PaletteBackStyle.ButtonStandalone;
                        group.GroupBorderStyle = PaletteBorderStyle.ButtonAlternate;
                        group.HeaderStylePrimary = settings.HeaderStyle;
                        group.HeaderVisibleSecondary = false;
                        group.Location = new Point(0, 0);
                        group.Margin = settings.HeaderMargin;
                        group.Name = $"KryptonGroup{index++}";
                        group.PaletteMode = settings.HeaderPaletteMode;
                        // 
                        // kryptonHeaderGroup1.Panel
                        // 
                        group.Panel.Controls.Add(controls);
                        group.Size = settings.HeaderSize;
                        group.StateNormal.HeaderPrimary.Content.Padding = settings.HeaderTitlePadding;
                        group.StateNormal.HeaderPrimary.Content.ShortText.Font = settings.HeaderFont;
                        group.StateNormal.HeaderPrimary.Content.ShortText.Color1 = settings.HeaderTitleColor;
                        group.TabIndex = 13;
                        group.ValuesPrimary.Heading = headerString;
                        group.ValuesPrimary.Image = null;

                        p.FlightsElem.ToList().ForEach(f =>
                        {
                        users = _cxtFlightEl.GetAll(Tuple.Create(nameof(User),"","")).Value?.Where(o => o.Id == f.Id).FirstOrDefault();

                            if (users.User != null)
                                itemString = $"{index++.ToString("00")} - {users.User.Name}";
                            else
                                itemString = $"{index++.ToString("00")} - {users.TeamName}";

                            controls.Items.Add(itemString);
                        });


                        flowLayoutPanel1.Controls.Add(group);
                    });
                }
            }
        }

        private void tsmSettings_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _panel = FormsOpened<PanelSettings>.IsShowDialog(_panel);
            _panel.FormClosed += _panel_FormClosed;
            _panel.Show();

        }

        private void _panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_panel.DialogResult == DialogResult.OK)
            {
                GenerateDynamicControls();
                _panel = null;
            }
        }

        PanelSettings _panel = null;
    }
}
