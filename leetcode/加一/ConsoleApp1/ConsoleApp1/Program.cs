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
            int[] nums = { 9 };
            Solution solution = new Solution();
            solution.PlusOne(nums);
        }
    }

    public class Solution {
        public int[] PlusOne(int[] digits) {
            int length = digits.Length-1;
            List<int> list = new List<int>(digits.Length+1);
            for (; length >= 0; length--) {
                if (digits[length] != 9)
                {
                    digits[length] += 1;
                    return digits;
                }
                else {
                    digits[length] = 0;
                }
            }
            if (length == -1) {
                list.Add(1);
                foreach (int a in digits) {
                    list.Add(a);
                }
           
            }
            return list.ToArray();
        }
    }
}
