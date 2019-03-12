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
            int[] vs = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            solution solution = new solution();
            solution.MaxSubArray(vs);
        }
    }
    public class solution {
        public int MaxSubArray(int[] nums) {
            int sum = 0, result = nums[0];
            for (int i = 0; i < nums.Length; i++) {
                if (sum > 0)
                {
                    sum += nums[i];
                }
                else {
                    sum = nums[i];
                }
                result= Math.Max(sum, result);
            }
            return result;
        }
    }
}
