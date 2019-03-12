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
            solution solution = new solution();
            solution.Generate(5);
        }
    }
    public class solution
    {
        public List<List<int>> Generate(int numRows)
        {
            int[,] array = new int[numRows, numRows];
            List<List<int>> list = new List<List<int>>();
            for (int i=0;i < numRows; i++) {
                List < int > linshi= new List<int>();
                for (int j = 0; j <= i; j++) {
                    if ((j == 0) || (j == i))
                    {
                        array[i, j] = 1;
                        linshi.Add(1);
                    }
                    else {
                        array[i, j] = array[i - 1, j] + array[i - 1, j - 1];
                        linshi.Add(array[i, j]);
                    }
                }
                list.Add(linshi);
            }
            return list;
        }


    }

}
