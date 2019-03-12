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
            int[] nums = { 1,3 };
            Solution solution = new Solution();
            int i = solution.SearchIndex(nums, 2);
            Console.WriteLine(i);
            Console.Read();
        }
    }

    public class Solution {
        public int SearchIndex(int[] nums, int target) {
            int left=0, right=nums.Length,middle=0;
            while (left <= right) {
                middle = (left + right) / 2;
                if (middle == nums.Length)
                    return nums.Length;
                if (nums[middle] > target)
                {
                    right = middle-1;
                }
                else if (nums[middle] < target)
                {
                    left = middle+1;
                }
                else {
                    return middle;
                }
            }
            return left;
        }
    }
}
