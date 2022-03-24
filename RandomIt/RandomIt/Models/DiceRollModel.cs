using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIt.Models
{
    internal class DiceRollModel
    {
        private readonly Random _random;

        public int DiceAmount { get; set; }

        public DiceRollModel()
        {
            _random = new Random();
            DiceAmount = 1;
        }

        public IEnumerable<int> Roll()
        {
            List<int> rollResults = new List<int>();

            for (int i = 0; i < DiceAmount; i++)
                rollResults.Add(_random.Next(6) + 1);

            return rollResults;
        }
    }
}
