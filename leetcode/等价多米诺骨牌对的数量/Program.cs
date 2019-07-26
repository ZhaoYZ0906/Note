using System;
using System.Collections.Generic;

namespace 等价多米诺骨牌对的数量
{
    class Program
    {
        /*
         * 给你一个由一些多米诺骨牌组成的列表 dominoes。

        如果其中某一张多米诺骨牌可以通过旋转 0 度或 180 度得到另一张多米诺骨牌，我们就认为这两张牌是等价的。
        
        形式上，dominoes[i] = [a, b] 和 dominoes[j] = [c, d] 等价的前提是 a==c 且 b==d，或是 a==d 且 b==c。
        
        在 0 <= i < j < dominoes.length 的前提下，找出满足 dominoes[i] 和 dominoes[j] 等价的骨牌对 (i, j) 的数量。
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int ss = new Solution().NumEquivDominoPairs(new int[][] { new int[]{ 1, 2 }, new int[] { 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 6 } });
        }
    }

    public class Solution
    {
        //数据结构 Dictionary<int, Dictionary<int, int>> 
        //第一个int存放每一行数组的第一个值；
        //  第二个存放第二个值，
        //  第三个存放前两个数组合之后出现的次数
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            int result = 0;
            Dictionary<int, Dictionary<int, int>> dictionary = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < dominoes.Length; i++)
            {
                Array.Sort(dominoes[i]);
                if (dictionary.ContainsKey(dominoes[i][0]))
                {
                    if (dictionary[dominoes[i][0]].ContainsKey(dominoes[i][1]))
                    {
                        //如果原来有三组，新添加一组，则会产生新的三对（新的和老的各组合一次）
                        //还有一种方法统计完出现了多少次，假如出现了3次则一共有 3* （3-1）/2次  n*(n-1)/2组合公式？
                        result += dictionary[dominoes[i][0]][dominoes[i][1]];
                        dictionary[dominoes[i][0]][dominoes[i][1]]++;
                    }
                    else
                    {
                        dictionary[dominoes[i][0]].Add(dominoes[i][1], 1);
                    }

                }
                else
                {
                    var unit = new Dictionary<int, int>();
                    unit.Add(dominoes[i][1], 1);
                    dictionary.Add(dominoes[i][0],unit);
                }
            }

            return result;
        }
    }
}
