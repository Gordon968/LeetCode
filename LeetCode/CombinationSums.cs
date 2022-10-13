using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target.You may return the combinations in any order.
    /// The same number may be chosen from candidates an unlimited number of times.Two combinations are unique if the frequency of at least one of the chosen numbers is different.
    /// It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
    ///
    /// Example 1:
    ///Input: candidates = [2, 3, 6, 7], target = 7
    ///Output: [[2,2,3], [7]]
    ///Explanation:
    ///2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
    ///7 is a candidate, and 7 = 7.
    ///These are the only two combinations.
    ///
    ///Example 2:
    ///Input: candidates = [2, 3, 5], target = 8
    ///Output: [[2,2,2,2], [2,3,3], [3,5]]
    ///
    ///Example 3:
    ///Input: candidates = [2], target = 1
    ///Output: []
    /// </summary>
    public class CombinationSums
    {
        private List<List<int>> results = new List<List<int>>();
        private int originalTarget = 0;
        public List<List<int>>CombinationSum(int []candidates, int target)
        {
            this.results.Clear();
            originalTarget = target;
            Array.Sort(candidates);
            int length = candidates.Length;
            int[] newCandidates = new int[length];
            Array.Copy(candidates, newCandidates, length);
            
            while (length > 0)
            {
                FindCombinations(newCandidates, originalTarget, new List<int>());
                newCandidates = new int[--length];
                Array.Copy(candidates, 1,newCandidates, 0, length);
            }
            return results;
        }

        private void FindCombinations(int []candidates, int remains, List<int>list)
        {
            if( remains == 0 )
            {
                //find the combination
                list.Sort();
                if (!IsListExists(list))
                {
                    this.results.Add(new List<int>(list));
                }
                return;
            }
            if( remains < 0 )
            {
                return;
            }
            foreach(int candidate in candidates.Where(e=>e<=remains))
            {
                list.Add(candidate);
                FindCombinations(candidates, remains - candidate, list);
                list.Remove(candidate);
            }
        }

        private bool IsListExists(List<int>newList)
        {
            foreach(List<int>elements in this.results.Where(e=>e.Count == newList.Count))
            {
                for(int i=0; i<elements.Count; i++)
                {
                    if( elements[i] != newList[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
