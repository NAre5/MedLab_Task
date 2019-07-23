using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MedLab_Task.Models;

namespace MedLab_Task.ViewModels
{
    public class MainViewModel : Screen
    {
        public BindableCollection<KnowledgeService.KnowledgeItem> kItems { get; set; }

        public MainViewModel()
        {
            KnowledgeService.KnowledgeBase kb = MainModel.GetKnowledgeBase(90);
            KnowledgeService.KnowledgeItem[] knowledgeItems = kb.knowledgeItems;
            knowledgeItems = Array.FindAll(knowledgeItems, ki => ki.ConceptType.Equals(KnowledgeService.ConceptTypes.Primitive) && ki.OutputType.Equals(KnowledgeService.OutputTypes.Numeric));
            kItems = new BindableCollection<KnowledgeService.KnowledgeItem>(knowledgeItems);
            DataService.DataPoint[] a = MainModel.GetDataByConcept(2, "BANDS");
            //a = Array.FindAll(a, d => d.PatientID.Equals("61"));
            KnowledgeService.KnowledgeItem k1 = Array.Find(kb.knowledgeItems, ki => ki.Title.Equals("BANDS"));
            DataService.DataPoint[] b = MainModel.GetDataByConcept(2, "BASOS");
            //b = Array.FindAll(b, d => d.PatientID.Equals("61"));
            KnowledgeService.KnowledgeItem k2 = Array.Find(kb.knowledgeItems, ki => ki.Title.Equals("BASOS"));
            List<DataService.DataPoint> result = Task2.get_all_intersection_periods(k1, a, k2, b, (arg1, arg2) => arg1 * arg2);
        }
    }
}
