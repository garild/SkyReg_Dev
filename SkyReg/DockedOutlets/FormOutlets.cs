using AC.StdControls.Toolkit.LBox;
using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using DataLayer.Utils;
using DockedOutlets.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DockedOutlets
{
    public partial class FormOutlets : KryptonForm
    {
        public static BasicSettings settings = null;

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
           
            TEST();
        }

        private void GenerateDynamicControls()
        {
            if (settings != null)
            {
                flowLayoutPanel1.Controls.Clear();
                var dataitem = new List<string>();
                using (DLModelRepository<Flight> _contextOperator = new DLModelRepository<Flight>())
                {
                    var flishts = _contextOperator.GetAll();
                    var items = new ListViewItem();
                    int i = 1;

                    flishts?.Value.Take(24).ToList().ForEach(
                        p =>
                        {
                            dataitem.Add($"{i++.ToString("00")}.  GARIB TIGRANYAN");
                        });
                }

                KryptonVirtualListBox controls = null;
                for (int i = 0; i < settings.Amount; i++)
                {
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
                    controls.Name = $"virtualListBox{i}";


                    var group = new KryptonHeaderGroup();
                    group.AutoSizeMode = AutoSizeMode.GrowOnly;
                    group.GroupBackStyle = PaletteBackStyle.ButtonStandalone;
                    group.GroupBorderStyle = PaletteBorderStyle.ButtonAlternate;
                    group.HeaderStylePrimary = settings.HeaderStyle;
                    group.HeaderVisibleSecondary = false;
                    group.Location = new Point(0, 0);
                    group.Margin = settings.HeaderMargin;
                    group.Name = $"KryptonGroup{i}";
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
                    group.ValuesPrimary.Heading = "   Nr Lot: 1254587558741  Pułap: 4000m  Miejsca: 24";
                    group.ValuesPrimary.Image = null;


                    dataitem.ForEach(p =>
                    {
                        controls.Items.Add(p);
                    });
                    flowLayoutPanel1.Controls.Add(group);

                }
            }
           
        }

        private void TEST()
        {
            using (DLModelRepository<Flight> _contextOperator = new DLModelRepository<Flight>())
            {
                var flishts = _contextOperator.GetAll();
                var items = new ListViewItem();
                int i = 1;
                var dataitem = new List<string>();
                flishts?.Value.Take(24).ToList().ForEach(
                    p =>
                    {
                        dataitem.Add($"{i++.ToString("00")}.             {p.FlyNr.ToUpper()}");
                    });
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
