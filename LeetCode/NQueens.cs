using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class NQueens
    {
        int NQueen = 0;

        public NQueens(int N)
        {
            NQueen = N;
        }
        /* A utility function to check if a queen can
        be placed on board[row,col]. Note that this
        function is called when "col" queens are already
        placeed in columns from 0 to col -1. So we need
        to check only left side for attacking queens 
        */
        bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;

            /* Check this row on left side */
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                {
                    return false;
                }
            }
            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            /* Check lower diagonal on left side */
            for (i = row, j = col; j >= 0 && i < NQueen; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        bool FillBoard(int[,]board, int col)
        {
            if( col >= NQueen)
            {
                PrintBoard(board);
                return true;
            }
            for( int i=0; i<NQueen; i++)
            {
                if(IsSafe(board, i, col))
                {
                    board[i, col] = 1;
                    FillBoard(board, col + 1);
                    
                    //  otherwise, back tract
                    board[i, col] = 0;
                }
            }
            return false;
        }
        void PrintBoard(int[,]board)
        {
            Console.WriteLine("---------");
            for (int i = 0; i < NQueen; i++)
            {
                Console.Write("|");
                for (int j = 0; j < NQueen; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine("\n---------");
            }
        }
        public static void Testing()
        {
            int[,] board =
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
            NQueens nQueens = new NQueens(4);
            if( !nQueens.FillBoard(board, 0))
            {
                Console.WriteLine("Cannot find any solution");
            }
            else
            {
                Console.WriteLine("Solution to place 4 Queens in 4X4 board:");
            }
           
        }
    }
}
