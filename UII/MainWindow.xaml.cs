
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
using BE;

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
            bl = new BL.BL_imp();
        }
        //create testers:

        BE.Tester Tamar = new BE.Tester
        {
            //ScheduleMatrix = new bool[,] ();
            ID = 208098699,
            FirstName = "Tamar",
            LastName = "Grinblat",
            TesterGender = BE.Gender.female,
            Phone = 0506615433,
            Street = "Harav Kuk",
            BuildingNum = "11",
            City = "Bney Brak",
            TesterBirth = new DateTime(1960, 12, 17),
            My_Car = BE.TypeCar.privateCar,
            TesterGearBox = BE.Gearbox.manual,
            Experience = 8,
            MaxTests = 10,
            MaxDis = 9,
        };
        BE.Trainee Abigail = new BE.Trainee
        {
            ID = 317801157,
            FirstName = "Abigail",
            LastName = "Fox",
            Phone = 0527145607,
            Street = "Yakov Chazan",
            BuildingNum = "30",
            City = "Ra'anana",
            TraineeBirth = new DateTime(1999, 06, 17),
            TraineeTypeCar = BE.TypeCar.privateCar,
            TraineeGearbox = BE.Gearbox.automatic,
            NameOfSchool = BE.School.drivingSchool,
            NameOfTeacher = "Rachel Shlomo",
            NumOFLesson = 3,
            NumOfTests = 0,
            DateLastTest = default(DateTime)

        };

        BE.Test MyTest = new BE.Test
        {
            TesterId = 208098699,
            TraineeId = 317801157,
            Date = new DateTime(2019, 01, 01),
            Street = "Yimiyahu",
            numOfTest = 8,
            City = "Ra'anana",
            Signaling = false,
            Mirror = false,
            Parking = false,
            priority = false,
            Hour = 9,
            Note = "this trainee still dosn't do the test",

        };
        private void btnAddTester_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.addTester(Tamar);
                MessageBox.Show("You have successfully added a tester");

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
                bl.addTrainee(Abigail);
                MessageBox.Show("You have successfully added a trainee");
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
                bl.addTest(MyTest);
                MessageBox.Show("You have successfully added a test");
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
                bl.deleteTester(Tamar);
                MessageBox.Show("you have successfully removed a tester");
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
                bl.deleteTrainee(Abigail);
                MessageBox.Show("you have successfully removed a trainee");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnRemoveTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.deleteTest(MyTest);
                MessageBox.Show("you have successfully removed a test");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdateTester_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateTester(Tamar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdateTrainee_Click(object sender, RoutedEventArgs e)
        {
            var trainee = bl.getTraineeList().Find(x => x.ID == 317801157);//the id can be given in a textbox in the future
            bl.updateTrainee(trainee);
            try
            {
                bl.updateTrainee(Abigail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdateTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateTest(MyTest);
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
                int found = bl.getTraineeNumOfTests(Abigail);
                MessageBox.Show(found.ToString());
                //MessageBox.Show(Abigail.ToString());

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
        private void btFindAllAvailbleTestrs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Tester> found = bl.getAllAvailbleTestrs(DateTime.Today, DateTime.Now.Hour);

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

        private void btTraineeNameOfteacer_Click(object sender, RoutedEventArgs e)
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
        private void btFindallavailableTester_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Tester> found = bl.getAllAvailbleTestrs(DateTime.Now, DateTime.Now.Hour);

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
        private void btreturnTestersByGearBox_Click(object sender, RoutedEventArgs e)
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
        private void btreturnTraineeBySchool_Click(object sender, RoutedEventArgs e)
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
        private void btreturnTraineesByNumOfTests_Click(object sender, RoutedEventArgs e)
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
        private void btnallTestsAccrodingToDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Tester> found = bl.getAllAvailbleTestrs(DateTime.Today, DateTime.Now.Hour);

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






        private void btreturnTestByCondition_Click(object sender, RoutedEventArgs e)
        {
            var found = bl.getTestByPredicate(x => x.passed == Success.passed);
            string temp = "";
            foreach (var item in found)
            {
                temp += item;
            }
            MessageBox.Show(temp, "Trainee that passed", MessageBoxButton.OK);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var found = bl.findById(Convert.ToInt32(txtFind.Text));
                if (found is BE.Test)
                    MessageBox.Show(((BE.Test)found).ToString());

                else if (found is BE.Tester)
                    MessageBox.Show(((BE.Tester)found).ToString());
                else if (found is BE.Trainee)
                    MessageBox.Show(((BE.Trainee)found).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnGetSuccessTraineesDay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Trainee> FailedTrainees = bl.getAllPassedTraineesDay();
                MessageBox.Show(FailedTrainees.Count.ToString());
                foreach (var item in FailedTrainees)
                {
                    MessageBox.Show(item.ToString());
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtidlike_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnFindTestersByDis_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

