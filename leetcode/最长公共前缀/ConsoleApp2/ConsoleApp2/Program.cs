using System;

namespace ConsoleApp2
{
    class Program
    {

        public static bool isstr(int len,string[] strs) {
            int i;
            //将前len个字符作为公共前缀
            string str1 = strs[0].Substring(0, len);
            for (i = 1; i < strs.Length; i++) {
                if (str1 != strs[i].Substring(0, len)) {
                    return false;
                }
            }
            return true;
        }


        static void Main(string[] args)
        {
            string[] strs = new string[] { "a", "b" };
            string result;

            

            if (strs.Length != 0)
                result = "";


            int minlength = strs[0].Length;

            //取出最小长度
            foreach (var ss in strs) {
                if (ss.Length < minlength) {
                    minlength = ss.Length;
                }
            }

            int left=0, right=minlength;


            while (left<=right) {
                int middle = (left + right) / 2;
                if (isstr(middle, strs))
                {
                    left=middle+1;
                }
                else {
                    right =middle-1;
                }

            }

            result = strs[0].Substring(0, (left + right) / 2);
            Console.Write(result);
            Console.Read();
            
        }
    }
}
