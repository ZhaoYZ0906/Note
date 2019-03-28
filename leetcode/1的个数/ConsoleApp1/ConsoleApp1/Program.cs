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
            uint a = 111101;
            var solution = new Solution().HammingWeight(a);
        }
    }

    public class Solution
    {
        //n为2进制数题目有问题
        public int HammingWeight(uint n)
        {
            int result=0;
            while (n > 0) {
                if (n%2==1)
                {
                    result++;                   
                }
                n = n / 2;
            }
            return result;
        }
    }
}
