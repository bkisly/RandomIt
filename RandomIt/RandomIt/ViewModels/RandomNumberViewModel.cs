using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;
using System.ComponentModel;

namespace RandomIt.ViewModels
{
    internal class RandomNumberViewModel : BindableViewModel
    {
        private readonly RandomNumberModel _model;

        public double MinValue
        {
            get { return _model.MinValue; }
            set { _model.MinValue = value; }
        }
        public double MaxValue
        {
            get { return _model.MaxValue; }
            set { _model.MaxValue = value; }
        }
        public int Precision
        {
            get { return _model.Precision; }
            set { _model.Precision = value; }
        }
        public double GeneratedValue { get; private set; }

        private bool _floatGeneration;
        public bool FloatGeneration
        {
            get { return _floatGeneration; }
            set 
            { 
                _floatGeneration = value;
                OnPropertyChanged(nameof(FloatGeneration));
                OnPropertyChanged(nameof(Increment));
            }
        }
        public double Increment 
        { 
            get 
            {
                if (_floatGeneration) return 1 / Math.Pow(10, Precision);
                else return 1;
             } 
        }

        public RandomNumberViewModel()
        {
            _model = new RandomNumberModel();
        }

        public void GenerateRandomInt()
        {
            GeneratedValue = _model.GenerateRandomInt();
            OnPropertyChanged(nameof(GeneratedValue));
        }

        public void GenerateRandomDouble()
        {
            GeneratedValue = _model.GenerateRandomDouble();
            OnPropertyChanged(nameof(GeneratedValue));
        }
    }
}
