using System;
using System.Collections.ObjectModel;
using System.Text;

namespace RandomIt.Models
{
    internal class RandomListElementModel
    {
        private  readonly Random _random;
        public ObservableCollection<string> Elements { get; private set; }

        public RandomListElementModel()
        {
            Elements = new ObservableCollection<string>();
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

        public void ClearElements()
        {
            Elements.Clear();
        }
    }
}
