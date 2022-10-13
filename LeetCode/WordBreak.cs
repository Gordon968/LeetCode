using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * The Dynamic Programming solution only finds whether it is possible to break a word or not. 
     * Here we need to print all possible word breaks.
     * We start scanning the sentence from the left. As we find a valid word, we need to check whether 
     * the rest of the sentence can make valid words or not. Because in some situations the first found word 
     * from the left side can leave a remaining portion that is not further separable. 
     * So, in that case, we should come back and leave the currently found word and keep on searching for the next word. 
     * And this process is recursive because to find out whether the right portion is separable or not, 
     * we need the same logic. So we will use recursion and backtracking to solve this problem. 
     * To keep track of the found words we will use a stack. Whenever the right portion of the string does not 
     * make valid words, we pop the top string from the stack and continue finding.
     */
    class WordBreak
    {
        static void wordBreak(List<string> dictionary, string input, string ans)
        {
            int n = input.Length;
            for( int i=1; i<=n; i++)
            {
                string word = input.Substring(0, i);
                if( dictionary.Contains(word))
                {
                    ans += word+" ";
                    if( i== n)
                    {
                        Console.WriteLine(ans);
                    }
                    else
                    {   
                        wordBreak(dictionary, input.Substring(i), ans);
                    }
                }
            }
        }
        public static void Testing()
        {
            string str1 = "iloveicecreamandmango"; // for first test case
            string str2 = "ilovesamsungmobile";     // for second test case
                           // length of second string
            List<string> dict = new List<string>(new string[]{"mobile","samsung","sam","sung",
                                      "man","mango", "icecream","and",
                                      "go","i","love","ice","cream"});
            Console.WriteLine("First Test:");
            string ans = "";
            // call to the method
            wordBreak(dict, str1, ans);
            Console.WriteLine();
            Console.WriteLine("Second Test:");

            // call to the method
            ans = "";
            wordBreak(dict, str2, ans);
        }
    }
}
