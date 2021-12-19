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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        //create mothers
        BE.Mother estherAlvesson = new BE.Mother
        {
            Id = 111111111,
            FirstName = "ESTHER",
            LastName = "ALVESSON",
            Phone = "0545567789",
            Address = "HaRav Herzog St 12, Jerusalem",
            AddressArea = "Shakhal St 23,Jerusalem",
            MaxDistance = 3,
            NeedNanny = new bool[6] { true, true, false, true, false, true },
            Hours = new BE.DayHours[6] { new BE.DayHours( "sunday", 8, 16 ),
                                         new BE.DayHours("monday", 8,16),
                                         new BE.DayHours("tuesday", 0, 0),
                                         new BE.DayHours("wednesday", 8,16),
                                         new BE.DayHours("thursday", 0, 0),
                                         new BE.DayHours("friday",8, 12)},
            Comments = "good mommy"
        };
        BE.Mother yaelFox = new BE.Mother
        {
            Id = 222222222,
            FirstName = "YAEL",
            LastName = "FOX",
            Phone = "0589999999",
            Address = "Ha-'va'ad haleumi St 21,Jerusalem",
            AddressArea = "Shakhal St 23,Jerusalem",
            MaxDistance = 4,
            NeedNanny = new bool[6] { true, true, true, true, false, true },
            Hours = new BE.DayHours[6] { new BE.DayHours( "sunday", 8, 15 ),
                                         new BE.DayHours("monday", 8,15),
                                         new BE.DayHours("tuesday", 8, 15),
                                         new BE.DayHours("wednesday", 8,15),
                                         new BE.DayHours("thursday", 0, 0),
                                         new BE.DayHours("friday",8, 12)},
            Comments = "good mommy"
        };
        BE.Mother avigailFox = new BE.Mother
        {
            Id = 333333333,
            FirstName = "AVIGAIL",
            LastName = "FOX",
            Phone = "0547777777",
            Address = "HaMem Gimel St 4, Jerusalem",
            AddressArea = "Shakhal St 23,Jerusalem",
            MaxDistance = 3,
            NeedNanny = new bool[6] { true, true, false, true, false, true },
            Hours = new BE.DayHours[6] { new BE.DayHours( "sunday", 8, 16 ),
                                         new BE.DayHours("monday", 8,16),
                                         new BE.DayHours("tuesday", 0, 0),
                                         new BE.DayHours("wednesday", 8,16),
                                         new BE.DayHours("thursday", 0, 0),
                                         new BE.DayHours("friday",8, 12)},
            Comments = "good mommy"
        };
        //create children

        BE.Child daniella = new BE.Child
        {
            Id = 444444444,
            MotherId = 111111111,
            FirstName = "DANIELLA",
            DateOfBirth = new DateTime(2017, 07, 29),
            HaveSpecialNeeds = false,
            SpecialNeeds = "",
        };
        BE.Child ariella = new BE.Child
        {
            Id = 555555555,
            MotherId = 222222222,
            FirstName = "ARIELLA",
            DateOfBirth = new DateTime(2017, 07, 29),
            HaveSpecialNeeds = false,
            SpecialNeeds = "",
        };

        BE.Child gabriella = new BE.Child
        {
            Id = 666666666,
            MotherId = 333333333,
            FirstName = "GABRIELLA",
            DateOfBirth = new DateTime(2017, 06, 17),
            HaveSpecialNeeds = true,
            SpecialNeeds = "allergy to coconut",
        };
        //create nannies
        BE.Nanny shirCohen = new BE.Nanny
        {
            Id = 777777777,
            LastName = "COHEN",
            FirstName = "SHIR",
            DateOfBirth = new DateTime(1998, 01, 01),
            Phone = "0569980089",
            Address = "Bar Ilan St 15, Jerusalem",
            IsElevator = true,
            Floor = 2,
            NumExp = 15,
            MaxChildren = 5,
            MinAge = 3,
            MaxAge = 24,
            ByHour = true,
            HourWage = 30,
            MonthWage = 2500,
            VacationDays = true,
            IsWorkingToday = new bool[6] { true, true, false, true, false, true },
            Recommendations = "great nanny",
            WorkingHours = new BE.DayHours[6] { new BE.DayHours( "sunday", 8, 16 ),
                                         new BE.DayHours("monday", 8,16),
                                         new BE.DayHours("tuesday", 0,0 ),
                                         new BE.DayHours("wednesday", 8,16),
                                         new BE.DayHours("thursday", 0, 0),
                                         new BE.DayHours("friday",8, 12)},
            Likes = 3,
            DisLikes = 1,
        };
        BE.Nanny hadasaFox = new BE.Nanny
        {
            Id = 888888888,
            LastName = "FOX",
            FirstName = "HADASA",
            DateOfBirth = new DateTime(1997, 02, 03),
            Phone = "0569980089",
            Address = "Bar Ilan St 15, Jerusalem",
            IsElevator = false,
            Floor = 4,
            NumExp = 5,
            MaxChildren = 8,
            MinAge = 14,
            MaxAge = 36,
            ByHour = true,
            HourWage = 30,
            MonthWage = 3000,
            VacationDays = true,
            IsWorkingToday = new bool[6] { true, true, true, true, false, true },
            Recommendations = "great nanny",
            WorkingHours = new BE.DayHours[6] { new BE.DayHours( "sunday", 8, 15 ),
                                         new BE.DayHours("monday",8,15),
                                         new BE.DayHours("tuesday", 8,15 ),
                                         new BE.DayHours("wednesday", 8,15),
                                         new BE.DayHours("thursday", 0,0),
                                         new BE.DayHours("friday",8, 12)},
            Likes = 5,
            DisLikes = 3,
        };

        BE.Nanny shiraNahari = new BE.Nanny
        {
            Id = 999999999,
            LastName = "NAHARI",
            FirstName = "SHIRA",
            DateOfBirth = new DateTime(1998, 02, 02),
            Phone = "0598980089",
            Address = "Amram Gaon St 15, Jerusalem",
            IsElevator = false,
            Floor = 2,
            NumExp = 3,
            MaxChildren = 2,
            MinAge = 4,
            MaxAge = 24,
            ByHour = false,
            HourWage = 0,
            MonthWage = 2500,
            VacationDays = true,
            IsWorkingToday = new bool[6] { true, true, false, true, false, true },
            Recommendations = "great nanny",
            WorkingHours = new BE.DayHours[6] { new BE.DayHours( "sunday", 8, 16 ),
                                         new BE.DayHours("monday", 8,16),
                                         new BE.DayHours("tuesday", 0, 0),
                                         new BE.DayHours("wednesday", 8,16),
                                         new BE.DayHours("thursday",0 ,0),
                                         new BE.DayHours("friday",8, 16)},
            Likes = 5,
            DisLikes = 1,
        };



        BE.Contract first = new BE.Contract
        {
            IdNanny = 777777777,
            IdChild = 444444444,
            WasMeeting = true,
            WasContractSigned = false,
            HourWage = 0,
            MonthWage = 0,
            PaymentByHourOrMonth = true,
            StartOfEmployment = DateTime.Today,
            EndOfEmployment = new DateTime(2018, 01, 13),
            Distance = 0,//distance from mommy to nanny
        };
        BE.Contract second = new BE.Contract
        {
            IdNanny = 888888888,
            IdChild = 555555555,
            WasMeeting = true,
            WasContractSigned = false,
            HourWage = 0,
            MonthWage = 0,
            PaymentByHourOrMonth = true,
            StartOfEmployment = DateTime.Today,
            EndOfEmployment = new DateTime(2018, 01, 16),
            Distance = 0,//distance from mommy to nanny
        };
        BE.Contract third = new BE.Contract
        {
            IdNanny = 777777777,
            IdChild = 666666666,
            WasMeeting = true,
            WasContractSigned = false,
            HourWage = 0,
            MonthWage = 0,
            PaymentByHourOrMonth = true,
            StartOfEmployment = DateTime.Today,
            EndOfEmployment = new DateTime(2018, 02, 01),
            Distance = 0,//distance from mommy to nanny
        };



        private void btnAddNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.add(shiraNahari);
                bl.add(shirCohen);
                bl.add(hadasaFox);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.add(daniella);
                bl.add(gabriella);
                bl.add(ariella);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddMommy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.add(estherAlvesson);
                bl.add(yaelFox);
                bl.add(avigailFox);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.add(first);
                bl.add(second);
                bl.add(third);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRemoveNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.remove(shiraNahari);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRemoveContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.remove(first);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRemoveMommy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.remove(yaelFox);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.remove(daniella);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnFindNanny_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.findRelevantNannies(estherAlvesson);
            foreach (BE.Nanny item in lst)
            {
                MessageBox.Show(item.ToString());
            };

        }

        private void btnNoNanny_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.childrenWhoAreWithoutNanny();
            foreach (BE.Child item in lst)
            {
                MessageBox.Show(item.ToString());
            };
        }

        private void btnGetExpNannies_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getExperiencedNannies();
            foreach (BE.Nanny item in lst)
            {
                MessageBox.Show(item.ToString());
            };
        }

        private void btnGetFridayNannies_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getFridayNannies();
            foreach (BE.Nanny item in lst)
            {
                MessageBox.Show(item.ToString());
            };
        }

        //private void btngetChildrenOfNanny_Click(object sender, RoutedEventArgs e)
        //{
        //    var lst = bl.GetAllChildrenOfNanny(shirCohen);
        //    foreach (BE.Child item in lst)
        //    {
        //        MessageBox.Show(item.ToString());
        //    };
        //}

        //private void btnGetMotherChildren_Click(object sender, RoutedEventArgs e)
        //{
        //    var lst = bl.GetAllChildrenByMother(avigailFox);
        //    foreach (BE.Child item in lst)
        //    {
        //        MessageBox.Show(item.ToString());
        //    };

        //}

        private void btnGetExpiringContracts_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.monthExpiringContracts();
            foreach (BE.Contract item in lst)
            {
                MessageBox.Show(item.ToString());
            };

        }

        private void btnGetContracts_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getContractList();
            foreach (BE.Contract item in lst)
            {
                MessageBox.Show(item.ToString());
            };
        }

        private void btnGetnanies_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getNannyList();
            foreach (BE.Nanny item in lst)
            {
                MessageBox.Show(item.ToString());
            };
        }

        private void btnGetMommies_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getMotherList();
            foreach (BE.Mother item in lst)
            {
                MessageBox.Show(item.ToString());
            }

        }

        private void btnGetChildren_Click(object sender, RoutedEventArgs e)
        {
            var lst = bl.getChildrenList();
            foreach (BE.Child item in lst)
            {
                MessageBox.Show(item.ToString());
            }

        }
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var found = bl.findById(Convert.ToInt32(txtFind.Text));
                if (found is BE.Child)
                    MessageBox.Show(((BE.Child)found).ToString());
                else if (found is BE.Contract)
                    MessageBox.Show(((BE.Contract)found).ToString());
                else if (found is BE.Mother)
                    MessageBox.Show(((BE.Mother)found).ToString());
                else if (found is BE.Nanny)
                    MessageBox.Show(((BE.Nanny)found).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnUpdateNanny_Click_1(object sender, RoutedEventArgs e)
        {
            var nanny = bl.getNannyList().Find(x => x.Id == 999999999);//the id can be given in a textbox in the future
            nanny.MonthWage = 3700;
            bl.update(nanny);
        }
        private void btnUpdateChild_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateContract_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateMommy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFindChildren_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var found = bl.findById(Convert.ToInt32(txtFindChildren.Text));
                if (found is BE.Child)
                {
                    throw new Exception("no children per children. sorry :(");
                }
                else if (found is BE.Contract)
                    throw new Exception("no children per contract. sorry :(");
                else if (found is BE.Mother)
                {
                    var lst = bl.GetAllChildrenByMother((BE.Mother)(found));
                    foreach (BE.Child item in lst)
                    {
                        MessageBox.Show(item.ToString());
                    };
                }
                else if (found is BE.Nanny)
                {
                    var lst = bl.GetAllChildrenOfNanny((BE.Nanny)found);
                    foreach (BE.Child item in lst)
                    {
                        MessageBox.Show(item.ToString());
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPrintNanniesByMinAge_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnNanniesGroupedByAge(true, true);
            foreach (var group in result)
            {
                MessageBox.Show((group.Key).ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }
        }

        private void btnPrintContractsByDistance_Click(object sender, RoutedEventArgs e)
        {
            var result = bl.returnContractsGroupedByDistance(true);
            foreach (var group in result)
            {
                MessageBox.Show((group.Key).ToString());
                foreach (var itemInGroup in group)
                {
                    MessageBox.Show(itemInGroup.ToString());
                }
            }

        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var found = bl.findById(Convert.ToInt32(txtidlike.Text));
                if (found is BE.Nanny)
                    bl.addLike((BE.Nanny)found);
                else
                    throw new Exception("The id you entered is not a nanny's id.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDislike_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var found = bl.findById(Convert.ToInt32(txtidlike.Text));
                if (found is BE.Nanny)
                    bl.addDisLike((BE.Nanny)found);
                else
                    throw new Exception("The id you entered is not a nanny's id.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


    }
}
