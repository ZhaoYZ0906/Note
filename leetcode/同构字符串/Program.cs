using System;
using System.Collections.Generic;
using System.Linq;

namespace 同构字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Solution().IsIsomorphic("abb","cdd");
        }
    }

    //acc和bdd位同构
    public class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {

            List<int> indexS = new List<int>();
            List<int> indexT = new List<int>();

            for (int i = 0; i < s.Length; i++)
                indexS.Add(s.IndexOf(s[i]));

            for (int j = 0; j < t.Length; j++)
                indexT.Add(t.IndexOf(t[j]));

            //return indexS.SequenceEqual(indexT);

            //{
            //    int a, b, c, n, aFactorial=1, bFactorial=1, cFactorial=1;
            //    for (n = 100; n < 1000; n++)
            //    {
            //        c = n % 10;
            //        b = (n / 10) % 10;
            //        a = n / 100;
            //        for (int i = 1; i <= c; i++)
            //        {
            //            cFactorial = cFactorial * i;
            //        }
            //        for (int i = 1; i <= b; i++)
            //        {
            //            bFactorial = bFactorial * i;
            //        }
            //        for (int i = 1; i <= a; i++)
            //        {
            //            aFactorial = aFactorial * i;
            //        }

            //        if (n==(aFactorial+bFactorial+cFactorial))
            //        {
            //            printf("%d", n);
            //        }
            //    }
            //}
        }

      
    }
}
