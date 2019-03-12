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
            solution solution = new solution();
            solution.mysqrt(2147483647);
                         
        }
    }
    public class solution {
        public int mysqrt(int x) {
            int left=0, right= 46340, middle=0;
            while (left <= right) {
                middle = (left + right) / 2;
                if (x < middle*middle)
                {
                    right = middle -1;
                 }
                else {
                    if (x == middle * middle)
                        return middle;
                    else
                        left = middle+1 ;
                }
            }
            return right;
        }
    }
}
