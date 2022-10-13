using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Merge Sort is one of the popular sorting algorithms in C# as it uses the minimum number of comparisons.
     * The idea behind merge sort is that it is merging two sorted lists.
     */
    class SortMerge
    {
        public static void Sort(int []number, int left, int right)
        {
            if(right > left)
            {
                int mid = (right + left) / 2;
                Sort(number, left, mid);
                Sort(number, mid + 1, right);

                Merge(number, left, mid+1, right);
            }
        }
        protected static void Merge(int []number, int left, int mid, int right)
        {
            int leftE = mid - 1;//end index for the left part of 
            int leftIndex = left;
            int rightIndex = mid;
            int totalE = right - left + 1;
            int[] temp = new int[number.Length];
            int tempPos = left;
            while(leftIndex<=leftE && rightIndex<=right)
            {
                if( number[leftIndex] <= number[rightIndex])
                {
                    temp[tempPos++] = number[leftIndex++];
                }
                else
                {
                    temp[tempPos++] = number[rightIndex++];
                }
            }
            //merge rest of them
            while(leftIndex <= leftE)
            {
                temp[tempPos++] = number[leftIndex++];
            }
            while (rightIndex <= right)
            {
                temp[tempPos++] = number[rightIndex++];
            }
            leftIndex = left;
            for( int i=0; i<totalE; i++)
            {
                number[leftIndex] = temp[leftIndex];
                leftIndex++;
            }
        }

    }
}
