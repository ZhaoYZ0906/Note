using System;
using System.Collections.Generic;

namespace 柠檬水
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool a = new Solution().LemonadeChange(new int[] { 5, 5, 10, 20, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 5, 5, 20, 5, 20, 5});
        }
    }
    //按收钱的顺序找零钱，5元不找，10找5，20找15
    public class Solution
    {
        public bool LemonadeChange(int[] bills)
        {
            Dictionary<int, int> wallet = new Dictionary<int, int>();
            wallet.Add(5, 0);
            wallet.Add(10, 0);
            wallet.Add(20, 0);

            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i]==5)
                {
                    wallet[5]++;
                    continue;
                }
                if (bills[i] == 10&&wallet[5]>0)
                {
                    wallet[5]--;
                    wallet[10]++;
                    continue;
                }
                if (bills[i] == 20 && wallet[5] > 0 && wallet[10] > 0)
                {
                    wallet[5]--;
                    wallet[10]--;
                    wallet[20]++;
                    continue;
                }
                if (bills[i] == 20 && wallet[5] > 3)
                {
                    wallet[5]-=3;
                    wallet[20]++;
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}
