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
    /// Interaction logic for TesterMenu.xaml

    public partial class TesterMenu : Window
    {
        BL.Ibl bl;
        string action;

        public TesterMenu()
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
        private void btnBack_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Window TesterM1 = new TesterMenu();
            TesterM1.Show();
            this.Close();
        }



        private void btnAddTester_Click(object sender, RoutedEventArgs e)
        {
            string content = "Add";
            tester mytester = new tester(content);
            this.Close();
            mytester.Show();
        }


        private void BtnUpdateTester_Click(object sender, RoutedEventArgs e)
        {
            txtID.Visibility = System.Windows.Visibility.Visible;
            labelid.Visibility = System.Windows.Visibility.Visible;
            btnOKID.Visibility = System.Windows.Visibility.Visible;
            btnAddTester.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTester.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnUpdateTester.Visibility = System.Windows.Visibility.Hidden;

            btnView.Visibility = System.Windows.Visibility.Hidden;
            blbMenu.Visibility = System.Windows.Visibility.Hidden;
            btnBack.Visibility = System.Windows.Visibility.Hidden;
            back_button_png.Visibility = System.Windows.Visibility.Hidden;
            btnBack_Copy1.Visibility = System.Windows.Visibility.Visible;
            action = "update";
        }

        private void BtnRemoveTester_Click(object sender, RoutedEventArgs e)
        {
            txtID.Visibility = System.Windows.Visibility.Visible;
            labelid.Visibility = System.Windows.Visibility.Visible;
            btnOKID.Visibility = System.Windows.Visibility.Visible;
            btnAddTester.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTester.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnUpdateTester.Visibility = System.Windows.Visibility.Hidden;

            btnView.Visibility = System.Windows.Visibility.Hidden;
            blbMenu.Visibility = System.Windows.Visibility.Hidden;
            btnBack.Visibility = System.Windows.Visibility.Hidden;
            back_button_png.Visibility = System.Windows.Visibility.Hidden;
            btnBack_Copy1.Visibility = System.Windows.Visibility.Visible;

            action = "remove";
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            txtID.Visibility = System.Windows.Visibility.Visible;
            labelid.Visibility = System.Windows.Visibility.Visible;
            btnOKID.Visibility = System.Windows.Visibility.Visible;
            btnAddTester.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTester.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnUpdateTester.Visibility = System.Windows.Visibility.Hidden;

            btnView.Visibility = System.Windows.Visibility.Hidden;
            blbMenu.Visibility = System.Windows.Visibility.Hidden;
            btnBack.Visibility = System.Windows.Visibility.Hidden;
            back_button_png.Visibility = System.Windows.Visibility.Hidden;
            btnBack_Copy1.Visibility = System.Windows.Visibility.Visible;
            action = "view";
        }

        private void btnShowAll_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridTester myTester = new DataGridTester();
            this.Close();
            myTester.Show();
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
                    tester myTester = new tester(content, Convert.ToInt32(txtID.Text));
                    this.Close();
                    myTester.Show();
                }
                else if (action == "update")
                {
                    string content = "Update";
                    tester myTester = new tester(content, Convert.ToInt32(txtID.Text));
                    this.Close();
                    myTester.Show();
                }
                else
                {
                    string content = "View";
                    tester myTester = new tester(content, Convert.ToInt32(txtID.Text));
                    this.Close();
                    myTester.Show();
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

        private void btreturnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            MyPassword myPassword = new MyPassword();
            this.Close();
            myPassword.Show();

        }
    }
}
