using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MedLab_Task.Models;
using MedLab_Task;


namespace Tests
{
    public class Task2Tests
    {

        [Fact]
        public void get_all_intersection_periods_Check()
        {
            //
            MedLab_Task.DataService.DataPoint[] a = MainModel.GetDataByConcept(2, "BANDS");
            MedLab_Task.DataService.DataPoint[] b = MainModel.GetDataByConcept(2, "BANDS");
            //MainModel.GetDataByConcept(2, "BASOS");

            //
            Assert.Equal(a, a);
        }
    }
}
