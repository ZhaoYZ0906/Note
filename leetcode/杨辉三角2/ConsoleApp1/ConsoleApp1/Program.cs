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
            solution.GetRow(3);
        }
    }
    public class solution {
        public List<int> GetRow(int rowIndex) {
            int i = 0, j = 1;
            int[,] array = new int[rowIndex+1, rowIndex+1];
            for (i = 0; i <= rowIndex; i++) {
                for (j = 0; j <= i; j++) {
                    if (j == 0 || j == i)
                    {
                        array[i, j] = 1;
                    }
                    else {
                        array[i, j] = array[i - 1, j - 1] + array[i - 1, j];
                    }
                }
            }
            List<int> list = new List<int>();
            for (i = 0; i <= rowIndex; i++) {
                list.Add(array[rowIndex, i]);
            }
            return list;
        }
    }
}
