using System;

namespace 翻转图像
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
        public int[][] FlipAndInvertImage(int[][] A)
        {
            int all = 0;
            int[][] imageReversal = new int[A.GetLength(0)][];
            foreach (var item in A)
            {
                int[] numberArrat = new int[item.Length];
                int num = 0;
                for (int i = item.Length-1; i >= 0; i--)
                {
                    if (item[i]==0)
                    {
                        numberArrat[num] = 1;
                    }
                    if (item[i] == 1)
                    {
                        numberArrat[num] = 0;
                    }
                    num++;
                }
                imageReversal[all] = numberArrat;
                all++;
            }
            return imageReversal;
        }
    }
}
