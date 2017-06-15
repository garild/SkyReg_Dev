using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using DataLayer.Utils;
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
    public partial class ListViewOutlets : KryptonForm
    {
        public ListViewOutlets()
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
            GenerateDynamicControls();
            TEST();
        }

        private void GenerateDynamicControls()
        {
            var dataitem = new List<string>();
            using (DLModelRepository<Flight> _contextOperator = new DLModelRepository<Flight>())
            {
                var flishts = _contextOperator.GetAll();
                var items = new ListViewItem();
                int i = 1;
                
                flishts?.Value.Take(24).ToList().ForEach(
                    p =>
                    {
                        dataitem.Add($"{i++.ToString("00")}.             GARIB TIGRANYAN");
                    });

              


            }
            

            for (int i = 1; i < 8; i++)
            {
                var controls = new AC.StdControls.Toolkit.LBox.KryptonVirtualListBox();
                controls.BackStyle = PaletteBackStyle.ControlGroupBox;
                controls.BorderStyle = PaletteBorderStyle.ButtonStandalone;
                controls.Count = 0;
                controls.Dock = DockStyle.Fill;
                controls.DrawMode = DrawMode.OwnerDrawFixed;
                controls.HorizontalScrollbar = true;
                controls.ImeMode = ImeMode.NoControl;
                controls.ItemStyle = ButtonStyle.Form;
                controls.Location = new Point(0, 0);
                controls.Margin = new Padding(4);
                controls.PaletteMode = PaletteMode.SparkleBlue;
                controls.SelectionMode = SelectionMode.None;
                controls.Size = new Size(476, 487);
                controls.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.Color.White;
                controls.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                controls.TabIndex = 0;
                controls.Padding = new Padding(0);
                controls.Name = $"virtualListBox{i}";
                

                var group = new KryptonHeaderGroup();
                group.AutoSizeMode = AutoSizeMode.GrowOnly;
                group.GroupBackStyle = PaletteBackStyle.ButtonStandalone;
                group.GroupBorderStyle = PaletteBorderStyle.ButtonAlternate;
                group.HeaderStylePrimary = HeaderStyle.Calendar;
                group.HeaderVisibleSecondary = false;
                group.Location = new Point(0, 0);
                group.Margin = new Padding(0);
                group.Name = $"KryptonGroup{i}";
                group.PaletteMode = PaletteMode.SparkleBlue;
                // 
                // kryptonHeaderGroup1.Panel
                // 
                group.Panel.Controls.Add(controls);
                group.Size = new System.Drawing.Size(480, 512);
                group.StateNormal.HeaderPrimary.Content.Padding = new System.Windows.Forms.Padding(10, 2, 2, 2);
                group.StateNormal.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
               
                dataitem.ForEach(p =>
                {
                    virtualListBox.Items.Add(p);
                    //kryptonVirtualListBox7.Items.Add(p);
                    
                    //kryptonVirtualListBox8.Items.Add(p);
                    //kryptonVirtualListBox9.Items.Add(p);
                    //kryptonVirtualListBox10.Items.Add(p);
                    //kryptonVirtualListBox4.Items.Add(p);

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
            PanelSettings _panel = new PanelSettings();
            _panel.Show();
        }
    }
}
