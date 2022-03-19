using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Thucook.Commons.Utils
{
    public static class CalendarHelper
    {
        public static CalendarEvent FromString(string s, DateTime startTime, DateTime endTime)
        {
            // RRULE:FREQ=WEEKLY;INTERVAL=2;BYDAY=MO,FR
            // EXDATE:20210910T093000Z,20210911T093000Z
            var sanitizedString = string.Join('\n', s.Split('\n').Where(l => l.StartsWith("RRULE") || l.StartsWith("EXDATE")));
            var rruleString = $"BEGIN:VEVENT\n{sanitizedString}\nEND:VEVENT";
            var vEvent = Calendar.Load<CalendarEvent>(rruleString).FirstOrDefault();
            vEvent.DtStart = new CalDateTime(startTime.ToUniversalTime());
            vEvent.DtEnd = new CalDateTime(endTime.ToUniversalTime());
            return vEvent;
        }

        public static string ToString(CalendarEvent vEvent)
        {
            if (vEvent.RecurrenceRules.Count == 0)
            {
                return "";
            }
            var rruleString = $"RRULE:FREQ={vEvent.RecurrenceRules[0].Frequency.ToString().ToUpper()}";
            rruleString = $"{rruleString};INTERVAL={vEvent.RecurrenceRules[0].Interval}";
            if (vEvent.RecurrenceRules[0].Frequency == FrequencyType.Weekly && vEvent.RecurrenceRules[0].ByDay.Count > 0)
            {
                rruleString = $"{rruleString};BYDAY={string.Join(',', vEvent.RecurrenceRules[0].ByDay.Select(d => WeekDayToString(d)))}";
            }
            if (vEvent.RecurrenceRules[0].Count > 0)
            {
                rruleString = $"{rruleString};COUNT={vEvent.RecurrenceRules[0].Count}";
            }
            if (vEvent.RecurrenceRules[0].Until != DateTime.MinValue)
            {
                rruleString = $"{rruleString};UNTIL={vEvent.RecurrenceRules[0].Until.ToString("yyyyMMddTHHmmssZ")}";
            }
            if (vEvent.ExceptionDates.Count > 0)
            {
                List<DateTime> exDates = new();
                foreach (var exDate in vEvent.ExceptionDates)
                {
                    foreach (var period in exDate)
                    {
                        exDates.Add(period.StartTime.AsUtc);
                    }
                }
                rruleString = $"{rruleString}\nEXDATE:{string.Join(',', exDates.Select(d => d.ToString("yyyyMMddTHHmmssZ")))}";
            }

            return rruleString;
        }

        public static bool HasOverLap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1.CompareTo(end2) < 0 && end1.CompareTo(start2) > 0;
        }

        public static bool InSchedule(DateTime start1, DateTime end1, DateTime start2)
        {
            return start1.CompareTo(start2) <= 0 && end1.CompareTo(start2) > 0;
        }

        public static DateTime? CalculateUntil(string rruleString, DateTime startTime, DateTime endTime)
        {
            if (string.IsNullOrEmpty(rruleString))
            {
                return endTime;
            }

            //Create iCal event
            var newEvent = FromString(rruleString, startTime, endTime);
            var newOccurrences = newEvent.GetOccurrences(startTime, startTime.AddYears(1));
            // Calculate recurrenceUntil
            if (newEvent.RecurrenceRules.Count == 0)
            {
                return endTime;
            }
            else if (newEvent.RecurrenceRules[0].Count > 0)
            {
                return newOccurrences.LastOrDefault().Period.EndTime.AsUtc;
            }
            else if (newEvent.RecurrenceRules[0].Until != DateTime.MinValue)
            {
                return newEvent.RecurrenceRules[0].Until;
            }

            return null;
        }

        private static string WeekDayToString(WeekDay day)
        {
            switch (day.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "MO";
                case DayOfWeek.Tuesday:
                    return "TU";
                case DayOfWeek.Wednesday:
                    return "WE";
                case DayOfWeek.Thursday:
                    return "TH";
                case DayOfWeek.Friday:
                    return "FR";
                case DayOfWeek.Saturday:
                    return "SA";
                case DayOfWeek.Sunday:
                    return "SU";
                default:
                    return "MO";
            }
        }
    }
}
