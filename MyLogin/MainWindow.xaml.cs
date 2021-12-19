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

namespace LoginWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.Ibl bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();


        }
        Trainee myTrainee = new BE.Trainee();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            myTrainee.MyPassword = Configuration.Password;

                if ((usernameBox.Text.ToString() == "ABIGAIL") && (passwordText.Password == myTrainee.MyPassword))
            {
                PLWPF.MainWindow mainWindow = new PLWPF.MainWindow();
                this.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid Password or username");
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
