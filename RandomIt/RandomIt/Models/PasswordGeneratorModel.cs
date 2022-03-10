using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace RandomIt.Models
{
    internal class PasswordGeneratorModel
    {
        public bool IncludeUppercase { get; set; }
        public bool IncludeLowercase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSymbols { get; set; }

        public int PasswordLength { get; set; }

        public PasswordGeneratorModel()
        {
            PasswordLength = 10;
        }

        public string GeneratePassword()
        {
            throw new NotImplementedException();
        }
    }
}
