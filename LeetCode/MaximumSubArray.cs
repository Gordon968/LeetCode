using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /*
     * Give an integer array, find the continguous subarray (containing at least of one number),
     * which has largest sum and return it is sum
     * 
     */
    internal class MaximumSubArray
    {
        /*
         * Method 1:
         * We go through the array, from each of the elemet, add the next element to the list and record the lagest sum. 
         * For the next elemet if it is smaller than previous lagest element, we don't need to do any calculations. For example:
         * intput [5, 3, 2, 6, ...], we add all the numbers following first element 5, we don't need to add following numbers to 2nd, 3rd element, since 3, and 2 is smaller than 5
         */
        public static int MaxSumSubArray(int[] nums)
        {
            int n = nums.Length;
            if( n == 0)
            {
                return 0;
            }
            if( n == 1)
            {
                return nums[0];
            }

            int previousMaxElement = int.MinValue;
            int maxSum = int.MinValue;

            for(int i= 0; i < n; i++)
            {
                int maxSumAtI = int.MinValue;
                int sum = nums[i];
                if( nums[i] <= previousMaxElement)
                {
                    continue;
                }
                if( nums[i] > previousMaxElement)
                {
                    previousMaxElement = nums[i];
                }
                
                for( int j=i+1; j < n; j++)
                {
                    sum += nums[j];
                    if( maxSumAtI < sum )
                    {
                        maxSumAtI = sum;
                    }
                }

                
                if(maxSumAtI > maxSum)
                {
                    maxSum = maxSumAtI;
                }
            }
            return maxSum;
        }

        public static int MaxSumSubArrayDivideAndConque(int []nums, int low, int high)
        {
            if( low>high)
            {
                return int.MinValue;
            }
            if( high - low == 0)
            {
                //  one element
                return nums[low];
            }
            int middle = (high + low)/2;

            return Math.Max(Math.Max(MaxSumSubArrayDivideAndConque(nums, low, middle-1), MaxSumSubArrayDivideAndConque(nums, middle + 1, high)), MaxSumSubArrayCrossingMiddle(nums, low, middle, high));
        }

        private static int MaxSumSubArrayCrossingMiddle(int []nums, int low, int middle, int high)
        {
            int sum = 0;
            int left_sum = int.MinValue;
            for( int i=middle; i>=low; i--)
            {
                sum += nums[i];
                if( left_sum < sum)
                {
                    left_sum = sum;
                }
            }
            sum = 0;
            int right_sum = int.MinValue;
            for( int i=middle+1; i<=high; i++)
            {
                sum += nums[i];
                if( right_sum < sum)
                {
                    right_sum = sum;
                }
            }
            return Math.Max(left_sum + right_sum, Math.Max(left_sum, right_sum));
        }
    }
}
