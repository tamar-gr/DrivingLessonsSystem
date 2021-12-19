using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace BE
{
    public class Tester
    {
        int id;
        string lastName;
        string firstName;
        DateTime testerBirth;
        string street;
        string buildingNum;
        string city;
        Gender testerGender;
        int phone;
        int experience;
        int maxTests;
        TypeCar my_Car;
        double maxDis;
        Gearbox testerGearbox;
        bool[,] schedulematrix = new bool[5, 6];
     //   System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:/Users/ioshu/Downloads/last/PLWPF/music");
        public Tester(int my_id, string my_firstName, string my_lastName, Gender my_testerGender, int my_phone, string my_street, string my_buildingNum, string my_city,
        DateTime my_testerBirth, TypeCar my_Car1, Gearbox my_testerGearbox,
        int my_experience, int my_maxTests, double my_maxDis)
        {
            //player.Play();

            ID = my_id;
            FirstName = my_firstName;
            LastName = my_lastName;
            TesterGender = my_testerGender;
            Phone = my_phone;
            Street = my_street;
            Experience = my_experience;
            MaxTests = my_maxTests;
            BuildingNum = my_buildingNum;
            City = my_city;
            TesterBirth = my_testerBirth;
            my_Car = my_Car1;
            TesterGearBox = my_testerGearbox;
            MaxDis = my_maxDis;

        }
       
            public Tester() { }
        public Tester(Tester other)
        {
            foreach (PropertyInfo property in other.GetType().GetRuntimeProperties())
                property.SetValue(this, property.GetValue(other));
        }

        public Gearbox TesterGearBox
        {
            get { return testerGearbox; }
            set { testerGearbox = value; }
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
        public DateTime TesterBirth
        {
            get { return testerBirth; }
            set { testerBirth = value; }
        }
        public Gender TesterGender
        {
            get { return testerGender; }
            set { testerGender = value; }
        }
        public TypeCar My_Car
        {
            get { return my_Car; }
            set { my_Car = value; }
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

        public bool[,] ScheduleMatrix
        {
            get { return schedulematrix; }
            set
            {
                schedulematrix = value;


            }

        }
        
        public override string ToString()
        {
            return ("Tester details:" + '\n' + "Id: " + id + '\n' + "First Name: " + firstName +
                '\n' + "Last Name: " + lastName + '\n' + "Tester Birth: " + TesterBirth + '\n' +
                "Tester's Street:" + street + '\n' + "Tester's buildingNum  " + buildingNum +
                '\n' + "City: " + city + '\n' + "Tester's Gender" + testerGender + '\n' + "Tester's Gearbox: " + TesterGearBox + '\n' + "phone number: " + phone + '\n'
                + "max tests in a week: " + maxTests + '\n' + "years of experience: " + experience + '\n' +
                "tester kind of vehicle: " + my_Car + '\n'
                + "maximum distance from trainee: " + maxDis);


        }

    }
}
