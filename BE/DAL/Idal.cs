using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {
        void addTester(object t);
        void deleteTester(object t);
        void updateTester(object t);
        void addTrainee(object t);
        void deleteTrainee(object t);
        void updateTrainee(object t);
        void addTest(object t);
        void deleteTest(object t);
        void updateTest(object t);
        List<BE.Tester> getTestersList();
        List<BE.Trainee> getTraineeList();
        List<BE.Test> getTestsList();
        IEnumerable<BE.Test> GetAllTestsByTester(BE.Tester tester);
        IEnumerable<BE.Test> GetAllTestsOfTrainee(BE.Trainee trainee);






    }
}
