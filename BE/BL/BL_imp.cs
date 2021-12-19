using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_imp:Ibl
    {
        DAL.Idal dal;
        static Random rnd = new Random();
        //ctor
        public BL_imp()
        {
            dal = DAL.FactoryDal.getDal();
        }
        // update delete add
        public void addTester (object t)
        {
            if ( t is BE.Tester)
            {
              double age= (DateTime.Today.Year)-((BE.Tester)t).TesterBirth.Year;
                if (age >= BE.Configuration.minAgeTester && age < BE.Configuration.minAgeTester)
                    dal.addTester(t);
                else
                    throw new Exception(" The tester's age is illegal");
            }
        }
        public void addTrainee(object t)
        {
            if (t is BE.Trainee)
            {
                double age = (DateTime.Today.Year) - ((BE.Trainee)t).TraineeBirth.Year;
                if (age >= BE.Configuration.minAgeTrainee)
                    dal.addTrainee(t);
                else
                    throw new Exception("The trainee's age is illegal");
            }
        }
        public void addTest(BE.Test t)
        {

            int day = (int)t.Date.DayOfWeek;
            if (day > 5)
            {
                throw new Exception("worng day");
            }
            int hourday = t.Hour.Hour;
            if (hourday < 9 || hourday > 15)
            {
                throw new Exception("worng hour");
            }
            BE.Tester testerOfTheTest = getTestersList().Find(x => x.ID==t.IdOfTester);//ברשימת הטסטרים הוא מצא את הטסטר עם אותו תז
            if(testerOfTheTest.ScheduleMatrix[day,hourday]==false)
            {
                throw new Exception("this tester doesn't work in this hour in this day");
            }
                  
            if( getTestsList().Find(x => x.IdOfTester==testerOfTheTest.ID && x.Date==t.Date && x.Hour==t.Hour)!=null)
            {
                throw new Exception("this tester already has a test in this hour in this day");
            }
            BE.Trainee traineeOfTheTest = getTraineeList().Find(x => x.ID == t.IdOfTrainee);
            if (getTestsList().Find(x => x.IdOfTrainee== traineeOfTheTest.ID && x.Date == t.Date && x.Hour == t.Hour) != null)
            {
                throw new Exception("this trainee already has a test in this hour in this day");
            }
            ////////
            if (!getTraineeList().Exists(x => x.ID == ((BE.Test)t).IdOfTrainee))
                throw new Exception("The trainee's ID doesn't exist");
            if (!getTestersList().Exists(x => x.ID == ((BE.Test)t).IdOfTester))
                throw new Exception("The tester's ID doesn't exist");
            var tempTrainee = getTraineeList().Find(x => x.ID == ((BE.Test)t).IdOfTrainee);
            var tempTester = getTestersList().Find(x => x.ID == ((BE.Test)t).IdOfTester);
            int numOfDays = (DateTime.Today.Day) - tempTrainee.DateLastTest.Day;
            if(tempTester.TesterGearBox!=tempTrainee.TraineeGearbox)//הבוחן והנבחן על אותה תיבת הילוכים
                throw new Exception("The  tester's gearbox and the  trainee's gearbox are differents");
            if (tempTester.TesterkindOfVehicle!= tempTrainee.KindOfVehicle)//הבוחן והנבחן על אותו סוג רכב
                throw new Exception("The  tester's Kind Of Vehicle and the  trainee's Kind Of Vehicle are differents");
            if (tempTrainee.NumOfTests >= 1 && numOfDays > BE.Configuration.rangeFromTests)//כאשר יש לנבחן יותר ממבחן אחד בדיקה שעבר מספיק זמן
                {
                    var tempTest = getTestsList().Find(x => x.IdOfTrainee == tempTrainee.ID);
                    if (tempTest.GearBox == tempTrainee.TraineeGearbox && tempTest.Mark == BE.secces.passed && tempTest.KindOfVehicleTest == tempTrainee.KindOfVehicle)//בדיקה שלא עשה כבר את הבמחן הזה
                        throw new Exception("You already did this test on this vehicle  and passed the test! dont try again!!!");
                    else
                    {
                        dal.addTest(t);
                        (getTraineeList().Find(x => x.ID == ((BE.Test)t).IdOfTrainee)).NumOfTests++;
                    }
                }
                else
                    throw new Exception("the range between your tests is too small and needs to be at least over" + BE.Configuration.rangeFromTests.ToString() + " days ");
                if (tempTrainee.NumOfTests == 0 && tempTrainee.NumOFLesson >= BE.Configuration.nimNumOfLessons)//במידה וזה המבחן הראשון בדיקה שעשה מספיק שיעורים
                {
                    dal.addTest(t);
                    (getTraineeList().Find(x => x.ID == ((BE.Test)t).IdOfTrainee)).NumOfTests++;
                }
                else throw new Exception("you need  at least " + BE.Configuration.nimNumOfLessons.ToString() + " lessons");

            ///////////////////// לא גמרנו צריך להציע זמן אחר למבחן כאשר הטסטר לא פנוי 
            ///אין אפשרות להוסיף בוחן למבחן אם הבוחן עבר את מספר המבחנים השבועי הקצוב לו.
        }

        public void deleteTester(object t)
        {
            dal.deleteTester(t);
        }
        public void updateTester(object t)
        {
            dal.updateTester(t);
        }
       public void deleteTrainee(object t)
        {
            dal.deleteTrainee(t);
        }
        public void updateTrainee(object t)
        {
            dal.updateTrainee(t);
        }

        public void updateTest(object t)//לא ניתן לעדכן מבחן, כאשר לא קיימים כל השדות שהבוחן צריך למלא
        {
            dal.updateTest(t);
        }
        // get tests/testers/trainees 
        public List<BE.Tester> getTestersList()
        {
            return dal.getTestersList();
        }

        public List<BE.Trainee> getTraineeList()
        {
            return dal.getTraineeList();
        }
        public List<BE.Test> getTestsList()
        {
            return dal.getTestsList();
        }

        public int numOfTests(object t)//return number of tests per trainee
        {
            if (t is BE.Trainee)
                return ((BE.Trainee)t).NumOfTests;
            else return 0;
        }

        public IEnumerable<IGrouping<int, BE.Tester>> returnTestersByGearBox( bool ifToSort = false) //מחזיר רשימה של בוחנים לפי תיבת הילוכים 
        {
            IEnumerable<IGrouping<int, BE.Tester>> result=from Tester in getTestersList()
                    group Tester by getGearBoxOfTester(Tester.TesterGearBox) into TestersGroup
                    select TestersGroup;
           if (ifToSort == true)//sort by Experience
            {
                foreach (IGrouping<int, BE.Tester> g in result)
                {
                    g.OrderBy(t => t.Experience);
                }
            }
            return result;
        }

       

        public IEnumerable<IGrouping<string, BE.Trainee>> returnTraineeBySchool(bool ifToSort = false)
        {
            IEnumerable<IGrouping<string, BE.Trainee>> result = 
                from Trainee in getTraineeList()
                group Trainee by getTraineeSchool(Trainee.NameOfSchool) into TraineesGroup
                select TraineesGroup;

            if (ifToSort == true)//sort by name
            {
                foreach (IGrouping<int, BE.Trainee> g in result)
                {
                    g.OrderBy(t => t);
                }
            }
            return result;
        }
        public IEnumerable<IGrouping<string, BE.Trainee>> returnTraineeByTeacher(bool ifToSort = false)
        {
            IEnumerable<IGrouping<string, BE.Trainee>> result =
                from Trainee in getTraineeList()
                group Trainee by getTraineeTeacher(Trainee.NameOfTeacher) into TraineesGroup
                select TraineesGroup;

            if (ifToSort == true)//sort by name
            {
                foreach (IGrouping<int, BE.Trainee> g in result)
                {
                    g.OrderBy(t => t);
                }
            }
            return result;
        }

        public IEnumerable<IGrouping<int, BE.Trainee>> returnTraineesByNunOfTests(bool ifToSort = false)  
        {
            IEnumerable<IGrouping<int, BE.Trainee>> result = from Trainee in getTraineeList()
                                                            group Trainee by getTraineeNumOfTests(Trainee.NumOfTests) into TraineesGroup
                                                             select TraineesGroup;


            if (ifToSort == true)//sort by name
            {
                foreach (IGrouping<int, BE.Trainee> g in result)
                {
                    g.OrderBy(t => t);
                }
            }
            return result;
        }

        public int getTraineeNumOfTests(int NumOfTests)
        {
            return NumOfTests;
        }
        public int getGearBoxOfTester(BE.Gearbox g)
        {
            if (g == 0)
                return 0;
            else return 1;
        }
        public int calculateDistance(string a , string b)
        {
            int distance =rnd.Next(0, 200);
            return distance;
        }
        public List<BE.Tester> getAllTestersByDis(int a, string address)
        {

            List<BE.Tester> closeTesters = getTestersList().FindAll(x => calculateDistance(address, x.Street) <= a);
                return closeTesters;
        }
        public string passedTest(Object t)
        {
            if (t is BE.Trainee)
            {
                var tempTest = getTestsList().Find(x => x.IdOfTrainee == ((BE.Trainee)t).ID);
                if (tempTest.Mark == BE.secces.passed)
                    return ("the trainee is entitled to a driving license, congradulations!!");
                else return ("the trainee is not entitled to a driving license, sorry");
            }
            else return "";
        }
        public string getTraineeSchool (string NameOfSchool)
        {
            return NameOfSchool;
        }
        public  string getTraineeTeacher(string NameOfTeacher)
        {
            return NameOfTeacher;
        }
        public List<BE.Tester> getAllAvailbleTestrs( DateTime date, DateTime hour)
        {
            int day = (int)date.DayOfWeek;
            if (day>5)
            {
                throw new Exception("worng day");
            }
            int hourday = hour.Hour;
            if(hourday<9||hourday>15)
            {
                throw new Exception("worng hour");
            }
            List<BE.Tester> AllAvailbleTestrs = getTestersList().FindAll(x => x.ScheduleMatrix[day, hourday] == true);//check if the tester is working
            List<BE.Test> temp = getTestsList().FindAll(x => x.Hour == hour && x.Date == date);//all the tests in the same date & hour
            for( int i=0; i < AllAvailbleTestrs.Count; i++)
            {
                AllAvailbleTestrs.RemoveAll(x => x.ID == temp[i].IdOfTester);//remove all testers that has a test in the same date and hour
            }
            return AllAvailbleTestrs;
        }
        public List<BE.Test> getAlltestsInDate(DateTime date)
        {
           List<BE.Test> AllTestsInDate = dal.getTestsList().FindAll(x => x.Date == date);
           return AllTestsInDate;
        }
    }
}
