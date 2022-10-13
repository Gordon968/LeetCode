using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     *  question:
     *  Given a fixed-length integer array arr, duplicate each occurrence of zero, shifting the remaining elements to the right.
     *  Note that elements beyond the length of the original array are not written. Do the above modifications to the input array in place and do not return anything.
     */
    public class DuplicateZero
    {
        static void DuplcateZero(int[] input)
        {
            int length = input.Length;
            int[] output = new int[length];
            int outputIndex = 0;
            int inputIndex = 0;
            while(outputIndex < length)
            {
                output[outputIndex] = input[inputIndex];
                inputIndex++;
                outputIndex++;

                if (outputIndex == length)
                {
                    break;
                }

                if (input[inputIndex-1] == 0)
                {
                    output[outputIndex] = 0;
                    outputIndex++;
                }

                if(outputIndex == length)
                {
                    break;
                }
            }
            ClassPrint.PrintArr(output);
        }

        public static void TestDuplicateZeros()
        {
            int[] input1 = { 1, 0, 0, 2, 4, 5, 0, 6, 7, 8 };
            DuplcateZero(input1);
            int[] input2 = { 1, 2, 3 };
            DuplcateZero(input2);
            int[] input3 = { 0, 0, 0 };
            DuplcateZero(input3);
        }
    }
}
