using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "3.14159";
            int jishuqi = 0,jishuqi2=0;
            char[] vs = str.ToCharArray();
            string result = "";
            int length = str.Length,i=0;
            for (i = 0; i < length; i++) {
                if (vs[i] == '+' || vs[i] == '-' || char.IsNumber(vs[i]))
                {
                    result += vs[i];
                    jishuqi++;
                }
                else {
                    if (vs[i] != ' ')
                        jishuqi2++;
                }
                if ((char.IsNumber(vs[i]) == false && jishuqi> 1)||jishuqi2>0) {
                    break;
                }
            }
            
            

            if (int.TryParse(result, out i) == false&&result!=""&&result!="-" && result != "+")
                i= Int32.MinValue;



            Console.Write(i);
            Console.Read();
        }
    }
}
