using System.Collections.Generic;
using System.Collections.ObjectModel;
using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class RandomListElementViewModel : ListViewModel
    {
        private readonly new RandomListElementModel _model;

        public string RandomElement { get; private set; }

        public RandomListElementViewModel() : base(new RandomListElementModel())
        {
            _model = base._model as RandomListElementModel;
        }

        public void ChooseRandom()
        {
            RandomElement = _model.ChooseRandom().Name;
            OnPropertyChanged(nameof(RandomElement));
        }
    }
}
