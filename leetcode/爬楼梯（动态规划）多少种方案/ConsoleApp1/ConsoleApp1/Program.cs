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
            solution.ClimbStairs(8);
        }
        public class solution {
            public int ClimbStairs(int n) {
                switch (n) {
                    case 0: return 0;
                    case 1: return 1;
                    case 2: return 2;
                }
                int one = 1, two = 2,sum=0;
                for (int i = 2; i < n; i++) {
                    sum = one + two;
                    one = two;
                    two = sum;
                }
                return sum;
            }
        }
    }
}
