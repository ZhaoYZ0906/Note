using System;
using System.Collections.Generic;

namespace 快乐数
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    /// <summary>
    /// 一个“快乐数”定义为：对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和，然后重复这个过程直到这个数变为 1，
    /// 也可能是无限循环但始终变不到 1。如果可以变为 1，那么这个数就是快乐数。
    /// 输入: 19
    ///12 + 92 = 82
    ///82 + 22 = 68
    ///62 + 82 = 100
    ///12 + 02 + 02 = 1 返回true
    /// </summary>
    public class Solution
    {
        public bool IsHappy(int n)
        {
            int m = 0;
            HashSet<int> set = new HashSet<int>();
            while (true)
            {
                while (n!=0)
                {
                    m += (int)Math.Pow(n % 10, 2) ;
                    n /= 10;
                }
                if (m==1)
                {
                    return true;
                }
                if (set.Contains(m))
                {
                    return false;
                }
                set.Add(m);
                n = m;
                m = 0;
            }

        }
    }
}
