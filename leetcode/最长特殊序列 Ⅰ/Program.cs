using System;

namespace 最长特殊序列__
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = new Solution().FindLUSlength("", "");
        }
    }
    public class Solution
    {
        public int FindLUSlength(string a, string b)
        {
            if (a.Equals(b))
            {
                return -1;
            }

            return a.Length > b.Length ? a.Length : b.Length;
        }
    }
}
