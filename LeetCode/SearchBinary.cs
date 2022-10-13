using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    //  binary search is for the arraY that is sorted and find the value
    class SearchBinary
    {
        public static int SearchByLoop(int []array, int value)
        {
            int low = 0, high = array.Length - 1, middle = (high + low) / 2;

            while(low<= high)
            {
                if(array[middle] == value)
                {
                    return middle;
                }
                else if( array[middle] < value)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
                middle = (high + middle) / 2;
            }
            return - 1;
        }
        public static int SearchByRecursive(int []array, int low, int high, int value)
        {
            if(high>=low)
            {
                int m = (low + high) / 2;
                if( array[m] == value )
                {
                    return m;
                }
                else if( array[m]> value)
                {
                    return SearchByRecursive(array, low, m - 1, value);
                }
                else
                {
                    return SearchByRecursive(array, m + 1, high, value);
                }
            }
            return -1;
        }

        public static int[] Sort(int []array, int low, int high)
        {
            return null;
        }
    }
}
