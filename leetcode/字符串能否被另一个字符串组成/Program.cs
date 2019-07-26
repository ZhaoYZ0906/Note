using System;

namespace 字符串能否被另一个字符串组成
{
    //字符串A能否由字符串B组成
    //A在B中可以不是连续的
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.CanConstruct("dd", "sadggavcxr");
        }
    }

    public class Solution
    {
        public bool CanConstruct(string A, string B)
        {
            if (A.Length > B.Length)
            {
                return false;
            }
            int[] hash = new int[26];
            int n = 0;
            for (int i = 0; i < A.Length; i++)
            {
                hash[A[i] - 97]++;
                n++;
            }
            for (int i = 0; i < B.Length; i++)
            {
                if (hash[B[i] - 97] > 0)
                {
                    hash[B[i] - 97]--;
                    n--;
                }
            }

            return n == 0;
        }
    }

}
