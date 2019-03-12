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
            solution.CountAndSay(5);
        }
    }
    public class solution{
        public string CountAndSay(int n) {
            string result = "1",value="";
            int i,j,number=1;
            for (i = 1; i < n; i++) {
                for (j = 0; j < result.Length; j++) {
                    if (j < result.Length - 1 && result[j] == result[j + 1])
                    {
                        number++;
                    }
                    else {
                        value += number;
                        value += result[j];
                        number = 1;
                    }
                }
                result = value;
                value = "";
            }
            return result;
        }
}
}
