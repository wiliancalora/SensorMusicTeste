using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Services.Util
{
    public class DateHour
    {
        public static DateTime GetDateTimeServer()
        {
            //TimeZoneInfo Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            //return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Standard_Time);
            return DateTime.Now;
        }
    }
}
