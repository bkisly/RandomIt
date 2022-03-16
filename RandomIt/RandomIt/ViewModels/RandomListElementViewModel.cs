using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RandomIt.ViewModels
{
    internal class RandomListElementViewModel : INotifyPropertyChanged
    {
        private readonly RandomListElementModel _model;

        public ObservableCollection<string> Elements { get { return _model.Elements; } }
        public bool RandomChoicePossible
        {
            get { return Elements.Count > 0; }
        }
        public string RandomElement { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChooseRandom()
        {
            RandomElement = _model.ChooseRandom();
            OnPropertyChanged(nameof(RandomElement));
        }

        public void AddElement(string elementName)
        {
            _model.Elements.Add(elementName);
            OnPropertyChanged(nameof(RandomChoicePossible));
        }

        public void RemoveElement(string elementName)
        {
            _model.RemoveElement(elementName);
            OnPropertyChanged(nameof(RandomChoicePossible));
        }

        public void RemoveElement(int elementId)
        {
            _model.RemoveElement(elementId);
            OnPropertyChanged(nameof(RandomChoicePossible));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
