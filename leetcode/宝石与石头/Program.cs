using System;
using System.Collections.Generic;

namespace 宝石与石头
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    /// <summary>
    ///  给定字符串J 代表石头中宝石的类型，和字符串 S代表你拥有的石头。 
    ///  S 中每个字符代表了一种你拥有的石头的类型，你想知道你拥有的石头中有多少是宝石。
    ///  J 中的字母不重复，J 和 S中的所有字符都是字母。字母区分大小写
    /// </summary>
    public class Solution
    {
        public int NumJewelsInStones(string J, string S)
        {
            if (J.Length==0||J==null|| S.Length == 0 || S == null)
            {
                return 0;
            }
            HashSet<char> set = new HashSet<char>();
            int result = 0;
            for (int i = 0; i < J.Length; i++)
            {
                set.Add(J[i]);
            }
            for (int i = 0; i < S.Length; i++)
            {
                if (set.Contains(S[i]))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
