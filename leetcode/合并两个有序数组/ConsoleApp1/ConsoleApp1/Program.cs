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
            int[] nums1 = { 0 }, nums2 = {1};
            Solution solution = new Solution();
            solution.Merge(nums1, 0, nums2, 1);
        }
    }
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int length = nums1.Length-1, i =  m - 1, j = nums2.Length - 1;

            if (n != 0 && m != 0)
            {
                for (; length >= 0; length--)
                {
                    if (nums1[i] >= nums2[j])
                    {
                        nums1[length] = nums1[i];
                        i--;
                    }
                    else
                    {
                        nums1[length] = nums2[j];
                        j--;
                    }
                    if (i == -1 || j == -1)
                        break;
                }
                if (j != -1)
                {
                    for (int x = 0; x <= j; x++)
                    {
                        nums1[x] = nums2[x];
                    }
                }
            }
            else {
                for (int z = 0; z <= j; z++)
                    nums1[z] = nums2[z];
            }
        }
    }
}