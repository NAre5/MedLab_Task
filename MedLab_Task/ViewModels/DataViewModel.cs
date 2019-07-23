using Caliburn.Micro;
using MedLab_Task.Models;

namespace MedLab_Task.ViewModels
{
    public class DataViewModel
    {
        public BindableCollection<DataService.DataPoint> dItems { get; set; }//Data Items that binded to the View

        public DataViewModel(string conceptName)
        {
            //Load DataPoints from server
            DataService.DataPoint[] dps = MainModel.GetDataByConcept(2, conceptName);
            dItems = new BindableCollection<DataService.DataPoint>(dps);
        }

    }
}
