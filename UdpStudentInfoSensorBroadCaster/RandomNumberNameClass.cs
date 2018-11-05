using System;
using RandomNameGenerator;

namespace UdpStudentInfoSensorBroadCaster
{
    class RandomNumberNameClass
    {
        private Random _randomId;
        private Random _randomAge;
        public RandomNumberNameClass()
        {
            _randomId = new Random();
            _randomAge = new Random();
        }
        public int GetId()
        {
            return _randomId.Next(100);
        }
        public int GetAge()
        {
            return _randomAge.Next(20, 40);
        }
        public static string GetName(int i)
        {
            if (i % 2 == 0)
            {
                return NameGenerator.Generate(Gender.Male);
            }
            else
            {
                return NameGenerator.Generate(Gender.Female);
            }

        }
    }
}
