using System;

namespace 统计质数
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Solution().CountPrimes(10);
        }
    }
    public class Solution
    {
        //Sieve of Eratosthenes算法
        //leetcode-收藏-计算质数，题解里面
        public int CountPrimes(int n)
        {
            bool[] isbool = new bool[n];

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (isbool[i]==false)
                {
                    for (int j = 2*i; j < n; j+=i)
                    {
                        isbool[j] = true;
                    }
                }
            }

            int count = 0;
            for (int z = 2; z < n; z++)
            {
                if (isbool[z]==false)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
