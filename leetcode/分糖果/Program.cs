using System;
using System.Collections.Generic;

namespace 分糖果
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
        public int DistributeCandies(int[] candies)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < candies.Length; i++)
            {
                set.Add(candies[i]);
            }

            return set.Count > candies.Length / 2 ? candies.Length / 2 : set.Count;
        }
    }
}
