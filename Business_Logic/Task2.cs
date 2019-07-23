using System;
using System.Collections.Generic;

namespace MedLab_Business_Logic
{
    static class Task2
    {
        //static private DateTime addTimeunit(DateTime date,string timeunit,double step)
        //{
        //    switch (timeunit)
        //    {
        //        case "Milliseconds":
        //            return date.AddMilliseconds(step);
        //        case "Seconds":
        //            return date.AddSeconds(step);
        //        case "Minutes":
        //            return date.AddMinutes(step);
        //        case "Hours":
        //            return date.AddHours(step);
        //        case "Days":
        //            return date.AddDays(step);
        //        case "Months":
        //            return date.AddMonths((int)step);
        //        case "Years":
        //            return date.AddYears((int)step);
        //        default:
        //            return date;
        //    }
        //}

        //static private KeyValuePair<DateTime, DateTime> getSection(string timeunit,DateTime StartTime,double GoodBefore,DateTime EndTime,double GoodAfter)
        //{
        //    return new KeyValuePair<DateTime, DateTime>(addTimeunit(StartTime, timeunit, GoodBefore), addTimeunit(EndTime,timeunit,GoodAfter));
        //}

        //static public KeyValuePair<KeyValuePair<DateTime, DateTime>, double> get_intersection_period(KnowledgeItem k1,DataPoint d1, DataPoint d2, Func<double, double, double> func)
        //{
        //    KeyValuePair<DateTime, DateTime> section1 = getSection(k1.LocalPersistencyTimeUnit, DateTime.Parse(d1.StartTime), double.Parse(k1.GoodBefore), DateTime.Parse(d1.EndTime), double.Parse(k1.GoodAfter));
        //    KeyValuePair<DateTime, DateTime> section2 = getSection(k1.LocalPersistencyTimeUnit, DateTime.Parse(d2.StartTime), double.Parse(k1.GoodBefore), DateTime.Parse(d2.EndTime), double.Parse(k1.GoodAfter));
        //    KeyValuePair<DateTime, DateTime> intersecion = new KeyValuePair<DateTime, DateTime>((section1.Key > section2.Key ? section1.Key : section2.Key), (section1.Value < section2.Value ? section1.Value : section2.Value));

        //    if(intersecion.Key<intersecion.Value)
        //    {
        //        return new KeyValuePair<KeyValuePair<DateTime, DateTime>, double>(intersecion, func(double.Parse(d1.Value), double.Parse(d2.Value)));
        //    }
        //    return default(KeyValuePair<KeyValuePair<DateTime, DateTime>, double>);
        //}

        //static public List<KeyValuePair<KeyValuePair<DateTime, DateTime>, double>> get_all_intersection_periods(KnowledgeItem k1,ArrayOfDataPoint a1, ArrayOfDataPoint a2, Func<double, double, double> func)
        //{
        //    List<KeyValuePair<KeyValuePair<DateTime, DateTime>, double>> res = new List<KeyValuePair<KeyValuePair<DateTime, DateTime>, double>>();
        //    for (int i=0,j=0;i<a1.DataPoint.Length || j<a2.DataPoint.Length;)
        //    {
        //        KeyValuePair<KeyValuePair<DateTime, DateTime>, double> kvp = get_intersection_period(k1, a1.DataPoint[i], a2.DataPoint[j], func);
        //        if(kvp.Equals(default(KeyValuePair<KeyValuePair<DateTime, DateTime>, double>)))
        //        {

        //        }
        //        else
        //        {

        //        }
        //    }
        //    return default(List<KeyValuePair<KeyValuePair<DateTime, DateTime>, double>>);
        //}
        
    }
}
