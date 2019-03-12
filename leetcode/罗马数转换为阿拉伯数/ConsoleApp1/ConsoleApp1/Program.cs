using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0, i = 0;
            string s = "III";
            Dictionary<char,int> ht = new Dictionary<char,int>();
            ht.Add('I', 1);
            ht.Add('V', 5);
            ht.Add('X', 10);
            ht.Add('L', 50);
            ht.Add('C', 100);
            ht.Add('D', 500);
            ht.Add('M', 1000);
            try
            {
                for (i = 0; i < s.Length; i++) {
                    if (ht[s[i]] < ht[s[i + 1]])
                    {
                        result -= ht[s[i]];
                    }
                    else
                    {
                        result += ht[s[i]];
                    }
                 }
            }
            catch (Exception ee)
            {
                result += ht[s[i]];
            }
        }
    }
}
