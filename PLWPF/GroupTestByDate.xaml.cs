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
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupTesterByDatexaml.xaml
    /// </summary>
    public partial class GroupTestByDate : Window
    {
        Ibl bl;
        public GroupTestByDate(string hour, DatePicker date)
        {
            //InitializeComponent();
            //bl = FactoryBL.GetBL();
            //DateTime date1 = Convert.ToDateTime(date.SelectedDate);
            //int hour1 = Convert.ToInt32(hour);
            //List<BE.Tester> found = bl.getAllAvailbleTestrs(date1, hour1);
            //this.dataGrid .ItemsSource = found;
            //ListCollectionView collection = new ListCollectionView(bl.getAllAvailbleTestrs(date1, hour1));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("date"));
            //dataGrid .ItemsSource = collection;

            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            DateTime date1 = Convert.ToDateTime(date.SelectedDate);
         //   int hour1 = Convert.ToInt32(hour);
            //  List<BE.Tester> found = bl.getAllAvailbleTestrs(date1, hour1);
            //  this.dataGrid .ItemsSource = found;
             ListCollectionView collection = new ListCollectionView(bl.getAlltestsInDate(date1));
            //  collection.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
             dataGrid.ItemsSource = collection;

            //dataGrid.ItemsSource = bl.getTestsList();

        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TestFunctions m = new TestFunctions();
            this.Close();
            m.Show();
        }
    }
}
