using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Graph
    {
        internal const int MaxNode = 1024;
        // Contains the child nodes for each vertex of the graph

        // assuming that the vertices are numbered 0 ... Size-1

        private List<int>[] childNodes;



        /// <summary>Constructs an empty graph of given size</summary>

        /// <param name="size">number of vertices</param>

        public Graph(int size)
        {

            this.childNodes = new List<int>[size];

            for (int i = 0; i < size; i++)

            {

                // Assing an empty list of adjacents for each vertex

                this.childNodes[i] = new List<int>();

            }

        }



        /// <summary>Constructs a graph by given list of

        /// child nodes (successors) for each vertex</summary>

        /// <param name="childNodes">children for each node</param>

        public Graph(List<int>[] childNodes)
        {

            this.childNodes = childNodes;

        }



        /// <summary>

        /// Returns the size of the graph (number of vertices)

        /// </summary>

        public int Size
        {

            get { return this.childNodes.Length; }

        }



        /// <summary>Adds new edge from u to v</summary>

        /// <param name="u">the starting vertex</param>

        /// <param name="v">the ending vertex</param>

        public void AddEdge(int u, int v)
        {

            childNodes[u].Add(v);

        }



        /// <summary>Removes the edge from u to v if such exists

        /// </summary>

        /// <param name="u">the starting vertex</param>

        /// <param name="v">the ending vertex</param>

        public void RemoveEdge(int u, int v)
        {

            childNodes[u].Remove(v);

        }



        /// <summary>

        /// Checks whether there is an edge between vertex u and v

        /// </summary>

        /// <param name="u">the starting vertex</param>

        /// <param name="v">the ending vertex</param>

        /// <returns>true if there is an edge between

        /// vertex u and vertex v</returns>

        public bool HasEdge(int u, int v)
        {

            bool hasEdge = childNodes[u].Contains(v);

            return hasEdge;

        }



        /// <summary>Returns the successors of a given vertex

        /// </summary>

        /// <param name="v">the vertex</param>

        /// <returns>list of all successors of vertex v</returns>

        public IList<int> GetSuccessors(int v)
        {

            return childNodes[v];

        }
        public void TraverseBFS(int node)
        {
            bool[] visited = new bool[MaxNode];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;
            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                Console.Write("{0} ", currentNode);
                foreach (int childNode in childNodes[currentNode])
                {
                    if (!visited[childNode])
                    {
                        queue.Enqueue(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }
        public void TraverseDFS(int node)
        {
            bool[] visited = new bool[MaxNode];
            Stack<int> stack = new Stack<int>();
            stack.Push(node);
            visited[node] = true;
            while (stack.Count > 0)
            {
                int currentNode = stack.Pop();
                Console.Write("{0} ", currentNode);
                foreach (int childNode in childNodes[currentNode])
                {
                    if (!visited[childNode])
                    {
                        stack.Push(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }

        public void TraverseDFSRecursive(int node, bool[] visited)
        {
            if (!visited[node])
            {
                visited[node] = true;
                Console.Write("{0} ", node);
                foreach (int childNode in childNodes[node])
                {
                    TraverseDFSRecursive(childNode, visited);
                }
            }
        }

    }
}
