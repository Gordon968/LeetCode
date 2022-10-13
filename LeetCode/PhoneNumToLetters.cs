using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
    /// A mapping of digit to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
    ///Examples:
    ///Input: digits = "23"
    ///Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
    ///Input: digits = ""
    ///Output: []
    ///Input: digits = "2"
    ///Output: ["a","b","c"]
    ///
    ///Constraints:
    ///0 <= digits.length <= 4
    ///digits[i] is a digit in the range ['2', '9'].
    /// </summary>
    public class PhoneNumToLetters
    {
        static string[] digitToLetters = {"", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        public static List<string> ConvertDigitToLetters(string digits)
        {
            List<string> outputs = new List<string>();
            List<string> digitsForLetters = GetLettersFromDigits(digits);
            foreach(string letters in digitsForLetters)
            {
                outputs = AddLetters(outputs, letters);
            }
            return outputs;
        }

        private static List<string> GetLettersFromDigits(string digits)
        {
            List<string> digitsForLetters = new List<string>();

            foreach (char letter in digits)
            {
                int digit;
                if (int.TryParse(letter.ToString(), out digit))
                {
                    string lettersForDigit = digitToLetters[digit];
                    digitsForLetters.Add(lettersForDigit);
                }
            }
            return digitsForLetters;
        }
        private static List<string>AddLetters(List<string>original, string letters)
        {
            if( original.Count == 0 )
            {
                return AddLettersToString("", letters);
            }
            else
            {
                List<string> retString = new List<string>();
                foreach(string str in original )
                {
                    retString.AddRange(AddLettersToString(str, letters));
                }
                return retString;
            }
        }
        private static List<string>AddLettersToString(string original, string letters)
        {
            List<string> outputs = new List<string>();
            foreach(char letter in letters)
            {
                outputs.Add(original + letter);
            }
            return outputs;
        }
    }
}
