using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee
    {
        int id;
        string firstName;
        string lastName;
        Gender traineeGender;
        int phone;
        string street;
        int buildingNum;
        string city;
        DateTime traineeBirth;
        kindOfVehicle kindOfVehicle;
        Gearbox traineeGearbox;
        string nameOFSchool;
        string nameOfTeacher;
        int numOfLessons;
        DateTime dateLastTest;
        int numOfTests;

        //ctor
        public Trainee(DateTime my_LastTest= default(DateTime), int my_id= 01,string my_firstName="a" ,string my_lastName="b"
      , Gender my_traineeGender=0,int my_phone=5, string my_street="s", int my_buildingNum=1, string my_city="tlv",
        DateTime my_traineeBirth = new DateTime (),kindOfVehicle my_kindOfVehicle=0, Gearbox my_traineeGearbox=0,
        string my_nameOFSchool="drive", string my_nameOfTeacher="zeav", int my_numOfLessons=5, int my_numOfTests=0)
        {
            id = my_id;
            firstName = my_firstName;
            lastName = my_lastName;
            traineeGender = my_traineeGender;
            phone = my_phone;
            street = my_street;
            buildingNum = my_buildingNum;
            city = my_city;
            traineeBirth = my_traineeBirth;
            kindOfVehicle = my_kindOfVehicle;
            traineeGearbox = my_traineeGearbox;
            nameOFSchool = my_nameOFSchool;
            nameOfTeacher = my_nameOfTeacher;
            numOfLessons = my_numOfLessons;
            numOfTests = my_numOfTests;
            if (NumOfTests >= 1)
                dateLastTest = my_LastTest;    
        }
        
           
        //propeties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public Gender TraineeGender
        {
            get { return traineeGender; }
            set { traineeGender = value; }
        }
        public kindOfVehicle KindOfVehicle
        {
            get { return kindOfVehicle; }
            set { kindOfVehicle = value; }
        }
        public Gearbox TraineeGearbox
        {
            get { return traineeGearbox; }
            set { traineeGearbox = value; }
        }
        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public int BuildingNum
        {
            get { return buildingNum; }
            set { buildingNum = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public DateTime TraineeBirth////////
        {
            get { return traineeBirth; }
            set { traineeBirth = value; }
        }
        public DateTime DateLastTest////////
        {
            get { return dateLastTest; }
            set { dateLastTest = value; }
        }
        public string NameOfSchool
        {
            get { return nameOFSchool; }
            set { nameOFSchool = value; }
        }
        public string NameOfTeacher
        {
            get { return nameOfTeacher; }
            set { nameOfTeacher = value; }
        }
        public int NumOFLesson
        {
            get { return numOfLessons; }
            set { numOfLessons = value; }
        }
        public int NumOfTests
        {
            get { return numOfTests; }
            set { numOfTests = value; }
        }
        public override string ToString()
        {
            return ("Trainee details:" + '\n' + "Id: " + id + '\n' + "First Name: " + firstName +
                '\n' + "Last Name: " + lastName + '\n' + "Trainee's Birth: " + TraineeBirth + '\n' +
                "Trainee's Street:" + street + '\n' + "Tester's buildingNum  " + buildingNum +
                '\n' + "City" + city + '\n' + "Trainee's Gender:" + traineeGender + '\n'+ "phone number: " + phone + '\n'
                + "Trainee's gearbox: " + traineeGearbox + '\n'+ "Trainee's kind of vehicle: " + kindOfVehicle +
                '\n'+ "Name of school: " + nameOFSchool+ '\n'+ "Name of teacher:" + nameOfTeacher+ '\n'+ "Number of lessons:"+ NumOFLesson);


        }

    }
}
