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
            solution.LengthOfLastWord("b   a    ");
        }
    }

    public class solution {
        public int LengthOfLastWord(string s) {
            int length = s.Length,number=0;
            bool logo = true;
            if (length == 0) {
                return 0;
            }
            for (int i = 0; i < length; i++) {
                if (s[i] == ' ')
                {                    
                    logo = false;
                }
                else {
                    if (logo == false) {
                        number = 0;
                        logo = true;
                    }
                    
                    number++;
                }
            }
            return number;

        }
    }
}
