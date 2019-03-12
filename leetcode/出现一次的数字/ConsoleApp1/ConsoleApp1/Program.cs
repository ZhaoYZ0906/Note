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
            int[] ss = { 4,1, 2, 1,2 };
            Solution solution = new Solution();
            solution.SingleNumber(ss);
        }
    }
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++) {
               result= result ^ nums[i];
            }
            return result;
        }
    }
}
