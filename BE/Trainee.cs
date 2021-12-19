using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
       string buildingNum;
        string city;
        DateTime traineeBirth;
        TypeCar traineeTypeCar;
        Gearbox traineeGearbox;
        School nameOFSchool;
        string nameOfTeacher;
        int numOfLessons;
        DateTime dateLastTest;
        int numOfTests;
        string myPassword;
        
        
        public Trainee(DateTime my_LastTest, int my_id, string my_firstName, string my_lastName
         , Gender my_traineeGender, int my_phone, string my_street, string my_buildingNum, string my_city,
           DateTime my_traineeBirth, TypeCar my_traineeTypeCar, Gearbox my_traineeGearbox,
           School my_nameOFSchool, string my_nameOfTeacher, int my_numOfLessons, int my_numOfTests, string my_Password)
        {
            myPassword = my_Password;
            id = my_id;
            firstName = my_firstName;
            lastName = my_lastName;
            traineeGender = my_traineeGender;
            phone = my_phone;
            street = my_street;
            buildingNum = my_buildingNum;
            city = my_city;
            traineeBirth = my_traineeBirth;
            traineeTypeCar = my_traineeTypeCar;
            traineeGearbox = my_traineeGearbox;
            nameOFSchool = my_nameOFSchool;
            nameOfTeacher = my_nameOfTeacher;
            numOfLessons = my_numOfLessons;
            numOfTests = my_numOfTests;
            if (NumOfTests >= 1)
                dateLastTest = my_LastTest;
        }
        public Trainee(Trainee other)
        {
            foreach (PropertyInfo property in other.GetType().GetRuntimeProperties())
                property.SetValue(this, property.GetValue(other));


        }
      public  Trainee() { }
        //propeties
        public string MyPassword
        {
            get { return myPassword; }
            set { myPassword = value; }
        }
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
        public TypeCar TraineeTypeCar
        {
            get { return traineeTypeCar; }
            set { traineeTypeCar = value; }
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
        public string BuildingNum
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
        public School NameOfSchool
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
                '\n' + "City" + city + '\n' + "Trainee's Gender:" + traineeGender + '\n' + "phone number: " + phone + '\n'
                + "Trainee's gearbox: " + traineeGearbox + '\n' + "Trainee's kind of car: " + traineeTypeCar +
                '\n' + "Name of school: " + nameOFSchool + '\n' + "Name of teacher:" + nameOfTeacher + '\n' + "Number of lessons:" + NumOFLesson);


        }

    }
}
