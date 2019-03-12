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
            int[] vs = { 7, 1, 5, 3, 6, 4 };
            solution solution = new solution();
            solution.MaxProfit(vs);
        }
    }
    public class solution {
        public int MaxProfit(int[] prices) {
            if (prices.Length == 0)
                return 0;
            int low = prices[0], max = 0;
            for (int i = 1; i < prices.Length; i++) {
                max = Math.Max(max, prices[i] - low);
                low = Math.Min(low, prices[i]);
            }
            return max;
        }
    }
}
