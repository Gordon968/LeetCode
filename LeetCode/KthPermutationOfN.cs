using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * The set [1, 2, 3, ..., n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

    "123"
    "132"
    "213"
    "231"
    "312"
    "321"

Given n and k, return the kth permutation sequence.

 

Example 1:

Input: n = 3, k = 3
Output: "213"

Example 2:

Input: n = 4, k = 9
Output: "2314"

Example 3:

Input: n = 3, k = 1
Output: "123"

 

Constraints:

    1 <= n <= 9
    1 <= k <= n!


     */
    internal class KthPermutationOfN
    {
        public static string FindKthPermutation(int n, int k)
        {
            
            List<int> arrays = new List<int>();
            for( int i=1; i<=n; i++)
            {
                arrays.Add(i);
            }
            return FindPermRecursive(n, k, arrays);
        }

        static string FindPermRecursive(int n, int k, List<int>arrays)
        {
            string results = "";
            if( n==1 || k==0)
            {
                return arrays[0].ToString();
            }
            for (int i = 1; i <= k; i++)
            {
                int Index = 0;
                int factor = Factorial(n - i);
                while (k > factor)
                {
                    Index++;
                    k -= factor;
                }
                results += string.Format("{0}", arrays[Index]);
                arrays.RemoveAt(Index);
            }
            return results + FindPermRecursive(arrays.Count, k, arrays);
        }
        static int Factorial(int n)
        {
            if( n==0 || n==1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }


    }
}
