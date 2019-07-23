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

            MedLab_Task.DataService.DataPoint[] result = Task2.get_all_intersection_periods(k1, a, k2, b, (arg1, arg2) => arg1 * arg2);

            Assert.NotNull(result);
        }
    }
}
