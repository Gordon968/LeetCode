using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    internal class Median2SortedArray
    {
        public static double Median2Arrays(int[] array1, int[] array2)
        {
            int len1 = array1.Length;
            int len2 = array2.Length;
            int merged2ArrayLength = len1 + len2;
            int[] merged = new int[merged2ArrayLength];
            int leftArray1 = 0, leftArray2 = 0;
            int indexMerged = 0;
            while (leftArray1 < len1 && leftArray2 < len2)
            {
                if (array1[leftArray1] <= array2[leftArray2])
                {
                    merged[indexMerged++] = array1[leftArray1++];
                }
                else
                {
                    merged[indexMerged++] = array2[leftArray2++];
                }
            }
            while( leftArray1 < len1-1 )
            {
                merged[indexMerged++] = array1[leftArray1++];
            }
            while( leftArray2 < len2-1 )
            {
                merged[indexMerged++] = array2[leftArray2++];
            }

            if( merged2ArrayLength%2 == 0)
            {
                return (merged[merged2ArrayLength / 2] + merged[merged2ArrayLength / 2 - 1]) / 2.0;
            }
            else
            {
                return merged[merged2ArrayLength / 2];
            }
        }
    }
}
