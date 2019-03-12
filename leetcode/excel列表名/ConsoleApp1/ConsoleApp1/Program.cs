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
            int a = 701;
            Solution solution = new Solution();
            solution.ConvertToTitle(a);
        }
    }
    public class Solution
    {
        public string ConvertToTitle(int n)
        {
            String res = "";
            while (n > 0)
            {
                res = (char)('A' + (--n) % 26) + res;
                n /= 26;
            }
            return res;
        }
    }
}
