using System;

namespace 山脉数组的峰顶索引
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    //找出数组中最大的数
    public class Solution
    {
        public int PeakIndexInMountainArray(int[] A)
        {
            int left = 0, right = A.Length - 1, middle = (left + right) / 2;
            while (left <= right) {
                if (A[middle]> A[middle-1]&& A[middle] > A[middle + 1])
                {
                    return middle;
                }
                if (A[middle] > A[middle - 1] && A[middle] < A[middle + 1])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
                middle = (left + right) / 2;
            }
            return -1;
        }
    }
}
