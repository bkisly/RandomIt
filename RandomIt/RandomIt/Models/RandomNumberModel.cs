using System;

namespace RandomIt.Models
{
    internal class RandomNumberModel
    {
        private readonly Random _random;

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int Precision { get; set; }

        public RandomNumberModel()
        {
            _random = new Random();
            MinValue = 0;
            MaxValue = 10;
            Precision = 1;
        }

        public int GenerateRandomInt()
        {
            return _random.Next((int)MinValue, (int)MaxValue + 1);
        }

        public double GenerateRandomDouble()
        {
            double distance = MaxValue - MinValue;
            double value = _random.NextDouble() * distance + MinValue;

            return Math.Round(value, Precision);
        }
    }
}
