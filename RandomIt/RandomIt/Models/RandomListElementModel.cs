using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIt.Models
{
    internal class RandomListElementModel
    {
        private  readonly Random _random;
        public List<string> Elements { get; private set; }

        public RandomListElementModel()
        {
            _random = new Random();
        }

        public string ChooseRandom()
        {
            int elementIndex = _random.Next(Elements.Count);
            return Elements[elementIndex];
        }

        public void AddElement(string element)
        {
            Elements.Add(element);
        }

        public void RemoveElement(string element)
        {
            if (Elements.Contains(element))
                Elements.Remove(element);
        }

        public void RemoveElement(int elementId)
        {
            Elements.RemoveAt(elementId);
        }
    }
}
