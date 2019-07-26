using System;

namespace 大写字母是否正确
{
    //我们定义，在以下情况时，单词的大写用法是正确的：
    //全部字母都是大写，比如"USA"。
    //单词中所有字母都不是大写，比如"leetcode"。
    //如果单词不只含有一个字母，只有首字母大写， 比如 "Google"。
    //否则，我们定义这个单词没有正确使用大写字母。

    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            System.Console.WriteLine(s.DetectCapitalUse("Google"));
        }
    }
    public class Solution
    {
        public bool DetectCapitalUse(string word)
        {
            int i = 0, j = 0;
            for (i = 0; i < word.Length; i++)
            {
                if (char.IsUpper(word[i]))
                {
                    j++;
                }
            }
            if (j == 0 || j == word.Length || (j == 1 && char.IsUpper(word[0])))
            {
                return true;
            }
            return false;
        }
    }
}
