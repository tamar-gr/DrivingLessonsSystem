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
    /// Interaction logic for DataGridTrainee.xaml
    /// </summary>
    public partial class DataGridTrainee : Window
    {
        BL.Ibl bl;
        public DataGridTrainee(List<Trainee> trainee1 = null, IEnumerable<Trainee> trainee2 = null)
        {

            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            if (trainee1 != null)
                this.dataGridTrainee.ItemsSource = trainee1;
            else if (trainee1 != null)
                this.dataGridTrainee.ItemsSource = trainee2;
            else
                this.dataGridTrainee.ItemsSource = bl.getTraineeList();
            this.txtShowTrainees.Name = "Trainees";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TraineeMenu menuTrainee = new TraineeMenu();
            this.Close();
            menuTrainee.Show();
        }


        private void dataGridTrainees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridTrainee.SelectedItems == null)
                return;
            var selectedTrainees = dataGridTrainee.SelectedItem as Trainee;
            trainee myTrainee = new trainee("View", selectedTrainees.ID);
            this.Close();
            myTrainee.Show();
        }

        private void DataGridTrainee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
