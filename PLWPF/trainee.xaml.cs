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
    /// Interaction logic for BaiscTrainee.xaml
    /// </summary>
    public partial class trainee : Window
    {
        BL.Ibl bl;
        Trainee MyTrainee;
        public trainee(string content, int id = 0)
        {
            InitializeComponent();
            btnOk.Content = content;
            Title = (content + " " + "trainee");//the title of the window
            MyTrainee = new Trainee();
            bl = FactoryBL.GetBL();
            if (id != 0)//when we update, delete or view trainee we get the id and search it.
            {
                MyTrainee = (Trainee)bl.findById(id);
            }
            this.DataContext = MyTrainee;//fill the data in the window
            this.DataContext = MyTrainee;//fill the data in the window
            this.cmbGearbox.ItemsSource = Enum.GetValues(typeof(BE.Gearbox));//fill cmb by enums??
            this.cmbTraineeGender.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.cmbKindV.ItemsSource = Enum.GetValues(typeof(BE.TypeCar));
            this.cmbSchool.ItemsSource = Enum.GetValues(typeof(BE.School));
            if (content == "Remove" || content == "View")//cant change datacontext only view
            {

                txtid.IsEnabled = false;
                txtlastName.IsEnabled = false;
                txtfirstName.IsEnabled = false;
                datePickerTraineeBirth.IsEnabled = false;
                txtStreet.IsEnabled = false;
                txtBuilding.IsEnabled = false;
                txtCity.IsEnabled = false;
                cmbKindV.IsEnabled = false;
                cmbTraineeGender.IsEnabled = false;
                cmbGearbox.IsEnabled = false;
                txtphone.IsEnabled = false;
                txtLessons.IsEnabled = false;
                txtNumOfTest.IsEnabled = false;
                txtTeacher.IsEnabled = false;
                cmbSchool.IsEnabled = false;
                DateOfTheLastTest.IsEnabled = false;

            }
            if (content == "Update")//cant update id of trainee
            {
                txtid.IsEnabled = false;
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
        private void TxtBuilding_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBuilding.Text, "[^0-9]"))//check if  building was fiiled is only numbers
            {
                MessageBox.Show("Please enter number of building in only numbers.");
                txtBuilding.Text = txtid.Text.Remove(txtBuilding.Text.Length - 1);
            }
        }

        private void TxtLessons_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLessons.Text, "[^0-9]"))//check if  number of lessons was fiiled is only numbers
            {
                MessageBox.Show("Please enter number of lessons in only numbers.");
                txtLessons.Text = txtid.Text.Remove(txtLessons.Text.Length - 1);
            }

        }

        private void TxtNumOfTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNumOfTest.Text, "[^0-9]"))//check if  number of tests was fiiled is only numbers
            {
                MessageBox.Show("Please enter number of tests in only numbers.");
                txtNumOfTest.Text = txtid.Text.Remove(txtNumOfTest.Text.Length - 1);
            }
            if(txtNumOfTest.Text=="0")
            {
                DateOfTheLastTest.IsEnabled = false;
            }
            else
            {
                DateOfTheLastTest.IsEnabled = true;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


            TraineeMenu mytraineeMenu = new TraineeMenu();
            try
            {
                if ((string)btnOk.Content == "Add")
                {
                    int numId = Convert.ToInt32(txtid.Text);
                    if (numId < 100000000 || numId > 999999999)
                        
                            //check if id is legal
                        throw new Exception("Non-valid Id. Please enter a valid Id.");

                    if ((txtfirstName.Text == "") || (txtCity.Text == "") || (txtBuilding.Text == "") || (txtLessons.Text == "")
                        || (txtNumOfTest.Text == "") || (txtTeacher.Text == "") || (txtlastName.Text == "") || (txtStreet.Text == "")
                        || (txtphone.Text == "") || (cmbSchool.Text == "") || (cmbGearbox.Text == "") || (cmbKindV.Text == "")
                        || (cmbTraineeGender.Text == ""))//chech the texts box are not empty
                    {
                        throw new Exception("Not all fields are filled in.");
                    }
                    DateTime temp = (MyTrainee.TraineeBirth.AddYears(Configuration.MinAgeForTrainee));
                    if (temp > DateTime.Today)
                    {
                        throw new Exception("too young to be a trainee");
                    }

                    if (datePickerTraineeBirth.SelectedDate > DateTime.Today)
                    {
                        throw new Exception("Please, enter a passed date");
                    }
                    if (DateOfTheLastTest.SelectedDate > DateTime.Today)
                    {
                        throw new Exception("Please, enter a passed date");
                    }
                    bl.addTrainee(MyTrainee);//ask him if he sure he wants to add?
                    MyTrainee = new Trainee();//clean the datacontext
                    this.DataContext = MyTrainee;
                    this.Close();
                    mytraineeMenu.Show();

                }
                else if ((string)btnOk.Content == "Remove")
                {
                    var mbResult = MessageBox.Show("Are you sure you want to remove this trainee?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (mbResult == MessageBoxResult.OK)
                    {
                        bl.deleteTrainee(MyTrainee);
                        MyTrainee = new Trainee();//clean the datacontext
                        this.DataContext = MyTrainee;
                        this.Close();
                        MessageBox.Show("Trainee removed");
                        mytraineeMenu.Show();

                    }
                }
                else if ((string)btnOk.Content == "Update")
                {
                    var mbResult = MessageBox.Show("Are you sure you want to update this trainee?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (mbResult == MessageBoxResult.OK)
                    {
                        bl.updateTrainee(MyTrainee);
                        MyTrainee = new Trainee();
                        this.DataContext = MyTrainee;
                        this.Close();
                        MessageBox.Show("Trainee updated");
                        mytraineeMenu.Show();

                    }


                    else
                    {
                        this.Close();
                        mytraineeMenu.Show();
                    }
                }

                else
                {
                    MyTrainee = new Trainee();
                    this.DataContext = MyTrainee;
                    this.Close();
                    mytraineeMenu.Show();
                }


            }





            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void CmbGearbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbTraineeGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbKindV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbSchool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TraineeGenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window MenuWindow = new TraineeMenu();
            MenuWindow.Show();
            this.Close(); this.Close();
           
        }

        private void TxtTeacher_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window MenuWindow = new TraineeMenu();
            MenuWindow.Show();
            this.Close();
        }
    }

}



