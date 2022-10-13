using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace LeetCode
{
    internal class WildCardMatch
    {
        public static bool IsMatch(string input, int startI, string pattern, int startP)
        {
            if( startI == input.Length-1 && startP == pattern.Length-1 )
            {
                return true;
            }
            if(startI == input.Length - 1 && pattern[startP+1] != '*')
            {
                return false;
            }
            int pIndex = startP;
            int newStartP = startP;
            while (pattern[pIndex] == '*')
            {
                //  get rid of consecutive "*"
                pIndex++;
            }
            if(pIndex != startP)
            {
                newStartP = pIndex - 1; 
            }

            if (pattern[newStartP] == '*')
            {
                while (startI < input.Length - 1)
                {
                    if (pattern[pIndex] != input[startI] && pattern[pIndex] != '?')
                    {
                        startI++;
                    }
                    bool isMatch = IsMatch(input, startI, pattern, pIndex + 1);

                    if( isMatch)
                    {
                        return true;
                    }
                    else
                    {
                        startI++;
                    }
                }
                return false;
            }
            else if(pattern[startP] == '?')
            {
                return IsMatch(input, startI + 1, pattern, startP + 1);
            }
            else
            {
                if( startI == input.Length || startP == pattern.Length )
                {
                    return false;
                }
                if( input[startI + 1] == pattern[startP + 1])
                {
                    return IsMatch(input, startI + 2, pattern, startP + 2);
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsMatch(string input, string pattern)
        {
            int n = input.Length;
            int m = pattern.Length;
            if( m== 0)
            {
                if (n== 0)
                {
                    return true;
                }
            }
            bool[,] lookup = new bool[n + 1, m + 1];
            for(int i=0; i < n+1; i++)
            {
                for(int j=0; j<m+1; j++)
                {
                    lookup[i, j] = false;
                }
            }
            // empty pattern can match empty string
            lookup[0, 0] = true;
            // "*" can match empty string
            for(int j=1;j<=m; j++)
            {
                if (pattern[j-1] == '*')
                {
                    lookup[0, j] = lookup[0, j - 1];
                }
            }

            for(int i=1; i<=n; i++)
            {
                for(int j=1; j<=m; j++)
                {
                    if (pattern[j-1] == '*')
                    {
                        //  for '*' we either move on to next char in the pattern or match ith char in the input
                        lookup[i, j] = lookup[i, j - 1] || lookup[i - 1, j];
                    }
                    else if( pattern[j-1] == '?' || input[i-1] == pattern[j-1])
                    {
                        lookup[i, j] = lookup[i-1, j-1];
                    }
                    else
                    {
                        lookup[i, j] = false;
                    }
                }
            }
            return lookup[n, m];
        }
    }
}
