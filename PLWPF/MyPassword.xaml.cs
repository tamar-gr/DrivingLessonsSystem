//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using BE;
//namespace PLWPF
//{
//    /// <summary>
//    /// Interaction logic for MyPassword.xaml
//    /// </summary>
//    public partial class MyPassword : Window
//    {
//        public MyPassword()
//        {
//            InitializeComponent();
//            //IdTextBox.Focus(); // focusing on the insertion password box
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            // we save the ID user inputed in a local class named DATA , for re using later
//            Data.UserID = IdTextBox.Text;
//            // checking there are any char. in the textbox
//            if (Data.UserID.Length == 0)
//            {
//                MessageBox.Show("plese enter a number!",
//                    "", MessageBoxButton.OK, MessageBoxImage.Asterisk,
//                    MessageBoxResult.Yes, MessageBoxOptions.RtlReading);
//                return;
//            }

//            if (Data.UserID == "208098699" )
//            {
//                MessageBox.Show("hello,please enter your password", "", MessageBoxButton.OK, MessageBoxImage.None,
//                    MessageBoxResult.OK, MessageBoxOptions.RtlReading);
//                Label1.Content = "הזנת סיסמת מנהל";
//                IdTextBox.Visibility = Visibility.Collapsed;
//                button1.Visibility = Visibility.Collapsed;
//                ManagerPasswordBox.Visibility = Visibility.Visible;
//                button2.Visibility = Visibility.Visible;
//                return;
//            }






//        }

//        BL.Ibl bl = BL.FactoryBL.GetBL(); // getting a bl instance



//        private void IdTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
//        {
//            if (e.Key == System.Windows.Input.Key.Enter) // responding to ENTER key like as a button click
//                Button_Click(null, e);
//        }

//        private void Button2_Click(object sender, RoutedEventArgs e) // this button appears if the ID user
//        {                                                           // inputed belongs to a manager
//            //if (Encryption.VerifyHashPassword(ManagerPasswordBox.Password, Configuration.Password))
//            //{// while clicking this button , we check if the hashing of the user input matches the manager password we have in DS
//                Data.UserType = Data.Usertype.tester;
//            //}
//        }

//        private void ManagerPasswordBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
//        {
//            if (e.Key == System.Windows.Input.Key.Enter) // responding enter key as a button click
//                Button2_Click(null, e);
//        }
//    }
//}
using System.Windows;
using System.Windows.Controls;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// 
    /// This class is made to log the user into the system, using his ID 
    /// </summary>
 public partial class MyPassword : Window
    {
        public MyPassword()
        {
            InitializeComponent();
            IdTextBox.Focus(); // focusing on the insertion password box
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // we save the ID user inputed in a local class named DATA , for re using later
            Data.UserID = IdTextBox.Text;
            // checking there are any char. in the textbox
            if (Data.UserID.Length == 0)
            {
                MessageBox.Show("אנא הכנס מספר!",
                    "", MessageBoxButton.OK, MessageBoxImage.Asterisk,
                    MessageBoxResult.Yes, MessageBoxOptions.RtlReading);
                return;
            }

            if (Data.UserID == "208098699" || Data.UserID == "029985090")
            {
                MessageBox.Show("שלום מנהל, אנא הזן סיסמה", "", MessageBoxButton.OK, MessageBoxImage.None,
                    MessageBoxResult.OK, MessageBoxOptions.RtlReading);
                Label1.Content = "הזנת סיסמת מנהל";
                IdTextBox.Visibility = Visibility.Collapsed;
                button1.Visibility = Visibility.Collapsed;
                ManagerPasswordBox.Visibility = Visibility.Visible;
                button2.Visibility = Visibility.Visible;
                return;
            }

            // trying to get a trainee or a tester that has the ID user inputed


            BL.Ibl bl = BL.FactoryBL.GetBL(); // getting a bl instance

            //private void IdNotFound() // if ID isn't found in DS , asking user if he wants to add a user to system
            //{
            //    int x = (int)MessageBox.Show("תעודת זהות לא נמצאה במערכת, האם ברצונך להוסיף משתמש חדש?",
            //            "ת.ז לא נמצאה במערכת", MessageBoxButton.YesNo, MessageBoxImage.Question,
            //            MessageBoxResult.Yes, MessageBoxOptions.RtlReading);

            //    if (x == 6) // is he wants - asking if he wants to add a trainee or a tester - in page AddPerson
            //    {
            //        Data.MainUserControl = new AddPerson();
            //    }

            //    else // else - leaving him in the same page
            //    {
            //        Data.MainUserControl = new MyPassword ();
            //    }
            //}
        }
        private void IdTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter) // responding to ENTER key like as a button click
                Button_Click(null, e);
        }

        private void Button2_Click(object sender, RoutedEventArgs e) // this button appears if the ID user
        {                                                           // inputed belongs to a manager
            if (BE.Encryption.VerifyHashPassword(ManagerPasswordBox.Password, BE.Configuration.Password))
            {// while clicking this button , we check if the hashing of the user input matches the manager password we have in DS
                Data.UserType = Data.Usertype.tester;
            }
        }

        private void ManagerPasswordBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter) // responding enter key as a button click
                Button2_Click(null, e);
        }
    }
}


