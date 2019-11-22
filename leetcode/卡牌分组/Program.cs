using System;
using System.Collections.Generic;

namespace 卡牌分组
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool ss = new Solution().HasGroupsSizeX(new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 2, 2 });
        }
    }
    public class Solution
    {
        public bool HasGroupsSizeX(int[] deck)
        {
            if (deck.Length<=1)
            {
                return false;
            }

            int counter = deck[0];
            Dictionary<int, int> dectionary = new Dictionary<int, int>();
            for (int i = 0; i < deck.Length; i++)
            {
                if (!dectionary.ContainsKey(deck[i]))
                {
                    dectionary.Add(deck[i], 1);
                    continue;
                }
                dectionary[deck[i]]++;
            }
            counter = dectionary[counter];
            foreach (var item in dectionary)
            {
                if (counter!=item.Value && (item.Value%counter)!=0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
