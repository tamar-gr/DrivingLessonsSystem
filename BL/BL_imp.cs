using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using BE;

namespace BL
{
    public class BL_imp : Ibl
    {
        DAL.Idal dal;
        static Random rnd = new Random();
        //ctor
        public BL_imp()
        {
            dal = DAL.FactoryDal.getDal();
        }
        // update delete add
        public void addTester(object t)
        {

            if (t is Tester)
            {
                DateTime tempmin = ((Tester)t).TesterBirth.AddYears(Configuration.MinAgeForTester);
                DateTime tempmax = ((Tester)t).TesterBirth.AddYears(Configuration.maxageTester);
                if (tempmin > DateTime.Today || tempmax < DateTime.Today)
                    throw new Exception(" The tester's age is illegal");
               
                else
                    dal.addTester((Tester) t);
            }
        }
        public void addTrainee(object t)
        {
            if (t is Trainee)
            {
                DateTime temp = ((Trainee)t).TraineeBirth.AddYears(Configuration.MinAgeForTrainee);
                if (temp > DateTime.Today)
                {
                    throw new Exception("too young to be a trainee");
                }
               
                else
                    dal.addTrainee((Trainee) t);
            }
        }
        public void addTest(Test t)
        {
            t.Mark = BE.Success.failed;
            t.Mirror = false;
            t.Parking = false;
            t.Reverse = false;
            t.Signaling = false;
            t.priority = false;
            t.passed = BE.Success.failed;
            if(getTestsList ().Exists(x=>x.Parking ==t.Parking||x.priority==t.priority||x.Reverse==t.Reverse||x.Signaling==t.Signaling||x.Mark==t.Mark))
            {
                throw new Exception("You didnt pass the test");
            }
            if (!(getTestersList().Exists(x => x.ID == t.TesterId)) || !(getTraineeList().Exists(x => x.ID == t.TraineeId)))
            {
                throw new Exception("We don't have in our system this trainee's ID or tester's ID");
            }
            int day = (int)t.Date.DayOfWeek;
            if (day > 5)
            {
                throw new Exception("worng day");//checks wrong day
            }
            if (t.Hour < 9 || t.Hour > 15)
            {
                throw new Exception("worng hour");//checks wrong hour
            }
            Tester testerOfTheTest = getTestersList().Find(x => x.ID == t.TesterId);//checks if id exsist in tester list
            if (testerOfTheTest.MaxTests == sumOfTestsInWeek(t.Date, testerOfTheTest.ID))//max test in week
            {
                DateTime temp = t.Date.AddDays(7);
                throw new Exception("The tester passed the number of weekly tests. you can try this date:" + temp.ToString());

            }
            if (testerOfTheTest.ScheduleMatrix[day, (t.Hour - 9)] == false)//date
            {

                throw new Exception("this tester doesn't work in this hour in this day ");
            }
           
            if (getTestsList().Find(x => x.TesterId == testerOfTheTest.ID && x.Date == t.Date && x.Hour == t.Hour) != null)//בדיקה שלטסטר אין מבחן אחר
            {
                DateTime date = AnotherDateForTest(t.Date, t.Hour);
                throw new Exception("this tester already has a test in this hour in this day. You can change to: " + date.ToString());
            }
            Trainee traineeOfTheTest = getTraineeList().Find(x => x.ID == t.TraineeId);
            if (getTestsList().Find(x => x.TraineeId == traineeOfTheTest.ID && x.Date == t.Date && x.Hour == t.Hour) != null)//checks tester doesnt have a test at the same time
            {
                throw new Exception("this trainee already has a test in this hour in this day");
            }
        
            if (!(getTraineeList().Exists(x => x.ID == ((BE.Test)t).TraineeId)))//id check
                throw new Exception(" trainee's ID not found");
            if (!(getTestersList().Exists(x => x.ID == ((BE.Test)t).TesterId)))
                throw new Exception(" tester's ID not found");
            var tempTrainee = getTraineeList().Find(x => x.ID == ((BE.Test)t).TraineeId);
            var tempTester = getTestersList().Find(x => x.ID == ((BE.Test)t).TesterId);
            int numOfDays = (DateTime.Today.Day) - tempTrainee.DateLastTest.Day;
            if (tempTester.TesterGearBox != tempTrainee.TraineeGearbox)// same gearbox for tester and trainee
                throw new Exception("The  tester's gearbox and the  trainee's gearbox are differents");
            if (tempTester.My_Car != tempTrainee.TraineeTypeCar)//same car type for tester and trainee
                throw new Exception("The  tester's Kind Of Vehicle and the  trainee's Kind Of Vehicle are differents");
            if (tempTrainee.NumOfTests >= 1 && numOfDays > BE.Configuration.rangeBetweenTests)//range between tests
            {
                var tempTest = getTestsList().Find(x => x.TraineeId == tempTrainee.ID);
                if (tempTest.GearBox == tempTrainee.TraineeGearbox && tempTest.Mark == BE.Success.passed && tempTest.TestTypeCar == tempTrainee.TraineeTypeCar)//בדיקה שלא עשה כבר את הבמחן הזה
                    throw new Exception("You already did this test on this vehicle  and passed the test! dont try again!!!");
                else
                {
                    dal.addTest(t);
                    getTraineeList().Find(x => x.ID == ((Test)t).TraineeId).NumOfTests++;
                }
            }
            else if (tempTrainee.NumOfTests >= 1 && numOfDays < BE.Configuration.rangeBetweenTests)
            {
                throw new Exception("the range between your tests is too small and needs to be at least over" + BE.Configuration.rangeBetweenTests.ToString() + " days ");
            }
            if (tempTrainee.NumOfTests == 0 && tempTrainee.NumOFLesson >= BE.Configuration.minNumOfLessons)//enough lessons
            {
                dal.addTest(t);
                (getTraineeList().Find(x => x.ID == ((Test)t).TraineeId)).NumOfTests++;
            }
            else throw new Exception("you need  at least " + Configuration.minNumOfLessons.ToString() + " lessons");



        }
        public int sumOfTestsInWeek(DateTime date, int testerID)
        {
            int sum = 0;
            DateTime temp = date;
            int dayOfWeek = (int)date.DayOfWeek;
            for (int i = 0; i <= dayOfWeek; i++)
            {
                temp.AddDays(-i);
                sum += getTestsList().FindAll(x => x.TesterId == testerID && x.Date == temp).Count;
                temp = date;
            }
            for (int i = 1; i <= 4 - dayOfWeek; i++)
            {
                temp.AddDays(i);
                sum += getTestsList().FindAll(x => x.TesterId == testerID && x.Date == temp).Count;
                temp = date;
            }
            return sum;
        }

