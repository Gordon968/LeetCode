using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Node
    {
        int key;
        Node left, right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }
        public int Key {get=> key; set=>Key = value; }
        public Node Left { set { left=value; } get { return left; }}

        public Node Right { get => right; set => right = value; }

    }
}
