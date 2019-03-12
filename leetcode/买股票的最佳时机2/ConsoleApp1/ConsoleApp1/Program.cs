using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ss = { 7, 1, 5, 3, 6, 4 };
            Solution solution = new Solution();
            solution.MaxProfit(ss);
        }
    }
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int max = 0,i=0;
            if (prices.Length == 0)
                return 0;
            for (; i < prices.Length - 1; i++) {
                if (prices[i] < prices[i + 1]) {
                    max += prices[i + 1] - prices[i];
                }
            }
            return max;
        }
    }
}
