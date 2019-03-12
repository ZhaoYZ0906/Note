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
            int[] cost = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            Solution solution = new Solution();
            solution.MinCostClimbingStairs(cost);
        }
    }
    public class Solution {
        public int MinCostClimbingStairs(int[] cost) {
            int length = cost.Length, i = 0;
            switch (length) {
                case 0:return 0;
                case 1: return cost[0];
                case 2: return Math.Min(cost[0],cost[1]);
            }
            for (i = 2; i < length; i++)
            {
                cost[i] = Math.Min(cost[i - 1] + cost[i], cost[i - 2] + cost[i]);
            }
            return Math.Min(cost[i-1],cost[i-2]);
        }
    }
}
