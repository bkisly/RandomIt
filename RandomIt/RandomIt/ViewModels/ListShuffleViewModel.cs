using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RandomIt.ViewModels
{
    internal class ListShuffleViewModel : INotifyPropertyChanged
    {
        private readonly ListShuffleModel _model;

        public ObservableCollection<ListElement> Elements { get { return _model.Elements; } }
        public ObservableCollection<ListElement> ShuffledElements { get; private set; }

        private string _elementName;
        public string ElementName 
        {
            get { return _elementName; }
            set
            {
                _elementName = value;
                OnPropertyChanged(nameof(IsElementNameNotEmpty));
            }
        }

        private IList<object> _selectedElements;
        public IList<object> SelectedElements
        {
            get { return _selectedElements; }
            set 
            {
                _selectedElements = value;
                OnPropertyChanged(nameof(SelectedElements));
            }
        }

        public bool ContainsElements { get { return Elements.Count > 0; } }
        public bool ContainsSelectedElements 
        { 
            get { return _selectedElements != null && _selectedElements.Count > 0; } 
        }
        public bool IsElementNameNotEmpty { get { return !string.IsNullOrWhiteSpace(ElementName); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public ListShuffleViewModel()
        {
            _model = new ListShuffleModel();
            ShuffledElements = new ObservableCollection<ListElement>();
        }

        public void Shuffle()
        {
            ShuffledElements.Clear();
            
            foreach(ListElement element in _model.Shuffle())
                ShuffledElements.Add(element);
        }

        public void AddElement()
        {
            _model.AddElement(new ListElement(ElementName));
            OnPropertyChanged(nameof(ContainsElements));
        }

        public void RemoveSelected()
        {
            object[] selectedElementsCopy = new object[_selectedElements.Count];
            _selectedElements.CopyTo(selectedElementsCopy, 0);

            foreach(ListElement element in _selectedElements)
                _model.RemoveElement(element);

            OnPropertyChanged(nameof(ContainsElements));
            OnPropertyChanged(nameof(ContainsSelectedElements));
        }

        public void ClearElements()
        {
            _model.ClearElements();

            OnPropertyChanged(nameof(ContainsElements));
            OnPropertyChanged(nameof(ContainsSelectedElements));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
