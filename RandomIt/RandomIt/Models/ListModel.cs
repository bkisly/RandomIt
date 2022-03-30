using System.Collections.ObjectModel;

namespace RandomIt.Models
{
    internal abstract class ListModel
    {
        public ObservableCollection<ListElement> Elements { get; private set; }

        public ListModel()
        {
            Elements = new ObservableCollection<ListElement>();
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
