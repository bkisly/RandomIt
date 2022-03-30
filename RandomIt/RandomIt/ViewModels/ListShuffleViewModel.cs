﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using RandomIt.Models;

namespace RandomIt.ViewModels
{
    internal class ListShuffleViewModel : BindableViewModel
    {
        private readonly ListShuffleModel _model;

        public ObservableCollection<ListElement> Elements { get { return _model.Elements; } }
        public ObservableCollection<ListElement> ShuffledElements { get; private set; }

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

        public bool ContainsElements { get { return Elements.Count > 0; } }
        public bool ContainsSelectedElements 
        { 
            get { return _selectedElements != null && _selectedElements.Count > 0; } 
        }
        public bool IsElementNameNotEmpty { get { return !string.IsNullOrWhiteSpace(ElementName); } }

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
