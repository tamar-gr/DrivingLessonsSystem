using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Dal_imp:Idal
    {
       public void addTester(object t)
        {
           if(t is BE.Tester)
            {
                if (!getTestersList().Exists(x => x.ID == ((BE.Tester)t).ID))
                {
                    getTestersList().Add((BE.Tester)t);
                }
                else throw new Exception ("The operation was not accomplished. A tester with the same id already exists.");

            }

        }
        public void deleteTester(object t)
        {
            if (t is BE.Tester && getTestersList().Exists(x => x.ID == ((BE.Tester)t).ID))
            {
                DS.DataSource.testers.Remove(getTestersList().Find(x => x.ID == ((BE.Tester)t).ID));
            }
            else throw new Exception("The operation was not accomplished. No such person");
        }
        public void updateTester(object t)
        {
           if (t is BE.Tester && getTestersList().Exists(x => x.ID == ((BE.Tester)t).ID))
            {
                int index = getTestersList().FindIndex(x => x.ID == ((BE.Tester)t).ID);
                DS.DataSource.testers[index] = (BE.Tester)t;
            }
           else throw new Exception("The operation was not accomplished. A tester with this  id isn't exists.");
        }
        public void addTrainee(object t)
        {
            if (t is BE.Trainee)
            {
                if (!getTraineeList().Exists(x => x.ID == ((BE.Trainee)t).ID))
                {
                    getTraineeList().Add((BE.Trainee)t);
                }
                else throw new Exception ("The operation was not accomplished. A trainee with the same id already exists.");
            }

        }
        public void deleteTrainee(object t)
        {
            if (t is BE.Trainee && getTraineeList().Exists(x => x.ID == ((BE.Trainee)t).ID))
            {
                DS.DataSource.trainees.Remove(getTraineeList().Find(x => x.ID == ((BE.Trainee)t).ID));

            }
            else throw new Exception("The operation was not accomplished. No such person");

        }
        public void updateTrainee(object t)
        {
            if (t is BE.Trainee && getTraineeList().Exists(x => x.ID == ((BE.Trainee)t).ID))
            {
                int index = getTraineeList().FindIndex(x => x.ID == ((BE.Trainee)t).ID);
                DS.DataSource.trainees[index] = (BE.Trainee)t;
            }
            else throw new Exception("The operation was not accomplished. A trainee with this  id isn't exists.");
        }
        public void addTest(object t)
        {
            if (t is BE.Test)
            {
                ((BE.Test)t).NumOfTest = BE.Configuration.TestNum++;
                DS.DataSource.tests.Add((BE.Test)t);
            }

        }
        public void deleteTest(object t)
        {
            if (t is BE.Test && getTestsList().Exists(x => x.NumOfTest == ((BE.Test)t).NumOfTest))
                DS.DataSource.tests.Remove(getTestsList().Find(x => x.NumOfTest == ((BE.Test)t).NumOfTest));
            else throw new Exception("The operation was not accomplished. No such test");
        }
        public void updateTest(object t)
        {
            if(t is BE.Test && getTestsList().Exists(x => x.NumOfTest == ((BE.Test)t).NumOfTest))
            {
                int index = getTestsList().FindIndex(x => x.NumOfTest == ((BE.Test)t).NumOfTest);
                DS.DataSource.tests[index] = (BE.Test)t;
            }
            else throw new Exception("The operation was not accomplished. U are trying to update test that not exists");
        }
        public  List<BE.Tester> getTestersList()
        {
            return DS.DataSource.testers;
        }
      public  List<BE.Trainee> getTraineeList()
        {
            return DS.DataSource.trainees;
        }
       public List<BE.Test> getTestsList()
        {
            return DS.DataSource.tests;
        }
        public IEnumerable<BE.Test> GetAllTestsByTester(BE.Tester tester)
        {
            return getTestsList().FindAll(x => x.IdOfTester == tester.ID);
        }
        public IEnumerable<BE.Test> GetAllTestsOfTrainee(BE.Trainee trainee)
        {
            return getTestsList().FindAll(x => x.IdOfTester == trainee.ID);
        }
    }
}
