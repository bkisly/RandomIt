using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RandomIt.ViewModels
{
    public abstract class ThrowableViewModel
    {
        private readonly ThrowableModel _model;

        public ObservableCollection<int> RollResults { get; private set; }
        public int Amount
        {
            get { return _model.Amount; }
            set { _model.Amount = value; }
        }

        public event ThrowResultsChangedEventHandler ThrowResultsChanged;

        public ThrowableViewModel(ThrowableModel model)
        {
            _model = model;
            RollResults = new ObservableCollection<int>();
        }

        public void Roll()
        {
            RollResults.Clear();
            
            foreach(int result in _model.Throw())
                RollResults.Add(result);

            ThrowResultsChanged?.Invoke(this, new ThrowResultsChangedEventArgs(RollResults));
        }
    }
}
