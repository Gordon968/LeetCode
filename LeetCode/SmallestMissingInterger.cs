using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class SmallestMissingInterger
    {
        /*
        Given an unsorted integer array nums, return the smallest missing positive integer.
        You must implement an algorithm that runs in O(n) time and uses constant extra space.
        Example 1:
        Input: nums = [1, 2, 0]
        Output: 3
        Example 2:
        Input: nums = [3, 4, -1, 1]
        Output: 2
        */
        public static int FindSmallestMissingPosInterger(int[] nums)
        {
            int length = nums.Length;
            int min = int.MaxValue;
            int output = 1;
            
            List<int> positives = new List<int>();

            for(int i=0; i<length;  i++)
            {
                if (nums[i] > 0 && nums[i] < min)
                {
                    min = nums[i];
                }
                
                if(nums[i] > 0)
                {
                    positives.Add(nums[i]);
                }
            }

            if( min != 1)
            {
                //  minmum number is bigger than 1, we find the minimum missing number
                output = min - 1;
            }
            else
            {
                int posSize = positives.Count;
                for(int i=0; i<posSize; i++)
                {
                    if(positives[i]-1 < posSize)
                    {
                        positives[positives[i] - 1] = -1;
                    }
                }
            }
            for(int i=0; i<positives.Count; i++ )
            {
                if(positives[i] > 0 )
                {
                    output = positives[i] - 1;
                }
            }
            return output;
        }
    }
}
