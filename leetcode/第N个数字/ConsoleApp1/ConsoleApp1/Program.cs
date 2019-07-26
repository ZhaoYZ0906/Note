using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().FindNthDigit(13));
        }
    
        //失败品谢谢
    public class Solution
    {
        public int FindNthDigit(int n) {

            if (n<10)
            {
                return n;
            }

            int i = 1,j=1,z = 1;
            while (true)
            {
                if (n< i * j * 9)
                {
                    break;//如果n小于当前计算组的个数，则说明n在此组中，所以跳出   n大于个数时说明不在此组则进行下一组
                }
                n -= i * j * 9;//1*1*9 1-9一共9个数  2*10*9  10-99 一个90个数，180位  3*100*9 100-999一共900个数2700位
                i++;//组号+1
                j *= 10;//计算组的初始值
            }
            //StartNumber = j, //确定所在分组的初始值，比如第二组为10，第三组为100
            int number = 0;
            if (n != i) {
                number = n / i + j; //确定要找的为在哪个数上，因为n/i有余数，所以+1
                    }
            else
            {
                number = j;
            }
            int PositionNumber = n%i;//确定第几位
            for (; z <= i-PositionNumber; z++)
            {
                number /= 10;
            }
            return number%10;

        }
    }
}
