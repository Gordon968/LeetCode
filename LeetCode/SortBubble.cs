using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Bubble Sort is the most simple sorting algorithm. 
     * In general, bubble sort works by scanning each element of a list. 
     * Further, it checks the order of adjacent elements in the list. 
     * If the algorithm finds that the adjacent elements are in wrong order, 
     * it swaps these elements. For instance, if bubble sort is sorting in ascending order, 
     * it will check whether the next element is smaller than the previous one. 
     * If it is so, it will swap the two elements. Otherwise, it leaves the elements as they are.
     */
    class SortBubble
    {
        public static int[] Sort(int []array)
        {
            for(int i=0; i<array.Length-1; i++)
            {
                for(int j=0; j<array.Length-i-1; j++)
                {
                    //  make it the lat element is biggest
                    //  next i loop put it 2nd biggest...
                    if( array[j] > array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
    }
}
