using System;
using System.Collections.Generic;
using System.Text;
/*/ <summary>
/// Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
Example 2:

Input: strs = [""]
Output: [[""]]
Example 3:

Input: strs = ["a"]
Output: [["a"]]
/// </summary>
/// */
namespace LeetCode
{
    class GroupAnagram
    {
        public static List<List<string>> GroupAnagrams(List<string>inputs)
        {
            //  since all the anagrams has sam letter, so all the values of the letter is the same, we can use hash code, or we can rearrage the letter to
            Dictionary<int, List<string>> hash = new Dictionary<int, List<string>>();
            foreach(string item in inputs)
            {
                int theHashCode = 0;
                foreach(char letter in item)
                {
                    theHashCode += (letter - 'a');
                }
                if(!hash.ContainsKey(theHashCode))
                {
                    List<string> hashString = new List<string>();
                    hashString.Add(item);
                    hash.Add(theHashCode, hashString);
                }
                else
                {
                    hash[theHashCode].Add(item);
                }
            }

            List<List<string>>outputs = new List<List<string>>();
            foreach(KeyValuePair<int, List<string>>pair in hash)
            {
                outputs.Add(pair.Value);
            }
            return outputs;
        }

    }
}
