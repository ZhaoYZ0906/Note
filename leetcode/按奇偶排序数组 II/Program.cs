using System;

namespace 按奇偶排序数组_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    //偶数放在偶数位上，奇数放在奇数位上
    public class Solution
    {
        public int[] SortArrayByParityII(int[] A)
        {
            int odd = 1, even = 0;
            int[] result = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i]%2==0)
                {
                    result[even] = A[i];
                    even += 2;
                }
                if (A[i] % 2 == 1)
                {
                    result[odd] = A[i];
                    odd += 2;
                }
            }
            return result;
        }
    }
}
