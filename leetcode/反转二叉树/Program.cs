using System;
using System.Collections.Generic;

namespace 反转二叉树
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
        public TreeNode InvertTree(TreeNode root)
        {
            //if (root!=null)
            //{
            //    TreeNode treeNode = InvertTree(root.left);
            //    root.left = InvertTree(root.right);
            //    root.right = treeNode;
            //}

            if (root != null)
            {
                TreeNode treeNode = root.left;
                root.left = root.right;
                root.right = treeNode;
                InvertTree(root.left);
                InvertTree(root.right);
            }
            return root;
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
