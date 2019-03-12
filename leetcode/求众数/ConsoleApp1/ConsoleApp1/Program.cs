using System;
using System.Collections;
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
            int[] vs = { 1, 2, 3, 1, 1, 1 };
            Solution solution = new Solution();
            solution.MajorityElement(vs);
        }
    }
    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            int length = nums.Length,i,count=1,nuber=nums[0];
            
            for (i = 1; i < length; i++) {
                if (nuber == nums[i])
                {
                    count++;
                }
                else {
                    count--;
                    if (count == 0) {
                        count = 1;
                        nuber = nums[i];
                    }
                }
            }
            return nuber;
        }
    }
}
