using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * A valid number can be split up into these components (in order):

    A decimal number or an integer.
    (Optional) An 'e' or 'E', followed by an integer.

A decimal number can be split up into these components (in order):

    (Optional) A sign character (either '+' or '-').
    One of the following formats:
        One or more digits, followed by a dot '.'.
        One or more digits, followed by a dot '.', followed by one or more digits.
        A dot '.', followed by one or more digits.

An integer can be split up into these components (in order):

    (Optional) A sign character (either '+' or '-').
    One or more digits.

For example, all the following are valid numbers: ["2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789"], while the following are not valid numbers: ["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"].

Given a string s, return true if s is a valid number.

 

Example 1:

Input: s = "0"
Output: true

Example 2:

Input: s = "e"
Output: false

Example 3:

Input: s = "."
Output: false

     */
    internal class ValidNum
    {
        public static bool IsvalidNum(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            if (!IsADigit(input[0]) && !IsASign(input[0]))
            {
                return false;
            }
            bool hasDecimalPoint = false;
            bool hasExponentialSign = false;

            bool isValid = true;
            int i = 1;
            while(i < input.Length)
            {
                if (IsADigit(input[i]))
                {
                    i++;
                    continue;
                }
                if (IsExponentialSign(input[i]))
                {
                    if (hasExponentialSign)
                    {
                        isValid = false;
                        break;
                    }
                    
                    hasExponentialSign = true;
                    
                    if (IsADigit(input[i - 1]))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                else if(IsDecimalPoint(input[i]))
                {
                    if( hasDecimalPoint )
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        hasDecimalPoint = true;
                        if(hasExponentialSign)
                        {
                            isValid = false;
                            break;
                        }
                        i++;
                    }
                }
                else if( IsASign(input[i]))
                {
                    if( IsExponentialSign(input[i-1]))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        isValid=false;
                        break;
                    }
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }


        static bool IsADigit(char c)
        {
            return c>='0' && c<='9';
        }

        static bool IsASign(char c)
        {
            return c =='+' || c=='-';
        }

        static bool IsExponentialSign(char c)
        {
            return c == 'e' || c == 'E';
        }

        static bool IsDecimalPoint(char c)
        {
            return c == '.';
        }
    }
}
