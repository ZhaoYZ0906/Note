using System;

namespace 到最近的人的最大距离
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ss = new Solution().MaxDistToClosest(new int[] { 1,0,1,0,1,1,1,0, 0, 0, 0, 1, 0, 1 });
        }
    }
    public class Solution
    {
        public int MaxDistToClosest(int[] seats)
        {
            int i = 0, j = seats.Length - 1;
            while (seats[i] != 1) {
                i++;
            }
            while (seats[j] != 1)
            {
                j--;
            }
            int maxs = Math.Max(i, seats.Length - 1 - j);
            i++;
            int num = 0;
            while (i<=j)
            {
                if (seats[i++] != 1)
                    num++;
                else
                {
                    if (num >= 2 * maxs + 1)
                        maxs = num / 2 + num % 2;
                    num = 0;
                }

            }
            return maxs;
        }
    }
}
