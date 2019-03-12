using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //这个算法可以用hashtable做效率比较高，思路一样只是把固定的字符替换
        //入栈操作
        public static void push(char[] chars,ref int j,char onechar) {
            chars[j] = onechar;
            j++;

        }

        //出栈操作
        public static void pop(char[] chars,ref int j,char onechar,ref bool result) {
            if (j != 0&&chars[j - 1] == onechar)
            {
                chars[j - 1] = '\0'; j--;
            }
            else
            {
                result = false;
            }
        }

        static void Main(string[] args)
        {
            bool result = true;
            string s = "[]}";
            //i为s的下标 j为chars的下标
            int i = 0,length=s.Length,j=0;
            char[] chars = new char[s.Length];

            //判断特殊情况 比如{/【/（只有一位的无效   和   】/}/）开头的一定无效
            if (s.Length <= 1||s[0]=='}'|| s[0] == ')' || s[0] == ']' ) {
                result = false;
            }

            //如果为左括号则入栈，如果为右括号则判断前一个是否为对应左括号，是则左右括号出栈；不是则退出循环
            while (i < length&&result==true) {
                switch (s[i]) {
                    case '{': push(chars, ref j, '{'); break;
                    case '[': push(chars, ref j, '['); break;
                    case '(': push(chars, ref j, '('); break;
                    case '}': pop(chars, ref j, '{',ref result);  break;
                    case ']': pop(chars, ref j, '[', ref result); break;
                    case ')': pop(chars, ref j, '(', ref result); break;
                    default: result = false; break;
                }
                i++;
            }

            if (s.Length <= 1 || chars[0] != '\0') {
                result = false;
            }



            Console.Write(result);
            Console.Read();

        }
    }
}
