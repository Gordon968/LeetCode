using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class FindMin
    {
        /**
         *  Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,4,4,5,6,7] might become:

            [4,5,6,7,0,1,4] if it was rotated 4 times.
            [0,1,4,4,5,6,7] if it was rotated 7 times.
            Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

            Given the sorted rotated array nums that may contain duplicates, return the minimum element of this array.

            You must decrease the overall operation steps as much as possible.
         */
        public static void Test()
        {
            int[] nums = { 1, 3, 5 };
            Console.WriteLine(FindMinVal(nums));
            int[] nums2 = { 2, 2, 2, 0, 1 };
            Console.WriteLine(FindMinVal(nums2));
            int[] nums3 = { 5, 5, 5, 5, 5 };
            Console.WriteLine(FindMinVal(nums3));
            //int[] nums4 = { 5, 4, 3, 2, 1, 0 };
            //Console.WriteLine(FindMinVal(nums4));
            int[] nums5 = { 1, 1,3 };
            Console.WriteLine(FindMinVal(nums5));
            int[] nums6 = { 5, 5, 5, 3, 4, 4};
            Console.WriteLine(FindMinVal(nums6));
            int[] nums7 = { 3, 5, 1 };
            Console.WriteLine(FindMinVal(nums7));
        }
        /// <summary>
        /// the array can be: 
        /// 1) a, b, c, d, e, f, g, the minimum is first element
        /// 2) f, g, a, b, c, d, e  the minimum is 3rd element, increase then decrese, we can find the right most maximum index, and the next one is minumum
        /// 3) f, f, g, g, a, a, b.....
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMinVal(int[] nums)
        {
            int length = nums.Length;
            int max = nums[0];
            int index = 0;
            for (int i = 1; i < length; i++)
            {
                if (nums[i] >= max)
                {
                    max = nums[i];
                    index = i;
                }
                else
                {
                    break;
                }
            }
            return nums[(index + 1) % length];
        }
    }
}
