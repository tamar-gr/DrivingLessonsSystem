using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface Idal
    {
        //add
        void addTester(Tester t);
        void addTrainee(Trainee t);
        void addTest(Test t);
        //delete
        void deleteTester(Tester t);
        void deleteTest(Test t);
        void deleteTrainee(Trainee t);
        //update
        void updateTrainee(Trainee t);
        void updateTester(Tester t);
        void updateTest(Test t);
        //lists
        List<BE.Tester> getTestersList(Predicate<BE.Tester> predicate = null);
        List<BE.Trainee> getTraineeList(Predicate<BE.Trainee> predicate = null);
        List<BE.Test> getTestsList(Predicate<BE.Test> predicate = null);
        IEnumerable<BE.Test> GetAllTestsByTester(BE.Tester tester);
        IEnumerable<BE.Test> GetAllTestsOfTrainee(BE.Trainee trainee);
        void UpdateConfig();
    }
}
