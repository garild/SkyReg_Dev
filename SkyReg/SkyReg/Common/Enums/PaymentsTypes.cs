using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SkyRegEnums
{
    public enum PaymentsTypes
    {
        [Description("Wpłata gotówka")]
        KP = 0,
        [Description("Wypłata gotówka")]
        KW = 1,
        [Description("Pakiet")]
        Pakiet = 2,
        [Description("Wpłata inna")]
        BP = 3,
        [Description("Wypłata inne")]
        BW = 4,
        [Description("Należność")]
        Naleznosc = 5,
        [Description("Zobowiazanie")]
        Zobowiazanie = 6,

    }
}
