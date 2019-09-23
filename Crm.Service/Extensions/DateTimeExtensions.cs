using System;

namespace amocrm.library.Extensions
{
    internal static class DateTimeExtensions
    {
        public static DateTime FromTimestamp(this DateTime date, long timestamp)
        {
            if (timestamp <= 0) return DateTime.MinValue;

            var startDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return startDate.AddSeconds(timestamp).ToLocalTime();
        }

        internal static long ToTimestamp(this DateTime date)
        {
            if (date == DateTime.MinValue) return 0;

            var dateUTC = date.ToUniversalTime();
            return ((DateTimeOffset)dateUTC).ToUnixTimeSeconds();
        }
    }
}
