using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.

Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

For the last line of text, it should be left-justified, and no extra space is inserted between words.

Note:

    A word is defined as a character sequence consisting of non-space characters only.
    Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
    The input array words contains at least one word.

 

Example 1:

Input: words = ["This", "is", "an", "example", "of", "text", "justification."], maxWidth = 16
Output:
[
   "This    is    an",
   "example  of text",
   "justification.  "
]

Example 2:

Input: words = ["What","must","be","acknowledgment","shall","be"], maxWidth = 16
Output:
[
  "What   must   be",
  "acknowledgment  ",
  "shall be        "
]
Explanation: Note that the last line is "shall be    " instead of "shall     be", because the last line must be left-justified instead of fully-justified.
Note that the second line is also left-justified because it contains only one word.

Example 3:

Input: words = ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"], maxWidth = 20
Output:
[
  "Science  is  what we",
  "understand      well",
  "enough to explain to",
  "a  computer.  Art is",
  "everything  else  we",
  "do                  "
]
     */
    internal class TextJustification
    {
        public static List<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> results = new List<string>();

            int index = 0;

            while(index < words.Length)
            {
                int startIndex = index;
                int endIndex = startIndex;
                int length = 0;
                
                //List<string>subWords = new List<string>();
                int lineLength = 0;
                while(length < maxWidth && endIndex < words.Length)
                {
                    length += words[endIndex].Length+1; //1 is for space after word
                    if (length < maxWidth)
                    {
                        lineLength += words[endIndex].Length;
                        //subWords.Add(words[endIndex]);
                        endIndex++;
                    }
                    else
                    {
                        endIndex--;
                        break;
                    }
                    if( endIndex == words.Length )
                    {
                        endIndex--;
                        break;
                    }
                }
                int extraLen = maxWidth - lineLength;
                int numWordSeparations = endIndex - startIndex;
                int numberSpace = numWordSeparations != 0 ? extraLen / numWordSeparations:0;
                int extraOne = numWordSeparations != 0 ? extraLen % numWordSeparations : 0;
                string line = "";
                for( int i=startIndex; i <= endIndex; i++ )
                {
                    line += words[i];
                    if (i != endIndex)
                    {
                        for (int j = 0; j < numberSpace; j++)
                        {
                            line += " ";
                        }
                        if( extraOne > 0)
                        {
                            line += " ";
                            extraOne--;
                        }
                    }
                }
                if( line == "")
                {
                    break;
                }
                results.Add(line);
                index = endIndex+1;
            }
            //  get rid of extraspace for the last line
            string lastLine = results[results.Count-1];
            results.RemoveAt(results.Count - 1);
            string []lastLineWords = lastLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            lastLine = "";
            for( int i=0; i<lastLineWords.Length; i++)
            {
                lastLine += lastLineWords[i]+" ";
            }
            results.Add(lastLine);
            return results;  
        }
    }
}
