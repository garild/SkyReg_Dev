using ComponentFactory.Krypton.Toolkit;
using SkyReg.Common;
using SkyReg.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SkyReg
{
    public partial class PanelSettings : KryptonForm
    {
        public static BasicSettings _basicSettings { get; set; }
      

        public PanelSettings()
        {
            InitializeComponent();
            LoadSetting();
        }

        private void LoadSetting()
        {
            if (_basicSettings == null)
                _basicSettings = new BasicSettings();
                //Groupy
                groupPalette.DataSource = Enum.GetNames(typeof(PaletteMode));
                groupStyle.DataSource = Enum.GetNames(typeof(HeaderStyle));
                gridAmount.Value = _basicSettings.Amount;
                groupPalette.SelectedIndex = (int)_basicSettings.HeaderPaletteMode;
                groupStyle.SelectedIndex = (int)_basicSettings.HeaderStyle;
                txtGroupeSize.Text = $"{_basicSettings.HeaderSize.Width};{_basicSettings.HeaderSize.Height}";
                txtGroupMargins.Text = $"{_basicSettings.HeaderMargin.Left};{_basicSettings.HeaderMargin.Top};{_basicSettings.HeaderMargin.Right};{_basicSettings.HeaderMargin.Bottom}";
                txtHeadPadding.Text = $"{_basicSettings.HeaderTitlePadding.Left};{_basicSettings.HeaderTitlePadding.Top};{_basicSettings.HeaderTitlePadding.Right};{_basicSettings.HeaderTitlePadding.Bottom}";
                //List
                listPalette.DataSource = Enum.GetNames(typeof(PaletteMode));
                listStyle.DataSource = Enum.GetNames(typeof(ButtonStyle));

                listPalette.SelectedIndex = (int)_basicSettings.ListItemsPaletteMode;
                listStyle.SelectedIndex = (int)_basicSettings.ListItemsStyle;
                listSize.Text = $"{_basicSettings.ListItemsSize.Width};{_basicSettings.ListItemsSize.Height}";
                listMargins.Text = $"{_basicSettings.ListItemsMargin.Left};{_basicSettings.ListItemsMargin.Top};{_basicSettings.ListItemsMargin.Right};{_basicSettings.ListItemsMargin.Bottom}";
                txtItemPadding.Text = $"{_basicSettings.ListItemsPadding.Left};{_basicSettings.ListItemsPadding.Top};{_basicSettings.ListItemsPadding.Right};{_basicSettings.ListItemsPadding.Bottom}";
            
        }


        public void SaveGroupData()
        {
            var m = txtGroupMargins.Text.Split(';').ToArray();
            var s = txtGroupeSize.Text.Split(';').ToArray();
            var p = txtHeadPadding.Text.Split(';').ToArray();
            _basicSettings.HeaderMargin = new Padding(int.Parse(m[0]), int.Parse(m[1]), int.Parse(m[2]), int.Parse(m[3]));
            _basicSettings.HeaderTitlePadding = new Padding(int.Parse(p[0]), int.Parse(p[1]), int.Parse(p[2]), int.Parse(p[3]));
            _basicSettings.HeaderStyle = (HeaderStyle)groupStyle.SelectedIndex;
            _basicSettings.HeaderPaletteMode = (PaletteMode)groupPalette.SelectedIndex;
            _basicSettings.HeaderSize = new Size(int.Parse(s[0]), int.Parse(s[1]));
           
        }

        public void SaveListData()
        {
            var m = listMargins.Text.Split(';').ToArray();
            var s = listSize.Text.Split(';').ToArray();
            var p = txtItemPadding.Text.Split(';').ToArray();
            _basicSettings.ListItemsMargin = new Padding(int.Parse(m[0]), int.Parse(m[1]), int.Parse(m[2]), int.Parse(m[3]));
            _basicSettings.ListItemsPadding = new Padding(int.Parse(p[0]), int.Parse(p[1]), int.Parse(p[2]), int.Parse(p[3]));
            _basicSettings.ListItemsStyle = (ButtonStyle)listStyle.SelectedIndex;
            _basicSettings.ListItemsPaletteMode = (PaletteMode)listPalette.SelectedIndex;
            _basicSettings.ListItemsSize = new Size(int.Parse(s[0]), int.Parse(s[1]));
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }


        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            string saveFile = SkyRegUser.GlobalPathFile + @"\UserConfig.xml";
            SaveGroupData();
            SaveListData();
            _basicSettings.Amount = (int)gridAmount.Value;
            PassangerList.settings = _basicSettings;

            if (File.Exists(SkyRegUser.UserConfigFile))
            {
                var UserConfig = new BaseModel();
                using (StreamReader tr2 = new StreamReader(SkyRegUser.UserConfigFile, Encoding.GetEncoding("windows-1250")))
                {
                    XmlSerializer deserializerUser = new XmlSerializer(typeof(BaseModel));
                    UserConfig = (BaseModel)deserializerUser.Deserialize(tr2);
                };
                using (StreamWriter TW = new StreamWriter(saveFile, false, Encoding.GetEncoding("windows-1250")))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(BaseModel));
                    UserConfig.BasicSettings = _basicSettings;
                    serializer.Serialize(TW, UserConfig);
                }

            }

            DialogResult = DialogResult.OK;
            this.Close();

        }
        
        private void btnGroupColor_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _basicSettings.HeaderTitleColor = btnGroupColor.SelectedColor;
        }

        private void btnListColor_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _basicSettings.ListItemTextColor = btnListColor.SelectedColor;
        }

        private void groupFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = _basicSettings.HeaderFont;
            var result = fontDialog1.ShowDialog(this);
            fontDialog1.ShowColor = true;
            if (result == DialogResult.OK)
            {
                var font = fontDialog1.Font;
                _basicSettings.HeaderFont = font;
            }
        }

        private void listFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = _basicSettings.ListItemsFont;
            var result = fontDialog1.ShowDialog(this);
            fontDialog1.ShowColor = true;
            if (result == DialogResult.OK)
            {
                var font = fontDialog1.Font;
                _basicSettings.ListItemsFont = font;
            }
        }

    }
}
