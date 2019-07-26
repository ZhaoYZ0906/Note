using System;
using System.Collections.Generic;

namespace 丑数
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
        public bool IsUgly(int num)
        {
            if (num>0)
            {
                while (num%2==0)
                {
                    num /= 2;
                }
                while (num % 3 == 0)
                {
                    num /= 3;
                }
                while (num % 5 == 0)
                {
                    num /= 5;
                }
            }
            return num == 1 ? true : false;
        }

        public int NthUglyNumber(int n)
        {
            List<int> list = new List<int>();
            int p2 = 0, p3 = 0, p5 = 0,number=0;
            list.Add(1);
            while (n>0)
            {
                number = Math.Min(list[p2] * 2, list[p3] * 3);
                number= Math.Min(number, list[p5] * 5);
                list.Add(number);
                if (number== list[p2] * 2)
                {
                    p2++;
                }
                if (number == list[p3] * 3)
                {
                    p3++;
                }
                if (number == list[p5] * 5)
                {
                    p5++;
                }
                n--;
            }
            return list[list.Count - 2];
        }

    }
}
