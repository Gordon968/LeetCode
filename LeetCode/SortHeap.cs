using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * It divides its input into a sorted and unsorted region, 
     * it iteratively shrinks the unsorted region by extraction the largest element and 
     * moving that to the sorted region.
     * It first removes the topmost item (the largest) and replace it with the rightmost leaf. 
     * The topmost item is stored in an array and Re-establish the heap.
     * this is done until there are no more items left in the heap.
     */
    class SortHeap
    {
        int Length = 0;

        public int[] Sort(int[] array)
        {
            int[] output = new int[array.Length];

            BuildMaxHeap(array);
            while (this.Length > 0)
            {
                int max = RemoveMaximum(array);
                output[this.Length] = max;
            }
            return output;
        }
        private void BuildMaxHeap(int[] array)
        {
            this.Length = array.Length;

            for (int i = this.Length / 2; i > 0; i--)
            {
                MaxHeapify(i, array);
            }

            return;
        }

        public void MaxHeapify(int index, int[] array)
        {
            var left = 2 * index;
            var right = 2 * index + 1;

            int max = index;
            if (left <= this.Length && array[left - 1] > array[index - 1])
            {
                max = left;
            }

            if (right <= this.Length && array[right - 1] > array[max - 1])
            {
                max = right;
            }

            if (max != index)
            {
                int temp = array[max - 1];
                array[max - 1] = array[index - 1];
                array[index - 1] = temp;
                MaxHeapify(max, array);
            }

            return;
        }

        public int RemoveMaximum(int[] array)
        {
            int maximum = array[0];

            array[0] = array[this.Length - 1];
            this.Length--;
            MaxHeapify(1, array);
            return maximum;
        }
    }
}
