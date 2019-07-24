using System;
using System.Collections.Generic;

namespace MedLab_Task.Models
{
    public static class Task2
    {
        /// <summary>
        /// Adds/Decrease step times the given timeunit to the given date
        /// </summary>
        /// <param name="date">The date we want to change</param>
        /// <param name="timeunit">A timeunit Like Hours, Seconds, etc.</param>
        /// <param name="step">The number of times we want to move the date according to the timeunit</param>
        /// <returns>the date after the addition or Decreasion of timeunit*step</returns>
        static private DateTime AddTimeunit(DateTime date, string timeunit, double step)
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

        /// <summary>
        /// Makes from a start date, end date, and before and after spaces a time section
        /// </summary>
        /// <param name="timeunit">A timeunit Like Hours, Seconds, etc.</param>
        /// <param name="StartTime">The Start date</param>
        /// <param name="GoodBefore">The space before the Start date</param>
        /// <param name="EndTime">The End date</param>
        /// <param name="GoodAfter">The space after the End date</param>
        /// <returns>Time section</returns>
        static private KeyValuePair<DateTime, DateTime> GetSection(string timeunit, DateTime StartTime, double GoodBefore, DateTime EndTime, double GoodAfter)
        {
            return new KeyValuePair<DateTime, DateTime>(AddTimeunit(StartTime, timeunit, -GoodBefore), AddTimeunit(EndTime, timeunit, GoodAfter));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k1">First KnowledgeItem</param>
        /// <param name="d1">First KnowledgeItem's DataPoint</param>
        /// <param name="k2">Second KnowledgeItem</param>
        /// <param name="d2">Second KnowledgeItem's DataPoint</param>
        /// <param name="func">function like div,mult,add,dec, etc.</param>
        /// <returns>DataPoint of the intersection of the two DataPoints</returns>
        static public DataService.DataPoint get_intersection_period(KnowledgeService.KnowledgeItem k1, DataService.DataPoint d1, KnowledgeService.KnowledgeItem k2, DataService.DataPoint d2, Func<double, double, double> func)
        {
            KeyValuePair<DateTime, DateTime> section1 = GetSection(k1.LocalPersistencyTimeUnit, d1.StartTime, double.Parse(k1.GoodBefore), d1.EndTime, double.Parse(k1.GoodAfter));
            KeyValuePair<DateTime, DateTime> section2 = GetSection(k2.LocalPersistencyTimeUnit, d2.StartTime, double.Parse(k2.GoodBefore), d2.EndTime, double.Parse(k2.GoodAfter));
            KeyValuePair<DateTime, DateTime> intersecion = new KeyValuePair<DateTime, DateTime>((section1.Key > section2.Key ? section1.Key : section2.Key), (section1.Value < section2.Value ? section1.Value : section2.Value));
            DataService.DataPoint result = new DataService.DataPoint();
            result.StartTime = intersecion.Key;
            result.EndTime = intersecion.Value;
            result.Value = func(double.Parse(d1.Value), double.Parse(d2.Value)).ToString();
            result.PatientID = d1.PatientID;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k1">First KnowledgeItem</param>
        /// <param name="a1">First KnowledgeItem's DataPoints</param>
        /// <param name="k2">Second KnowledgeItem</param>
        /// <param name="a2">Second KnowledgeItem's DataPoints</param>
        /// <param name="func">function like div,mult,add,dec, etc.</param>
        /// <returns>Array of DataPoints from the intersection of the two KnowledgeItems DataPoints</returns>
        static public DataService.DataPoint[] get_all_intersection_periods(KnowledgeService.KnowledgeItem k1, DataService.DataPoint[] a1, KnowledgeService.KnowledgeItem k2, DataService.DataPoint[] a2, Func<double, double, double> func)
        {

            List<DataService.DataPoint> l1 = new List<DataService.DataPoint>(a1);
            List<DataService.DataPoint> l2 = new List<DataService.DataPoint>(a2);

            //sort by PatientID and then StartTime
            int Comp(DataService.DataPoint dp1, DataService.DataPoint dp2) => dp1.PatientID.CompareTo(dp2.PatientID) != 0 ? dp1.PatientID.CompareTo(dp2.PatientID) : dp1.StartTime.CompareTo(dp2.StartTime);
            l1.Sort(Comp);
            l2.Sort(Comp);

            List<DataService.DataPoint> periods_list = new List<DataService.DataPoint>();
            for (int i = 0, j = 0; i < l1.Count && j < l1.Count;)
            {
                //check for the same patient 
                if (l1[i].PatientID.Equals(l2[j].PatientID))
                {
                    DataService.DataPoint kvp = get_intersection_period(k1, a1[i], k2, a2[j], func);
                    if (kvp.StartTime.CompareTo(kvp.EndTime) >= 0)
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
                else
                {
                    if (l1[i].PatientID.CompareTo(l2[j].PatientID) < 0)
                        i++;
                    else
                        j++;

                }
            }
            return periods_list.ToArray();
        }
    }
}
