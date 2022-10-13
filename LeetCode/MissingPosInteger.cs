using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Given an unsorted integer array nums, return the smallest missing positive integer.

You must implement an algorithm that runs in O(n) time and uses constant extra space.

 

Example 1:

Input: nums = [1,2,0]
Output: 3
Explanation: The numbers in the range [1,2] are all in the array.

Example 2:

Input: nums = [3,4,-1,1]
Output: 2
Explanation: 1 is in the array but 2 is missing.

Example 3:

Input: nums = [7,8,9,11,12]
Output: 1
Explanation: The smallest positive integer 1 is missing.

 

Constraints:

    1 <= nums.length <= 105
    -231 <= nums[i] <= 231 - 1


     */
    internal class MissingPosInteger
    {
        public static int FirstMissingPositive(int[] nums)
        {
            if( nums == null || nums.Length == 0)
            {
                return 1;
            }
            //  the missing integer will not be 2 bigger than total positive numbers
            int totalPosNum = nums.Length;
            Dictionary<int, int> maps = new Dictionary<int, int>();
            for( int i = 0; i < nums.Length; i++)
            {
                if( nums[i] > 0)
                {
                    // we don't care about duplicats
                    maps[nums[i]] = 1;
                }
                else
                {
                    totalPosNum--;
                }
            }
            if( totalPosNum == 0)
            {
                return 1;
            }
            int result = -1;
            for( int i=1; i<totalPosNum+1; i++)
            {
                if(maps.ContainsKey(i) )
                {
                    continue;
                }
                else
                {
                    result = i;
                    break;
                }
            }
            if(result == -1)
            {
                result = totalPosNum + 1;
            }
            return result;
        }
    }
}
