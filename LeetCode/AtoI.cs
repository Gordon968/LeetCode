using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    internal class AtoI
    {
        public static int MyAtoI(string input)
        {
            char[] chars = input.ToCharArray();
            bool isPositive = true;
            string numbers = string.Empty;
            for(int i=0; i < chars.Length; i++)
            {
                char c = chars[i];
                if(c == ' ' && string.IsNullOrEmpty(numbers) )
                {
                    continue;
                }
                if(c == '-' && string.IsNullOrEmpty(numbers))
                {
                    isPositive = false;
                    continue;
                }
                if(c >= '0' && c <= '9')
                {
                    numbers += c;
                }
                else 
                {
                    if( string.IsNullOrEmpty(numbers) )
                    {
                        // not a number
                        throw new Exception("It is not a number.");
                    }
                    else
                    {
                        //  rest of them is not count
                        break;
                    }
                }
            }

            if( string.IsNullOrEmpty(numbers))
            {
                // not a number
                throw new Exception("It is not a number.");
            }

            int num = 0;
            for(int i=0; i < numbers.Length; i++)
            {
                num += (numbers[i] - '0') *(int) Math.Pow(10, numbers.Length - i-1);
            }
            return isPositive ? num : -num;

        }
    }
}
