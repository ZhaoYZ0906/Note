using System;
using System.Linq;

namespace 字符串相加
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = new Solution().AddStrings("1", "9");
        }
    }
    public class Solution
    {
        public string AddStrings(string num1, string num2)
        {

            int sum = 0;
            string result = "";
            for (int i = num1.Length-1,j=num2.Length-1; i > -1||j>-1; i--,j--)
            {
                if (i > -1) sum = sum + num1[i] - '0';
                if (j > -1) sum = sum + num2[j] - '0';
                result += sum % 10;
                sum = sum / 10;
            }
            if (sum!=0)
            {
                result =  result+ sum.ToString();
            }
            var str= result.ToCharArray();
            Array.Reverse(str,0,str.Length);
            return new String(str);
        }
    }
}
