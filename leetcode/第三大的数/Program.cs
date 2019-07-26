using System;
using System.Collections.Generic;
using System.Linq;

namespace 第三大的数
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ss= new Solution().ThirdMax(new int[]{ 2,1,5,6,7});
        }
    }
    public class Solution
    {
        public int ThirdMax(int[] nums)
        {
            Array.Sort(nums);
            if (nums.Length<3)
            {
                return nums[nums.Length-1];
            }

            List<int> result = new List<int>();

            foreach (var item in nums)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result.Count>=3? result[result.Count-3] :result[result.Count - 1];
        }
    }
}
