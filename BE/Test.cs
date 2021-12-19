using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace BE
{
    public class Test
    {
        int NumOfTest;
        int testerId;
        int traineeId;
        DateTime date;
        int TimeOfTest;
        string street;
        string buildingNum;
        string city;
        TypeCar testetTypeCar;
        Gearbox gearbox;//kind of gearbox
        Success mark;//trainees
        Success Passed;
         bool mirror;// בדק במראות
       bool reverse;//רוורס
        bool parking;//חנה נכון
      bool signaling;//אותת
        string note;
        bool Priority;//זכות קדימה
      
        
        public Test(int my_idOftester, int my_idOfTrainee, bool my_signaling, int NumOfTest, string my_note,
        bool my_parking, DateTime my_date, string my_street,string my_buildingNum, string my_city, Success my_mark, 
        bool my_mirror,bool my_priority,int my_timeOfTest, TypeCar my_testerTypeCar, Gearbox my_gearbox, Success my_passed, bool my_reverse)
       
    
        {
            NumOfTest = ++BE.Configuration.TestNum;
            testerId = my_idOftester;
            traineeId = my_idOfTrainee;
            date = my_date;
            TimeOfTest = my_timeOfTest;
            street = my_street;
            buildingNum = my_buildingNum;
            city = my_city;
            testetTypeCar = my_testerTypeCar;
            gearbox = my_gearbox;
            mark = my_mark;
            priority = my_priority;
            mirror = my_mirror;
            reverse = my_reverse;
            parking = my_parking;
            signaling = my_signaling;
            note = my_note;
            passed = my_passed;


        }
        public Test() { NumOfTest = ++BE.Configuration.TestNum; }
        public Test(Test other)//copy ctor
        {
            foreach (PropertyInfo property in other.GetType().GetRuntimeProperties())
                property.SetValue(this, property.GetValue(other));



        }
        public TypeCar TestTypeCar
        {
            get
            {
                return testetTypeCar;
            }
            set
            {
                testetTypeCar = value;
            }
        }
        public Gearbox GearBox
        {
            get
            {
                return gearbox;
            }
            set
            {
                gearbox = value;
            }
        }
        public int numOfTest
        {
            get
            {
                return NumOfTest;
            }
            set
            {
                NumOfTest = value;
            }

        }
       
        public int TesterId
        {
            get
            {
                return testerId;
            }
            set
            {
                testerId = value;
            }
        }
        public int TraineeId
        {
            get
            {
                return traineeId;
            }
            set
            {
                traineeId = value;
            }
        }
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }
        public string BuildingNum
        {
            get
            {
                return buildingNum;
            }
            set
            {
                buildingNum = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public int Hour
        {
            get
            {
                return TimeOfTest;
            }
            set
            {
                TimeOfTest = value;
            }
        }
        public Success Mark
        {
            get { return mark; }
            set { mark = value; }
        }
       
        public bool Mirror
        {
            get
            {
                return mirror;
            }
            set
            {
                mirror = value;
            }
        }
        public bool Reverse
        {
            get
            { return reverse; }
            set { reverse = value; }
        }
        public bool Parking
        {
            get { return parking; }
            set { parking = value; }
        }
        public bool Signaling
        {
            get
            {
                return signaling;
            }
            set
            {
                signaling = value;
            }
        }
        public bool priority
        {
            get
            {
                return Priority;
            }
            set
            {
                Priority = value;
            }
        }
        public Success passed

        {

            get
            {
                return Passed;
            }
            set
            {
                Passed = value;
            }
        }
public string Note
        {
            get
            {
                return note;
            }
            set
            {
                note = value;
            }
        }
       
        public override string ToString()
        {
            return ("Test's details" + '\n' + "Number of test: " + NumOfTest + '\n' + "id of tester: " + testerId +
                '\n' + "id of trainee: " + traineeId + '\n' + "Date of test: " + date + '\n' +
                "Test's Street:" + street + '\n' + "Test's buildingNum:  " + buildingNum +
                '\n' + "City:" + city + '\n' + "Mark:" + mark 
                + "Mirror: " + mirror + '\n' + "revers: " + reverse + '\n' + "Priority: "+priority +"Parking: " + parking + '\n'
                + "signaling: " + signaling);


        }
    }
}
