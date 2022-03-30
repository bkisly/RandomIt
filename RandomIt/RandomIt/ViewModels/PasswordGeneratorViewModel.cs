using System;
using System.Collections.Generic;
using System.Text;
using RandomIt.Models;
using System.ComponentModel;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace RandomIt.ViewModels
{
    internal class PasswordGeneratorViewModel : BindableViewModel
    {
        private readonly PasswordGeneratorModel _model;

        public bool IncludeUppercase
        {
            get { return _model.IncludeUppercase; }
            set 
            { 
                _model.IncludeUppercase = value;
                OnPropertyChanged(nameof(PasswordGenerationPosible));
            }
        }
        public bool IncludeLowercase
        {
            get { return _model.IncludeLowercase; }
            set 
            { 
                _model.IncludeLowercase = value;
                OnPropertyChanged(nameof(PasswordGenerationPosible));
            }
        }
        public bool IncludeNumbers
        {
            get { return _model.IncludeNumbers; }
            set 
            { 
                _model.IncludeNumbers = value;
                OnPropertyChanged(nameof(PasswordGenerationPosible));
            }
        }
        public bool IncludeSymbols
        {
            get { return _model.IncludeSymbols; }
            set 
            { 
                _model.IncludeSymbols = value;
                OnPropertyChanged(nameof(PasswordGenerationPosible));
            }
        }
        public int PasswordLength
        {
            get { return _model.PasswordLength; }
            set { _model.PasswordLength = value; }
        }

        public string GeneratedPassword { get; private set; }
        public bool PasswordGenerationPosible
        {
            get
            {
                bool possible = IncludeUppercase || IncludeLowercase || IncludeNumbers || IncludeSymbols;
                return possible;
            }
        }

        public PasswordGeneratorViewModel()
        {
            _model = new PasswordGeneratorModel();
        }

        public void GeneratePassword()
        {
            GeneratedPassword = _model.GeneratePassword();
            OnPropertyChanged(nameof(GeneratedPassword));
        }

        public async Task CopyPasswordToClipboard()
        {
            await Clipboard.SetTextAsync(GeneratedPassword);
        }
    }
}
