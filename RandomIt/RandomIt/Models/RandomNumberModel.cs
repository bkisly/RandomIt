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
        }

        public int GenerateRandomInt()
        {
            return _random.Next((int)MinValue, (int)MaxValue + 1);
        }

        public double GenerateRandomDouble()
        {
            int min = (int)MinValue * Precision;
            int max = (int)MaxValue * Precision;
            return (double)_random.Next(min, max) / (double)Precision;
        }
    }
}
