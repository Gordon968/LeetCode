using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /* Add 3 numbers from a integer array, so that i!=j, j!=k, i!=j num[i]+num[j]+num[k] = 0
     * get all this 3 numbers combinations
     */
    internal class ThreeSum
    {
        public static List<List<int>> GetAllListWith3SumsTo0(int[]num)
        {
            List<List<int>> list = new List<List<int>>();
            for( int i=0; i<num.Length; i++ )
            {
                List<List<int>> twoSum = GetAllListWith2SumsToNumber(num, -num[i], i, num[i]);
                for( int j=0; j<twoSum.Count; j++ )
                {
                    list.Add(twoSum[j]);
                }
            }
            return list;
        }

        public static List<List<int>> GetAllListWith2SumsToNumber(int[] nums, int twoSumVal, int threeSumIIndex, int iValue)
        {
            List<List<int>> twoSumList = new List<List<int>>();
            for(int i = threeSumIIndex+1; i < nums.Length; i++)
            {
                int jValue = twoSumVal - nums[i];
                for(int j = i+1; j < nums.Length; j++)
                {
                    if (nums[j] == jValue)
                    {
                        twoSumList.Add(new List<int>() {iValue, nums[i], nums[j] });
                    }
                }
            }
            return twoSumList;
        }
    }
}
