using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Core.Utilities.Time
{
    public class DateTimeUtil
    {
        public static long GetMillisecondsFromCurrentUtcDateTime()
        {
            DateTime epoch = DateTime.Parse("1/1/1970 00:00:00");
            TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks - epoch.Ticks);
            return (long)ts.TotalMilliseconds;
        }

        public static DateTime GetDateTimeFromMilliseconds(long milliseconds)
        {
            DateTime dt = DateTime.Parse("1/1/1970 00:00:00");
            return dt.AddMilliseconds(milliseconds);
        }

        public static long GetMillisecondsFromDateTime(DateTime dt)
        {
            DateTime epoch = DateTime.Parse("1/1/1970 00:00:00");
            TimeSpan ts = new TimeSpan(dt.Ticks - epoch.Ticks);
            return (long)ts.TotalMilliseconds;
        }

        public static string GetISODateTimeString(DateTime utc)
        {
            string value = utc.ToString("u");
            value = value.Replace(" ", "T");
            return value;
        }

        public static string GetISODateTimeFilenameString(DateTime dt)
        {
            string value = dt.ToString("u");
            value = value.Replace(" ", "T");
            value = value.Replace(":", "_");
            return value;
        }

        public static DateTime RevertISODateTimeFilenameString(string value)
        {
            value = value.Replace("T", " ");
            value = value.Replace("_", ":");
            return Convert.ToDateTime(value);
        }

        public static string GetISODateTimeStringWithFractions(DateTime utc)
        {
            return utc.ToString("o");
        }

        public static DateTime GetUTCFromMJD(double mjd)
        {
            double unixTime = (mjd - 40587) * 86400; //Modified Julian Date (MJD) is Julian Date (JD) - 2400000.5, Unix Date (UD) is JD + 2440587.5, Unix Time is UD * 86400 (seconds per day)

            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime();

            return dtDateTime;

        }

        public static double GetSecondsSinceEpoch(DateTime dt)
        {
            TimeSpan span = dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
            return Math.Floor(span.TotalSeconds);
        }
    }
}
