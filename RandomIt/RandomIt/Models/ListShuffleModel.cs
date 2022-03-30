using System;
using System.Collections.Generic;

namespace RandomIt.Models
{
    internal class ListShuffleModel : ListModel
    {
        private readonly Random _random;

        public ListShuffleModel() : base()
        {
            _random = new Random();
        }

        public IEnumerable<ListElement> Shuffle()
        {
            List<ListElement> shuffledElements = new List<ListElement>();
            List<ListElement> elementsCopy = new List<ListElement>(Elements);

            for(int i = 0; i < Elements.Count; i++)
            {
                ListElement randomElement = elementsCopy[_random.Next(elementsCopy.Count)];
                shuffledElements.Add(randomElement);
                elementsCopy.Remove(randomElement);
            }

            return shuffledElements;
        }
    }
}
