using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SkyReg.Utils
{ 
    public sealed class CommonMethods
    {
        public static bool isNetworkWorking()
        {
            var all = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var item in all)
            {
                if (item.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;
                if (item.Name.ToLower().Contains("virtual") || item.Description.ToLower().Contains("virtual"))
                    continue;
                if (item.OperationalStatus == OperationalStatus.Up)
                {
                    return true;
                }
            }

            return false;
        }

        public static void CheckInternetConnection()
        {
            if (!CommonMethods.isNetworkWorking())
            {
                KryptonMessageBox.Show("Brak połaczenia z internetem", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public  static int GetErrorCode(DbUpdateException e)
        {
            SqlException sql = e.InnerException.InnerException as SqlException;
            return sql.Number;
        }

        public static bool IsDuplicateInsertError(DbUpdateException e)
        {
            return GetErrorCode(e) == 2601;
        }

        public static bool IsUniqueConstraint(DbUpdateException e)
        {
            return GetErrorCode(e) == 2627;
        }

        public static bool IsForeignKeyError(DbUpdateException e)
        {
            return GetErrorCode(e) == 547;
        }
        
    }


    public static class CustomeStringFormatWith
    {
        public static string FormatWith(this string str, object o)
        {
            return FormatWithObject(str, o, CultureInfo.CurrentCulture);
        }
        private static string FormatWithObject(this string str, object o, IFormatProvider formatProvider)
        {
            if (o == null)
                return str;
            var propertyNamesAndValues = o.GetType()
              .GetProperties()
              .Where(pi => pi.CanRead)
              .Select(pi => new {
                  pi.Name,
                  Value = pi.GetValue(o, null)
              });

            char substLeftDouble = '\0';              // **very** unlikely
            char substRightDouble = substLeftDouble;  // initially equal
            if (str.Contains("{{") || str.Contains("}}"))
            {
                var strAndDigits = "0123456789" + str;
                while (strAndDigits.Contains(++substLeftDouble)) ;
                substRightDouble = substLeftDouble;
                while (strAndDigits.Contains(++substRightDouble)) ;
                str = Regex.Replace(str, "{{", new string(substLeftDouble, 1));
                str = Regex.Replace(str, "}}", new string(substRightDouble, 1), RegexOptions.RightToLeft);
            }

            var index = 0;
            foreach (var pnv in propertyNamesAndValues)
            {
                //str = str.Replace("{" + pnv.Name, "{" + index.ToString(CultureInfo.InvariantCulture));
                str = Regex.Replace(str, "{" + pnv.Name + @"\b", "{" + index.ToString(CultureInfo.InvariantCulture));
                index++;
            }
            if (substRightDouble != substLeftDouble)  // if they differ, then we need to handle this case
            {
                str = str.Replace(new string(substLeftDouble, 1), "{{").Replace(new string(substRightDouble, 1), "}}");
            }
            // this depends on the Select enumerating in the same order as foreach
            return string.Format(formatProvider, str, propertyNamesAndValues.Select(p => p.Value).ToArray());
        }
    }
}