        public void deleteTester(BE.Tester t)
        {

            dal.deleteTester(t);
        }
        public void updateTester(Tester t)
        {

           dal.updateTester(t);
        }
        public void deleteTrainee(BE.Trainee t)
        {

            dal.deleteTrainee(t);
        }
        public void updateTrainee(Trainee t)
        {
            dal.updateTrainee(t);
        }

        public void updateTest(Test t) 
        {
            dal.updateTest(t); 
        }
        // get tests/testers/trainees 
        public List<Tester> getTestersList()
        {
            return dal.getTestersList();
        }
    
        public List<Trainee> getTraineeList()
        {
            return dal.getTraineeList();
        }
        public List<Test> getTestsList()
        {
            return dal.getTestsList();
        }

        public int getTraineeNumOfTests(object t)//return number of tests per trainee
        {
            if (t is Trainee)
                return ((Trainee)t).NumOfTests;
            else return 0;
        }

        public IEnumerable<IGrouping<int, Tester>> returnTestersByGearBox(bool ifToSort = false) //מחזיר רשימה של בוחנים לפי תיבת הילוכים 
        {
            IEnumerable<IGrouping<int, Tester>> result = from Tester in getTestersList()
                                                         group Tester by getGearBoxOfTester(Tester.TesterGearBox) into TestersGroup
                                                         select TestersGroup;
            if (ifToSort == true)//sort by Experience
            {
                foreach (IGrouping<int, Tester> g in result)
                {
                    g.OrderBy(t => t.Experience);
                }
            }
            return result;
        }



