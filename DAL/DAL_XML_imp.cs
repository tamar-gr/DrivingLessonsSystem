using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{

  public  class DAL_XML_imp : Idal
    {
        static DS.XmlDs Ds = DS.DSFactory.GetXmlDS();

        XElement TempRoot;
        XElement testerRoot;
        XElement traineeRoot;
        XElement testRoot;
        string testerPath = @"Tester1";
        string traineePath = @"Trainee1";
        string testPath = @"Test1";
        string TempPath = @"Temp1";//numTest
        public DAL_XML_imp()
        {
            if (!File.Exists(TempPath))
                CreateFileTemp();
            XElement help = XElement.Load(TempPath);
            Configuration.TestNum = int.Parse(help.Element("NumOfTest").Value);
            if (!File.Exists(TempPath))
                CreateFileTemp();            
            if (!File.Exists(testerPath))
                CreateTestersFiles();
            if (!File.Exists(traineePath))
                CreateTraineesFiles();
            if (!File.Exists(testPath))
                CreateTestsFiles();
           
            LoadTesters();
            LoadTrainees();
            LoadTests();

            XElement tempConfig = Ds.Configuration;
            // than foreach element in the file
            foreach (XElement item in tempConfig.Elements())
            {
                // check if it's value isn't null.
                if (item.Value != null)
                {
                    // finding the field in the configuration class with the name of the current elemnt
                    PropertyInfo configItem = typeof(Configuration).GetProperties().FirstOrDefault(e => e.Name == item.Name);
                    // if there was found an object with that name-
                    if (configItem != null && !configItem.Name.Contains("Pass"))
                    {
                        //case it is 1 of the 2 passwords - using the decrypting func. to load the value
                        // to the matching field


                        // else - simply loading the value from the element into the matching field
                        // of the configuration class
                        configItem.SetValue(configItem, Convert.ChangeType(item.Value, configItem.PropertyType));
                    }
                }
            }
        }
        private void CreateFileTemp()
        {
            TempRoot = new XElement("Number");
            TempRoot.Save(TempPath);
            XElement NumOfTest = new XElement("NumOfTest", "10000001");
            TempRoot.Add(NumOfTest);
            TempRoot.Save(TempPath);
            XElement help = XElement.Load(TempPath);
            Configuration.TestNum = int.Parse(help.Element("NumOfTest").Value);
        }
     
        private void CreateTestersFiles()
        {

            testerRoot = new XElement("testers");
            testerRoot.Save(testerPath);
        }
        private void CreateTraineesFiles()
        {

            traineeRoot = new XElement("trainees");
            traineeRoot.Save(traineePath);
        }
        private void CreateTestsFiles()
        {

            testRoot = new XElement("tests");
            testRoot.Save(testPath);
        }
        private void LoadTesters()
        {
            try
            {
                testerRoot = XElement.Load(testerPath);
            }
            catch
            {
                throw new Exception("Tester XML::File upload problem");
            }
        }
      
        private void LoadTrainees()
        {
            try
            {
                traineeRoot = XElement.Load(traineePath);
            }
            catch
            {
                throw new Exception("Trainee XML::File upload problem");
            }
        }
        private void LoadTests()
        {
            try
            {
                testRoot = XElement.Load(testPath);
            }
            catch
            {
                throw new Exception("Test XML::File upload problem");
            }
        }
        // get lists:
        public List<Tester> getTestersList(Predicate<Tester> predicate = null)
        {
            LoadTesters();
            List<Tester> testers = new List<Tester>();
            try
            {

                testers = (from p in testerRoot.Elements()
                           select new Tester()
                           {
                               ID = Convert.ToInt32(p.Element("id").Value),
                               FirstName = p.Element("name").Element("firstName").Value,
                               LastName = p.Element("name").Element("lastName").Value,
                               TesterBirth = Convert.ToDateTime(p.Element("testerBirth").Value),
                               TesterGender = (Gender)Enum.Parse(typeof(Gender), p.Element("testerGender").Value),
                               Phone = Convert.ToInt32(p.Element("phone").Value),
                               City = p.Element("address").Element("city").Value,
                               Street = p.Element("address").Element("street").Value,
                               BuildingNum = p.Element("address").Element("buildingNum").Value,
                               Experience = Convert.ToInt32(p.Element("experience").Value),
                               MaxTests = Convert.ToInt32(p.Element("maxTests").Value),
                               My_Car = (TypeCar)Enum.Parse(typeof(TypeCar), p.Element("my_Car").Value),
                               ScheduleMatrix = new bool[,] {
                                     {
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Sunday9pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Sunday10pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Sunday11pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Sunday12pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Sunday13pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Sunday14pm").Value),




                                       },
                                      {
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Monday9pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Monday10pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Monday11pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Monday12pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Monday13pm").Value),
                                           Convert.ToBoolean(p.Element("workingSchedule").Element("Monday14pm").Value),


                                       },
                                        {

                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Tuesday9pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Tuesday10pm").Value),
                                       Convert.ToBoolean(p.Element("workingSchedule").Element("Tuesday11pm").Value),
                                       Convert.ToBoolean(p.Element("workingSchedule").Element("Tuesday12pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Tuesday13pm").Value),
                                       Convert.ToBoolean(p.Element("workingSchedule").Element("Tuesday14pm").Value),

                                       },
                                        {
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Wednesday9pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Wednesday10pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Wednesday11pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Wednesday12pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Wednesday13pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Wednesday14pm").Value),
                                   },
                                   {

                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Thursday9pm").Value),
                                        Convert.ToBoolean(p.Element("workingSchedule").Element("Thursday10pm").Value),
                                       Convert.ToBoolean(p.Element("workingSchedule").Element("Thursday11pm").Value),
                                       Convert.ToBoolean(p.Element("workingSchedule").Element("Thursday12pm").Value),
                                       Convert.ToBoolean(p.Element("workingSchedule").Element("Thursday13pm").Value),
                                       Convert.ToBoolean(p.Element("workingSchedule").Element("Thursday14pm").Value),
                                   },

                               },
                               MaxDis = Convert.ToInt32(p.Element("maxDis").Value),
                               TesterGearBox = (Gearbox)Enum.Parse(typeof(Gearbox), p.Element("testerGearbox").Value),

                           }).ToList();

            }
            catch
            {
                testers = null;
                throw new Exception("problem in getTestersList");
            }
            return testers;
        }

        public List<Trainee> getTraineeList(Predicate<Trainee> predicate = null)
        {
            LoadTrainees();
            List<Trainee> trainees = new List<Trainee>();
            try
            {
                trainees = (from p in traineeRoot.Elements()
                            select new Trainee()
                            {
                                ID = Convert.ToInt32(p.Element("id").Value),
                                FirstName = p.Element("name").Element("firstName").Value,
                                LastName = p.Element("name").Element("lastName").Value,
                                TraineeBirth = Convert.ToDateTime(p.Element("traineeBirth").Value),
                                TraineeGender = (Gender)Enum.Parse(typeof(Gender), p.Element("traineeGender").Value),
                                Phone = Convert.ToInt32(p.Element("phone").Value),
                                City = p.Element("address").Element("city").Value,
                                Street = p.Element("address").Element("street").Value,
                                BuildingNum = p.Element("address").Element("buildingNum").Value,
                                NumOfTests = int.Parse(p.Element("numOfTests").Value),
                                DateLastTest = DateTime.Parse(p.Element("dateLastTest").Value),
                                TraineeTypeCar = (TypeCar)Enum.Parse(typeof(TypeCar), p.Element("traineeTypeCar").Value),
                                TraineeGearbox = (Gearbox)Enum.Parse(typeof(Gearbox), p.Element("traineeGearbox").Value),
                                NameOfSchool = (School)Enum.Parse(typeof(School), p.Element("nameOFSchool").Value),
                                NameOfTeacher = p.Element("nameOfTeacher").Value,
                                NumOFLesson = int.Parse(p.Element("numOfLessons").Value),

                            }).ToList();
            }
            catch
            {
                trainees = null;
                throw new Exception("problem in getTestersList");
            }
            return trainees;

        }

        public List<Test> getTestsList(Predicate<Test> predicate = null)
        {
            LoadTests();
            List<Test> tests = new List<Test>();
            try
            {
                tests = (from p in testRoot.Elements()
                         select new Test()
                         {
                             numOfTest = int.Parse(p.Element("numOfTest").Value),
                             TesterId = int.Parse(p.Element("testerId").Value),
                             TraineeId = int.Parse(p.Element("traineeId").Value),
                             Date = DateTime.Parse(p.Element("date").Value),
                             Hour = int.Parse(p.Element("hour").Value),
                             Street = p.Element("address").Element("street").Value,
                             BuildingNum = p.Element("address").Element("buildingNum").Value,
                             City = p.Element("address").Element("city").Value,
                             TestTypeCar = (TypeCar)Enum.Parse(typeof(TypeCar), p.Element("testetTypeCar").Value),
                             GearBox = (Gearbox)Enum.Parse(typeof(Gearbox), p.Element("gearbox").Value),
                             Mark = (Success)Enum.Parse(typeof(Success), p.Element("mark").Value),
                             passed = (Success)Enum.Parse(typeof(Success), p.Element("Passed").Value),
                             Mirror = bool.Parse(p.Element("mirror").Value),
                             Reverse = bool.Parse(p.Element("reverse").Value),
                             Parking = bool.Parse(p.Element("parking").Value),
                             Signaling = bool.Parse(p.Element("signaling").Value),
                             Note = p.Element("note").Value,
                             priority = bool.Parse(p.Element("Priority").Value),

                         }).ToList();
            }




            catch
            {
                tests = null;
                throw new Exception("problem in getTetsList");
            }
            return tests;

        }

        //ADD:
        public void addTester(Tester tester)
        {


            if (getTestersList().Exists(x => x.ID == tester.ID))
                throw new Exception("The operation was not accomplished. A tester with the same id already exists.");
            if (getTraineeList().Exists(x => x.ID == tester.ID))
                throw new Exception("The operation was not accomplished. A trainee with the same id already exists.");
            XElement id = new XElement("id", tester.ID);
            XElement firstName = new XElement("firstName", tester.FirstName);
            XElement lastName = new XElement("lastName", tester.LastName);
            XElement name = new XElement("name", firstName, lastName);
            XElement testerBirth = new XElement("testerBirth", tester.TesterBirth);
            XElement testerGender = new XElement("testerGender", tester.TesterGender);
            XElement phone = new XElement("phone", tester.Phone);
            XElement city = new XElement("city", tester.City);
            XElement street = new XElement("street", tester.Street);
            XElement buildingNum = new XElement("buildingNum", tester.BuildingNum);
            XElement address = new XElement("address", city, street, buildingNum);
            XElement experience = new XElement("experience", tester.Experience);
            XElement maxTests = new XElement("maxTests", tester.MaxTests);
            XElement my_Car = new XElement("my_Car", tester.My_Car);
            XElement hour1 = new XElement("Sunday9pm", tester.ScheduleMatrix[0, 0]);
            XElement hour2 = new XElement("Sunday10pm", tester.ScheduleMatrix[0, 1]);
            XElement hour3 = new XElement("Sunday11pm", tester.ScheduleMatrix[0, 2]);
            XElement hour4 = new XElement("Sunday12pm", tester.ScheduleMatrix[0, 3]);
            XElement hour5 = new XElement("Sunday13pm", tester.ScheduleMatrix[0, 4]);
            XElement hour6 = new XElement("Sunday14pm", tester.ScheduleMatrix[0, 5]);
            XElement hour7 = new XElement("Monday9pm", tester.ScheduleMatrix[1, 0]);
            XElement hour8 = new XElement("Monday10pm", tester.ScheduleMatrix[1, 1]);
            XElement hour9 = new XElement("Monday11pm", tester.ScheduleMatrix[1, 2]);
            XElement hour10 = new XElement("Monday12pm", tester.ScheduleMatrix[1, 3]);
            XElement hour11 = new XElement("Monday13pm", tester.ScheduleMatrix[1, 4]);
            XElement hour12 = new XElement("Monday14pm", tester.ScheduleMatrix[1, 5]);
            XElement hour13 = new XElement("Tuesday9pm", tester.ScheduleMatrix[2, 0]);
            XElement hour14 = new XElement("Tuesday10pm", tester.ScheduleMatrix[2, 1]);
            XElement hour15 = new XElement("Tuesday11pm", tester.ScheduleMatrix[2, 2]);
            XElement hour16 = new XElement("Tuesday12pm", tester.ScheduleMatrix[2, 3]);
            XElement hour17 = new XElement("Tuesday13pm", tester.ScheduleMatrix[2, 4]);
            XElement hour18 = new XElement("Tuesday14pm", tester.ScheduleMatrix[2, 5]);
            XElement hour19 = new XElement("Wednesday9pm", tester.ScheduleMatrix[3, 0]);
            XElement hour20 = new XElement("Wednesday10pm", tester.ScheduleMatrix[3, 1]);
            XElement hour21 = new XElement("Wednesday11pm", tester.ScheduleMatrix[2, 2]);
            XElement hour22 = new XElement("Wednesday12pm", tester.ScheduleMatrix[3, 3]);
            XElement hour23 = new XElement("Wednesday13pm", tester.ScheduleMatrix[3, 4]);
            XElement hour24 = new XElement("Wednesday14pm", tester.ScheduleMatrix[3, 5]);
            XElement hour25 = new XElement("Thursday9pm", tester.ScheduleMatrix[4, 0]);
            XElement hour26 = new XElement("Thursday10pm", tester.ScheduleMatrix[4, 1]);
            XElement hour27 = new XElement("Thursday11pm", tester.ScheduleMatrix[4, 2]);
            XElement hour28 = new XElement("Thursday12pm", tester.ScheduleMatrix[4, 3]);
            XElement hour29 = new XElement("Thursday13pm", tester.ScheduleMatrix[4, 4]);
            XElement hour30 = new XElement("Thursday14pm", tester.ScheduleMatrix[4, 5]);
            XElement scheduleArr = new XElement("workingSchedule", hour1, hour2, hour3, hour4, hour5, hour6, hour7, hour8, hour9, hour10, hour11, hour12, hour13, hour14, hour15, hour16,
                hour17, hour18, hour19, hour20, hour21, hour22, hour23, hour24, hour25, hour26, hour27, hour28, hour29, hour30);
            XElement maxDis = new XElement("maxDis", tester.MaxDis);
            XElement testerGearbox = new XElement("testerGearbox", tester.TesterGearBox);
            testerRoot.Add(new XElement("Tester", id, name, testerBirth, testerGender, phone, address, experience, maxTests, my_Car, scheduleArr, maxDis, testerGearbox));
            testerRoot.Save(testerPath);
        }


        public void addTrainee(Trainee trainee)
        {


            if (getTraineeList().Exists(x => x.ID == trainee.ID))

                throw new Exception("The operation was not accomplished. A trainee with the same id already exists.");
            else if (getTestersList().Exists(x => x.ID == trainee.ID))
            {
                throw new Exception("The operation was not accomplished. A tester with the same id already exists.");
            }
            else
            {
                XElement id = new XElement("id", trainee.ID);
                XElement firstName = new XElement("firstName", trainee.FirstName);
                XElement lastName = new XElement("lastName", trainee.LastName);
                XElement name = new XElement("name", firstName, lastName);
                XElement traineeBirth = new XElement("traineeBirth", trainee.TraineeBirth);
                XElement traineeGender = new XElement("traineeGender", trainee.TraineeGender);
                XElement phone = new XElement("phone", trainee.Phone);
                XElement street = new XElement("street", trainee.Street);
                XElement city = new XElement("city", trainee.City);
                XElement buildingNum = new XElement("buildingNum", trainee.BuildingNum);
                XElement address = new XElement("address", city, street, buildingNum);
                XElement nameOFSchool = new XElement("nameOFSchool", trainee.NameOfSchool);
                XElement nameOfTeacher = new XElement("nameOfTeacher", trainee.NameOfTeacher);
                XElement traineeTypeCar = new XElement("traineeTypeCar", trainee.TraineeTypeCar);
                XElement traineeGearbox = new XElement("traineeGearbox", trainee.TraineeGearbox);
                XElement dateLastTest = new XElement("dateLastTest", trainee.DateLastTest);
                XElement numOfTests = new XElement("numOfTests", trainee.NumOfTests);
                XElement numOfLessons = new XElement("numOfLessons", trainee.NumOFLesson);
                traineeRoot.Add(new XElement("Trainee", id, name, traineeBirth, traineeGender, phone,
                    address, nameOFSchool, nameOfTeacher, traineeTypeCar, traineeGearbox, dateLastTest, numOfTests, numOfLessons));
                traineeRoot.Save(traineePath);
            }

        }

        public void addTest(Test test)
        {
            test.numOfTest = test.numOfTest;
            XElement help = XElement.Load(TempPath);
            help.Element("NumOfTest").Value = Configuration.TestNum.ToString();
            help.Save(TempPath);


            XElement NumOfTest = new XElement("numOfTest", test.numOfTest);
            XElement testerId = new XElement("testerId", test.TesterId);
            XElement traineeId = new XElement("traineeId", test.TraineeId);
            XElement date = new XElement("date", test.Date);
            XElement TimeOfTest = new XElement("hour", test.Hour);
            XElement street = new XElement("street", test.Street);
            XElement city = new XElement("city", test.City);
            XElement buildingNum = new XElement("buildingNum", test.BuildingNum);
            XElement address = new XElement("address", city, street, buildingNum);
            XElement testetTypeCar = new XElement("testetTypeCar", test.TestTypeCar);
            XElement gearbox = new XElement("gearbox", test.GearBox);
            XElement mark = new XElement("mark", test.Mark);
            XElement Passed = new XElement("Passed", test.passed);
            XElement Priority = new XElement("Priority", test.priority);
            XElement mirror = new XElement("mirror", test.Mirror);
            XElement reverse = new XElement("reverse", test.Reverse);
            XElement parking = new XElement("parking", test.Parking);
            XElement signaling = new XElement("signaling", test.Signaling);
            XElement note = new XElement("note", test.Note);
            testRoot.Add(new XElement("Test", NumOfTest, testerId, traineeId, date, TimeOfTest, Passed,
                    address, testetTypeCar, gearbox, mark, Priority, mirror, reverse, parking, signaling, note));
            testRoot.Save(testPath);


        }

        //DELETE:
        public void deleteTester(Tester tester)//מחיקת טסטר מוחק גם מבחן אבל רק אחד
        {
            XElement testerElement;
            XElement testElenent;
            try
            {
                testerElement = (from p in testerRoot.Elements()
                                 where Convert.ToInt32(p.Element("id").Value) == tester.ID
                                 select p).FirstOrDefault();
                testerElement.Remove();
                testerRoot.Save(testerPath);
                testElenent = (from p in testRoot.Elements()
                               where Convert.ToInt32(p.Element("testerId").Value) == tester.ID
                               select p).FirstOrDefault();
                testElenent.Remove();
                testRoot.Save(testPath);
            }
            catch
            {
                throw new Exception("RemoveTester xml:: no such tester exists");
            }
        }

        public void deleteTrainee(Trainee trainee)//מוחק גם את המבחן אבל רק אחד
        {
            XElement traineeElement;
            XElement testElenent;
            try
            {
                traineeElement = (from p in traineeRoot.Elements()
                                  where Convert.ToInt32(p.Element("id").Value) == trainee.ID
                                  select p).FirstOrDefault();
                traineeElement.Remove();
                traineeRoot.Save(traineePath);
                testElenent = (from p in testRoot.Elements()
                               where Convert.ToInt32(p.Element("traineeId").Value) == trainee.ID
                               select p).FirstOrDefault();
                testElenent.Remove();
                testRoot.Save(testPath);
            }
            catch
            {
                throw new Exception("RemoveTrainee xml:: no such trainee exists");
            }
        }
        public void deleteTest(Test test)
        {
            XElement testElement;
            try
            {
                testElement = (from p in testRoot.Elements()
                               where Convert.ToInt32(p.Element("NumOfTest").Value) == test.numOfTest
                               select p).FirstOrDefault();
                testElement.Remove();
                testRoot.Save(testPath);
            }
            catch
            {
                throw new Exception("RemoveTest xml:: no such test exists");
            }
        }

        //UPDATE:
        public void updateTester(Tester tester)
        {
            XElement testerElement = (from p in testerRoot.Elements()
                                      where Convert.ToInt32(p.Element("id").Value) == tester.ID
                                      select p).FirstOrDefault();
            testerElement.Element("name").Element("firstName").Value = tester.FirstName;
            testerElement.Element("name").Element("lastName").Value = tester.LastName;
            testerElement.Element("testerBirth").Value = tester.TesterBirth.ToShortDateString();
            testerElement.Element("testerGender").Value = Enum.GetName(tester.TesterGender.GetType(), tester.TesterGender);
            testerElement.Element("phone").Value = Convert.ToString(tester.Phone);
            testerElement.Element("address").Element("city").Value = tester.City;
            testerElement.Element("address").Element("street").Value = tester.Street;
            testerElement.Element("address").Element("buildingNum").Value = tester.BuildingNum.ToString();
            testerElement.Element("experience").Value = tester.Experience.ToString();
            testerElement.Element("maxTests").Value = tester.MaxTests.ToString();
            testerElement.Element("my_Car").Value = Enum.GetName(tester.My_Car.GetType(), tester.My_Car);
            {
                testerElement.Element("workingSchedule").Element("Sunday9pm").Value = tester.ScheduleMatrix[0, 0].ToString();//ScheduleArr
                testerElement.Element("workingSchedule").Element("Sunday10pm").Value = tester.ScheduleMatrix[0, 1].ToString();
                testerElement.Element("workingSchedule").Element("Sunday11pm").Value = tester.ScheduleMatrix[0, 2].ToString();
                testerElement.Element("workingSchedule").Element("Sunday12pm").Value = tester.ScheduleMatrix[0, 3].ToString();
                testerElement.Element("workingSchedule").Element("Sunday13pm").Value = tester.ScheduleMatrix[0, 4].ToString();
                testerElement.Element("workingSchedule").Element("Sunday14pm").Value = tester.ScheduleMatrix[0, 5].ToString();
                testerElement.Element("workingSchedule").Element("Monday9pm").Value = tester.ScheduleMatrix[1, 0].ToString();
                testerElement.Element("workingSchedule").Element("Monday10pm").Value = tester.ScheduleMatrix[1, 1].ToString();
                testerElement.Element("workingSchedule").Element("Monday11pm").Value = tester.ScheduleMatrix[1, 2].ToString();
                testerElement.Element("workingSchedule").Element("Monday12pm").Value = tester.ScheduleMatrix[1, 3].ToString();
                testerElement.Element("workingSchedule").Element("Monday13pm").Value = tester.ScheduleMatrix[1, 4].ToString();
                testerElement.Element("workingSchedule").Element("Monday14pm").Value = tester.ScheduleMatrix[1, 5].ToString();
                testerElement.Element("workingSchedule").Element("Tuesday9pm").Value = tester.ScheduleMatrix[2, 0].ToString();
                testerElement.Element("workingSchedule").Element("Tuesday10pm").Value = tester.ScheduleMatrix[2, 1].ToString();
                testerElement.Element("workingSchedule").Element("Tuesday11pm").Value = tester.ScheduleMatrix[2, 2].ToString();
                testerElement.Element("workingSchedule").Element("Tuesday12pm").Value = tester.ScheduleMatrix[2, 3].ToString();
                testerElement.Element("workingSchedule").Element("Tuesday13pm").Value = tester.ScheduleMatrix[2, 4].ToString();
                testerElement.Element("workingSchedule").Element("Tuesday14pm").Value = tester.ScheduleMatrix[2, 5].ToString();
                testerElement.Element("workingSchedule").Element("Wednesday9pm").Value = tester.ScheduleMatrix[3, 0].ToString();
                testerElement.Element("workingSchedule").Element("Wednesday10pm").Value = tester.ScheduleMatrix[3, 1].ToString();
                testerElement.Element("workingSchedule").Element("Wednesday11pm").Value = tester.ScheduleMatrix[3, 2].ToString();
                testerElement.Element("workingSchedule").Element("Wednesday12pm").Value = tester.ScheduleMatrix[3, 3].ToString();
                testerElement.Element("workingSchedule").Element("Wednesday13pm").Value = tester.ScheduleMatrix[3, 4].ToString();
                testerElement.Element("workingSchedule").Element("Wednesday14pm").Value = tester.ScheduleMatrix[3, 5].ToString();
                testerElement.Element("workingSchedule").Element("Thursday9pm").Value = tester.ScheduleMatrix[4, 0].ToString();
                testerElement.Element("workingSchedule").Element("Thursday10pm").Value = tester.ScheduleMatrix[4, 1].ToString();
                testerElement.Element("workingSchedule").Element("Thursday11pm").Value = tester.ScheduleMatrix[4, 2].ToString();
                testerElement.Element("workingSchedule").Element("Thursday12pm").Value = tester.ScheduleMatrix[4, 3].ToString();
                testerElement.Element("workingSchedule").Element("Thursday13pm").Value = tester.ScheduleMatrix[4, 4].ToString();
                testerElement.Element("workingSchedule").Element("Thursday14pm").Value = tester.ScheduleMatrix[4, 5].ToString();
            }
            testerElement.Element("maxDis").Value = tester.MaxDis.ToString();
            testerElement.Element("testerGearbox").Value = Enum.GetName(tester.TesterGearBox.GetType(), tester.TesterGearBox);

            testerRoot.Save(testerPath);
        }
        public void updateTrainee(Trainee trainee)
        {
            XElement traineeElement = (from p in traineeRoot.Elements()
                                       where Convert.ToInt32(p.Element("id").Value) == trainee.ID
                                       select p).FirstOrDefault();
            traineeElement.Element("name").Element("firstName").Value = trainee.FirstName;
            traineeElement.Element("name").Element("lastName").Value = trainee.LastName;
            traineeElement.Element("traineeBirth").Value = trainee.TraineeBirth.ToShortDateString();
            traineeElement.Element("traineeGender").Value = Enum.GetName(trainee.TraineeGender.GetType(), trainee.TraineeGender);
            traineeElement.Element("phone").Value = Convert.ToString(trainee.Phone);
            traineeElement.Element("address").Element("city").Value = trainee.City;
            traineeElement.Element("address").Element("street").Value = trainee.Street;
            traineeElement.Element("address").Element("buildingNum").Value = trainee.BuildingNum.ToString();
            traineeElement.Element("traineeTypeCar").Value = Enum.GetName(trainee.TraineeTypeCar.GetType(), trainee.TraineeTypeCar);
            traineeElement.Element("traineeGearbox").Value = Enum.GetName(trainee.TraineeGearbox.GetType(), trainee.TraineeGearbox);
            traineeElement.Element("nameOFSchool").Value = Enum.GetName(trainee.NameOfSchool.GetType(), trainee.NameOfSchool);
            traineeElement.Element("nameOfTeacher").Value = trainee.NameOfTeacher;
            traineeElement.Element("dateLastTest").Value = trainee.DateLastTest.ToShortDateString();
            traineeElement.Element("numOfLessons").Value = trainee.NumOFLesson.ToString();
            traineeElement.Element("numOfTests").Value = trainee.NumOfTests.ToString();
            traineeRoot.Save(traineePath);
        }

        public void updateTest(Test test)
        {
            XElement testElement = (from p in testRoot.Elements()
                                    where Convert.ToInt32(p.Element("numOfTest").Value) == test.numOfTest
                                    select p).FirstOrDefault();
            testElement.Element("testerId").Value = test.TesterId.ToString();
            testElement.Element("traineeId").Value = test.TraineeId.ToString();
            testElement.Element("date").Value = test.Date.ToShortDateString();
            testElement.Element("hour").Value = test.Hour.ToString();
            testElement.Element("address").Element("city").Value = test.City;
            testElement.Element("address").Element("street").Value = test.Street;
            testElement.Element("address").Element("buildingNum").Value = test.BuildingNum.ToString();
            testElement.Element("testetTypeCar").Value = Enum.GetName(test.TestTypeCar.GetType(), test.TestTypeCar);
            testElement.Element("gearbox").Value = Enum.GetName(test.GearBox.GetType(), test.GearBox);
            testElement.Element("mark").Value = Enum.GetName(test.Mark.GetType(), test.Mark);
            testElement.Element("Passed").Value = Enum.GetName(test.passed.GetType(), test.passed);
            testElement.Element("Priority").Value = Convert.ToString(test.priority);
            testElement.Element("mirror").Value = Convert.ToString(test.Mirror);
            testElement.Element("reverse").Value = Convert.ToString(test.Reverse);
            testElement.Element("parking").Value = Convert.ToString(test.Parking);
            testElement.Element("signaling").Value = Convert.ToString(test.Signaling);
            testElement.Element("note").Value = test.Note;
            testRoot.Save(testPath);
        }


        public IEnumerable<Test> GetAllTestsByTester(Tester tester)
        {
            return getTestsList().FindAll(x => x.TesterId == tester.ID);
        }
        public IEnumerable<Test> GetAllTestsOfTrainee(Trainee trainee)
        {
            return getTestsList().FindAll(x => x.TesterId == trainee.ID);//
        }
        public void UpdateConfig()
        {
            // pulling each element of the configuration class , except the two passwords,
            IEnumerable<XElement> ConfigElements = from PropertyInfo it in typeof(Configuration).GetProperties()
                                                   where !it.Name.Contains("Password")
                                                   select new XElement(it.Name, it.GetValue(it));
            // than replacing the whole config.xml file with the "new" updated data
            Ds.Configuration.ReplaceAll(ConfigElements);
            Ds.SaveConfig();
        }
    }
}
