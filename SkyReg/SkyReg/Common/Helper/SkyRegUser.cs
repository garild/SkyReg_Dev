using SkyReg.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public sealed class SkyRegUser
    {
        public static int UserId { get; set; }
        public static string UserLogin { get; set; }

        public static string DatabaseConfigFile { get; set; }
        public static string UserConfigFile { get; set; }
        public static string GlobalPathFile { get; set; }

        public static string AppVer { get; set; }
        public static string LocalMachineName { get; set; }
        public static bool IsDbExists { get; set; }
               
    }

}
