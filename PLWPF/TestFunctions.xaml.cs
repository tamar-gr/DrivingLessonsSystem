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
    public partial class TestFunctions : Window
    {
        BL.Ibl bl;
        public TestFunctions()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        Test mytest = new Test();
        //private void btreturnTestByCondition_Click(object sender, RoutedEventArgs e)
        //{
        //    ChangePassword testConditions = new ChangePassword();
        //    this.Close();
        //    testConditions.Show();
        //}
        private void btnFindTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtHour.Text == "")
                    MessageBox.Show("Enter an hour  first");
                else
                if (DateofTest.SelectedDate == null)
                    MessageBox.Show("Select a date  first");
                else
                {
                    GroupTestByDate d = new GroupTestByDate(txtHour.Text, DateofTest);
                    this.Close();
                    d.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TestMenu testMenu = new TestMenu();
            testMenu.Show();
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtHour_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    //private void textBox_TextChanged(object sender, TextChangedEventArgs e)
    //{

    //}
}