using System;

namespace RandomIt.Models
{
    internal class RandomListElementModel : ListModel
    {
        private readonly Random _random;

        public RandomListElementModel() : base()
        {
            _random = new Random();
        }

        public ListElement ChooseRandom()
        {
            int elementIndex = _random.Next(Elements.Count);
            return Elements[elementIndex];
        }
    }
}
