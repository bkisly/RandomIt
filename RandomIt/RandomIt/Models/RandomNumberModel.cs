using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIt.Models
{
    internal class RandomNumberModel
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int Precision { get; set; }

        private Random _random;

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
            int poweredPrecision = (int)Math.Pow(10, Precision);
            int min = (int)MinValue * poweredPrecision;
            int max = (int)MaxValue * poweredPrecision;
            return (double)_random.Next(min, max) / poweredPrecision;
        }
    }
}
