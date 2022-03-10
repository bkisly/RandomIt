using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RandomIt.Models
{
    internal class PasswordGeneratorModel
    {
        private readonly Random _random;

        public bool IncludeUppercase { get; set; }
        public bool IncludeLowercase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSymbols { get; set; }

        public int PasswordLength { get; set; }

        public PasswordGeneratorModel()
        {
            _random = new Random();
            PasswordLength = 10;
        }

        public string GeneratePassword()
        {
            string password;
            char[][] groups = GetCharGroups();

            do
            {
                password = "";

                for(int i = 0; i < PasswordLength; i++)
                {
                    char[] randomGroup = groups[_random.Next(groups.Length)];
                    char randomChar = randomGroup[_random.Next(randomGroup.Length)];
                    password += randomChar;
                }
            }
            while (!IsPasswordCorrect(password));

            return password;
        }

        private bool IsPasswordCorrect(string password)
        {
            if(IncludeUppercase)
            {
                if (!password.ContainsCharacter(CharGroup.Uppercase))
                    return false;
            }
            if(IncludeLowercase)
            {
                if (!password.ContainsCharacter(CharGroup.Lowercase))
                    return false;
            }
            if(IncludeNumbers)
            {
                if (!password.ContainsCharacter(CharGroup.Numbers))
                    return false;
            }
            if(IncludeSymbols)
            {
                if (!password.ContainsCharacter(CharGroup.Symbols))
                    return false;
            }

            return true;
        }

        private char[][] GetCharGroups()
        {
            List<char[]> necessaryCharGroups = new List<char[]>();

            if (IncludeUppercase) necessaryCharGroups.Add(PasswordStringHelper.UppercaseLetters);
            if (IncludeLowercase) necessaryCharGroups.Add(PasswordStringHelper.LowercaseLetters);
            if (IncludeNumbers) necessaryCharGroups.Add(PasswordStringHelper.Numbers);
            if (IncludeSymbols) necessaryCharGroups.Add(PasswordStringHelper.Symbols);

            return necessaryCharGroups.ToArray();
        }
    }
}