        public IEnumerable<IGrouping<int, Trainee>> returnTraineeBySchool(bool ifToSort = false)
        {
            IEnumerable<IGrouping<int, Trainee>> result =
                from Trainee in getTraineeList()
                group Trainee by getTraineeSchool(Trainee.NameOfSchool) into TraineesGroup
                select TraineesGroup;

            if (ifToSort == true)//sort by name
            {
                return result.OrderBy(x => x.Key);
            }
            return result;
        }
        public List<Trainee> getAllSuccessTraineesDay()//return all the trainees that passed today
        {
            var lst = getTestsList().FindAll(x => x.Mark == Success.passed && x.Date == DateTime.Today);
            List<Trainee> SuccesTrainees = new List<Trainee>();
            foreach (var item in lst)
            {
                SuccesTrainees = getTraineeList().FindAll(x => x.ID == item.TraineeId);
            }
            return SuccesTrainees;
        }
        public IEnumerable<IGrouping<string, Trainee>> returnTraineeByTeacher(bool ifToSort = false)
        {
            IEnumerable<IGrouping<string, Trainee>> result =
                from Trainee in getTraineeList()
                group Trainee by getTraineeTeacher(Trainee.NameOfTeacher) into TraineesGroup
                select TraineesGroup;

            if (ifToSort == true)//sort by name
            {
                return result.OrderBy(x => x.Key);
            }
            return result;
        }

        public IEnumerable<IGrouping<int, Trainee>> returnTraineesByNunOfTests(bool ifToSort = false)
        {
            IEnumerable<IGrouping<int, Trainee>> result = from Trainee in getTraineeList()
                                                          group Trainee by getTraineeNumOfTests(Trainee.NumOfTests) into TraineesGroup
                                                          select TraineesGroup;


            if (ifToSort == true)//sort by name
            {
                return result.OrderBy(x => x.Key);
            }
            return result;
        }


        public int getGearBoxOfTester(Gearbox g)
        {
            if (g == 0)
                return 0;
            else return 1;
        }

        public int Distance(string a, string b)
        {
            int distance = rnd.Next(0, 200);
            return distance;
        }
        
        public string passedTest(Object t)
        {
            if (t is Trainee)
            {
                var tempTest = getTestsList().Find(x => x.TraineeId == ((Trainee)t).ID);
                if (tempTest.Mark == Success.passed)
                    return ("the trainee is entitled to a driving license, congradulations!!");
                else return ("the trainee is not entitled to a driving license, sorry");
            }
            else return "";
        }
        public int getTraineeSchool(School NameOfSchool)
        {
            if (NameOfSchool == School.drivingSchool)
                return 0;
            if (NameOfSchool == School.d_school)
                return 1;
            if (NameOfSchool == School.learningToDrive)
                return 2;

            else
                return 4;
        }
        public string getTraineeTeacher(string NameOfTeacher)
        {
            return NameOfTeacher;
        }
        public List<Tester> getAllAvailbleTestrs(DateTime date, int hour)
        {
            int day = (int)date.DayOfWeek;
            if (day > 5)
            {
                throw new Exception("worng day");
            }
            if (hour < 9 || hour > 15)
            {
                throw new Exception("worng hour");
            }
            List<Tester> AllAvailbleTestrs = getTestersList().FindAll(x => x.ScheduleMatrix[day, (hour - 9)] == true);//check if the tester is working
            List<Test> temp = getTestsList().FindAll(x => x.Hour == hour && x.Date == date);//all the tests in the same date & hour
            for (int i = 0; i < AllAvailbleTestrs.Count; i++)
            {
                AllAvailbleTestrs.RemoveAll(x => x.ID == temp[i].TesterId);//remove all testers that has a test in the same date and hour
            }
            return AllAvailbleTestrs;
        }
        public List<Test> getAlltestsInDate(DateTime date)//return all the tests per date
        {
            List<Test> AllTestsInDate = dal.getTestsList().FindAll(x => x.Date == date);
            return AllTestsInDate;
        }

