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
            new Solution().TrailingZeroes(31);
        }
    }
    public class Solution
    {
        public int TrailingZeroes(int n)
        {
            int count=0;
            while (n >= 1) {
                n = n / 5;
                count += n;
            }
            
            return count;
        }
    }
}
