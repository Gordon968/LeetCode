using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class ClassPrint
    {
        public static void PrintArr(int[] arr)
        {
            string output = "[";
            for (int j = 0; j < arr.Length; j++)
            {
                output += arr[j];
                if (j < arr.Length - 1)
                {
                    output += ",";
                }
            }
            output += "]";

            Console.WriteLine(output);
        }

        public static void PrintArr(string[] arr)
        {
            string output = "[";
            for (int j = 0; j < arr.Length; j++)
            {
                output += arr[j];
                if (j < arr.Length - 1)
                {
                    output += ",";
                }
            }
            output += "]";

            Console.WriteLine(output);
        }

        public static void PrintArrays(List<int[]> arrs)
        {

            Console.WriteLine("Sub arrays for index = " );
            for (int i = 0; i < arrs.Count; i++)
            {
                string output = "[";

                for (int j = 0; j < arrs[i].Length; j++)
                {
                    output += arrs[i][j];
                    if (j < arrs[i].Length - 1)
                    {
                        output += ",";
                    }
                }
                output += "]";

                Console.WriteLine(output);
            }
        }

        public static void PrintArrays<T>(List<List<T>> arrs)
        {

            Console.WriteLine("Sub arrays for index = ");
            for (int i = 0; i < arrs.Count; i++)
            {
                string output = "[";

                for (int j = 0; j < arrs[i].Count; j++)
                {
                    output += arrs[i][j];
                    if (j < arrs[i].Count - 1)
                    {
                        output += ",";
                    }
                }
                output += "]";

                Console.WriteLine(output);
            }
        }
    }
}
