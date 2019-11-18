using System;
using System.Collections;
using System.Collections.Generic;

namespace BiggestIsland
{
    class Program
    {
        static void Main(string[] args)
        {
           

            int[][] board = new int[][] {
                                new int[]{1,0,0,0,1},
                                new int[]{1,1,1,1,1},
                                new int[]{0,0,0,0,0},
                                new int[]{1,1,0,1,1} };

            System.Console.WriteLine(new IslandConnectedCell(board).getIslandSizes());
            //  System.out.println();
        }

    }

    public class IslandConnectedCell
    {
        private int[][] board;
        private int rows;
        private int cols;

        public IslandConnectedCell(int[][] board)
        {
            this.board = board;
            this.rows = board.Length;
            this.cols = board[0].Length;
        }

        public List<int> getIslandSizes()
        {
            bool[][] visited = new bool[this.rows][];

            List<int> countList = new List<int>();

            for (int row = 0; row< this.rows; row++)
            {
                for (int col = 0; col< this.cols; col++)
                {
                    if (visited[row] == null)
                        visited[row] = new bool[this.cols];

                    if (this.board[row][col] == 1 && ! visited[row][col])
                    {
                        countList.Add(mark(row, col, visited));
                    }
                }
            }
            return countList;
        }

        private int mark(int row, int col, bool[][] visited)
        {
            if (row >= this.rows || row < 0 || col >= this.cols || col < 0 || this.board[row][col] == 0 || visited[row][col])
                return 0;
            visited[row][col] = true;
            int count = 1;
            for (int r = -1; r <= 1; r++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    if (r != 0 || c != 0)
                        count += mark(row + r, col + c, visited);
                }
            }
            return count;
        }
    }
}
