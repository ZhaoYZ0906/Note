using System;
using System.Collections.Generic;

namespace 最后一块石头的重量
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
        public int LastStoneWeight(int[] stones)
        {
            if (stones.Length==1)
            {
                return stones[0];
            }
            Array.Sort(stones);
            for (int i = stones.Length-1; i >=1; i--)
            {
                stones[i - 1] = stones[i] - stones[i - 1];
                Array.Sort(stones);
            }
            return stones[0];
        }
    }
}
