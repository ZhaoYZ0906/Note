using System;
using System.Collections;

namespace 去掉重复元素
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
        public bool ContainsDuplicate(int[] nums)
        {
            Hashtable hashtable = new Hashtable();
            foreach (var item in nums)
            {
                if (hashtable.ContainsKey(item)) {
                    return true;
                }
                hashtable.Add(item, false);
            }
            return false;
        }
    }
}
