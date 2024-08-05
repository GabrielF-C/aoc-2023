using AOC2023.common;
using System.Runtime.CompilerServices;

namespace AOC2023.d1
{
    internal class DayOneParser(string fileName, bool debug = false) : Parser<int>(fileName, debug)
    {
        private static readonly Dictionary<string, char> SPELLED_DIGITS = new() {
            { "one", '1' },
            { "two", '2' },
            { "three", '3' },
            { "four", '4' },
            { "five", '5' },
            { "six", '6' },
            { "seven", '7' },
            { "eight", '8' },
            { "nine", '9' },
            { "zero", '0' }
        };

        protected override int ParseLine(string line)
        {
            char? firstDigit = ParseFirstDigit(line);
            char? lastDigit = ParseLastDigit(line);
            return Convert.ToInt32(string.Concat(firstDigit, lastDigit));
        }

        private static char? ParseFirstDigit(string line)
        {
            char? digit = null;
            for (int i = 0; i < line.Length; i++)
            {
                string subStr = line[i..];

                digit = FirstSpelledDigit(subStr);
                if (digit == null && char.IsDigit(subStr.First()))
                {
                    digit = subStr.First();
                }

                if (digit != null)
                {
                    break;
                }
            }
            return digit;
        }

        private static char? ParseLastDigit(string line)
        {
            char? digit = null;
            for (int i = line.Length; i > 0; i--)
            {
                string subStr = line[..i];

                digit = LastSpelledDigit(subStr);
                if (digit == null && char.IsDigit(subStr.Last()))
                {
                    digit = subStr.Last();
                }

                if (digit != null)
                {
                    break;
                }
            }
            return digit;
        }

        private static char? FirstSpelledDigit(string s)
        {
            foreach (var d in SPELLED_DIGITS)
            {
                if (s.StartsWith(d.Key))
                {
                    return d.Value;
                }
            }
            return null;
        }

        private static char? LastSpelledDigit(string s)
        {
            foreach (var d in SPELLED_DIGITS)
            {
                if (s.EndsWith(d.Key))
                {
                    return d.Value;
                }
            }
            return null;
        }
    }
}
