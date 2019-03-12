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
            int[] nums = { 2};
            solution.RemoveElement(nums, 3);
        }
    }

    public class Solution {
        public int RemoveElement(int[] nums, int val) {
            int i=0, j=0,result=0;
            if (nums.Length < 1)
                return 0;
            for (; i < nums.Length; i++) {
                if (nums[i] == val)
                {
                    if (nums[j] != val)
                        j = i;
                }
                else {
                    if (nums[j] == val) {
                        nums[j] = nums[i];
                        nums[i] = val;
                        j++;
                    }
                    result++;
                }
            }
            return result;
        }
    }
}