        public DateTime AnotherDateForTest(DateTime OldDate, int OldHour)//return another date for test
        {
            OldDate.AddDays(1);
            while (getTestsList().Exists(x => x.Date == OldDate && x.Hour == OldHour) == true)
            {
                OldDate.AddDays(1);
            }
            return OldDate;
        }
        public List<Trainee> getAllPassedTraineesDay()//return all the trainees that passed today
        {
            var lst = getTestsList().FindAll(x => x.Mark == Success.passed && x.Date == DateTime.Today);
            List<Trainee> passedTrainees = new List<Trainee>();
            foreach (var item in lst)
            {
                passedTrainees = getTraineeList().FindAll(x => x.ID == item.TraineeId);
            }
            return passedTrainees;
        }
        public Double MarkOfTeacher(string NameOfTeacher)//return mark of teacher in precents 
        {
            var lst = getTraineeList().FindAll(x => x.NameOfTeacher == NameOfTeacher);
            Double count = 0;
            foreach (var item in lst)
            {
                if (getTestsList().Exists(x => x.TraineeId == item.ID && x.Mark == Success.passed))
                    ++count;//count all his trainees that passed the test
            }
            int NumOfTrainees = getTraineeList().Count;//all the trianees in the system
            return ((count / NumOfTrainees) * 100);

        }
        public List<Trainee> AllPassedByVehicle(TypeCar vehicle)//return all the trainees the passed test on a bus
        {
            var lst = getTestsList().FindAll(x => x.TestTypeCar == vehicle);
            var lst1 = new List<int>();
            foreach (var item in lst)
            {
                if (item.Mark == Success.passed)
                {
                    lst1.Add(item.TraineeId);
                }

            }
            List<Trainee> VehicleTrainees = new List<Trainee>();
            Trainee t;
            foreach (var item in lst1)
            {
                if (getTraineeList().Exists(x => x.ID == item))
                {
                    t = getTraineeList().Find(x => x.ID == item);
                    VehicleTrainees.Add(t);
                }
            }
            return VehicleTrainees;

        }
        public IEnumerable<Test> getTestByPredicate(Func<Test, bool> func)//return all the tests by predicate
        {
            var conditon = from item in getTestsList()
                           orderby item.numOfTest
                           where func(item) == true
                           select item;
            return conditon;

        }

        public object findById(int num)//return the object(trianee/ tester/ test) according to id/code of test
        {
            BE.Tester tester = getTestersList().Find(x => x.ID == num);
            if (tester != null)
                return tester;
            BE.Trainee trainee = getTraineeList().Find(x => x.ID == num);
            if (trainee != null)
                return trainee;
            BE.Test test = getTestsList().Find(x => x.numOfTest == num);
            if (test != null)
                return test;

            else
                throw new Exception("No such Id in our database.");

        }


        public List<Tester> GetAllTestersByGearbox(Gearbox gearbox)
        {
            var lst = getTestersList().FindAll(x => x.TesterGearBox == gearbox);
            List<Tester> GearboxTestrs = new List<Tester>();
            foreach (var item in lst)
            {
                GearboxTestrs.Add(item);
            }
            return GearboxTestrs;
        }

        public List<Trainee> GetAllTraineeBySchool(BE.School school)
        {
            var lst = getTraineeList().FindAll(x => x.NameOfSchool == school);
            List<Trainee> TraineeSchool = new List<Trainee>();
            foreach (var item in lst)
            {
                TraineeSchool.Add(item);
            }
            return TraineeSchool;
        }

        public void greenForm(Trainee t)
        {

            if (t.NumOfTests % 6 == 0)
            {
                throw new Exception(" needs a new Green Form ");

            }
        }

        public bool TesterInRange(Tester tester, Address address)
        {
            string origin = tester.Street + " " + tester.BuildingNum + " " + tester.City;
            string destination = address.City + " " + address.Street + " " + address.BuildingNum;
            if ((tester.Street == "") || (tester.BuildingNum == null) || (tester.City == "") ||
             (address.City == "") || (address.Street == "") || (address.BuildingNum == 0))
                return true;

            string KEY = @"EjPs2Wb9aFggzAVbnqIfON49uKZ24buv";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
             @"?key=" + KEY +
             @"&from=" + origin +
             @"&to=" + destination +
             @"&outFormat=xml" +
             @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
             @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);
                //display the returned driving time
                if (distInMiles * 1.609344 > tester.MaxDis && tester.MaxDis > 3)
                    return false;
            }
            return true;
        }
        public bool TestResult(Test t)
        {
            bool result = false;
            if (t.Mirror == true && t.priority == true && t.Parking == true && t.Reverse == true && t.Signaling == true)
            {
                t.passed= Success.passed;
                result = true;
            }

            return result;
        }
        public void deleteTest(BE.Test t)
        {
            dal.deleteTest(t);


        }
        public void ChangePassword(string NewPassword)
        {
            Configuration.Password = NewPassword;
        }
       public void  UpdateConfig()
        {
            dal.UpdateConfig();
        }
        //public string FirstTest( Trainee trainee )
        // {
        //        var temp=   getTraineeList().FindAll(x => x.NumOfTests == 1 && x.NameOfTeacher == trainee.NameOfTeacher);
        //     foreach (var temp1 in temp)
        //         {
        //         if(temp1==getTestsList().Exists(x=>x.passed==trainee))
        //     }
        // }
    }


}
