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
    /// Interaction logic for TestMenu.xaml
    /// </summary>
    public partial class TestMenu : Window
    {
        BL.Ibl bl;
        string action;

        public TestMenu()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window MenuWindow = new MainWindow();
            this.Close();
            MenuWindow.Show();
        }



        private void btnAddTest_Click(object sender, RoutedEventArgs e)
        {
            string content = "Add";
            test mytest = new test(content);
            this.Close();
            mytest.Show();
        }


        private void BtnUpdateTest_Click(object sender, RoutedEventArgs e)
        {
            txtTestCode.Visibility = System.Windows.Visibility.Visible;
            labelTestCode.Visibility = System.Windows.Visibility.Visible;
            btnOKTestCode.Visibility = System.Windows.Visibility.Visible;
            btnAddTest.Visibility = System.Windows.Visibility.Hidden;
            btnUpdateTest.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTest.Visibility = System.Windows.Visibility.Hidden;
            btnView.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnMore.Visibility = System.Windows.Visibility.Hidden;
            action = "update";
        }


        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            txtTestCode.Visibility = System.Windows.Visibility.Visible;
            labelTestCode.Visibility = System.Windows.Visibility.Visible;
            btnOKTestCode.Visibility = System.Windows.Visibility.Visible;
            btnAddTest.Visibility= System.Windows.Visibility.Hidden;
            btnUpdateTest.Visibility = System.Windows.Visibility.Hidden;
            btnRemoveTest.Visibility = System.Windows.Visibility.Hidden;
            btnView.Visibility = System.Windows.Visibility.Hidden;
            btnShowAll.Visibility = System.Windows.Visibility.Hidden;
            btnMore.Visibility = System.Windows.Visibility.Hidden;
            action = "view";
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            DataGridTest myTest = new DataGridTest();
            this.Close();
            myTest.Show();
        }

        private void BtnOKTestCode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtTestCode.Text) < 10000000)
                    throw new Exception("Non-valid test code. Please enter a valid test code.");

                var found = bl.findById(Convert.ToInt32(txtTestCode.Text));

                if (action == "update")
                {
                    string content = "Update";
                    test myTest = new test(content, Convert.ToInt32(txtTestCode.Text));
                    this.Close();
                    myTest.Show();
                }
                else
                {
                    string content = "View";
                    tester myTest = new tester(content, Convert.ToInt32(txtTestCode.Text));
                    this.Close();
                    myTest.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtTestCode.Text = "";
                txtTestCode.Visibility = System.Windows.Visibility.Hidden;
                labelTestCode.Visibility = System.Windows.Visibility.Hidden;
                btnOKTestCode.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            TestFunctions t = new TestFunctions();
            this.Close();
            t.Show();


        }

        private void BtnOKTestCode_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtTestCode.Text) < 10000000|| Convert.ToInt32(txtTestCode.Text) > 99999999)
                    throw new Exception("Non-valid Id. Please enter a valid test code.");

                var found = bl.findById(Convert.ToInt32(txtTestCode.Text));
                if (action == "remove")
                {
                    string content = "Remove";
                    test myTest = new test(content, Convert.ToInt32(txtTestCode.Text));
                    this.Close();
                    myTest.Show();
                }
                else if (action == "update")
                {
                    string content = "Update";
                    test myTest = new test(content, Convert.ToInt32(txtTestCode.Text));
                    this.Close();
                    myTest.Show();
                }
                else
                {
                    string content = "View";
                    test myTest = new test(content, Convert.ToInt32(txtTestCode.Text));
                    this.Close();
                    myTest.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtTestCode.Text = "";
                txtTestCode.Visibility = System.Windows.Visibility.Hidden;
                labelTestCode.Visibility = System.Windows.Visibility.Hidden;
                btnOKTestCode.Visibility = System.Windows.Visibility.Hidden;
            }

        }
    }
}
