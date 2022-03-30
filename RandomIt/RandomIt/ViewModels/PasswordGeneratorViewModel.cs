using System.Threading.Tasks;
using Xamarin.Essentials;
using RandomIt.Models;

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
                OnPropertyChanged(nameof(PasswordGenerationPossible));
            }
        }
        public bool IncludeLowercase
        {
            get { return _model.IncludeLowercase; }
            set 
            { 
                _model.IncludeLowercase = value;
                OnPropertyChanged(nameof(PasswordGenerationPossible));
            }
        }
        public bool IncludeNumbers
        {
            get { return _model.IncludeNumbers; }
            set 
            { 
                _model.IncludeNumbers = value;
                OnPropertyChanged(nameof(PasswordGenerationPossible));
            }
        }
        public bool IncludeSymbols
        {
            get { return _model.IncludeSymbols; }
            set 
            { 
                _model.IncludeSymbols = value;
                OnPropertyChanged(nameof(PasswordGenerationPossible));
            }
        }
        public int PasswordLength
        {
            get { return _model.PasswordLength; }
            set { _model.PasswordLength = value; }
        }

        public string GeneratedPassword { get; private set; }
        public bool PasswordGenerationPossible
        {
            get
            {        
                return IncludeUppercase || IncludeLowercase || IncludeNumbers || IncludeSymbols;
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

        public async Task CopyToClipboardAsync()
        {
            await Clipboard.SetTextAsync(GeneratedPassword);
        }
    }
}
