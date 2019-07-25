using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using MedLab_Task;
using System.Xml.Serialization;
using MedLab_Task.Models;

namespace MedLab_Task.Views
{
    /// <summary>
    /// Interaction logic for Task2GuiView.xaml
    /// </summary>
    public partial class Task2GuiView : Page
    {
        public Task2GuiView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KnowledgeService.KnowledgeBase kb = MainModel.GetKnowledgeBase(90);
            KnowledgeService.KnowledgeItem[] knowledgeItems = kb.knowledgeItems;

            knowledgeItems = Array.FindAll(knowledgeItems, ki => ki.ConceptType.Equals(MedLab_Task.KnowledgeService.ConceptTypes.Primitive) && ki.OutputType.Equals(MedLab_Task.KnowledgeService.OutputTypes.Numeric));

            DataService.DataPoint[] a = MainModel.GetDataByConcept(2, this.firstConceptName.Text);
            KnowledgeService.KnowledgeItem k1 = Array.Find(kb.knowledgeItems, ki => ki.Title.Equals(this.firstConceptName.Text));
            DataService.DataPoint[] b = MainModel.GetDataByConcept(2, this.secondConceptName.Text);
            KnowledgeService.KnowledgeItem k2 = Array.Find(kb.knowledgeItems, ki => ki.Title.Equals(this.secondConceptName.Text));

            Func<double, double, double> func;
            switch(this.functionName.Text)
            {
                case "div":
                    func = (arg1, arg2) => arg1 / arg2;
                    break;
                case "plus":
                    func = (arg1, arg2) => arg1 + arg2;
                    break;
                case "minus":
                    func = (arg1, arg2) => arg1 - arg2;
                    break;
                case "mult":
                    func = (arg1, arg2) => arg1 * arg2;
                    break;
                default:
                    func = (arg1, arg2) => arg1 * arg2;
                    break;
            }
            DataService.DataPoint[] dataPoints = Task2.get_all_intersection_periods(k1, a, k2, b, func);

            XmlSerializer serial = new XmlSerializer(typeof(DataService.DataPoint[]));
            StreamWriter streamWriter  = new StreamWriter(@"C:\Users\erant\Desktop\silent\STUDIES\other" + "\\test.xml");
            serial.Serialize(streamWriter, dataPoints);
            streamWriter.Close();

        }
    }
}
