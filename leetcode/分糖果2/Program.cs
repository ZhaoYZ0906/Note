using System;
using System.Collections.Generic;

namespace 分糖果2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ss = new Solution().DistributeCandies(7, 4);
        }
    }
    //给出数量candies，人数num_people=n,给第一个人1，第二个人2.。。。第n个人n，在循环回来第一个人给n+1，知道candies分完
    public class Solution
    {
        public int[] DistributeCandies(int candies, int num_people)
        {
            int[] vs = new int[num_people];
            int number = 1, second=0;
            while (candies>0)
            {
                if (candies-number<0)
                {
                    vs[second] += candies;
                    break;
                }
                vs[second] += number;
                candies -= number;
                number++;
                second = (second + 1)%num_people;

            }
            return vs;
        }
    }
}
