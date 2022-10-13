using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    internal class ReverseInt
    {
        public static int ReverseInteger(int input)
        {
            bool negative = input < 0;
            if (negative)
            {
                input = -input;
            }
            string inputS = input.ToString();
            int length = inputS.Length;
            double reverse = 0;
            for(int i = length-1; i >= 0; i--)
            {
                char c = inputS[i];
                reverse += (c - '0') * Math.Pow(10, i);
            }
            if( reverse > int.MaxValue )
            {
                reverse = 0.0;
            }
            return (int)(negative ? -reverse : reverse);
        }
    }
}
