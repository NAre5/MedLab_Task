using System;
using Xunit;
using MedLab_Task.Models;


namespace Tests
{
    public class Task2Tests
    {

        [Fact]
        public void get_all_intersection_periods_Check()
        {
            //Load KnowledgeItems from server
            MedLab_Task.KnowledgeService.KnowledgeBase kb = MainModel.GetKnowledgeBase(90);
            MedLab_Task.KnowledgeService.KnowledgeItem[] knowledgeItems = kb.knowledgeItems;
            //filter for ConceptType=Primitive and OutputType=Numeric
            knowledgeItems = Array.FindAll(knowledgeItems, ki => ki.ConceptType.Equals(MedLab_Task.KnowledgeService.ConceptTypes.Primitive) && ki.OutputType.Equals(MedLab_Task.KnowledgeService.OutputTypes.Numeric));

            //Load DataPoints from server of "BANDS"
            MedLab_Task.DataService.DataPoint[] a = MainModel.GetDataByConcept(2, "BANDS");
            //Find KnowledgeItem of "BANDS"
            MedLab_Task.KnowledgeService.KnowledgeItem k1 = Array.Find(kb.knowledgeItems, ki => ki.Title.Equals("BANDS"));
            //Load DataPoints from server of "BASOS"
            MedLab_Task.DataService.DataPoint[] b = MainModel.GetDataByConcept(2, "BASOS");
            //Find KnowledgeItem of "BASOS"
            MedLab_Task.KnowledgeService.KnowledgeItem k2 = Array.Find(kb.knowledgeItems, ki => ki.Title.Equals("BASOS"));

            MedLab_Task.DataService.DataPoint[] result = Task2.get_all_intersection_periods(k1, a, k2, b, (arg1, arg2) => arg1 / arg2);

            Assert.NotNull(result);
        }

        [Fact]
        public void get_intersection_period_intersectionCheck()
        {
            MedLab_Task.KnowledgeService.KnowledgeItem knowledgeItem1 = new MedLab_Task.KnowledgeService.KnowledgeItem();
            knowledgeItem1.LocalPersistencyTimeUnit = "Milliseconds";
            knowledgeItem1.GoodBefore = "1";
            knowledgeItem1.GoodAfter = "1";
            MedLab_Task.DataService.DataPoint dataPoint1 = new MedLab_Task.DataService.DataPoint();
            dataPoint1.PatientID = "tester";
            dataPoint1.StartTime = new DateTime(10000);
            dataPoint1.EndTime = new DateTime(40000);
            dataPoint1.Value = "3";

            MedLab_Task.KnowledgeService.KnowledgeItem knowledgeItem2 = new MedLab_Task.KnowledgeService.KnowledgeItem();
            knowledgeItem2.LocalPersistencyTimeUnit = "Milliseconds";
            knowledgeItem2.GoodBefore = "1";
            knowledgeItem2.GoodAfter = "1";
            MedLab_Task.DataService.DataPoint dataPoint2 = new MedLab_Task.DataService.DataPoint();
            dataPoint2.PatientID = "tester";
            dataPoint2.StartTime = new DateTime(20000);
            dataPoint2.EndTime = new DateTime(50000);
            dataPoint2.Value = "4";
            MedLab_Task.DataService.DataPoint result = Task2.get_intersection_period(knowledgeItem1, dataPoint1, knowledgeItem2, dataPoint2, (a, b) => a * b);
            //
            DateTime expectedStartDate = new DateTime(10000);
            DateTime expectedEndDate = new DateTime(50000);
            string expectedValue = "12";
            //
            Assert.Equal(result.StartTime,expectedStartDate);
            Assert.Equal(result.EndTime,expectedEndDate);
            Assert.Equal(result.Value,expectedValue);


        }

    }
}
