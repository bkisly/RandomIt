using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIt.Models
{
    internal abstract class ThrowableModel
    {
        private readonly Random _random;
        private readonly int _sides;

        public int Amount { get; set; }

        public ThrowableModel(int sides)
        {
            _random = new Random();
            _sides = sides;
            Amount = 1;
        }

        public IEnumerable<int> Throw()
        {
            List<int> throwResults = new List<int>();

            for (int i = 0; i < Amount; i++)
                throwResults.Add(_random.Next(_sides) + 1);

            return throwResults;
        }
    }
}
