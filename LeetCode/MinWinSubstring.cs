using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

    The testcases will be generated such that the answer is unique.

    A substring is a contiguous sequence of characters within the string.

 

    Example 1:

    Input: s = "ADOBECODEBANC", t = "ABC"
    Output: "BANC"
    Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.

    Example 2:

    Input: s = "a", t = "a"
    Output: "a"
    Explanation: The entire string s is the minimum window.

    Example 3:

    Input: s = "a", t = "aa"
    Output: ""
    Explanation: Both 'a's from t must be included in the window.
    Since the largest window of s only has one 'a', return empty string.

     */
    internal class MinWinSubstring
    {
        public static string MinWindow(string s, string t)
        {
            if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            {
                return "";
            }
            if( s == t)
            {
                return s;
            }
            if( s.Contains(t) )
            {
                return t;
            }
            //  create a hash table for t
            Dictionary<char, int> tHash = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (tHash.ContainsKey(t[i]))
                {
                    tHash[t[i]] += 1;
                }
                else
                {
                    tHash[t[i]] = 1;
                }
            }
            return MinSubs(s, tHash);
        }

        static string MinSubs(string input, Dictionary<char, int> tHashOrig)
        {
            if (input == "")
            {
                return "";
            }
            if (tHashOrig.Count == 0)
            {
                return "";
            }
            string subString = input;
            bool found = false;
            for (int i = 0; i < input.Length; i++)
            {
                Dictionary<char, int> tHash = new Dictionary<char, int>(tHashOrig);
                string subStrAtI = "";
                char c = input[i];
                if (tHash.ContainsKey(c))
                {
                    tHash[c]--;
                    
                    if (tHash[c] <= 0)
                    {
                        tHash.Remove(c);
                    }
                }
                else
                {
                    continue;
                }
                subStrAtI += c;
                if (tHash.Count > 0)
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        char cAtJ = input[j];
                        if(tHash.ContainsKey(cAtJ))
                        {
                            tHash[cAtJ]--;
                            
                            if(tHash[cAtJ] <= 0 )
                            {
                                tHash.Remove(cAtJ);
                            }
                        }
                        subStrAtI += cAtJ;
                        if( tHash.Count == 0)
                        {
                            break;
                        }
                    }
                }
                if(tHash.Count == 0)
                {
                    found = true;
                }
                if (subString.Length > subStrAtI.Length && tHash.Count == 0)
                {
                    subString = subStrAtI;
                }
            }
            return found ? subString : "";
        }

        static string MinSubsRec(string input, Dictionary<char, int> tHashOrig)
        {
            if (input == "")
            {
                return "";
            }
            if (tHashOrig.Count == 0)
            {
                return "";
            }
            string subString = input;
            
            Dictionary<char, int> tHash = new Dictionary<char, int>(tHashOrig);
            string subStrAtI = "";
            char c = input[0];
            if (tHash.ContainsKey(c))
            {
                if (tHash[c] > 0)
                {
                    tHash[c]--;
                }
                if (tHash[c] <= 0)
                {
                    tHash.Remove(c);
                }
            }
            subStrAtI += c;

            subStrAtI += MinSubsRec(input.Substring(1), tHash);

            if (subString.Length > subStrAtI.Length)
            {
                subString = subStrAtI;
            }
            
            return subString;
        }
    }
}
