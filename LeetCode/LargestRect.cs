using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.
    Example 1:

    Input: heights = [2,1,5,6,2,3]
    Output: 10
    Explanation: The above is a histogram where width of each bar is 1.
    The largest rectangle is shown in the red area, which has an area = 10 units.

    Example 2:
    Input: heights = [2,4]
    Output: 4
     */
    internal class LargestRect
    {
        public static int MaxArea(int[]heights)
        {
            int area = 0;
            if (heights.Length == 0)
            {
                return 0;
            }
            if (heights.Length == 1)
            {
                return heights[0];
            }
            int miHeight = 0, maHeight = 0;
            minMaxHeight(heights, 0, heights.Length - 1, out miHeight, out maHeight);
            if( miHeight == maHeight)
            {
                return maHeight * heights.Length;
            }
            for(int i = 0; i < heights.Length; i++)
            {
                int areaAtI = heights[i];
                if (heights[i] == 0)
                {
                    continue;
                }
                int height = heights[i];
                for(int j=i+1; j < heights.Length; j++)
                {
                    if(height > heights[j])
                    {
                        height = heights[j];
                    }
                    
                    int areaI_J = (j - i + 1) * height;
                    if(areaAtI < areaI_J)
                    {
                        areaAtI = areaI_J;
                    }
                    if (height == 0)
                    {
                        break;
                    }
                }
                if( area < areaAtI)
                {
                    area = areaAtI;
                }
            }
            return area;
        }
        public static void minMaxHeight(int[] histogram, int i, int j, out int min, out int max)
        {
            min = histogram[i];
            max = histogram[i];
            if (i == j)
            {
                min = max = histogram[i];
                return;
            }
            for (int k = i + 1; k <= j; k++)
            {
                if (min > histogram[k])
                {
                    min = histogram[k];
                }
                if (max < histogram[k])
                {
                    max = histogram[k];
                }
            }
        }
        public static int minHeight(int[]histogram, int i, int j)
        {
            int height = histogram[i];
            if( i == j )
            {
                return histogram[i];
            }
            for(int k = i+1; k <= j; k++)
            {
                if( height > histogram[k])
                {
                    height = histogram[k];
                }
            }
            return height;
        }
        public static int maxHeight(int[] histogram, int i, int j)
        {
            int height = int.MinValue;
            if (i == j)
            {
                return histogram[i];
            }
            for (int k = i; k <= j; k++)
            {
                if (height < histogram[k])
                {
                    height = histogram[k];
                }
            }
            return height;
        }
    }
}
