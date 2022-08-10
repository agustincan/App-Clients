using System.Globalization;

namespace Common.Utils
{
    public static class Extensions
    {
        public static DateTime StringToDateTime(this string dateString, string format = "yyyyMMdd hh:mm:ss")
        {
            DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime aDate);
            return aDate;
        }
        public static DateTime StringToDate(this string dateString, string format = "yyyyMMdd")
        {
            DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime aDate);
            return aDate.Date;
        }
    }
}