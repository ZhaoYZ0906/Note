using System;

namespace 左叶子之和
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    //计算给定二叉树的所有左叶子之和。
    //注意时左叶子节点不是左节点
    public class Solution
    {
        int result = 0;
        public int SumOfLeftLeaves(TreeNode root) {         
            if (root==null){
            return 0;
            }
            help(root);
            return result;
        }

        public void help(TreeNode treeNode) {
            if (treeNode==null)
            {
                return;
            }
            if (treeNode.left!=null&&treeNode.left.left==null&&treeNode.left.right==null)
            {
                result += treeNode.left.val;
            }
            help(treeNode.left);
            help(treeNode.right);
            return;
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
