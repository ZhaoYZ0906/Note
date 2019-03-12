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
            int[] ss = { 2, 7, 11, 15 };
            solution.TwoSum(ss, 13);
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int i = 0, j = numbers.Length-1;
            int[] ss = new int[2];
            while (i < j) {
                if ((numbers[i] + numbers[j]) == target)
                {
                    ss[0] = i;ss[1] = j;
                    return ss;
                }
                else {
                    if ((numbers[i] + numbers[j]) > target)
                    {
                        j--;
                    }
                    else {
                        i++;
                    }
                }
            }
            return ss;
        }
    }

}
