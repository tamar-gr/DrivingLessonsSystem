using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester
    {
        int id;
        string lastName;
        string firstName;
        DateTime testerBirth;
        string street;
        int buildingNum;
        string city;
        Gender testerGender;
        int phone;
        int experience;
        int maxTests;
        kindOfVehicle testerkindOfVehicle;
        double maxDis;
        Gearbox testerGearbox;
        bool [,] schedulematrix= new bool [5,6];

        public Tester(int my_id = 01, string my_firstName = "a", string my_lastName = "b"
      , Gender my_testerGender = 0, int my_phone = 5, string my_street = "s", int my_buildingNum = 1, string my_city = "tlv",
        DateTime my_testerBirth = new DateTime(), kindOfVehicle my_kindOfVehicle = 0, Gearbox my_testerGearbox = 0,
        int my_experience=1, int my_maxTests=5, double my_maxDis=2)
        {
            id = my_id;
            firstName = my_firstName;
            lastName = my_lastName;
            testerGender = my_testerGender;
            phone = my_phone;
            street = my_street;
            experience = my_experience;
            maxTests = my_maxTests;
            buildingNum = my_buildingNum;
            city = my_city;
            testerBirth = my_testerBirth;
            testerkindOfVehicle = my_kindOfVehicle;
            testerGearbox = my_testerGearbox;
            maxDis = my_maxDis;
        }

        public Gearbox TesterGearBox
        {
            get { return testerGearbox; }
            set { testerGearbox = value; }
        }
        public int ID
        {
            get { return id;}
            set{id = value;}
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string  FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public DateTime TesterBirth////////
        {
            get { return testerBirth; }
            set { testerBirth = value; }
        }
        public Gender TesterGender
        {
            get { return testerGender; }
            set { testerGender = value; }
        }
        public kindOfVehicle TesterkindOfVehicle
        {
            get { return testerkindOfVehicle; }
            set { testerkindOfVehicle = value; }
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
        
        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public int MaxTests
        {
            get { return maxTests; }
            set { maxTests = value; }
        }
        ////
        public double MaxDis
        {
            get { return maxDis; }
            set { maxDis = value; }
            
        }
       
        public bool [,] ScheduleMatrix
        {
            get { return schedulematrix ; }
            set { schedulematrix = value; }

        }
        public override string ToString()
        {
            return ("Tester details:"+ '\n'+ "Id: " + id + '\n' + "First Name: " + firstName + 
                '\n' + "Last Name: " + lastName + '\n' + "Tester Birth: " + TesterBirth + '\n'+
                "Tester's Street:" + street +'\n' + "Tester's buildingNum  " + buildingNum + 
                '\n' + "City" + city + '\n' + "Tester's Gender" + testerGender + '\n' + "phone number: "+phone + '\n'
                + "max tests in a week: "+ maxTests + '\n' + "years of experience: "+ experience + '\n' +
                "tester kind of vehicle: "  + testerkindOfVehicle + '\n'
                + "maximum distance from tester: " + maxDis);
          
 
        }

    }
}
