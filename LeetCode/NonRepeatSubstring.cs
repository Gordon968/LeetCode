using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    internal class NonRepeatSubstring
    {
        public static int MaxLengthSubString(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return 0;
            }
            int maxLength = 1;
            int length = input.Length;
            bool reachEnd = false;
            string substring = string.Empty;
            for(int i = 0; i < length; i++)
            {
                substring = input[i].ToString();
                for(int j=i+1; j < length; j++)
                {
                    if(substring.Contains(input[j]))
                    {
                        maxLength = Math.Max(substring.Length, maxLength);
                        break;
                    }
                    else
                    {
                        substring += input[j];
                    }
                    //  for starting i, we reach to the end of string, we don't need to go start again from i+1
                    if (j == length-1)
                    {
                        reachEnd = true;
                    }
                }
               
                maxLength = Math.Max(substring.Length, maxLength);
                if( reachEnd)
                {
                    break;
                }
            }
            maxLength = Math.Max(substring.Length, maxLength);
            return maxLength;
        }
    }
}
