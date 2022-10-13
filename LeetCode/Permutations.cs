using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 47 Permutations II:
    /// Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.
    /// Example 1:
    /// Input: nums = [1,1,2]
    /// Output:
    /// [[1,1,2],
    /// [1,2,1],
    /// [2,1,1]]
    ///
    ///Example 2:
    ///Input: nums = [1,2,3]
    ///Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    ///
    ///Constraints:
    ///
    ///    1 <= nums.length <= 8
    ///   -10 <= nums[i] <= 10
    /// </summary>
    public class Permutations
    {
        static List<string> HashStringArray = new List<string>();

        public static List<int[]> GetPermutations(int[]input)
        {
            HashStringArray.Clear();

            List<int[]> allPermutations = new List<int[]>();
            Permutate(allPermutations, input, 0);

            return allPermutations;
        }

        static public void Permutate(List<int[]>outputs, int []input, int index)
        {
            string strInput = ArrayToString(input);
            if (!HashStringArray.Contains(strInput))
            {
                HashStringArray.Add(strInput);

                outputs.Add((int[])input.Clone());
            }
            if (index == input.Length)
            {
                return;
            }

            for(int i=index; i<input.Length; i++)
            {
                Swap(input, i, index);
                Permutate(outputs, input, index + 1);
                Swap(input, i, index);
            }
        }
        public static void Swap(int[]input, int i, int j)
        {
            if (i == j || input[i] == input[j])
            {
                return;
            }
            else
            {
                int temp = input[i];
                input[i] = input[j];
                input[j] = temp;
            }
        }
        public static string ArrayToString(int[]input)
        {
            string retVal = "";
            for( int i=0; i<input.Length; i++ )
            {
                retVal += string.Format("{0}", input[i]);
            }
            return retVal;
        }
    }
}
