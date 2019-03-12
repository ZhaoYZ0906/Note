using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 0,i,j,arrlength=0;
            bool logo = true;
            string[] strs = new string[] {"flower", "flow", "flight"};
            string result = "";
            char jilv = ' ';

            //判断是否为空
            if (strs.Length != 0)
            {
                arrlength = strs.Length;
                length = strs[0].Length;
            }

            //找出数组中的最小字符串长度
            foreach (var ss in strs) {
                if (length > ss.Length) {
                    length = ss.Length;
                }
            }

            //每次判断n个字符串的第i个字符是否相等
            for (i = 0; i < length; i++) {
                jilv = strs[0][i];
                for (j = 0; j < arrlength; j++) {
                    
                    if (strs[j][i] != jilv)
                    {
                        logo = false;
                        break;
                    }            
                }
                if (logo == false)
                    break;
                result += strs[j-1][i];
            }

            if (result == "") {
                result = "无公共前缀";
            }

            Console.WriteLine(result);
            Console.Read();

        }
    }
}
