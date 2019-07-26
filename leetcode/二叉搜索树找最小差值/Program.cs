using System;

namespace 二叉搜索树找最小差值
{
    //给定一个所有节点为非负值的二叉搜索树，求树中任意两节点的差的绝对值的最小值。
    class Program { 
    static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    
    public class Solution { 


        int result = int.MaxValue;
        TreeNode pre = null;
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null)
                return 0;
            help(root);
            return result;
        }

        //注意pre存储节点，
        //当先序遍历时pre分别存储 根 左节点 存储第一个节点导致根节点和左节点计算-》存储第二个节点导致左节点与右节点计算，根据遍历顺序得出来的
        //当中序遍历时pre分别存储 左 根节点 存储第一个节点导致左节点和根节点计算-》存储第二个节点导致根节点与右节点计算，根据遍历顺序得出来的
        //当后序遍历时pre分别存储 左 右节点 存储第一个节点导致左节点和右节点计算-》存储第二个节点导致右节点与根节点计算，根据遍历顺序得出来的
        public void help(TreeNode treeNode) {
            if (treeNode==null)
            {
                return;
            }
            help(treeNode.left);
            if (pre != null) {
                result = Math.Min(result,Math.Abs( treeNode.val - pre.val));
            }
            pre = treeNode;

            help(treeNode.right);
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
