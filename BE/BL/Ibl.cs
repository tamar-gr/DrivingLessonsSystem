using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface Ibl
    {
        void addTester(object t);
        void addTrainee(object t);
        void addTest(BE.Test t);
        void deleteTester(object t);
        void updateTester(object t);
        void deleteTrainee(object t);
        void updateTrainee(object t);
        void updateTest(object t);
        List<BE.Tester> getTestersList();
        List<BE.Trainee> getTraineeList();
        List<BE.Test> getTestsList();
        int numOfTests(object t);//
        IEnumerable<IGrouping<int, BE.Tester>> returnTestersByGearBox(bool ifToSort = false);
        IEnumerable<IGrouping<string, BE.Trainee>> returnTraineeBySchool(bool ifToSort = false);
        IEnumerable<IGrouping<string, BE.Trainee>> returnTraineeByTeacher(bool ifToSort = false);
        IEnumerable<IGrouping<int, BE.Trainee>> returnTraineesByNunOfTests(bool ifToSort = false);
        int getTraineeNumOfTests(int NumOfTests);
        int getGearBoxOfTester(BE.Gearbox g);
        int calculateDistance(string a, string b);
        List<BE.Tester> getAllTestersByDis(int a, string address);
        string passedTest(Object t);
        string getTraineeSchool(string NameOfSchool);
        string getTraineeTeacher(string NameOfTeacher);
        List<BE.Tester> getAllAvailbleTestrs(DateTime date, DateTime hour);
        List<BE.Test> getAlltestsInDate(DateTime date);
       
        
    }
}
