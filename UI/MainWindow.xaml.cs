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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
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
        //create testers:

        /*BE.Tester EfratA = new BE.Tester
        {

            ID = 111111111,
            FirstName = "Efrat",
            LastName = "Amar",
            TesterGender = BE.Gender.female,
            Phone = 0545567789,
            Street = "HaRav Herzog",
            BuildingNum = 8,
            City = "Jerusalm",
            TesterBirth = new DateTime(1970, 05, 14),
            TesterkindOfVehicle = BE.kindOfVehicle.privateCar,
            TesterGearBox = BE.Gearbox.automatic,
            Experience = 10,
            MaxTests = 4,
            MaxDis = 5,
        };
        */
        BE.Trainee HodayaY = new BE.Trainee
        {
            ID = 222222222,
            FirstName = "Hodaya",
            LastName = "Yitzhari",
            Phone = 0589999999,
            Street = "David Elazar",
            BuildingNum = 8,
            City = "Ra'anana",
            TraineeBirth = new DateTime(1999, 07, 5),
            KindOfVehicle = BE.kindOfVehicle.privateCar,
            TraineeGearbox = BE.Gearbox.automatic,
            NameOfSchool = BE.DrivingSchoool.IziDrive,
            NameOfTeacher = "Keren Hagani",
            NumOFLesson = 3,
            NumOfTests = 0,
            DateLastTest = default(DateTime)
         
        };
        BE.Test t = new BE.Test
        {
            IdOfTester= 111111111,
            IdOfTrainee= 222222222,
            Date=new DateTime(2019,01,01),
            Street="Yimiyahu",
            BuildingNum=8,
            City= "Ra'anana",
            Mark=BE.secces.failed,
            KeepDis=BE.secces.failed,
            Mirror=BE.secces.failed,
            Revers=BE.secces.failed,
            Parking=BE.secces.failed,
            Signaling=BE.secces.failed,
            Note="this trainee still dosn't do the test",

        };
       

        private void btnAddTester_Click(object sender, RoutedEventArgs e)
        {
            try
            {

              //bl.addTester(EfratA);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddTrainee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTrainee(HodayaY);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTest(t);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnRemoveTester_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bl.deleteTester(EfratA);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRemoveTrainee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteTrainee(HodayaY);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

   
        private void btnTestersByGearBox_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTestersByGearBox(true);
            foreach (var group in result)
            {
                MessageBox.Show((group.Key).ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }

        }

       

        private void btnGetTraineeBySchool_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTraineeBySchool(true);
            foreach (var group in result)
            {
                MessageBox.Show((group.Key).ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }
        }

        private void btnGetTraineeByTeacher_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTraineeByTeacher(true);
            foreach (var group in result)
            {
                MessageBox.Show((group.Key).ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }
        }

     

        private void btnGetTraineesByNunOfTests_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTraineesByNunOfTests(true);
            foreach (var group in result)
            {
                MessageBox.Show((group.Key).ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }

        }

        private void btnGetTesters_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getTestersList();
            foreach (BE.Tester item in lst)
            {
                MessageBox.Show(item.ToString());
            };
        }

        private void btnGetTrainees_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getTraineeList();
            foreach (BE.Trainee item in lst)
            {
                MessageBox.Show(item.ToString());
            };
        }

        private void btnGetTests_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getTestsList();
            foreach (BE.Test item in lst)
            {
                MessageBox.Show(item.ToString());
            }

        }
       /* private void btnUpdateChild_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateContract_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateMommy_Click(object sender, RoutedEventArgs e)
        {

        }*/

        private void btnFindTestersByDis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Tester> found = bl.getAllTestersByDis(Convert.ToInt32(txtFindTestersByDis.Text), txtfindtestersbyadd.Text);
                 
                    foreach (BE.Tester item in found)
                    {
                        MessageBox.Show(item.ToString());
                    };
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnpassed_Click(object sender, RoutedEventArgs e)
        {
            
                MessageBox.Show(bl.passedTest(HodayaY));
            
        }


        private void btnPrintTestersByGearbox_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTestersByGearBox(true);
            foreach (var group in result)
            {
                MessageBox.Show(group.ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }

        }

        private void btnPrintTraineeBySchool_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTraineeBySchool(true);
            foreach (var group in result)
            {
                MessageBox.Show(group.ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }
        }

        private void btnPrintTraineeByTeacher_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTraineeByTeacher(true);
            foreach (var group in result)
            {
                MessageBox.Show(group.ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }
        }

        private void btnPrintTraineesByNunOfTests_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnTraineesByNunOfTests(true);
            foreach (var group in result)
            {
                MessageBox.Show(group.ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }
        }

        private void btnFindTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Test> found = bl.getAlltestsInDate(DateTime.Today);

                foreach (BE.Test item in found)
                {
                    MessageBox.Show(item.ToString());
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFindAllAvailbleTestrs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Tester> found = bl.getAllAvailbleTestrs(DateTime.Today,DateTime.Now.Hour);

                foreach (BE.Tester item in found)
                {
                    MessageBox.Show(item.ToString());
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTraineeNumOfTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int found = bl.getTraineeNumOfTests(HodayaY);
                MessageBox.Show(found.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
