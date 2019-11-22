using System;

namespace 比较含退格的字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool ss = new Solution().BackspaceCompare("a##c", "#a#c");
        }
    }
    public class Solution
    {
        public bool BackspaceCompare(string S, string T)
        {
            int Si = 0, Ti = 0;
            string s = "", t = "";
            for (int i = 0; i < Math.Max(S.Length,T.Length); i++)
            {
                if (i<S.Length)
                {
                    if (S[i] == '#' && Si > 0)
                    {
                        s=s.Substring(0, s.Length-1>0? s.Length - 1:0);
                    }
                    else {
                        s += S[i];
                        Si++;
                    }
                    
                }
                if (i < T.Length)
                {
                    if (T[i] == '#' && Ti > 0)
                    {
                        t=t.Substring(0, t.Length - 1>0?t.Length:0);
                    }
                    else
                    {
                        t += T[i];
                        Ti++;
                    }
                }
            }

            return s==t;
        }
    }
}
