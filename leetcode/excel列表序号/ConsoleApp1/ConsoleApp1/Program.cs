using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.TitleToNumber("ZY");
            Console.WriteLine((int)'A');
            Console.Read();
        }
    }
    public class Solution
    {
        public int TitleToNumber(string s)
        {
            int length = s.Length,sum=0,i;
            for (i = 0; i <length; i++) {
                sum = sum * 26 + (int)s[i] - 64;
            }
            return sum;
        }
    }
}
