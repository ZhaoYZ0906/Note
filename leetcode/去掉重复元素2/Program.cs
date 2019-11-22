using System;
using System.Collections;
using System.Collections.Generic;

namespace 去掉重复元素2
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
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            HashSet<int> ts =new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (ts.Contains(nums[i]))
                {
                    return true;
                }
                ts.Add(nums[i]);
                if (ts.Count > k) {
                    ts.Remove(nums[i - k]);
                }
            }
            return false;
        }
    }
}
