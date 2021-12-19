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
using System.Threading;
using BL;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for BasicTest.xaml
    /// </summary>
    public partial class test : Window
    {


        BL.Ibl bl;
        Test MyTest;
        Tester myTester;
        //bool colculating = true;
        bool distance = true;
        public test(string content, int testcode = 0)
        {
            InitializeComponent();
            btnOK.Content = content;
            Title = (content + " " + "test");
            MyTest = new Test();
            bl = FactoryBL.GetBL();
            if (testcode != 0)//when we update, delete or view trainee we get the id and search it.
            {
                MyTest = (Test)bl.findById(testcode);
            }
            this.DataContext = MyTest;//fill the data in the window
            this.cmbkindOfvehicle.ItemsSource = Enum.GetValues(typeof(BE.TypeCar));
            this.cmbgearBox.ItemsSource = Enum.GetValues(typeof(BE.Gearbox));
            chMirrors.Visibility = System.Windows.Visibility.Hidden;
            chParking.Visibility = System.Windows.Visibility.Hidden;
            chReverse.Visibility = System.Windows.Visibility.Hidden;
            chSignaling.Visibility = System.Windows.Visibility.Hidden;
            chPriority.Visibility = System.Windows.Visibility.Hidden;
            if (content == "Remove" || content == "View")//just view
            {

                textCode.IsEnabled = false;
                textTesterID.IsEnabled = false;
                txTtraineeID.IsEnabled = false;
                textHour.IsEnabled = false;
                textCity.IsEnabled = false;
                textStreet.IsEnabled = false;
                textBuilding.IsEnabled = false;
                cmbkindOfvehicle.IsEnabled = false;
                cmbgearBox.IsEnabled = false;
                chParking.Visibility = System.Windows.Visibility.Visible;
                chPriority.Visibility = System.Windows.Visibility.Visible;
                chMirrors.Visibility = System.Windows.Visibility.Visible;
                chSignaling.Visibility = System.Windows.Visibility.Visible;
                chReverse.Visibility = System.Windows.Visibility.Visible;

                chReverse.IsEnabled = false;
                chParking.IsEnabled = false;
                chPriority.IsEnabled = false;
                chMirrors.IsEnabled = false;
                chParking.IsEnabled = false;
                chSignaling.IsEnabled = false;
                chReverse.IsChecked = MyTest.Reverse;
                chParking.IsChecked = MyTest.Parking;
                chPriority.IsChecked = MyTest.priority;
                chMirrors.IsChecked = MyTest.Mirror;
                chSignaling.IsChecked = MyTest.Signaling;

            }
            if (content == "Update")//cant change trainee id
            {
                TestCode.IsEnabled = false;
                chParking.Visibility = System.Windows.Visibility.Visible;
                chPriority.Visibility = System.Windows.Visibility.Visible;
                chMirrors.Visibility = System.Windows.Visibility.Visible;
                chSignaling.Visibility = System.Windows.Visibility.Visible;
                chReverse.Visibility = System.Windows.Visibility.Visible;


             
                //   chPriority.IsChecked = MyTest.priority;
                //  chMirrors.IsChecked = MyTest.Mirror;
               // chParking.IsChecked = MyTest.Parking;

            }
            if (content == "Add")
            {

                textCode.IsEnabled = false;
                txtNote.Visibility = System.Windows.Visibility.Hidden;
                lblnote.Visibility = System.Windows.Visibility.Hidden;
                lblmirror.Visibility = System.Windows.Visibility.Hidden;
                lblparking.Visibility = System.Windows.Visibility.Hidden;
                lblrevers.Visibility = System.Windows.Visibility.Hidden;
                lblsignaling.Visibility = System.Windows.Visibility.Hidden;
                chMirrors.Visibility = System.Windows.Visibility.Hidden;
                chParking.Visibility = System.Windows.Visibility.Hidden;
                chReverse.Visibility = System.Windows.Visibility.Hidden;
                chSignaling.Visibility = System.Windows.Visibility.Hidden;
                chPriority.Visibility = System.Windows.Visibility.Hidden;
                txtResult.Visibility = System.Windows.Visibility.Hidden;
                result.Visibility = System.Windows.Visibility.Hidden;
                chPriority.Visibility = System.Windows.Visibility.Hidden;
                lblpriority.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            TestMenu mytestMenu = new TestMenu();
            try
            {
                if ((string)btnOK.Content == "Add")
                {
                    myTester = bl.getTestersList().FirstOrDefault(x => x.ID == Convert.ToInt32(textTesterID.Text));
                    BE.Address address = new BE.Address(myCity: textCity.Text, Street: textStreet.Text, Building: textBuilding.Text);
              
                    if (myTester != null && address != null)
                    {
                        Thread thread = new Thread(() => checkRange(address, myTester));
                        thread.Start();
                    }
                    int numId1 = Convert.ToInt32(textTesterID.Text);
                    if (numId1 < 100000000 || numId1 > 999999999)//9 numbers for id
                        throw new Exception("Non-valid Id of tester. Please enter a valid Id.");
                    int numId = Convert.ToInt32(txTtraineeID.Text);
                    if (numId < 100000000 || numId > 999999999)//9 numbers for id
                        throw new Exception("Non-valid Id of trainee. Please enter a valid Id.");

                    if ((textTesterID.Text == "") || (txTtraineeID.Text == "") || (textCity.Text == "") || (textBuilding.Text == "") || (textStreet.Text == "")
                        || (cmbgearBox.Text == "") || (cmbkindOfvehicle.Text == ""))// empty checkBox
                    {
                        throw new Exception("Not all fields are filled in.");
                    }

                    bl.addTest(MyTest);
                    MyTest = new Test();
                   
                    this.Close();
                    mytestMenu.Show();

                }

                else if ((string)btnOK.Content == "Update")
                {
                    var mbResult = MessageBox.Show("Are you sure you want to update this test?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (mbResult == MessageBoxResult.OK)
                    {
                        MyTest.Reverse = chReverse.IsChecked.Value;
                        MyTest.Parking = chParking.IsChecked.Value;
                        MyTest.Mirror = chMirrors.IsChecked.Value;
                        MyTest.priority = chPriority.IsChecked.Value;
                        MyTest.Parking = chParking.IsChecked.Value;
                        MyTest.Signaling = chSignaling.IsChecked.Value;
                        bl.updateTest(MyTest);
                        MyTest = new Test();
                        this.DataContext = MyTest;
                        this.Close();
                        MessageBox.Show("Test updated");
                        mytestMenu.Show();

                    }


                    else
                    {
                        this.Close();
                        mytestMenu.Show();
                    }
                }

                else
                {
                    MyTest = new Test();
                    this.DataContext = MyTest;
                    this.Close();
                    mytestMenu.Show();
                }


            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        private void checkRange(Address address, Tester tester)
        {
           bool colculating = true;
            distance = bl.TesterInRange(tester, address);
            colculating = false;


        }
        private void TextHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textHour.Text, "[^0-9]"))//check if  hour was fiiled is only numbers
            {
                MessageBox.Show("Please enter hour in only numbers.");
                textHour.Text = textHour.Text.Remove(textHour.Text.Length - 1);
            }
        }

        private void TextBuilding_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBuilding.Text, "[^0-9]"))//check if  building was fiiled is only numbers
            {
                MessageBox.Show("Please enter building in only numbers.");
                textBuilding.Text = textBuilding.Text.Remove(textBuilding.Text.Length - 1);
            }

        }

        private void cmbKipDis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbFinalmark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window MenuWindow = new TestMenu();
            MenuWindow.Show();
            this.Close();
        }

        private void TextTesterID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtResult_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (chPriority.IsChecked == true && chParking.IsChecked == true && chSignaling.IsChecked == true && chReverse.IsChecked == true && chPriority.IsChecked == true)
            {
                txtResult.Text = "passed";
            }
            else
            {
                txtResult.Text = "failed";
            }
        }

        private void TextCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            textCode.Text = MyTest.numOfTest.ToString();
        }

        private void result_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (chPriority.IsChecked == true && chParking.IsChecked == true && chSignaling.IsChecked == true && chReverse.IsChecked == true && chPriority.IsChecked == true)
            {
                txtResult.Text = "passed";
            }
            else
            {
                txtResult.Text = "failed";
            }
        }
    }
}
