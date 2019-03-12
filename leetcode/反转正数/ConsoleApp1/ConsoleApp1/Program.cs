using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1534236469;
            int   yushu,i=10;
            double result = 0;
            while (i != 0) {
                yushu = x % i;
                x = (x - yushu) / 10;
                result = result * 10 + yushu;
                if (x == 0)
                {
                    break;
                }
                if ((result * 10) > 2147483647 || (result * 10) < -2147483648)
                {
                    result = 0;
                    break;
                }
            }
 


            Console.Write(result);
            Console.Read();

        }
    }
}
