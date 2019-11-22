using System;

namespace 托普利茨矩阵
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    /// <summary>
    /// 如果一个矩阵的每一方向由左上到右下的对角线上具有相同元素，那么这个矩阵是托普利茨矩阵。
    /// 从第二排第二个开始一次与左上角的数进行比较，不同则false，不用考虑越界问题
    /// </summary>
    public class Solution
    {
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            int row = matrix.Length, col = matrix[0].Length;
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i][j]!=matrix[i-1][j-1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
