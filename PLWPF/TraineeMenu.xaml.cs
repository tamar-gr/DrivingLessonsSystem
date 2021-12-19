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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TraineeMenu.xaml
    /// </summary>
    public partial class TraineeMenu : Window
    {
        BL.Ibl bl;
        string action;
        public TraineeMenu()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window MenuWindow = new MainWindow();
            MenuWindow.Show();
            this.Close();
        }

        private void btnAddTrainee_Click(object sender, RoutedEventArgs e)
        {
            string content = "Add";
            trainee mytrainee = new trainee(content);
            this.Close();
            mytrainee.Show();
        }

        private void btnUpdateTrainee_Click(object sender, RoutedEventArgs e)
        {
            txtID.Visibility = System.Windows.Visibility.Visible;
            labelid.Visibility = System.Windows.Visibility.Visible;
            btnOKID.Visibility = System.Windows.Visibility.Visible;
            btnAddTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnMore.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnUpdateTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnView.Visibility = System.Windows.Visibility.Hidden;
            lbllMenu.Visibility = System.Windows.Visibility.Hidden;
            action = "update";
        }

        private void btnRemoveTrainee_Click(object sender, RoutedEventArgs e)
        {
            txtID.Visibility = System.Windows.Visibility.Visible;
            labelid.Visibility = System.Windows.Visibility.Visible;
            btnOKID.Visibility = System.Windows.Visibility.Visible;
            btnAddTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnMore.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnUpdateTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnView.Visibility = System.Windows.Visibility.Hidden;
            lbllMenu.Visibility = System.Windows.Visibility.Hidden;
            action = "remove";
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            txtID.Visibility = System.Windows.Visibility.Visible;
            labelid.Visibility = System.Windows.Visibility.Visible;
            btnOKID.Visibility = System.Windows.Visibility.Visible;
            btnAddTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnMore.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnUpdateTrainee.Visibility = System.Windows.Visibility.Hidden;
            btnView.Visibility = System.Windows.Visibility.Hidden;
            lbllMenu.Visibility = System.Windows.Visibility.Hidden;
            action = "view";
        }

        private void btnShowAll_Click_1(object sender, RoutedEventArgs e)
        {

            DataGridTrainee myTrainee = new DataGridTrainee();
            this.Close();
            myTrainee.Show();
        }

        private void BtnOKID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtID.Text) < 100000000 || Convert.ToInt32(txtID.Text) > 999999999)
                    throw new Exception("Non-valid Id. Please enter a valid Id.");

                var found = bl.findById(Convert.ToInt32(txtID.Text));
                if (action == "remove")
                {
                    string content = "Remove";
                    trainee MyTrainee = new trainee(content, Convert.ToInt32(txtID.Text));
                    this.Close();
                    MyTrainee.Show();
                }
                else if (action == "update")
                {
                    string content = "Update";
                    trainee myTrainee = new trainee(content, Convert.ToInt32(txtID.Text));
                    this.Close();
                    myTrainee.Show();
                }
                else
                {
                    string content = "View";
                    trainee myTrainee = new trainee(content, Convert.ToInt32(txtID.Text));
                    this.Close();
                    myTrainee.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtID.Text = "";
                txtID.Visibility = System.Windows.Visibility.Hidden;
                labelid.Visibility = System.Windows.Visibility.Hidden;
                btnOKID.Visibility = System.Windows.Visibility.Hidden;
            }

        
    }

        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            TraineeFunctions t = new TraineeFunctions();
            this.Close();
            t.Show();
        }
    }
}
