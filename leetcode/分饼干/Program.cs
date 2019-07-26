using System;
using System.Collections.Generic;

namespace 分饼干
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = new Solution().FindContentChildren(
                new int[] {1,2,3},
                new int[] {1,1});
        }
    }
    //对每个孩子 i ，都有一个胃口值 gi ，
    //这是能让孩子们满足胃口的饼干的最小尺寸；并且每块饼干 j ，
    //都有一个尺寸 sj 。如果 sj >= gi ，我们可以将这个饼干 j 分配给孩子 i ，这个孩子会得到满足。

    /*
     对 g 和 s 升序排序
     初始化两个指针 i 和 j 分别指向 g 和 s 初始位置
     对比 g[i] 和 s[j]
     g[i] <= s[j]：饼干满足胃口，把能满足的孩子数量加 1，并移动指针 i = i + 1，j = j + 1
     g[i] > s[j]：无法满足胃口，j 右移，继续查看下一块饼干是否可以满足胃口
         */


    public class Solution
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            if (g.Length==0||s.Length==0)
            {
                return 0;
            }
            int result = 0;
            Array.Sort(g);
            Array.Sort(s);
            for (int i = 0,j=0; i < g.Length&&j<s.Length;)
            {
                if (g[i]<=s[j])
                {
                    result++;
                    i++;
                    j++;
                    continue;
                }
                j++;
            }
            return result;
        }
    }
}



