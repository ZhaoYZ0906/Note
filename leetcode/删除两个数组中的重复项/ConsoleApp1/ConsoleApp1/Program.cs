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
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //i表示迭代的指针，j表示修改后的指针
            int i, j=0;

            for (i = 1; i < nums.Length; i++) {
                if (nums[i] != nums[j])
                {
                    j++;
                    nums[j] = nums[i];
                }
                
            }

            Console.Write(nums);
            Console.Read();
        }
    }
}
