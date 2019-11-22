using System;
using System.Collections.Generic;

namespace 子域名访问计数
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    /// <summary>
    /// 输入: 
    //["900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"]
    //输出: 
    //["901 mail.com","50 yahoo.com","900 google.mail.com","5 wiki.org","5 org","1 intel.mail.com","951 com"]
    /// </summary>
    public class Solution
    {
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] array = new string[cpdomains.Length * 2];
            int i = 0;

            foreach (var item in cpdomains)
            {
                var ss= item.Split(" ");
                array[i] = ss[0];
                array[i + 1] = ss[1];
                i += 2;
            }

            for ( i = 1; i < array.Length; i+=2)
            {                
                var ss = array[i].Split(".");
                var str = ss[ss.Length-1];
                for (int j = ss.Length-1; j >= 0; j--)
                {
                    if (dictionary.ContainsKey(str))
                    {
                        dictionary[str] += int.Parse(array[i - 1]);
                    }
                    else {
                        dictionary.Add(str, int.Parse(array[i - 1]));
                    }

                    if (j==0)
                    {
                        break;
                    }
                    str =ss[j-1]+"."+ str;
                }
            }
            var list = new List<string>(); 
            foreach (var item in dictionary)
            {
                list.Add(item.Value+" "+item.Key);
            }
            list.Sort();
            return list ;
        }
    }
}
