using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_Theme_05
{
    /// <summary>
    /// Methods to process Strings.
    /// </summary>
    public class StringMagic
    {

        /// <summary>
        /// Replaces Punctuation, Separators and Digits with whitespaces.
        /// </summary>
        /// <param name="text">Input string.</param>
        /// <returns>A string where all Punctuation, Separators and Digits are replaced by whitespaces.</returns>
        public static string RemoveExtraSymbols(string text)
        {
            char[] letters = text.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsPunctuation(letters[i]) || char.IsSeparator(letters[i])/* || char.IsDigit(letters[i])*/)
                {
                    letters[i] = (char) 32;
                }
            }

            return new string(letters);
        }

        /// <summary>
        /// Returns one of the shortest words from the input string.
        /// </summary>
        /// <param name="text">Input string.</param>
        /// <returns>One of the shortest words from the input strings.</returns>
        public static string OneOfTheShortestWords(string text)
        {
            char[] separators = new char[] {' '};

            string[] subs = StringMagic.RemoveExtraSymbols(text)
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int tempMinLength = int.MaxValue;
            string oneOfTheShortest = "";

            foreach (var sub in subs)
            {
                if (sub.Length <= tempMinLength)
                {
                    tempMinLength = sub.Length;
                    oneOfTheShortest = sub;
                }
            }

            return oneOfTheShortest;
        }

        /// <summary>
        /// Returns all the longest words from the input string separated by whitespace.
        /// </summary>
        /// <param name="text">Input string.</param>
        /// <returns>All the longest words from the input string separated by whitespace.</returns>
        public static List<string> AllTheLongestWords(string text)
        {
            char[] separators = new char[] {' '};

            string[] subs = StringMagic.RemoveExtraSymbols(text)
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var allTheLongest = new List<string>();

            int tempMaxLength = default;

            //string longest = subs.OrderByDescending(s => s.Length).First();
            foreach (var sub in subs)
            {
                if (sub.Length >= tempMaxLength)
                {
                    tempMaxLength = sub.Length;
                }
            }

            foreach (var t in subs)
            {
                if ((t.Length == tempMaxLength))
                {
                    allTheLongest.Add(t);
                }
            }

            return allTheLongest;
        }
    }
}