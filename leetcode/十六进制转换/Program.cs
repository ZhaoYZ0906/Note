using System;
using System.Linq;
using System.Text;

namespace 十六进制转换
{
    //只能正整数
    class Program
    {
        static void Main(string[] args)
        {
           string ss= new Solution().ToHex(-2147483648);
        }
    }
    public class Solution
    {
        public string ToHex(int num)
        {          
            
            if (num == 0||num > 2147483646||num< -2147483647)
            {
                return "0";
            }
            num = Math.Abs(num);
            char[] map = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            string sb ="";
            while (num != 0)
            {
                sb+=(map[num & 15]);
                num = num>> 4;
            }
            char a;
            var result = sb.ToCharArray();
            for (int i = 0; i < sb.Length/2; i++)
            {
                a=result[i];
                result[i] = result[sb.Length - 1 - i];
                result[sb.Length - 1 - i] = a;
            }
            StringBuilder ff = new StringBuilder();

            foreach (var item in result)
            {
                ff.Append(item);
            }
            return ff.ToString();

        }
    }
}
