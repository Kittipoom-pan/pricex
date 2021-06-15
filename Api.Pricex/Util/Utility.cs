using System;
using System.Collections.Generic;

namespace Api.Pricex.Util
{
    public class Utility
    {
        static string WS_DATETIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
        static string WS_DATE_FORMAT = "dd/MM/yyyy";
        static string WS_TIME_FORMAT = "HH:mm:ss";

        public static DateTime convertToDateTime(string input)
        {
            DateTime result;

            bool isPass = DateTime.TryParse(input, out result);

            if (!isPass)
                result = DateTime.Now;

            return result;
        }

        public static string convertToDateFormatString(string input)
        {
            DateTime result;

            bool isPass = DateTime.TryParse(input, out result);

            if (!isPass)
                result = DateTime.Now;

            return result.ToString(WS_DATE_FORMAT);
        }

        public static string convertToDateTimeFormatString(string input)
        {
            DateTime result;

            bool isPass = DateTime.TryParse(input, out result);

            if (!isPass)
                result = DateTime.Now;

            return result.ToString(WS_DATETIME_FORMAT);
        }

        public static IEnumerable<DateTime> EachCalendarDay(DateTime startDate, DateTime endDate)
        {
            for (var date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1)) yield
            return date;
        }
    }
}
