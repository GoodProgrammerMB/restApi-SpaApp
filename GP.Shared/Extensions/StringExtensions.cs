using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GP.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string ToSentense(this string @this)
        {
            if (string.IsNullOrEmpty(@this))
                return "";

            var lower = @this.ToLower();
            var result = lower.First().ToString().ToUpper() + lower.Substring(1);

            return result;
        }

        public static string TakeChars(this string @this, int count) => new string(@this.Take(count).ToArray());

        public static bool HasAny(this string @this, char seek) => @this?.ToLower().Any(@char => @char == seek) ?? false;

        public static string RemoveBase64Prefix(this string @this) => @this.StartsWith("data") ? @this.Substring(@this.IndexOf(',') + 1) : @this;

        public static string ReplaceWildcards(this string @this, char wildcard, params string[] parameters)
        {
            try
            {
                if (parameters == null || !parameters.Any()) return @this;
                if (string.IsNullOrEmpty(@this)) return @this;
                if (!@this.HasAny(wildcard)) return @this;

                var stringBuilder = new StringBuilder();
                var paramIterator = parameters.GetEnumerator();
                var resourceIterator = @this.GetEnumerator();

                while (resourceIterator.MoveNext())
                {
                    if (resourceIterator.Current == wildcard)
                    {
                        if (paramIterator.MoveNext())
                            stringBuilder.Append(paramIterator.Current);
                        else
                            stringBuilder.Append(resourceIterator.Current);
                    }
                    else
                    {
                        stringBuilder.Append(resourceIterator.Current);
                    }
                }

                resourceIterator.Dispose();

                return stringBuilder.ToString();
            }
            catch
            {
                return @this;
            }
        }

        public static string AttachPrefix(this string @this, char prefix, int maxCount)
        {
            return @this.PadLeft(maxCount, prefix);
        }

        public static int GetNumberOfDecimalPlaces(this string @this)
        {
            var stringValue = @this.ToString(CultureInfo.InvariantCulture);
            var split = stringValue.Split('.');

            return split.Length == 1 ? 0 : split[1].Length;
        }

        public static string FixDecimalSeparator(this string text)
        {
            if (text == null)
                return null;

            if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
            {
                return text.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            }
            if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
            {
                return text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            }

            return text;
        }

        public static string GetNumberCharsOnly(this string input)
        {
            return new string(input?.Where(char.IsDigit).ToArray());
        }

        public static string RemoveAllNonDecimalChars(this string input)
        {
            char[] allowedChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.' };
            return new string(input?.Where(c => allowedChars.Contains(c)).ToArray());
        }

        public static string GenerateRandom(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(AllowedChars[_random.Next(0, AllowedChars.Count)]);
            }
            return sb.ToString();
        }

        private static List<char> _allowed = null;
        private static Random _random = new Random();
        private static List<char> AllowedChars
        {
            get
            {
                if (_allowed == null)
                {
                    _allowed = new List<char>();
                    for (char c = 'A'; c < 'Z'; c++)
                    {
                        _allowed.Add(c);
                    }
                    for (char c = 'a'; c < 'z'; c++)
                    {
                        _allowed.Add(c);
                    }
                    for (char c = '0'; c < '9'; c++)
                    {
                        _allowed.Add(c);
                    }
                }
                return _allowed;
            }
        }
    }
}
