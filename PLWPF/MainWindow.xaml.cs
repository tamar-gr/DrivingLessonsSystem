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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\ioshu\Downloads\last\PLWPF\music");
        public MainWindow()
        {
         
            InitializeComponent();
          // player.Play();
           

        }

        private void BtnTesters_Click(object sender, RoutedEventArgs e)//go to testers menu
        {
            TesterMenu MytesterMenu = new TesterMenu();
            this.Close();
            MytesterMenu.Show();
        }

        private void BtnTrainees_Click(object sender, RoutedEventArgs e)
        {
            TraineeMenu MytraineeMenu = new TraineeMenu();
            this.Close();
            MytraineeMenu.Show();
        }

        private void BtnTests_Click(object sender, RoutedEventArgs e)
        {
            //player.Stop();
            TestMenu myTestMenu = new TestMenu();
            this.Close();
            myTestMenu.Show();
        }

        private void BtnFindID_Click(object sender, RoutedEventArgs e)
        {
            myFind myFind1 = new myFind();
            this.Close();
            myFind1.Show();
        }
    }
}



