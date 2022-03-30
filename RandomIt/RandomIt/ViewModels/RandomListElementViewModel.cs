using System.Collections.Generic;
using System.Collections.ObjectModel;
using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class RandomListElementViewModel : BindableViewModel
    {
        private readonly RandomListElementModel _model;

        public ObservableCollection<ListElement> Elements { get { return _model.Elements; } }

        private IList<object> _selectedElements;
        public IList<object> SelectedElements
        {
            get { return _selectedElements; }
            set
            {
                _selectedElements = value;
                OnPropertyChanged(nameof(ContainsSelectedElements));
            }
        }

        public string RandomElement { get; private set; }

        private string _elementName;
        public string ElementName
        {
            get { return _elementName; }
            set 
            {
                _elementName = value;
                OnPropertyChanged(nameof(IsElementNotEmpty));
            }
        }

        public bool ContainsElements { get { return Elements.Count > 0; } }
        public bool ContainsSelectedElements
        {
            get 
            {
                if(_selectedElements == null) return false;
                return _selectedElements.Count > 0; 
            }
        }
        public bool IsElementNotEmpty { get { return !string.IsNullOrWhiteSpace(_elementName); } }

        public RandomListElementViewModel()
        {
            _model = new RandomListElementModel();
        }

        public void ChooseRandom()
        {
            RandomElement = _model.ChooseRandom().Name;
            OnPropertyChanged(nameof(RandomElement));
        }

        public void AddElement()
        {
            _model.AddElement(new ListElement(_elementName));
            OnPropertyChanged(nameof(ContainsElements));
        }

        public void RemoveSelectedElements()
        {
            object[] selectedElementsCopy = new object[_selectedElements.Count];
            _selectedElements.CopyTo(selectedElementsCopy, 0);

            foreach(ListElement element in selectedElementsCopy)
                _model.RemoveElement(element);

            _selectedElements.Clear();

            OnPropertyChanged(nameof(ContainsElements));
            OnPropertyChanged(nameof(ContainsSelectedElements));
        }

        public void ClearElements()
        {
            _model.ClearElements();
            _selectedElements.Clear();

            OnPropertyChanged(nameof(ContainsElements));
            OnPropertyChanged(nameof(ContainsSelectedElements));
        }
    }
}
