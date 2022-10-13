using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Insertion Sort, basically, this algorithm works by first virtually dividing the list in two parts. 
     * While, the first part belongs to the sorted list, the other part is unsorted. 
     * Further, the agorithm picks an element from the unsorted part and inserts it 
     * in the correct place in the sorted part of the list.
     */
    class SortInsertion
    {
        public static void Sort(int []array)
        {
            for( int i=1; i<array.Length; i++)
            {
                int j = i - 1;
                int valI = array[i];
                while(j>=0 && array[j] > valI)
                {
                    //  move the valI to front
                    int temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                    j--;
                }
                //int temp = array[j+1];
                //array[j+1] = valI;
                //array[i] = temp;
            }
        }
    }
}
