using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TreeBinary
    {
        Node root;

        public Node Root { get => root; set => root = value; }

        public TreeBinary()
        {
            Root = null;
        }
        public TreeBinary(int key)
        {
            Root = new Node(key);
        }

        public int Height(Node node)
        {
            if( node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public int Depth(Node node, int x)
        {
            if( node == null )
            {
                return -1;
            }
            int depth = -1;

            if ( node.Key == x )
            {
                return depth+1;
            }
            depth = Depth(node.Left, x);
            if( depth >= 0 )
            {
                return depth + 1;
            }
            depth = Depth(node.Right, x);
            if( depth >= 0 )
            {
                return depth + 1;
            }
            return depth;
        }
        /// <summary>
        /// The diameter of a tree T is the largest of the following quantities:
        /// the diameter of T’s left subtree.
        /// the diameter of T’s right subtree.
        /// the longest path between leaves that goes through the root of T(this can be computed from the heights of the subtrees of T)
        /// </summary>
        /// <returns></returns>
        public int Diameter(Node root)
        {
            if( root == null )
            {
                return 0;
            }
            int lHeight = Height(root.Left);
            int rHeight = Height(root.Right);

            int lDiameter = Diameter(root.Left);
            int rDiameter = Diameter(root.Right);

            return Math.Max(lHeight+rHeight + 1, Math.Max(lDiameter, rDiameter));
        }

        public void PreOrder(Node node)
        {
            if( node == null )
            {
                return;
            }
            Console.Write(node.Key + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
        public void InOrder(Node node)
        {
            if( node == null )
            {
                return;
            }
            InOrder(node.Left);
            
            Console.Write(node.Key + " ");
            
            InOrder(node.Right);
        }

        public void PostOrder(Node node)
        {
            if( node == null )
            {
                return;
            }
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Key + " ");
        }
        /*
         * insert to the tree with first available position
         */
        void InsertLevelOrder(Node node, int key)
        {
            if( node == null)
            {
                Root = new Node(key);
                return;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while(q.Count != 0 )
            {
                Node qHeader = q.Dequeue();
                if(qHeader.Left == null )
                {
                    qHeader.Left = new Node(key);
                    break;
                }
                else
                {
                    //  put left child to the top of the queue
                    q.Enqueue(qHeader.Left);
                }

                if(qHeader.Right == null )
                {
                    qHeader.Right = new Node(key);
                    break;
                }
                else
                {
                    q.Enqueue(node);
                }
            }
        }
        /*
         * Given a binary tree, delete a node from it by making sure that the tree shrinks 
         * from the bottom (i.e. the deleted node is replaced by the bottom-most and rightmost node). 
         * Delete 10 in below tree

               10
             /    \         
          20     30

        Output:    
               30
             /             
         20  
        
        It will delete all the nodes under that nodes
         */
        void DeleteDeepestNode(Node root, int value)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while(q.Count != 0)
            {
                Node temp = q.Dequeue();
                if (temp.Key == value)
                {
                    temp = null;
                    return;
                }
                if( temp.Right != null )
                {
                    if(temp.Right.Key == value)
                    {
                        temp.Right = null;
                        return;
                    }
                    else
                    {
                        q.Equals(temp.Right);
                    }
                }
                if( temp.Left != null)
                {
                    if( temp.Left.Key == value)
                    {
                        temp.Left = null;
                        return;
                    }
                    else
                    {
                        q.Enqueue(temp.Left);
                    }
                }
            }
        }
        /*
         * It delete the right most node, and replace the node to be deleted  with deleted key value (temp, last right most deepest node)
         */
        void Delete(Node root, int key)
        {
            if (root == null)
                return;

            if (root.Left == null && root.Right == null)
            {
                if (root.Key == key)
                {
                    root = null;
                    return;
                }
                else
                    return;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node temp = null, keyNode = null;

            // Do level order traversal until
            // we find key and last node.
            while (q.Count != 0)
            {
                temp = q.Dequeue();

                if (temp.Key == key)
                {
                    //  find the node, save it, and this node value will be replaced by the right most node that will be removed
                    keyNode = temp;
                }

                if (temp.Left != null)
                {
                    q.Enqueue(temp.Left);
                }
                if (temp.Right != null)
                {
                    q.Enqueue(temp.Right);
                }
            }

            if (keyNode != null)
            {
                int x = temp.Key;
                //temp is the deepest node to be deleted and its value will be put as keyNode's value
                DeleteDeepestNode(root, temp.Key);
                keyNode.Key = x;
            }
        }
        /*
         * GetLeaveNodeCount(root)
         */
        public int GetLeaveNodeCount(Node node)
        {
            if( node == null )
            {
                return 0;
            }
            if( node.Left == null && node.Right == null)
            {
                return 1;
            }
            else
            {
                return GetLeaveNodeCount(node.Left) + GetLeaveNodeCount(node.Right);
            }
        }
        
        public void DeleteBSTKey(int key)
        {
            Root = DeleteRec(Root, key);
        }
        /*
         * Node to be deleted is the leaf: Simply remove from the tree. 
         * Node to be deleted has only one child: Copy the child to the node and delete the child
         * Node to be deleted has two children: Find inorder successor of the node (right part child of the node). 
         * Copy contents of the inorder successor to the node and delete the inorder successor. 
         * Note that inorder predecessor can also be used.
         */
        public Node DeleteRec(Node node, int key)
        {
            if( node == null )
            {
                return null;
            }
            if( node.Key < key )
            {
                // it must be in the right child
                node.Right = DeleteRec(node.Right, key);
            }
            else if( node.Key > key)
            {
                // it must be in the left child
                node.Left = DeleteRec(node.Left, key);
            }
            else
            {
                // node.Key == key
                if( node.Left == null && node.Right == null)
                {
                    //  it is a leaf node
                    return null;
                }
                else if( node.Left == null )
                {
                    //  no left child, point to the right child
                    return node.Right;
                }
                else if( node.Right == null )
                {
                    // no right child, point to left child
                    return node.Left;
                }
                else
                {
                    //  has left and right child
                    //  we need to replace the key with min value on the right child
                    int minVal = MinValue(node.Right);
                    node.Right = DeleteRec(node.Right, minVal);
                    node.Key = minVal;
                    return node;
                }
            }
            return node;
        }
        int MinValue(Node node)
        {
            int minVal = node.Key;
            
            while( node.Left != null )
            {
                minVal = node.Left.Key;
                node = node.Left;
            }
            return minVal;
        }

        public void PrintRightView(Node root)
        {
            if (root == null)
            {
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                // number of nodes at current level
                int n = queue.Count;

                // Traverse all nodes of current level
                for (int i = 1; i <= n; i++)
                {
                    Node temp = queue.Dequeue();

                    // Print the left most element at
                    // the level
                    if (i == n)
                        Console.Write(temp.Key + " ");

                    // Add left node to queue
                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);

                    // Add right node to queue
                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);
                }
            }
        }
        /*
         * we will see that our main task is to print the left most node of every level. 
         * So, we will do a level order traversal on the tree and print the leftmost node at every level. 
         * Below is the implementation of above approach
         */
        public void PrintLeftView(Node root)
        {
            if (root == null)
            {
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                // number of nodes at current level
                int n = queue.Count;

                // Traverse all nodes of current level
                for (int i = 1; i <= n; i++)
                {
                    Node temp = queue.Dequeue();

                    // Print the left most element at
                    // the level
                    if (i == 1)
                        Console.Write(temp.Key + " ");

                    // Add left node to queue
                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);

                    // Add right node to queue
                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);
                }
            }
        }

        /*
         * The problem can also be solved using simple recursive traversal. 
         * We can keep track of the level of a node by passing a parameter to 
         * all recursive calls. The idea is to keep track of the maximum level also. 
         * Whenever we see a node whose level is more than maximum level so far, 
         * we print the node because this is the first node in its level (Note that 
         * we traverse the left subtree before right subtree). 
         * 
         * initial calls PrintLeftTreeRecursive(root, 1, 0)
         */
        public void PrintLeftTreeRecursive(Node node, int level, ref int maxLevel)
        {
            if( node == null )
            {
                return;
            }
            if( maxLevel < level)
            {
                Console.Write(node.Key + " ");
                maxLevel = level;
            }
            PrintLeftTreeRecursive(node.Left, level + 1, ref maxLevel);
            PrintLeftTreeRecursive(node.Right, level + 1, ref maxLevel);
        }
        /*
         * initial calls PrintRightTreeRecursive(root, 1, 0);
         */
        public void PrintRightTreeRecursive(Node node, int level, ref int maxLevel)
        {
            if (node == null)
            {
                return;
            }
            if (maxLevel < level)
            {
                Console.Write(node.Key + " ");
                maxLevel = level;
            }
            PrintRightTreeRecursive(node.Right, level + 1, ref maxLevel);
            PrintRightTreeRecursive(node.Left, level + 1, ref maxLevel);
        }
    }
}
