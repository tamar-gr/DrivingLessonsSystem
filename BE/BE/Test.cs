using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        int numOfTest;
        int idOftester;
        int idOfTrainee;
        DateTime date;
        DateTime hour;
        string street;
        int buildingNum;
        string city;
        kindOfVehicle kindOfVehicleTest;
        Gearbox gearbox;//סוג תיבת הילוכים
        secces mark;//ציון הנבחן
        secces keepDis;//שמר מרחק
        secces mirror;// בדק במראות
        secces revers;//רוורס
        secces parking;//חנה נכון
        secces signaling;//אותת
        string note;

        public Test(int my_numOfTest=00000000,int my_idOftester=01,int my_idOfTrainee=01,
        DateTime my_date=new DateTime () , string my_street="s",int my_buildingNum=1,string my_city="tlv", 
        secces my_mark=0, secces my_keepDis=0, secces my_mirror=0, 
        secces my_revers=0, secces my_parking=0, secces my_signaling=0, string my_note="this trainee is the best!!")
        {
            numOfTest = my_numOfTest;
            idOftester = my_idOftester;
            idOfTrainee = my_idOfTrainee;
            date = my_date;
            street = my_street;
            buildingNum = my_buildingNum;
            city = my_city;
            mark = my_mark;
            keepDis = my_keepDis;
            mirror = my_mirror;
            revers = my_revers;
            parking = my_parking;
            signaling = my_signaling;
            note = my_note;

        }
        public kindOfVehicle KindOfVehicleTest
        {
            get { return kindOfVehicleTest; }
            set { kindOfVehicleTest = value; }
        }
        public Gearbox GearBox
        {
            get { return gearbox; }
            set { gearbox = value; }
        }
        public int NumOfTest
        {
            get { return numOfTest; }
            set { numOfTest = value; }
        }
        public  int IdOfTester
        {
            get { return idOftester; }
            set { idOftester = value; }
        }
        public int IdOfTrainee
        {
            get { return idOfTrainee; }
            set { idOfTrainee = value; }
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
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public DateTime Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        public secces Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public secces KeepDis
        {
            get { return keepDis; }
            set { keepDis= value; }
        }
        public secces Mirror
        {
            get { return mirror; }
            set { mirror = value; }
        }
        public secces Revers
        {
            get { return revers; }
            set { revers = value; }
        }
        public secces Parking
        {
            get { return parking; }
            set { parking = value; }
        }
        public secces Signaling
        {
            get { return signaling; }
            set { signaling = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public override string ToString()
        {
            return ("Test's details" + '\n' + "Number of test: " + numOfTest + '\n' + "id of tester: " + IdOfTester +
                '\n' + "id of trainee: " + IdOfTrainee + '\n' + "Date of test: " + date + '\n' +
                "Test's Street:" + street + '\n' + "Test's buildingNum:  " + buildingNum +
                '\n' + "City:" + city + '\n' + "Mark:" + mark +'\n' +  "keep distance: " + keepDis+ '\n' 
                + "Mirror: " + mirror + '\n' + "revers: " + revers + '\n' + "Parking: " + parking + '\n'
                + "signaling: " + signaling);


        }
    }
}
