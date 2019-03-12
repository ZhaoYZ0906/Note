using System;

namespace 旋转数组
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution ss=new Solution();
            int[] vs={1,2,3,4,5,6};
            ss.rotate_2(vs,2);
            Console.Write(vs);
        }
    }
    public class Solution {
        public void rotate_2(int[] nums, int k) {
        int n = nums.Length;
        k %= n;
        reverse(nums, 0, n - 1);
        reverse(nums, 0, k - 1);
        reverse(nums, k, n - 1);
    }


    private void reverse(int[] nums, int start, int end) {
        while (start < end) {
            int temp = nums[start];
            nums[start++] = nums[end];
            nums[end--] = temp;
        }
    }
}
}
