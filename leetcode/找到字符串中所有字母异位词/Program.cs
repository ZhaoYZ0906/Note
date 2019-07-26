using System;
using System.Collections;
using System.Collections.Generic;

namespace 找到字符串中所有字母异位词
{
    //针对太长的字符串会超时
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = new Solution().FindAnagrams("baa", "aa");
        }
    }
    public class Solution
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            if (s==null||s.Length==0)
            {
                return new List<int>();
            }

            var result = new List<int>();
            int s_length = s.Length, p_length = p.Length, sum = 0;

            for (int i = 0; i < p.Length; i++)
            {
                sum += p[i];
            }

            int temporary = 0;

            for (int i = s_length-1; i >= p_length-1; i--)
            {
                for (int j = 0; j < p_length; j++)
                {
                    temporary+= s[i - j];
                }
                if (temporary==sum && help(s.Substring(i- p.Length + 1, p.Length),p))
                {
                    result.Add(i- p_length+1);
                }
                temporary = 0;
            }

            return result;
        }

        public bool help(string s,string p) {
            Dictionary<char, int> s_hash =new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s_hash.ContainsKey(s[i]))
                {
                    s_hash[s[i]]++;
                }
                if (!s_hash.ContainsKey(s[i]))
                {
                    s_hash.Add(s[i], 1);
                }                
                s_hash[s[i]]++;
            }

            for (int i = 0; i < p.Length; i++)
            {
                if (!s_hash.ContainsKey(p[i]))
                {
                    return false;
                }
                s_hash[p[i]]--;
            }
            return true;
        }
    }
}
