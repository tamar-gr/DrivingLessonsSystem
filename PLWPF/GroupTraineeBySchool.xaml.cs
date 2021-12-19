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
    /// Interaction logic for GroupTraineeBySchool.xaml
    /// </summary>
    public partial class GroupTraineetBySchool : Window
    {
        BL.Ibl bl;

        public GroupTraineetBySchool()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

            foreach (Trainee item in bl.getTraineeList())
            {
                foreach (Trainee item1 in bl.GetAllTraineeBySchool(BE.School.drivingSchool))
                {
                    item.NameOfSchool = item1.NameOfSchool;

                }
            }
            this.dataGrid.ItemsSource = bl.getTestsList();
            ListCollectionView collection = new ListCollectionView(bl.getTraineeList());
            collection.GroupDescriptions.Add(new PropertyGroupDescription("NameOfSchool"));
            dataGrid.ItemsSource = collection;
            foreach (Trainee item in bl.getTraineeList())
            {
                foreach (Trainee item1 in bl.GetAllTraineeBySchool(BE.School.d_school))
                {
                    item.NameOfSchool = item1.NameOfSchool;

                }
            }

            this.dataGrid.ItemsSource = bl.getTestsList();
            ListCollectionView collection1 = new ListCollectionView(bl.getTraineeList());
            collection.GroupDescriptions.Add(new PropertyGroupDescription("NameOfSchool"));
            dataGrid.ItemsSource = collection;

            foreach (Trainee item in bl.getTraineeList())
            {
                foreach (Trainee item1 in bl.GetAllTraineeBySchool(BE.School.drivingSchool))
                {
                    item.NameOfSchool = item1.NameOfSchool;

                }
            }

            this.dataGrid.ItemsSource = bl.getTestsList();
            ListCollectionView collection2 = new ListCollectionView(bl.getTraineeList());
            collection.GroupDescriptions.Add(new PropertyGroupDescription("NameOfSchool"));
            dataGrid.ItemsSource = collection;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TraineeFunctions m = new TraineeFunctions();
            this.Close();
            m.Show();
        }
    }


}

