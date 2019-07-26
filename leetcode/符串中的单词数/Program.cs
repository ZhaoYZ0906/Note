using System;

namespace 符串中的单词数
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
        //统计字符串中的单词个数，这里的单词指的是连续的不是空格的字符。

        //请注意，你可以假定字符串里不包括任何不可打印的字符。
        public int CountSegments(string s)
        {
            if (s==null||s.Length<1)
            {
                return 0;
            }

            int result = s[0]==' '?0:1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i]!=' '&&s[i-1]==' ')
                {
                    result++;
                }
            }
            
            return result;
        }
    }
}
