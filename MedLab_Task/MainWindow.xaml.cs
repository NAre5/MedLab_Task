using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MedLab_Task
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static KnowledgeService.KnowledgeLibraryWSSoapClient _knowledgeClient = new KnowledgeService.KnowledgeLibraryWSSoapClient("KnowledgeLibraryWSSoap");
        private static DataService.aKontrollerSoapClient _dataClient = new DataService.aKontrollerSoapClient("aKontrollerSoap");

        public MainWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<KnowledgeService.KnowledgeItem> resultss { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KnowledgeService.KnowledgeBase kb = _knowledgeClient.GetKnowledgeBase(90);
            DataService.DataPoint[] dps = _dataClient.GetDataByConcept(2, "WBC");
            kb.knowledgeItems.Where(ki => ki != null && ki.ConceptType.Equals(DataService.ConceptTypes.Primitive) && ki.OutputType.Equals(DataService.OutputTypes.Numeric));
            try
            {
                // Getting drive list.

                resultss = new ObservableCollection<KnowledgeService.KnowledgeItem>(kb.knowledgeItems);
                //int itemsCount = items.Length;

                // Initializing new Grid.
                //Grid grid = this.grid;
                //grid.Children.Clear();
                ////DrivesBorder.Child = drivesGrid;

                //// Adding Rows and Colums to Grid.
                //RowDefinition[] rows = new RowDefinition[ itemsCount];
                //ColumnDefinition[] columns = new ColumnDefinition[1];

                //// Draw Rows.
                //for (int i = 0; i < itemsCount; i++)
                //{
                //    rows[i] = new RowDefinition();
                //    grid.RowDefinitions.Add(rows[i]);

                //    // Setting Row height.
                //    rows[i].Height = new GridLength(5);
                //}
                //// Draw Columns.
                //for (int i = 0; i < 1; i++)
                //{
                //    columns[i] = new ColumnDefinition();
                //    grid.ColumnDefinitions.Add(columns[i]);
                //}

                //// Setting column width.
                ////columns[1].Width = new GridLength(60);
                ////columns[3].Width = new GridLength(180);
                ////columns[5].Width = new GridLength(60);

                //// Draw Labels to show drive letters.
                //Label[] itemsLabel = new Label[itemsCount];

                //// Draw Progress bar to show drive usage.
                ////drivesProgress = new ProgressBar[itemsCount];

                //// Draw Labels to show drive usage.
                ////percentageLabel = new Label[itemsCount];

                //// Adding Labels and Progressbars to Grid.
                //for (int i = 0; i < itemsCount; i++)
                //{
                //    // Initialize Labels to show drives.
                //    itemsLabel[i] = new Label();
                //    itemsLabel[i].Content = items[i].Title;
                //    itemsLabel[i].Foreground = Brushes.Navy;
                //    Grid.SetRow(itemsLabel[i], i);
                //    Grid.SetColumn(itemsLabel[i], 0);
                //    grid.Children.Add(itemsLabel[i]);

                //}
            }
            catch (Exception Ex) { }
        }
    }
}
