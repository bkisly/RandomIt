using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RandomIt.Models
{
    internal enum CharGroup
    {
        Uppercase,
        Lowercase,
        Numbers,
        Symbols
    }

    internal static class PasswordStringHelper
    {
        public static readonly char[] UppercaseLetters = GetChars(CharGroup.Uppercase).ToArray();
        public static readonly char[] LowercaseLetters = GetChars(CharGroup.Lowercase).ToArray();
        public static readonly char[] Numbers = GetChars(CharGroup.Numbers).ToArray();
        public static readonly char[] Symbols = GetChars(CharGroup.Symbols).ToArray();

        private static readonly Dictionary<CharGroup, char[]> _charGroupPairs = InitializeCharPairs();

        public static bool ContainsCharacter(this string s, CharGroup charGroup)
        {
            char[] chars = _charGroupPairs[charGroup];

            foreach (char c in chars)
                if (s.Contains(c.ToString())) return true;

            return false;
        }

        public static IEnumerable<char> GetChars(int asciiBegin, int asciiEnd)
        {
            for (int i = asciiBegin; i <= asciiEnd; i++)
                yield return (char)i;
        }

        public static IEnumerable<char> GetChars(CharGroup charGroup)
        {
            switch (charGroup)
            {
                case CharGroup.Uppercase:
                    return GetChars(65, 90);
                case CharGroup.Lowercase:
                    return GetChars(97, 122);
                case CharGroup.Numbers:
                    return GetChars(48, 57);
                case CharGroup.Symbols:
                    List<char> chars = new List<char>();

                    for (int i = 33; i <= 126; i++)
                    {
                        if ((i >= 48 && i <= 59) || (i >= 65 && i <= 90) || (i >= 97 && i <= 122))
                            continue;

                        chars.Add((char)i);
                    }

                    return chars;
                default:
                    return null;
            }
        }

        private static Dictionary<CharGroup, char[]> InitializeCharPairs()
        {
            Dictionary<CharGroup, char[]> pairs = new Dictionary<CharGroup, char[]>
            {
                { CharGroup.Uppercase, UppercaseLetters },
                { CharGroup.Lowercase, LowercaseLetters },
                { CharGroup.Numbers, Numbers },
                { CharGroup.Symbols, Symbols }
            };

            return pairs;
        }
    }
}
