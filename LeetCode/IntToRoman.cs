using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Integer to Roman
    Medium

    Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

    Symbol       Value
    I             1
    V             5
    X             10
    L             50
    C             100
    D             500
    M             1000

    For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

    Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

        I can be placed before V (5) and X (10) to make 4 and 9. 
        X can be placed before L (50) and C (100) to make 40 and 90. 
        C can be placed before D (500) and M (1000) to make 400 and 900.

    Given an integer, convert it to a roman numeral.

 

    Example 1:

    Input: num = 3
    Output: "III"
    Explanation: 3 is represented as 3 ones.

    Example 2:

    Input: num = 58
    Output: "LVIII"
    Explanation: L = 50, V = 5, III = 3.

    Example 3:

    Input: num = 1994
    Output: "MCMXCIV"
    Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

 

    Constraints:

        1 <= num <= 3999
    */
    internal class IntToRoman
    {
        static Dictionary<int, Dictionary<int, char>> myDict = new Dictionary<int, Dictionary<int, char>>();
        public static string IntergerToRoman(int num)
        {
            InitializeDict();

            //  First we need to get all the digit
            string roman = string.Empty;

            int divide = 10;
            int digitDisFromRight = 1;
            do
            {
                int digit = num % divide;
                num -= digit;
                roman = roman.Insert(0, getRomanForDigit(digitDisFromRight, digit));
                digitDisFromRight++;
                divide *= 10;
            } while (num >= divide / 10);

            return roman;
        }
        private static string getRomanForDigit(int digitDisFromRight, int number)
        {
            string roman = string.Empty;
            Dictionary<int, char> dict = myDict[digitDisFromRight];
            List<int> digVal = new List<int>();
            List<char> romVal = new List<char>();
            foreach (KeyValuePair<int, char> keyvalue in dict)
            {
                digVal.Add(keyvalue.Key);
                romVal.Add(keyvalue.Value);
            }

            if (number < digVal[0]*4)
            {
                // i.e. III
                for (int i = 0; i < number / digVal[0]; i++)
                {
                    roman = roman.Insert(0, romVal[0].ToString());
                }
            }
            else if (number == digVal[0] * 4)
            {
                // i.e. IV
                roman = roman.Insert(0, romVal[0].ToString());
                roman = roman.Insert(1, romVal[1].ToString());
            }
            else if (number == digVal[1])
            {
                // i.e. V
                roman = roman.Insert(0, romVal[1].ToString());
            }
            else if (number < 9*digVal[0] && number > 5* digVal[0])
            {
                //i.e. VII
                for (int i = 0; i < (number - 5) / digVal[0]; i++)
                {
                    roman = roman.Insert(0, romVal[0].ToString());
                }
                roman = roman.Insert(0, romVal[1].ToString());
            }
            else if (number == 9* digVal[0])
            {
                //i.e. IX
                Dictionary<int, char> nextDict = myDict[digitDisFromRight + 1];
                char romanVal;
                foreach (KeyValuePair<int, char> keyvalue in nextDict)
                {
                    romanVal = keyvalue.Value;
                    roman = roman.Insert(0, romanVal.ToString());
                    break;
                }
                roman = roman.Insert(0, romVal[0].ToString());
            }
            return roman;
        }

        private static void InitializeDict()
        {
            myDict[1] = new Dictionary<int, char>(); myDict[1].Add(1, 'I'); myDict[1].Add(5, 'V');
            myDict[2] = new Dictionary<int, char>(); myDict[2].Add(10, 'X'); myDict[2].Add(50, 'L');
            myDict[3] = new Dictionary<int, char>(); myDict[3].Add(100, 'C'); myDict[3].Add(500, 'D');
            myDict[4] = new Dictionary<int, char>(); myDict[4].Add(1000, 'M');
        }
    }
}
