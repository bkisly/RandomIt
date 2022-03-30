using System.Collections.Generic;
using System.Collections.ObjectModel;
using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class ListShuffleViewModel : ListViewModel
    {
        private readonly new ListShuffleModel _model;

        public ObservableCollection<ListElement> ShuffledElements { get; private set; }

        public ListShuffleViewModel() : base(new ListShuffleModel())
        {
            _model = base._model as ListShuffleModel;
            ShuffledElements = new ObservableCollection<ListElement>();
        }

        public void Shuffle()
        {
            ShuffledElements.Clear();
            
            foreach(ListElement element in _model.Shuffle())
                ShuffledElements.Add(element);
        }
    }
}
