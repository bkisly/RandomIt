using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RandomIt.Models
{
    internal class ListShuffleModel
    {
        private readonly Random _random;
        public ObservableCollection<ListElement> Elements { get; private set; }

        public ListShuffleModel()
        {
            _random = new Random();
            Elements = new ObservableCollection<ListElement>();
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

        public void AddElement(ListElement element)
        {
            Elements.Add(element);
        }

        public void RemoveElement(ListElement element)
        {
            if (Elements.Contains(element))
                Elements.Remove(element);
        }
        public void ClearElements()
        {
            Elements.Clear();
        }
    }
}
