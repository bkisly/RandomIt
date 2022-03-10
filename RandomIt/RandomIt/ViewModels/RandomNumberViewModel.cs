﻿using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;
using System.ComponentModel;

namespace RandomIt.ViewModels
{
    internal class RandomNumberViewModel : INotifyPropertyChanged
    {
        private RandomNumberModel _randomNumberModel;

        public double MinValue
        {
            get { return _randomNumberModel.MinValue; }
            set { _randomNumberModel.MinValue = value; }
        }
        public double MaxValue
        {
            get { return _randomNumberModel.MaxValue; }
            set { _randomNumberModel.MaxValue = value; }
        }
        public int Precision
        {
            get { return _randomNumberModel.Precision; }
            set { _randomNumberModel.Precision = value; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public RandomNumberViewModel()
        {
            _randomNumberModel = new RandomNumberModel();
        }

        public void GenerateRandomInt()
        {
            GeneratedValue = _randomNumberModel.GenerateRandomInt();
            OnPropertyChanged(nameof(GeneratedValue));
        }

        public void GenerateRandomDouble()
        {
            GeneratedValue = _randomNumberModel.GenerateRandomDouble();
            OnPropertyChanged(nameof(GeneratedValue));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}