using System;

namespace 字符串中第一个不重复字母的位置
{
    //给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。
    //例如sddddgewezcv返回0
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            System.Console.WriteLine(s.FirstUniqChar("sddddgewezcv"));
        }
    }
    public class Solution
    {
        public int FirstUniqChar(string s)
        {
            int[] array = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                array[s[i] - 97]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (array[s[i] - 97] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
