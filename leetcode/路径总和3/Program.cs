using System;
using System.Collections.Generic;

namespace 路径总和3
{
    class Program
    {
        //思想是遍历到某个节点时，检查该节点到根节点的路径上包含该节点的所有可能，如此每一个节点在检查可能的路径时都不会重复。

        //比如假设有路径1,2,3,4，-4,5，sum=5，如果遍历到3时，只需要检查1,2,3中是否有包含3的解，发现2,3是一个解；
        
        //遍历到5时只需检查包含5的解，包括5，以及4，-4,5两个解。这样就没有重复检查。因为包含5的解在之前一定没被检查过。
        
        //检查方式也是极其简单，使用vector保存遍历过程中的值，然后反向for循环这个vector求和即可。
        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode(10) {
                left = new TreeNode(5) {
                    left = new TreeNode(3) {
                        left = new TreeNode(3),
                        right = new TreeNode(-2),
                    },
                    right = new TreeNode(2) {
                        right = new TreeNode(1)
                    }

                },
                right = new TreeNode(-3) {
                    right = new TreeNode(11)
                }
            };

            int ss = new Solution().PathSum(treeNode,8);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
 
    public class Solution
    {
        int r = 0;
        List<int> stack = new List<int>();
        public int PathSum(TreeNode root, int sum)
        {
            if (root==null)
            {
                return 0;
            }
            help(root, sum);
            return r;
        }

        public void help(TreeNode root, int sum) {
            if (root==null)
            {
                return;
            }
            int temporary = 0;

            stack.Add(root.val);

            for (int i = stack.Count-1; i >= 0; i--)
            {
              
                temporary += stack[i];
                if (temporary==sum)
                {
                    r++;
                }
            }
            help(root.left, sum);
            help(root.right, sum);
            stack.RemoveAt(stack.Count - 1);
        }

    }
}
