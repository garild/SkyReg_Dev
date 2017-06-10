using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public enum PaymentsTypes
    {
        [Description("KP")]
        Wpłata = 0,
        [Description("KW")]
        Wypłata = 1,
        [Description("Pakiety")]
        Pakiet = 2
    }
}
