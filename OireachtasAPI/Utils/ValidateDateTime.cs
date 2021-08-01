using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Utils
{
    public static class ValidateDateTime
    {
        public static DateTime ConvertInputToDateTime(string date)
        {
            DateTime dateTime;
            DateTime.TryParseExact(date,
                                   "dd-MM-yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dateTime);
            return dateTime;
        }

        public static bool IsValidDateTime(string date)
        {
            DateTime dateTime;
            return DateTime.TryParseExact(date,
                                   "dd-MM-yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dateTime);
        }
    }
}
