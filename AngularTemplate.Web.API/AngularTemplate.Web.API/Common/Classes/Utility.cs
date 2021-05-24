using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularTemplate.Web.API.Common.Classes
{
    public class Utility
    {
        static TimeZoneInfo easternZone =
    TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        /// <summary>
        /// Convert the time according to Tampa - Eastern Standard Time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EST(DateTime dateTime)
        {
            if (dateTime == null)
            {
                return dateTime;
            }

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, easternZone);
        }

        /// <summary>
        /// Display TimeDifference function 
        /// used by SLA and Response time
        /// </summary>
        /// <param name="endDate"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public static string TimeDifference(DateTime endDate, DateTime startDate)
        {
            if (startDate == null || endDate == null)
            {
                return string.Empty;
            }

            string strTime = string.Empty;

            TimeSpan difference;
            if (endDate >= startDate)
            {
                difference = (endDate - startDate);
            }
            else
            {
                difference = (startDate - endDate);
                strTime = "(";
            }

            if (difference.Days >= 1)
            {
                strTime += DisplayDay(difference.Days);
                strTime += DisplayHour(difference.Hours);

            }
            else if (difference.Hours >= 1)
            {
                strTime += DisplayHour(difference.Hours);
                strTime += DisplayMinutes(difference.Minutes);
            }

            if (strTime == string.Empty || strTime == "(")
            {
                strTime += DisplayMinutes(difference.TotalMinutes);
            }

            if (strTime.Substring(0, 1) == "(") { strTime = strTime.Trim() + ")"; }

            return strTime;
        }

        private static string DisplayDay(int day)
        {
            string result = day.ToString() + "\u00a0day";
            if (day > 1) { result += "s"; }
            return result + " ";
        }

        private static string DisplayHour(int hour)
        {
            string result = hour.ToString() + "\u00a0hour";
            if (hour > 1) { result += "s"; }
            return result + " ";
        }

        private static string DisplayMinutes(double minutes)
        {
            string result = Math.Round(minutes, 0) + "\u00a0min";
            if (minutes > 1) { result += "s"; }
            return result + " ";
        }
    }
}