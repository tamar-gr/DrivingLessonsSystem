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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class tester : Window
    {
        Ibl bl;
        Tester MyTester = new Tester();
        public tester(string content, int id = 0)// when we add tester id=0
        {
            InitializeComponent();
            btnOk.Content = content;
            Title = (content + " " + "tester");//the title of the window
            MyTester = new Tester();
            bl = FactoryBL.GetBL();
            if (id != 0)//when we update, delete or view tester we get the id and search it.
            {
                MyTester = (Tester)bl.findById(id);
            }
            this.DataContext = MyTester;
            this.cmbGearbox.ItemsSource = Enum.GetValues(typeof(BE.Gearbox));//fill cmb by enums??
            this.cmbTesterGender.ItemsSource = Enum.GetValues(typeof(BE.Gender));
           this.cmbKindV.ItemsSource = Enum.GetValues(typeof(BE.TypeCar));
            if (content == "Remove" || content == "View")
            {
                txtid.IsEnabled = false;
                txtlastName.IsEnabled = false;
                txtfirstName.IsEnabled = false;
                TesterBirth.IsEnabled = false;
                txtStreet.IsEnabled = false;
                txtBuilding.IsEnabled = false;
                txtCity.IsEnabled = false;
                cmbKindV.IsEnabled = false;
                cmbTesterGender.IsEnabled = false;
                cmbGearbox.IsEnabled = false;
                txtphone.IsEnabled = false;
                txtmaxDistance.IsEnabled = false;
                txtExperience.IsEnabled = false;
                chkMon10.IsEnabled = false;
                chkMon11.IsEnabled = false;
                chkMon12.IsEnabled = false;
                chkMon13.IsEnabled = false;
                chkMon14.IsEnabled = false;
                chkMon9.IsEnabled = false;
                chkSun10.IsEnabled = false;
                chkSun11.IsEnabled = false;
                chkSun12.IsEnabled = false;
                chkSun13.IsEnabled = false;
                chkSun14.IsEnabled = false;
                chkSun9.IsEnabled = false;
                chkThe10.IsEnabled = false;
                chkThe11.IsEnabled = false;
                chkThe12.IsEnabled = false;
                chkThe13.IsEnabled = false;
                chkThe14.IsEnabled = false;
                chkThe9.IsEnabled = false;
                chkTu10.IsEnabled = false;
                chkTu11.IsEnabled = false;
                chkTu12.IsEnabled = false;
                chkTu13.IsEnabled = false;
                chkTu14.IsEnabled = false;
                chkTu9.IsEnabled = false;
                chkWen10.IsEnabled = false;
                chkWen11.IsEnabled = false;
                chkWen12.IsEnabled = false;
                chkWen13.IsEnabled = false;
                chkWen14.IsEnabled = false;
                chkWen9.IsEnabled = false;
                if (MyTester.ScheduleMatrix[0, 0] == true)
                    chkSun9.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 5] == true)
                    chkSun14.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 4] == true)
                    chkSun13.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 3] == true)
                    chkSun12.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 2] == true)
                    chkSun11.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 1] == true)
                    chkSun10.IsChecked = true;
                //filled Sunday
                if (MyTester.ScheduleMatrix[1, 0] == true)
                    chkMon9.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 5] == true)
                    chkMon14.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 4] == true)
                    chkMon13.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 3] == true)
                    chkMon12.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 2] == true)
                    chkMon11.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 1] == true)
                    chkMon10.IsChecked = true;
                //filled Monday
                if (MyTester.ScheduleMatrix[2, 0] == true)
                    chkTu9.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 5] == true)
                    chkTu14.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 4] == true)
                    chkTu13.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 3] == true)
                    chkTu12.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 2] == true)
                    chkTu11.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 1] == true)
                    chkTu10.IsChecked = true;

                //filled Tuesday
                if (MyTester.ScheduleMatrix[3, 0] == true)
                    chkWen9.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 5] == true)
                    chkWen14.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 4] == true)
                    chkWen13.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 3] == true)
                    chkWen12.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 2] == true)
                    chkWen11.IsChecked = true;

                if (MyTester.ScheduleMatrix[3, 1] == true)
                    chkWen10.IsChecked = true;

                //filled Wensday
                if (MyTester.ScheduleMatrix[4, 0] == true)
                    chkThe9.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 5] == true)
                    chkThe14.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 4] == true)
                    chkThe13.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 3] == true)
                    chkThe12.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 2] == true)
                    chkThe11.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 1] == true)
                    chkThe10.IsChecked = true;

            }

            if (content == "Update")
            {
                txtid.IsEnabled = false;
                if (MyTester.ScheduleMatrix[0, 0] == true)
                    chkSun9.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 5] == true)
                    chkSun14.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 4] == true)
                    chkSun13.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 3] == true)
                    chkSun12.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 2] == true)
                    chkSun11.IsChecked = true;
                if (MyTester.ScheduleMatrix[0, 1] == true)
                    chkSun10.IsChecked = true;
                //filled Sunday
                if (MyTester.ScheduleMatrix[1, 0] == true)
                    chkMon9.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 5] == true)
                    chkMon14.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 4] == true)
                    chkMon13.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 3] == true)
                    chkMon12.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 2] == true)
                    chkMon11.IsChecked = true;
                if (MyTester.ScheduleMatrix[1, 1] == true)
                    chkMon10.IsChecked = true;
                //filled Monday
                if (MyTester.ScheduleMatrix[2, 0] == true)
                    chkTu9.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 5] == true)
                    chkTu14.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 4] == true)
                    chkTu13.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 3] == true)
                    chkTu12.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 2] == true)
                    chkTu11.IsChecked = true;
                if (MyTester.ScheduleMatrix[2, 1] == true)
                    chkTu10.IsChecked = true;

                //filled Tuesday
                if (MyTester.ScheduleMatrix[3, 0] == true)
                    chkWen9.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 5] == true)
                    chkWen14.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 4] == true)
                    chkWen13.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 3] == true)
                    chkWen12.IsChecked = true;
                if (MyTester.ScheduleMatrix[3, 2] == true)
                    chkWen11.IsChecked = true;

                if (MyTester.ScheduleMatrix[3, 1] == true)
                    chkWen10.IsChecked = true;

                //filled Wensday
                if (MyTester.ScheduleMatrix[4, 0] == true)
                    chkThe9.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 5] == true)
                    chkThe14.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 4] == true)
                    chkThe13.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 3] == true)
                    chkThe12.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 2] == true)
                    chkThe11.IsChecked = true;
                if (MyTester.ScheduleMatrix[4, 1] == true)
                    chkThe10.IsChecked = true;
                if (chkSun9.IsChecked == true)
                    MyTester.ScheduleMatrix[0, 0] = true;
                if (chkSun14.IsChecked == true)
                    MyTester.ScheduleMatrix[0, 5] = true;
                if (chkSun13.IsChecked == true)
                    MyTester.ScheduleMatrix[0, 4] = true;
                if (chkSun12.IsChecked == true)
                    MyTester.ScheduleMatrix[0, 3] = true;
                if (chkSun11.IsChecked == true)
                    MyTester.ScheduleMatrix[0, 2] = true;
                if (chkSun10.IsChecked == true)
                    MyTester.ScheduleMatrix[0, 1] = true;
                //filled Sunday
                if (chkMon9.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 0] = true;
                if (chkMon14.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 5] = true;
                if (chkMon13.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 4] = true;
                if (chkMon12.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 3] = true;
                if (chkMon11.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 2] = true;
                if (chkMon10.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 1] = true;
                //filled Monday
                if (chkTu9.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 0] = true;
                if (chkTu14.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 5] = true;
                if (chkTu13.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 4] = true;
                if (chkTu12.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 3] = true;
                if (chkTu11.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 2] = true;
                if (chkTu10.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 1] = true;
                //filled Tuesday
                if (chkWen9.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 0] = true;
                if (chkWen14.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 5] = true;
                if (chkWen13.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 4] = true;
                if (chkWen12.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 3] = true;
                if (chkWen11.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 2] = true;
                if (chkWen10.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 1] = true;
                //filled Wensday
                if (chkThe9.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 0] = true;
                if (chkThe14.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 5] = true;
                if (chkThe13.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 4] = true;
                if (chkThe12.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 3] = true;
                if (chkThe11.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 2] = true;
                if (chkThe10.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 1] = true;

            }
        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtid.Text, "[^0-9]"))//check if  id was fiiled is only numbers
            {
                MessageBox.Show("Please enter id in only numbers.");
                txtid.Text = txtid.Text.Remove(txtid.Text.Length - 1);
            }
        }
        private void phoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        { 
            if (System.Text.RegularExpressions.Regex.IsMatch(txtphone.Text, "[^0-9]"))//check if  phone was fiiled is only numbers
            {
                MessageBox.Show("Please enter phone in only numbers.");
                txtphone.Text = txtid.Text.Remove(txtphone.Text.Length - 1);
            }

        }
        private void maxDistanceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtmaxDistance.Text, "[^0-9]"))//check if  max distance was fiiled is only numbers
            {
                MessageBox.Show("Please enter distance in only numbers.");
                txtmaxDistance.Text = txtid.Text.Remove(txtmaxDistance.Text.Length - 1);
            }
        }
        private void TxtMaxtests_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMaxtests.Text, "[^0-9]"))//check if  max tasts was fiiled is only numbers
            {
                MessageBox.Show("Please enter distance in only numbers.");
                txtMaxtests.Text = txtid.Text.Remove(txtMaxtests.Text.Length - 1);
            }

        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            TesterMenu myTesterMenu = new TesterMenu();
           // try
            //{

                if ((string)btnOk.Content == "Add")
                {
                    int numId = Convert.ToInt32(txtid.Text);
                    if (numId < 100000000 || numId > 999999999)//check if id is legal
                        throw new Exception("Non-valid Id. Please enter a valid Id.");

                    if ((txtfirstName.Text == "") || (txtCity.Text == "") || (txtBuilding.Text == "") || (txtMaxtests.Text == "")
                         || (txtExperience.Text == "") || (txtlastName.Text == "") || (txtStreet.Text == "")
                        || (txtphone.Text == "") || (txtmaxDistance.Text == "") || (cmbGearbox.Text == "") || (cmbKindV.Text == "")
                        || (cmbTesterGender.Text == ""))//chech the texts box are not empty
                    {
                        throw new Exception("Not all fields are filled in.");
                    }

                    if (TesterBirth.SelectedDate < DateTime.Today)
                    {
                        throw new Exception("Please, enter a passed date");
                    }
                    //fill in the tester's scheduleMatrix the days he works according to the values he chose in checkbox
                    if (chkSun9.IsChecked == true)
                        MyTester.ScheduleMatrix[0, 0] = true;
                    if (chkSun14.IsChecked == true)
                        MyTester.ScheduleMatrix[0, 5] = true;
                    if (chkSun13.IsChecked == true)
                        MyTester.ScheduleMatrix[0, 4] = true;
                    if (chkSun12.IsChecked == true)
                        MyTester.ScheduleMatrix[0, 3] = true;
                    if (chkSun11.IsChecked == true)
                        MyTester.ScheduleMatrix[0, 2] = true;
                    if (chkSun10.IsChecked == true)
                        MyTester.ScheduleMatrix[0, 1] = true;
                    //filled Sunday
                    if (chkMon9.IsChecked == true)
                        MyTester.ScheduleMatrix[1, 0] = true;
                    if (chkMon14.IsChecked == true)
                        MyTester.ScheduleMatrix[1, 5] = true;
                    if (chkMon13.IsChecked == true)
                        MyTester.ScheduleMatrix[1, 4] = true;
                    if (chkMon12.IsChecked == true)
                        MyTester.ScheduleMatrix[1, 3] = true;
                    if (chkMon11.IsChecked == true)
                        MyTester.ScheduleMatrix[1, 2] = true;
                    if (chkMon10.IsChecked == true)
                        MyTester.ScheduleMatrix[1, 1] = true;
                    //filled Monday
                    if (chkTu9.IsChecked == true)
                        MyTester.ScheduleMatrix[2, 0] = true;
                    if (chkTu14.IsChecked == true)
                        MyTester.ScheduleMatrix[2, 5] = true;
                    if (chkTu13.IsChecked == true)
                        MyTester.ScheduleMatrix[2, 4] = true;
                    if (chkTu12.IsChecked == true)
                        MyTester.ScheduleMatrix[2, 3] = true;
                    if (chkTu11.IsChecked == true)
                        MyTester.ScheduleMatrix[2, 2] = true;
                    if (chkTu10.IsChecked == true)
                        MyTester.ScheduleMatrix[2, 1] = true;
                    //filled Tuesday
                    if (chkWen9.IsChecked == true)
                        MyTester.ScheduleMatrix[3, 0] = true;
                    if (chkWen14.IsChecked == true)
                        MyTester.ScheduleMatrix[3, 5] = true;
                    if (chkWen13.IsChecked == true)
                        MyTester.ScheduleMatrix[3, 4] = true;
                    if (chkWen12.IsChecked == true)
                        MyTester.ScheduleMatrix[3, 3] = true;
                    if (chkWen11.IsChecked == true)
                        MyTester.ScheduleMatrix[3, 2] = true;
                    if (chkWen10.IsChecked == true)
                        MyTester.ScheduleMatrix[3, 1] = true;
                    //filled Wensday
                    if (chkThe9.IsChecked == true)
                        MyTester.ScheduleMatrix[4, 0] = true;
                    if (chkThe14.IsChecked == true)
                        MyTester.ScheduleMatrix[4, 5] = true;
                    if (chkThe13.IsChecked == true)
                        MyTester.ScheduleMatrix[4, 4] = true;
                    if (chkThe12.IsChecked == true)
                        MyTester.ScheduleMatrix[4, 3] = true;
                    if (chkThe11.IsChecked == true)
                        MyTester.ScheduleMatrix[4, 2] = true;
                    if (chkThe10.IsChecked == true)
                        MyTester.ScheduleMatrix[4, 1] = true;
                    //filled Thursday

                    bl.addTester(MyTester);
                    MyTester = new Tester();
                    //this.DataContext = MyTester;
                    this.Close();
                    myTesterMenu.Show();


                }
                else if ((string)btnOk.Content == "Remove")
                {
                    var mbResult = MessageBox.Show("Are you sure you want to remove this tester?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (mbResult == MessageBoxResult.OK)
                    {
                        bl.deleteTester(MyTester);
                        MyTester = new Tester();//clean the datacontext
                        this.DataContext = MyTester;
                        this.Close();
                        MessageBox.Show("Tester removed");
                        myTesterMenu.Show();

                    }
                }
                else if ((string)btnOk.Content == "Update")
            {
            
                    MyTester.ScheduleMatrix[0, 0] = chkSun9.IsChecked.Value;              
                    MyTester.ScheduleMatrix[0, 5] = chkSun14.IsChecked.Value;
                    MyTester.ScheduleMatrix[0, 4] = chkSun13.IsChecked.Value;
                    MyTester.ScheduleMatrix[0, 3] = chkSun12.IsChecked.Value;
                    MyTester.ScheduleMatrix[0, 2] = chkSun11.IsChecked.Value; 
                    MyTester.ScheduleMatrix[0, 1] = chkSun10.IsChecked.Value;
                //filled Sunday
                if (chkMon9.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 0] = true;
                if (chkMon14.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 5] = true;
                if (chkMon13.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 4] = true;
                if (chkMon12.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 3] = true;
                if (chkMon11.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 2] = true;
                if (chkMon10.IsChecked == true)
                    MyTester.ScheduleMatrix[1, 1] = true;
                //filled Monday
                if (chkTu9.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 0] = true;
                if (chkTu14.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 5] = true;
                if (chkTu13.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 4] = true;
                if (chkTu12.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 3] = true;
                if (chkTu11.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 2] = true;
                if (chkTu10.IsChecked == true)
                    MyTester.ScheduleMatrix[2, 1] = true;
                //filled Tuesday
                if (chkWen9.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 0] = true;
                if (chkWen14.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 5] = true;
                if (chkWen13.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 4] = true;
                if (chkWen12.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 3] = true;
                if (chkWen11.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 2] = true;
                if (chkWen10.IsChecked == true)
                    MyTester.ScheduleMatrix[3, 1] = true;
                //filled Wensday
                if (chkThe9.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 0] = true;
                if (chkThe14.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 5] = true;
                if (chkThe13.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 4] = true;
                if (chkThe12.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 3] = true;
                if (chkThe11.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 2] = true;
                if (chkThe10.IsChecked == true)
                    MyTester.ScheduleMatrix[4, 1] = true;











                if (chkMon9.IsChecked == false)
                    MyTester.ScheduleMatrix[1, 0] = false;
                if (chkMon14.IsChecked == false)
                    MyTester.ScheduleMatrix[1, 5] = false;
                if (chkMon13.IsChecked == false)
                    MyTester.ScheduleMatrix[1, 4] = false;
                if (chkMon12.IsChecked == false)
                    MyTester.ScheduleMatrix[1, 3] = false;
                if (chkMon11.IsChecked == false)
                    MyTester.ScheduleMatrix[1, 2] = false;
                if (chkMon10.IsChecked == false)
                    MyTester.ScheduleMatrix[1, 1] = false;
                //filled Monday
                if (chkTu9.IsChecked == false)
                    MyTester.ScheduleMatrix[2, 0] = false;
                if (chkTu14.IsChecked == false)
                    MyTester.ScheduleMatrix[2, 5] = false;
                if (chkTu13.IsChecked == false)
                    MyTester.ScheduleMatrix[2, 4] = false;
                if (chkTu12.IsChecked == false)
                    MyTester.ScheduleMatrix[2, 3] = false;
                if (chkTu11.IsChecked == false)
                    MyTester.ScheduleMatrix[2, 2] = false;
                if (chkTu10.IsChecked == false)
                    MyTester.ScheduleMatrix[2, 1] = false;
                //filled Tuesday
                if (chkWen9.IsChecked == false)
                    MyTester.ScheduleMatrix[3, 0] = false;
                if (chkWen14.IsChecked == false)
                    MyTester.ScheduleMatrix[3, 5] = false;
                if (chkWen13.IsChecked == false)
                    MyTester.ScheduleMatrix[3, 4] = false;
                if (chkWen12.IsChecked == false)
                    MyTester.ScheduleMatrix[3, 3] = false;
                if (chkWen11.IsChecked == false)
                    MyTester.ScheduleMatrix[3, 2] = false;
                if (chkWen10.IsChecked == false)
                    MyTester.ScheduleMatrix[3, 1] = false;
                //filled Wensday
                if (chkThe9.IsChecked == false)
                    MyTester.ScheduleMatrix[4, 0] = false;
                if (chkThe14.IsChecked == false)
                    MyTester.ScheduleMatrix[4, 5] = false;
                if (chkThe13.IsChecked == false)
                    MyTester.ScheduleMatrix[4, 4] = false;
                if (chkThe12.IsChecked == false)
                    MyTester.ScheduleMatrix[4, 3] = false;
                if (chkThe11.IsChecked == false)
                    MyTester.ScheduleMatrix[4, 2] = false;
                if (chkThe10.IsChecked == false)
                    MyTester.ScheduleMatrix[4, 1] = false;











                var mbResult = MessageBox.Show("Are you sure you want to update this tester?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (mbResult == MessageBoxResult.OK)
                    {
                        bl.updateTester(MyTester);
                        MyTester = new Tester();
                        this.DataContext = MyTester;
                        this.Close();
                        MessageBox.Show("Tester updated");
                        myTesterMenu.Show();

                    }
                    else
                    {
                        this.Close();
                        myTesterMenu.Show();
                    }
                }
                else
                {
                    MyTester = new Tester();
                    this.DataContext = MyTester;
                    this.Close();
                    myTesterMenu.Show();
                }
           // }


            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }



        private void CmbTesterGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbKindV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbKindV_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtBuilding_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window MenuWindow = new TesterMenu();
            MenuWindow.Show();
            this.Close();
        }



        private void cmbTesterGender_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbGearbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbKindV_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
