using System;

namespace 学生考勤
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
        public bool CheckRecord(string s)
        {
            if (s==null||s.Length==0)
            {
                return true;
            }
            s += "PP";
            int a_counter = 0;
            bool l_counter = true;
            for (int i = 0; i < s.Length-2; i++)
            {
                if (s[i]=='L'&&s[i+1]=='L'&& s[i + 2] == 'L')
                {
                    l_counter = false;
                }
                if (s[i]=='A')
                {
                    a_counter++;
                }
            }

            return l_counter&&a_counter<2;
        }
    }
}
