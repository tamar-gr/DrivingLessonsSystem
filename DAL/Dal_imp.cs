using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;

namespace DAL
{
    public class Dal_imp : Idal

    {
        public Dal_imp()
        {
            //DataSource.testers = new List<Tester>();
            // DataSource.tests = new List<Test>();
            // DataSource.trainees = new List<Trainee>();
        }
        public void addTester(Tester t)
        {
            if (t is Tester)
            {
                if (!getTestersList().Exists(x => x.ID == ((Tester)t).ID))
                {
                    getTestersList().Add((Tester)t);
                }
                else throw new Exception("The operation was not accomplished. A tester with the same id already exists.");

            }

        }
        public void deleteTester(Tester t)
        {
            if (t is Tester && getTestersList().Exists(x => x.ID == ((Tester)t).ID))
            {
                var lst = getTestsList().FindAll(x => x.TesterId == ((Tester)t).ID);

                foreach (var item in lst)
                {
                    DataSource.tests.Remove(item);
                }
                DataSource.testers.Remove((Tester)t);

            }
            else throw new Exception("The operation was not accomplished. person not found");
        }
        public void updateTester(Tester t)
        {
            if (t is Tester && getTestersList().Exists(x => x.ID == ((Tester)t).ID))
            {
                int index = getTestersList().FindIndex(x => x.ID == ((Tester)t).ID);
                DataSource.testers[index] = (Tester)t;
            }
            else throw new Exception("The operation was not accomplished. Id not found");
        }
        public void addTrainee(Trainee t)
        {
            if (t is Trainee)
            {
                if (getTestersList().Exists(x => x.ID == ((Trainee)t).ID))
                {
                    throw new Exception("The operation was not accomplished.This id Already exists as a tester");

                }
                if (!getTraineeList().Exists(x => x.ID == ((Trainee)t).ID))
                {
                    getTraineeList().Add((Trainee)t);
                }
                else throw new Exception("The operation was not accomplished. A trainee with the same id already exists.");

            }

        }
        public void deleteTrainee(Trainee t)
        {
            if (t is Trainee && getTraineeList().Exists(x => x.ID == ((Trainee)t).ID))
            {
                var lst = getTestsList().FindAll(x => x.TraineeId == ((Trainee)t).ID);

                foreach (var item in lst)
                {
                    DataSource.tests.Remove(item);
                }
                DataSource.trainees.Remove((Trainee)t);

            }
            else throw new Exception("The operation was not accomplished. Person not found");


        }
        public void updateTrainee(Trainee t)
        {
            if (t is Trainee && getTraineeList().Exists(x => x.ID == ((Trainee)t).ID))
            {
                int index = getTraineeList().FindIndex(x => x.ID == ((Trainee)t).ID);
                DataSource.trainees[index] = (Trainee)t;
            }
            else throw new Exception("The operation was not accomplished. Id not found.");
        }
        public void addTest(Test t)
        {
            if (t is Test)
            {
                ((Test)t).numOfTest = Configuration.TestNum++;
                DataSource.tests.Add((Test)t);
            }

        }
        public void deleteTest(Test t)
        {
            if (t is Test && getTestsList().Exists(x => x.numOfTest == ((Test)t).numOfTest))
            {
                DataSource.tests.Remove(getTestsList().Find(x => x.numOfTest == ((Test)t).numOfTest));
            }
            else throw new Exception("The operation was not accomplished. test not found");
        }
        public void updateTest(Test t)
        {
            if (t is Test && getTestsList().Exists(x => x.numOfTest == ((Test)t).numOfTest))
            {
                int index = getTestsList().FindIndex(x => x.numOfTest == ((Test)t).numOfTest);
                DataSource.tests[index] = (Test)t;
            }
            else throw new Exception("The operation was not accomplished. Test not found");
        }
        public List<BE.Tester> getTestersList(Predicate<Tester> predicate = null)
        {

            //List<Tester> copy = DataSource.testers.GetRange(0, DataSource.testers.Count);
            //return copy;
            return DataSource.testers;
        }
        public List<Trainee> getTraineeList(Predicate<Trainee> predicate = null)
        {
            //List<Trainee> copy = DataSource.trainees.GetRange(0, DataSource.trainees.Count);
            //return copy;
            return DataSource.trainees;
        }
        public List<Test> getTestsList(Predicate<Test> predicate = null)
        {
            //List<Test> copy = DataSource.tests.GetRange(0,DataSource.tests.Count);
            // return copy;
            return DataSource.tests;
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
            throw new NotImplementedException();

        }
    }
}
