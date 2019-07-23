using System;
using System.Collections.Generic;

namespace MedLab_Task
{
    public static class Task2
    {
        static private DateTime addTimeunit(DateTime date, string timeunit, double step)
        {
            switch (timeunit)
            {
                case "Milliseconds":
                    return date.AddMilliseconds(step);
                case "Seconds":
                    return date.AddSeconds(step);
                case "Minutes":
                    return date.AddMinutes(step);
                case "Hours":
                    return date.AddHours(step);
                case "Days":
                    return date.AddDays(step);
                case "Months":
                    return date.AddMonths((int)step);
                case "Years":
                    return date.AddYears((int)step);
                default:
                    return date;
            }
        }

        static public KeyValuePair<DateTime, DateTime> getSection(string timeunit, DateTime StartTime, double GoodBefore, DateTime EndTime, double GoodAfter)
        {
            return new KeyValuePair<DateTime, DateTime>(addTimeunit(StartTime, timeunit, -GoodBefore), addTimeunit(EndTime, timeunit, GoodAfter));
        }

        static public KeyValuePair<KeyValuePair<DateTime, DateTime>, double> get_intersection_period(KnowledgeService.KnowledgeItem k1, DataService.DataPoint d1, KnowledgeService.KnowledgeItem k2, DataService.DataPoint d2, Func<double, double, double> func)
        {
            KeyValuePair<DateTime, DateTime> section1 = getSection(k1.LocalPersistencyTimeUnit, d1.StartTime, double.Parse(k1.GoodBefore), d1.EndTime, double.Parse(k1.GoodAfter));
            KeyValuePair<DateTime, DateTime> section2 = getSection(k1.LocalPersistencyTimeUnit, d2.StartTime, double.Parse(k2.GoodBefore), d2.EndTime, double.Parse(k2.GoodAfter));
            KeyValuePair<DateTime, DateTime> intersecion = new KeyValuePair<DateTime, DateTime>((section1.Key > section2.Key ? section1.Key : section2.Key), (section1.Value < section2.Value ? section1.Value : section2.Value));

            return new KeyValuePair<KeyValuePair<DateTime, DateTime>, double>(intersecion, func(double.Parse(d1.Value), double.Parse(d2.Value)));
        }

        static public List<KeyValuePair<KeyValuePair<DateTime, DateTime>, double>> get_all_intersection_periods(KnowledgeService.KnowledgeItem k1, DataService.DataPoint[] a1, KnowledgeService.KnowledgeItem k2, DataService.DataPoint[] a2, Func<double, double, double> func)
        {
            List<KeyValuePair<KeyValuePair<DateTime, DateTime>, double>> periods_list = new List<KeyValuePair<KeyValuePair<DateTime, DateTime>, double>>();
            bool flag = false; ;
            for (int i = 0, j = 0; i < a1.Length && j < a2.Length;)
            {
                KeyValuePair<KeyValuePair<DateTime, DateTime>, double> kvp = get_intersection_period(k1, a1[i],k2, a2[j], func);
                if (kvp.Key.Key >= kvp.Key.Value)
                {
                    if (a1[i].StartTime.CompareTo(a2[j].StartTime) < 0)
                        i++;
                    else
                        j++;
                }
                else
                {
                    periods_list.Add(kvp);
                    if (a1[i].EndTime.CompareTo(a2[j].EndTime) < 0)
                        i++;
                    else
                        j++;
                }
            }
            return periods_list;
        }

    }
}
