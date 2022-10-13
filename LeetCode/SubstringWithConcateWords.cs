using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /*
     * You are given a string s and an array of strings words. All the strings of words are of the same length.

A concatenated substring in s is a substring that contains all the strings of any permutation of words concatenated.

    For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated substring because it is not the concatenation of any permutation of words.

Return the starting indices of all the concatenated substrings in s. You can return the answer in any order.

 

Example 1:

Input: s = "barfoothefoobarman", words = ["foo","bar"]
Output: [0,9]
Explanation: Since words.length == 2 and words[i].length == 3, the concatenated substring has to be of length 6.
The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.
The output order does not matter. Returning [9,0] is fine too.

Example 2:

Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
Output: []
Explanation: Since words.length == 4 and words[i].length == 4, the concatenated substring has to be of length 16.
There is no substring of length 16 is s that is equal to the concatenation of any permutation of words.
We return an empty array.

Example 3:

Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
Output: [6,9,12]
Explanation: Since words.length == 3 and words[i].length == 3, the concatenated substring has to be of length 9.
The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"] which is a permutation of words.
The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"] which is a permutation of words.
The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"] which is a permutation of words.

     */
    internal class SubstringWithConcateWords
    {
        public static List<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            if (string.IsNullOrWhiteSpace(s) || words == null || words.Length == 0 )
            {
                return result;
            }
            int subStringLength = words.Length * words[0].Length;
            int individualWordLength = words[0].Length;
            int wordCount = words.Length;

            if ( s.Length < subStringLength)//everywords has same length
            {
                return result;
            }
            //  most important thing is to do the concatenation of words
            foreach(string word in words)
            {
                //  the string needs to contain all the words
                if( !s.Contains(word))
                {
                    return result;
                }
            }
            //  we have all the combination with the all the words, so we can put words in a map
            Dictionary<string, int>dictWords = new Dictionary<string, int>();
            for( int i=0; i<words.Length; i++)
            {
                if( dictWords.ContainsKey(words[i]) )
                {
                    dictWords[words[i]]++;
                }
                else
                {
                    dictWords[words[i]] = 1;
                }
            }

            for(int i=0; i<s.Length-subStringLength; i++)
            {
                Dictionary<string, int> tempDictWords = new Dictionary<string, int>(dictWords);
                int count = wordCount;

                for( int j=i; j<s.Length-individualWordLength; j+=individualWordLength )
                {
                    string theWord = s.Substring(j,individualWordLength);

                    if(tempDictWords.ContainsKey(theWord) && tempDictWords[theWord] > 0)
                    {
                        tempDictWords[theWord]--;
                        count--;
                    }
                    else
                    {
                        break;
                    }
                    if( count == 0)
                    {
                        //  this means we find one concatanation in the s
                        result.Add(i);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
