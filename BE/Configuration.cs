using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BE
{
    public class Configuration
    {
        public static int MinAgeForTester = 40;//tester must be minimum 40 years old
        public static int MinAgeForTrainee = 18;//trainee must be minimum 18 years old
        public static int minNumOfLessons = 20;//trainee must do minimum 20 lessons before a test
        public static int rangeBetweenTests = 7;//between tes and test trainee hve to wait at least 7 days
        public static int MaxAgeForTester = 70;
        public static int TestNum = 10000000;
        public static int maxageTester = 95;
        public static string Password = "123456";//password

    }

}
