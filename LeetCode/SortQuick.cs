using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * QuickSort is a Divide and Conquer algorithm. It picks an element as a pivot and 
     * partitions the given array around the picked pivot. 
     * There are many different versions of quickSort that pick pivot in different ways. 

     * Always pick the first element as a pivot.
     * Always pick the last element as a pivot (implemented below)
     * Pick a random element as a pivot.
     * Pick median as the pivot.
     * The key process in quickSort is a partition(). 
     */
    class SortQuick
    {
        public static void Sort(int[] array, int low, int high)
        {
            int pi = Partition(array, low, high);
            // value at index pi is alread in the right position so we don't need to include it in the next iteration
            Sort(array, low, pi-1);
            Sort(array, pi + 1, high);
        }
        /// <summary>
        /// //using last element as pivot, put values < pivot to the left of new piviot, 
        /// put values > pivot on right of the pivot
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int PartitionHigh(int[] array, int low, int high)
        {
            int pivot = array[high];
            int pivotIndex = low - 1;
            // go though each element and put smaller value to the left, bigger value on right
            for(int i=low; i<=high; i++)
            {
                if( array[i] < pivot)
                {
                    pivotIndex++;
                    Swap(array, pivotIndex, i);
                }
            }
            //  put the pivot in the right place
            pivotIndex++;
            Swap(array, pivotIndex, high);
            return pivotIndex;
        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[low];
            int pivotIndex = high+1;
            // go though each element and put smaller valur to the left, bigger value on right
            for (int i = high; i >=low; i--)
            {
                if (array[i] < pivot)
                {
                    pivotIndex--;
                    Swap(array, pivotIndex, i);
                }
            }
            //  put the pivot in the right place
            pivotIndex++;
            Swap(array, pivotIndex, low);
            return pivotIndex;
        }
        private static void Swap(int[] array, int i, int j)
        {
            if(i == j || i < 0 || i>=array.Length  || j<0 || j>=array.Length)
            {
                return;
            }
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
