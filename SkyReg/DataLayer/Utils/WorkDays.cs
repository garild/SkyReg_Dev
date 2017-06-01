using System;
using System.Linq;

namespace DataLayer
{
    public static class WorkDays
    {
        internal static DateTime AddWorkdays(this DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;

            while (workDays != 0)
            {
                tmpDate = tmpDate.AddDays(workDays > 0 ? 1 : -1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !IsHoliday(tmpDate))
                    if (workDays > 0)
                        workDays--;
                    else
                        workDays++;
            }
            return tmpDate;
        }

        public static int CountWorkDays(DateTime sendingDate, DateTime deliveryDate)
        {
            int result = 0;

            while (sendingDate < deliveryDate)
            {
                if (sendingDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    sendingDate = sendingDate.AddDays(2);
                    continue;
                }
                if (sendingDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    sendingDate = sendingDate.AddDays(1);
                    continue;
                }
                if (!IsHoliday(sendingDate))
                {
                    result++;
                }
                sendingDate = sendingDate.AddDays(1);
            }
            return result;
        }

        internal static bool IsHoliday(this DateTime date)
        {
            int year = date.Year;
            DateTime easter;

            DateTime[] holidays = new DateTime[11];
            holidays[0] = new DateTime(year, 01, 01);
            holidays[1] = new DateTime(year, 01, 06);
            holidays[2] = new DateTime(year, 05, 01);
            holidays[3] = new DateTime(year, 05, 03);
            holidays[4] = new DateTime(year, 08, 15);
            holidays[5] = new DateTime(year, 11, 01);
            holidays[6] = new DateTime(year, 11, 11);
            holidays[7] = new DateTime(year, 12, 25);
            holidays[8] = new DateTime(year, 12, 26);
            easter = CalculateEaster(year);
            holidays[9] = easter.AddDays(1);
            holidays[10] = easter.AddDays(60);

            return holidays.Contains(date.Date);
        }

        private static DateTime CalculateEaster(int year)
        {
            int a, b, c, d, e, f;

            a = year % 19;
            b = year % 4;
            c = year % 7;
            d = (a * 19 + getA(year)) % 30;
            e = (2 * b + 4 * c + 6 * d + getB(year)) % 7;
            if ((d == 29 && e == 6) ||
            (d == 28 && e == 6))
            {
                d -= 7;
            }
            f = 22 + d + e;
            if (f > 31)
            {
                return new DateTime(year, 04, f % 31);
            }
            else
            {
                return new DateTime(year, 03, f);
            }
        }

        private static int getA(int rok)
        {
            if (rok <= 1582)
            {
                return 15;
            }
            if (rok <= 1699)
            {
                return 22;
            }
            if (rok <= 1899)
            {
                return 23;
            }
            if (rok <= 2199)
            {
                return 24;
            }
            if (rok <= 2299)
            {
                return 25;
            }
            if (rok <= 2399)
            {
                return 26;
            }
            if (rok <= 2499)
            {
                return 25;
            }

            return 0; /* poza zakresem */
        }

        /// <summary>
        /// Pobierz wartosc B z tabeli lat
        /// </summary>
        /// <param name="rok">rok dla ktorego pobrac wartosc z tabeli</param>
        /// <returns>Wspolczynnik B dla podanego roku</returns>
        private static int getB(int rok)
        {
            if (rok <= 1582)
            {
                return 6;
            }
            if (rok <= 1699)
            {
                return 2;
            }
            if (rok <= 1799)
            {
                return 3;
            }
            if (rok <= 1899)
            {
                return 4;
            }
            if (rok <= 2099)
            {
                return 5;
            }
            if (rok <= 2199)
            {
                return 6;
            }
            if (rok <= 2299)
            {
                return 0;
            }
            if (rok <= 2499)
            {
                return 1;
            }

            return 0; /* poza zakresem */
        }
    }
}

