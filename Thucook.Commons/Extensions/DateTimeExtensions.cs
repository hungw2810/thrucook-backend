using System;
using TimeZoneConverter;

namespace Thucook.Commons.Extensions
{
    public static class DateTimeExtensions
    {
        public static readonly DateTime MIN_JAVASCRIPT_TIME = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToUnixTime(this DateTime utcTime)
        {
            return (long)(utcTime - MIN_JAVASCRIPT_TIME).TotalMilliseconds;
        }

        public static DateTime ToDateTimeFromUnixTime(this long time)
        {
            return MIN_JAVASCRIPT_TIME.AddMilliseconds(time);
        }

        public static DateTime ToDateTimeFromUnixTime_Floor(this long time)
        {
            return MIN_JAVASCRIPT_TIME.AddMilliseconds(time - 999);
        }

        public static DateTime ToDateTimeFromUnixTime_Ceil(this long time)
        {
            return MIN_JAVASCRIPT_TIME.AddMilliseconds(time + 999);
        }

        public static DateTime ToDateTimeFromUtc(this DateTime utcTime, string timeZoneId = "Asia/Ho_Chi_Minh")
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, TZConvert.GetTimeZoneInfo(timeZoneId));
        }
    }
}
