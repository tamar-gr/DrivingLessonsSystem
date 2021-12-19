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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupTraineesByTeacher.xaml
    /// </summary>
    public partial class GroupTraineesByTester : Window
    {
        BL.Ibl bl;

        public GroupTraineesByTester()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

            foreach (BE.Trainee item in bl.getTraineeList())
            {
                (item.NameOfTeacher) = bl.getTraineeTeacher(item.NameOfTeacher);
            }
            this.dataGrid.ItemsSource = bl.getTraineeList();
            ListCollectionView collection = new ListCollectionView(bl.getTraineeList());
            collection.GroupDescriptions.Add(new PropertyGroupDescription("NameOfTeacher"));
            dataGrid.ItemsSource = collection;

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TraineeFunctions m = new TraineeFunctions();
            this.Close();
            m.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
