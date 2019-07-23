using System;
using System.Collections.Generic;
using Caliburn.Micro;
using MedLab_Task.Models;

namespace MedLab_Task.ViewModels
{
    public class MainViewModel : Screen
    {
        public BindableCollection<KnowledgeService.KnowledgeItem> kItems { get; set; }//Knowledge Items that binded to the View

        public MainViewModel()
        {
            //Load KnowledgeItems from server
            KnowledgeService.KnowledgeBase kb = MainModel.GetKnowledgeBase(90);
            KnowledgeService.KnowledgeItem[] knowledgeItems = kb.knowledgeItems;
            //filter for ConceptType=Primitive and OutputType=Numeric
            knowledgeItems = Array.FindAll(knowledgeItems, ki => ki.ConceptType.Equals(KnowledgeService.ConceptTypes.Primitive) && ki.OutputType.Equals(KnowledgeService.OutputTypes.Numeric));
            kItems = new BindableCollection<KnowledgeService.KnowledgeItem>(knowledgeItems);
        }
    }
}
