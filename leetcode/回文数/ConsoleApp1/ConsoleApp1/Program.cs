using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = false;
            int x = 121,y=0;
            if (x < 0||(x%10==0&&x!=0))
                result = false;
            while (y < x)
            {
                y = y * 10 + x % 10;
                x /= 10;
            }

            if (x == y || y / 10 == x) {
                result = true;
            }

            Console.WriteLine(result);
            Console.Read();
        }
    }
}
