using System.Collections;
using System.Collections.Generic;
using System;

namespace 找出添加的字母
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(new Solution().FindTheDifference("aaaa", "aaaae"));
        }
    }

    public class Solution
    {
        public char FindTheDifference(string s, string t)
        {
            int i = 0, n = 0;
            for (; i < s.Length; i++)
                n += (int)t[i] - (int)s[i];
            return (char)(n + (int)t[i]);
        }


    }
}
