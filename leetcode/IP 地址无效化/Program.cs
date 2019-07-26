using System;
using System.Text;

namespace IP_地址无效化
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        public string DefangIPaddr(string address)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i]=='.')
                {
                    result.Append("[.]");
                    i++;
                }
                result.Append(address[i]);
            }
            return result.ToString();
        }
    }
}
