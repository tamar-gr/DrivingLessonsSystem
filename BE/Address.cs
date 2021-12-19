using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{/* בעיה ראשונה:
    שעושים עדכון למטריצה של הטסטר הוא עושה אינדקס מחוץ למערך
    בעיה שניה:
   true   הוא מחזיר תמידtestCondition 
      גם אם בטסט זה לא באמת ככה
      :בעיה שלשית
   הפונקציה שך למצוא את כל המבחנים לפי תאריך הוא לא מראה את הפרמטרים אלא מחזיר רשימה ריקה testFunnctionב
   בעיה רביעית:
   הוא לא מראה את הצקבוקס של הטסט*/
    public class Address
    {
        Tester tester = new Tester();
        string street;
        int buildingNum;
        string city;
        private string myCity;
        private string Building;

        public Address(string myCity, string Street, string Building)
        {
            this.myCity = myCity;
            this.Street = Street;
            this.Building = Building;
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
        public int BuildingNum
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
                this.city = City;
            }
        }
    }
}
