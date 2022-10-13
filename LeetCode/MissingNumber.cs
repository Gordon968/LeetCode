using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class MissingNumber
    {
        /*
         * Find All Numbers Disappeared in an Array
         * Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.
         * Example 1:
         * Input: nums = [4,3,2,7,8,2,3,1]
         * Output: [5,6]
         */
        public static int[] FindMissingNumber(int []input)
        {
            int length = input.Length;
            List<int> outputs = new List<int>();
            
            for(int i=1; i<length+1; i++)
            {
                outputs.Add(i);
            }
            for(int i=1; i<=length; i++)
            {
                outputs.Remove(input[i - 1]);
            }
            return outputs.ToArray();
        }
    }
}
