using System;

namespace 硬币排列
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var number = new Solution().ArrangeCoins(2147483647);
        }
    }

    public class Solution
    {
        public int ArrangeCoins(int n)
        {
            return (int)((-1 + Math.Sqrt(1 + 8 * (long)n)) / 2);
        }
    }
}
