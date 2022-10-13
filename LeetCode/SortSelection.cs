using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Selection Sort is also a simple sorting technique. Furthermore, 
     * selection sort also works by dividing the list into sorted and unsorted part. 
     * Unlike, insertion sort, selection sort finds minimum element from the unsorted list and 
     * puts it at the beginning. Further, the element at beginning goes to the position of the minimum 
     * element. Therefore, now the first element also becomes the part of sorted list. 
     * Initially, the whole list is unsorted. So, this algorithm finds the minimum from the whole list 
     * and swaps it with the element at first position. After that, the sorted list contains one element 
     * and unsorted list contains n-1 elements, where n is the total number of elements. 
     * The same process is repeated for rest of the ellements.
     */
    class SortSelection
    {
        public static void Sort(int[] array)
        {
            for(int i=0; i<array.Length -1; i++)
            {
                //  we want to swap the min value in the array with ith element
                int minIndex = i;
                for(int j=i+1; j<array.Length; j++)
                {
                    if(array[j] < array[minIndex])
                    {
                        //  find the min index in the j loop
                        minIndex = j;
                    }
                }
                //  swap the minIndex and I elements
                if( minIndex != i )
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }
    }
}
