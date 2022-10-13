using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Given an undirected graph and a number m, determine if the graph can be coloured with 
     * at most m colours such that no two adjacent vertices of the graph are colored with the 
     * same color. Here coloring of a graph means the assignment of colors to all vertices. 
     * the graph will have connection between N vertices:
     * indicated by true or false values Matrix, i.e.:
     * bool[,] graph = {
        { false, true, true, true },
        { true, false, true, false },
        { true, true, false, true },
        { true, false, true, false },
    }; Here vertices will not have a connecton to themself for coloring putpose    
     */
    class ColoringGraph
    {
        int V = 0; //number of vertices
        protected bool IsSafe(bool[,]graph, int [] color)
        {
            for(int i=0; i<V; i++)
            {
                for(int j=0; j<V; j++)
                {
                    if(graph[i, j] && color[i] == color[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph">edges between vertices</param>
        /// <param name="m">number of color</param>
        /// <param name="i">ith vertices</param>
        /// <param name="color">color with V element, each represent color on the vertices</param>
        /// <returns></returns>
        bool ColorVertices(bool[,] graph, int m, int i, int[] color)
        {
            if (i == V)
            {
                if( IsSafe(graph, color))
                {
                    PrintSolution(color);
                    return true;
                }
                return false;
            }
            for(int j=1; j<=m; j++)
            {
                color[i] = j;
                //  color next one
                if( ColorVertices(graph, m, i+1, color))
                {
                    return true;
                }
                //  back track color
                color[i] = 0;
            }
            return false;
        }
        void PrintSolution(int []color)
        {
            Console.WriteLine("Solution Exists:" +
                         " Following are the assigned colors ");
            for (int i = 0; i < V; i++)
                Console.Write("  " + color[i]);
            Console.WriteLine();
        }
    }
    
}
