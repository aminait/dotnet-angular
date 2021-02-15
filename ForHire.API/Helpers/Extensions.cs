using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace ForHire.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static string CalculateTimeElapsed(this DateTime theDateTime)
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(theDateTime);
            int intDays = ts.Days;
            int intHours = ts.Hours;
            int intMinutes = ts.Minutes;
            int intSeconds = ts.Seconds;

            if (intDays > 0)
                return string.Format("{0}d", intDays);

            if (intHours > 0)
                return string.Format("{0}h", intHours);

            if (intMinutes > 0)
                return string.Format("{0}m", intMinutes);

            if (intSeconds > 0)
                return string.Format("{0}s", intSeconds);
            return "0s";
        }

        public static string CalculateSizeRange(this int companySize)
        {
            if (companySize >= 1 && companySize <= 10)
            {
                return "1-10";
            }
            if (companySize >= 10 && companySize <= 50)
            {
                return "11-50";
            }
            if (companySize >= 50 && companySize <= 200)
            {
                return "51-200";
            }
            return "200+";
        }


    }
}