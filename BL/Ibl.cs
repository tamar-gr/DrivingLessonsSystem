using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface Ibl
    {
        void addTester(object t);
        void addTrainee(object t);
        void addTest(Test t);
        int sumOfTestsInWeek(DateTime date, int tsterID);
        void deleteTester(Tester t);
        void updateTester(Tester t);//xmal
        void deleteTrainee(BE.Trainee t);
        void deleteTest(BE.Test t);

        void updateTrainee(Trainee t);//xmal
        void updateTest(Test t);//xmal
        List<BE.Tester> getTestersList();
        List<BE.Trainee> getTraineeList();
        List<BE.Test> getTestsList();
        int getTraineeNumOfTests(object t);
        IEnumerable<IGrouping<int, BE.Tester>> returnTestersByGearBox(bool ifToSort = false);
        IEnumerable<IGrouping<int, BE.Trainee>> returnTraineeBySchool(bool ifToSort = false);
        IEnumerable<IGrouping<string, BE.Trainee>> returnTraineeByTeacher(bool ifToSort = false);
        IEnumerable<IGrouping<int, BE.Trainee>> returnTraineesByNunOfTests(bool ifToSort = false);
        //int getTraineeNumOfTests(int NumOfTests);
        int getGearBoxOfTester(BE.Gearbox g);
        int Distance(string a, string b);
        //List<BE.Tester> getAllTestersByDis(int a, string address);
        string passedTest(Object t);
        int getTraineeSchool(BE.School NameOfSchool);
        string getTraineeTeacher(string NameOfTeacher);
        List<BE.Tester> getAllAvailbleTestrs(DateTime date, int hour);
        List<BE.Test> getAlltestsInDate(DateTime date);
        IEnumerable<Test> getTestByPredicate(Func<Test, bool> func);
        List<Tester> GetAllTestersByGearbox(Gearbox gearbox);
        List<Trainee> GetAllTraineeBySchool(BE.School school);
        List<Trainee> getAllPassedTraineesDay();
        //Double MarkOfTeacher(string NameOfTeacher);
        List<Trainee> AllPassedByVehicle(TypeCar vehicle);
        object findById(int num);
        void greenForm(Trainee t);
        bool TesterInRange(Tester tester, Address address);
        bool TestResult(Test test);
        void ChangePassword(string NewPassword);
        void UpdateConfig();
    }
}
