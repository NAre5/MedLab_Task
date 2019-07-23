using System;
using System.Collections.Generic;
using System.Linq;

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

        static public DataService.DataPoint get_intersection_period(KnowledgeService.KnowledgeItem k1, DataService.DataPoint d1, KnowledgeService.KnowledgeItem k2, DataService.DataPoint d2, Func<double, double, double> func)
        {
            KeyValuePair<DateTime, DateTime> section1 = getSection(k1.LocalPersistencyTimeUnit, d1.StartTime, double.Parse(k1.GoodBefore), d1.EndTime, double.Parse(k1.GoodAfter));
            KeyValuePair<DateTime, DateTime> section2 = getSection(k1.LocalPersistencyTimeUnit, d2.StartTime, double.Parse(k2.GoodBefore), d2.EndTime, double.Parse(k2.GoodAfter));
            KeyValuePair<DateTime, DateTime> intersecion = new KeyValuePair<DateTime, DateTime>((section1.Key > section2.Key ? section1.Key : section2.Key), (section1.Value < section2.Value ? section1.Value : section2.Value));
            DataService.DataPoint result = new DataService.DataPoint();
            result.StartTime = intersecion.Key;
            result.EndTime = intersecion.Value;
            result.Value = func(double.Parse(d1.Value), double.Parse(d2.Value)).ToString();
            result.PatientID = d1.PatientID;
            return result;
        }

        static public List<DataService.DataPoint> get_all_intersection_periods(KnowledgeService.KnowledgeItem k1, DataService.DataPoint[] a1, KnowledgeService.KnowledgeItem k2, DataService.DataPoint[] a2, Func<double, double, double> func)
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
            return periods_list;
        }

    }
}
