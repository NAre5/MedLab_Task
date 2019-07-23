using Caliburn.Micro;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MedLab_Task.ViewModels;

namespace MedLab_Task.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        IWindowManager manager = new WindowManager();
        private void kItems_MouseDoubleClick(Object sender, MouseButtonEventArgs e)
        {
            
            manager.ShowWindow(new DataViewModel(((KnowledgeService.KnowledgeItem)((DataGrid)sender).CurrentItem).Title), null, null);
        }
    }
}
