using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_v2
{
    class Board
    {
        public string[,] board;
        public Board()
        {
            board = new string[20,20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    board[i, j] = " ";
                }
            }
        }
        public void print()
        {
            int count = 1;
            char columns = Convert.ToChar(64);
            for (int k = 0; k <= board.GetLength(0); k++)
            {
                if (k == 0)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write(" " + columns + " ");
                }
                columns++;
            }
            Console.WriteLine();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (count < 10)
                {
                    Console.Write(" " + count + "  ");
                }
                else
                {
                    Console.Write(" " + count + " ");
                }
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"[{board[i, j]}]");
                }
                count++;
                Console.WriteLine();
            }
        }
    }
}
