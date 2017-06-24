using AC.StdControls.Toolkit.LBox;
using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using DataLayer.Utils;
using DockedOutlets.Common;
using SkyRegEnums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DockedOutlets
{
    public partial class FormOutlets : KryptonForm
    {
        public static BasicSettings settings = null;
        private Timer _timer = new Timer();
         
        public FormOutlets()
        {
            SkyRegUser.GlobalPathFile = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)) + @"\SkyReg";
            SkyRegUser.DatabaseConfigFile = string.Format("{0}\\DatabaseConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.UserConfigFile = string.Format("{0}\\UserConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.LocalMachineName = Environment.MachineName;
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            SkyRegUser.AppVer = $"wersja {curVersion}";

            InitializeComponent();
            LoadSettings();

            EntityConnectionString.Configuration(DatabaseConfig.ConnectionString);
           
        }

        private void GenerateDynamicControls()
        {
            if (settings != null)
            {
                _timer.Interval =  60*1000 * settings.RefreshTimer; //4h
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
                var flights = _cxtFlight.GetAll(Tuple.Create("FlightsElem","Airplane",""));
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
                            users = _cxtFlightEl.GetAll(Tuple.Create("User","","")).Value?.Where(o => o.Id == f.Id).FirstOrDefault();

                            if (users.User != null)
                                itemString = $"{index++.ToString("00")} - {f.User.Name}";
                            else
                                itemString = $"{index++.ToString("00")} - {f.TeamName}";

                            controls.Items.Add(itemString);
                        });


                        flowLayoutPanel1.Controls.Add(group);
                    });
                }
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(SkyRegUser.DatabaseConfigFile))
            {
                using (TextReader tr = new StreamReader(SkyRegUser.DatabaseConfigFile))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(SkyRegUser.DatabaseConfigFile);
                    XmlSerializer deserializer;

                    //odczyt ustawień z nowej wersji pliku
                    var ConfigSettings = new DatabaseAccess();
                    deserializer = new XmlSerializer(ConfigSettings.GetType());
                    ConfigSettings = ((DatabaseAccess)deserializer.Deserialize(tr));
                    tr.Close();
                    ConfigSettings.Password = ConfigSettings.Password.DecryptString();
                    ConfigSettings.User = ConfigSettings.User.DecryptString();
                    new DatabaseConfig(ConfigSettings);
                    SkyRegUser.IsDbExists = true;
                }

            }
        }


        private void tsmSettings_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _panel = new PanelSettings();
            _panel.FormClosed += _panel_FormClosed;
            _panel.Show();

        }

        private void _panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_panel.DialogResult == DialogResult.OK)
            {
                GenerateDynamicControls();
            }
        }

        PanelSettings _panel = null;
    }
}
