using Caliburn.Micro;
using MedLab_Task.Models;

namespace MedLab_Task.ViewModels
{
    public class DataViewModel
    {
        public BindableCollection<DataService.DataPoint> dItems { get; set; }

        public DataViewModel(string conceptName)
        {
            DataService.DataPoint[] dps = MainModel.GetDataByConcept(2, conceptName);
            dItems = new BindableCollection<DataService.DataPoint>(dps);
        }

    }
}
