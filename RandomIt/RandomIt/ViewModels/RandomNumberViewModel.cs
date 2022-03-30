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
            set 
            { 
                _model.Precision = value;
                OnPropertyChanged(nameof(Increment));
            }
        }
        public double? GeneratedValue { get; private set; }

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
            GeneratedValue = null;
        }

        public void GenerateRandom()
        {
            if (_floatGeneration)
                GeneratedValue = _model.GenerateRandomDouble();
            else GeneratedValue = _model.GenerateRandomInt();

            OnPropertyChanged(nameof(GeneratedValue));
        }
    }
}
