using System.Collections.Generic;
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

        public static IEnumerable<char> GetChars(char asciiBegin, char asciiEnd)
        {
            for (char c = asciiBegin; c <= asciiEnd; c++)
                yield return c;
        }

        public static IEnumerable<char> GetChars(CharGroup charGroup)
        {
            switch (charGroup)
            {
                case CharGroup.Uppercase:
                    return GetChars('A', 'Z');
                case CharGroup.Lowercase:
                    return GetChars('a', 'z');
                case CharGroup.Numbers:
                    return GetChars('0', '9');
                case CharGroup.Symbols:
                    List<char> chars = new List<char>();

                    for (char c = '!'; c <= '~'; c++)
                    {
                        if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                            continue;

                        chars.Add(c);
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
