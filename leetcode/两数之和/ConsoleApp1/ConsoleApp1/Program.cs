using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] nums = { 4, 7, 11, 15 };int target = 15;
            int i;
            int logo;
            int[] result = new int[2];
            int length = nums.Length;
            Hashtable Hnums = new Hashtable();
            for (i = 0; i < 4; i++) {
                logo = target - Convert.ToInt32(nums[i]);
                if (Hnums.ContainsKey(logo))
                {
                    result[0] = Convert.ToInt32(Hnums[logo]);
                    result[1] = i;
                }
                else
                     if (Hnums.ContainsKey(nums[i])!=true)
                        Hnums.Add(nums[i], i);
            }
            //foreach (DictionaryEntry ss in Hnums) {
            //    logo = target - Convert.ToInt32(ss.Key);
            //    if (Hnums.ContainsKey(logo)) {
            //        result[1] = Convert.ToInt32(Hnums[logo]);
            //        result[0] =Convert.ToInt32( ss.Value);
            //    }
            //}
            Console.WriteLine(result[0].ToString()+result[1].ToString());
            Console.Read();



        }
    }
}
