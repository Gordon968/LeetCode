using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace LeetCode
{
    /*
    Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.



Example 1:

Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
    Output: 6
Explanation: The above elevation map(black section) is represented by array[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]. In this case, 6 units of rain water (blue section) are being trapped.

Example 2:

Input: height = [4, 2, 0, 3, 2, 5]
Output: 9




Constraints:

    n == height.length
    1 <= n <= 2 * 104
    0 <= height[i] <= 105
    */

    internal class WaterTrapping
    {
        public static int Trap(int[] height)
        {
            //  we can calculate the area trapped by 2 bars
            int bar_num = height.Length;
            int non_zero_initial_bar_index = 0;
            if( height.Length <=2 )
            {
                return 0;
            }
            while(non_zero_initial_bar_index < bar_num)
            {
                if (height[non_zero_initial_bar_index] == 0)
                {
                    non_zero_initial_bar_index++;
                }
                else
                {
                    break;
                }
            }
            if( non_zero_initial_bar_index == bar_num-1)
            {
                //  input is all zero height bars
                return 0;
            }
            int result = 0;
            int index = non_zero_initial_bar_index;
            while ( index <height.Length)
            {
                if(index+1 < height.Length && height[index] <= height[index+1])
                {
                    index++;
                }
                else
                {
                    //  the next one is short and available for trapping some water
                    //  there are a few situation that we can trap water
                    //  1) need to find the next index that is higher or equal with height[index]
                    //  2) later bar is high than previous bar
                    int nextBarIndex = index;
                    
                    int theNextHeight = -1;
                    
                    for(int i=index+1; i<height.Length; i++)
                    {
                        if (height[i] >= height[index])
                        {
                            // meet the condition one
                            nextBarIndex = i;
                            theNextHeight = height[i];
                            break;
                        }
                        
                        //  we can rtap water
                        if( theNextHeight <= height[i])
                        {
                            //  get the highest bar after index
                            nextBarIndex = i;
                            theNextHeight = height[i];
                        }    
                    }
                    
                    if (theNextHeight > 0)
                    { 
                        int theHeight = Math.Min(height[index], theNextHeight);
                        int totalWaterBy2Bar = theHeight * (nextBarIndex - index - 1);
                        int obstacks = 0;
                        for (int j = index + 1; j < nextBarIndex; j++)
                        {
                            obstacks += height[j];
                        }
                        
                        if (totalWaterBy2Bar - obstacks > 0)
                        {
                            result += totalWaterBy2Bar - obstacks;
                        }

                        //  we start at nextBarIndex again
                        if (nextBarIndex > index)
                        {
                            index = nextBarIndex;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}
