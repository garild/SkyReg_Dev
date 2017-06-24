﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ComponentFactory.Krypton.Toolkit;
using System.Drawing;
using System.Windows.Forms;

namespace SkyReg.Extensions
{
    [XmlRoot("BaseModel")]
    [XmlInclude(typeof(UsersRole))]
    [XmlInclude(typeof(BasicSettings))]
    public class BaseModel
    {
        public string Login { get; set; }
        public int UserId { get; set; }
        [XmlArray("Roles")]
        [XmlArrayItem("Roles")]
        public List<UsersRole> Roles { get; set; }

        public BasicSettings BasicSettings { get; set; }
        
    }

    public class UsersRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Value { get; set; }
        public bool Camera { get; set; }
        public bool TandemPilot { get; set; }
        public bool TandemPassenger { get; set; }
        public int SpecialType { get; set; }
    }
    
    public class BasicSettings
    {
        /// <summary>
        /// HeaderGroup
        /// </summary>
        [XmlIgnore]
        public Font HeaderFont { get; set; } = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        public float HeaderFontSize { get; set; } = 9.75F;
        public Padding HeaderMargin { get; set; } = new Padding(0);
        public Padding HeaderTitlePadding { get; set; } = new Padding(0, 0, 0, 0);
        public HeaderStyle HeaderStyle { get; set; } = HeaderStyle.Calendar;
        public PaletteMode HeaderPaletteMode { get; set; } = PaletteMode.SparkleBlue;
        public Size HeaderSize { get; set; } = new Size(480, 512);
        public Color HeaderTitleColor { get; set; } = Color.White;
        /// <summary>
        /// ListItems
        /// </summary>
        [XmlIgnore]
        public Font ListItemsFont { get; set; } = new Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        public float ListItemsFontSize { get; set; } = 10.25F;
        public Size ListItemsSize { get; set; } = new Size(476, 487);
        public Padding ListItemsMargin { get; set; } = new Padding(0, 0, 0, 0);
        public Padding ListItemsPadding { get; set; } = new Padding(0, 0, 0, 0);
        public ButtonStyle ListItemsStyle { get; set; } = ButtonStyle.Form;
        public PaletteMode ListItemsPaletteMode { get; set; } = PaletteMode.SparkleBlue;
        public Color ListItemTextColor { get; set; } = Color.White;

        //Others
        public int Amount { get; set; } = 1;
    }
}
