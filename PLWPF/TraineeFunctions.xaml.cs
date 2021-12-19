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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TestFunctions.xaml
    /// </summary>
    public partial class TraineeFunctions : Window
    {
        BL.Ibl bl;
        public TraineeFunctions()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }




        private void btnGetTesters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btreturnTraineeBySchool_Click(object sender, RoutedEventArgs e)
        {

            GroupTraineetBySchool traineetBySchool = new GroupTraineetBySchool();
            this.Close();
            traineetBySchool.Show();
        }


        private void btTraineeNameOfteacer_Click(object sender, RoutedEventArgs e)
        {
            GroupTraineesByTester groupTraineesByTeacher = new GroupTraineesByTester();
            this.Close();
            groupTraineesByTeacher.Show();
        }

      

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TraineeMenu traineeMenu = new TraineeMenu();
            traineeMenu.Show();
            this.Close();
        }

        private void PassedTrainees_Click(object sender, RoutedEventArgs e)
        {
            allPassedTrainees allPassed = new allPassedTrainees();
            this.Close();
            allPassed.Show();
        }
    }
}
