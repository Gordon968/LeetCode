using System;
using System.Collections.Generic;
using System.Text;
//implements powe(x, n), x real number and n is integer
namespace LeetCode
{
    class Power
    {
        public static double Pow(double x, int n)
        {
            if( n==0 )
            {
                return 1;
            }
            double answer = Pow(x, n / 2);
            if( n%2 == 0)
            {
                return answer*answer;
            }
            else
            {
                return x * answer * answer;
            }
        }

    }
}
