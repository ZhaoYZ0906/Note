using System;

namespace 岛屿的周长
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public int IslandPerimeter(int[][] grid)
        {
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j]==1)
                    {
                        result += 4;

                        if (i-1>=0&&grid[i-1][j]==1)
                        {
                            result--;
                        }
                        if (i+1<grid.Length&&grid[i+1][j]==1)
                        {
                            result--;
                        }
                        if (j-1>=0&&grid[i][j-1]==1)
                        {
                            result--;
                        }
                        if (j+1<grid[0].Length&&grid[i][j+1]==1)
                        {
                            result--;
                        }
                    }
                    
                }
            }
            return result;
        }
    }
}
