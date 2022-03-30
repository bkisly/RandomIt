using System;
using System.Collections.ObjectModel;

namespace RandomIt.Models
{
    internal class RandomListElementModel
    {
        private  readonly Random _random;
        public ObservableCollection<ListElement> Elements { get; private set; }

        public RandomListElementModel()
        {
            Elements = new ObservableCollection<ListElement>();
            _random = new Random();
        }

        public ListElement ChooseRandom()
        {
            int elementIndex = _random.Next(Elements.Count);
            return Elements[elementIndex];
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
