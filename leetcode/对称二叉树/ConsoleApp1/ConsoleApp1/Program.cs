using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     public class TreeNode
     {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }
            };
            soultion soultion = new soultion();
            bool ss= soultion.IsSymmetric(treeNode);

        }
    }

    public class soultion {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) {
                return true;
            }
            return IsSymmetric2(root.left, root.right);
        }
        public bool IsSymmetric2(TreeNode left, TreeNode right) {
            if (left == null && right == null)
                return true;
            if ((left == null && right != null) || (left!=null&&right==null)||left.val != right.val) {
                return false;
            }
            return IsSymmetric2(left.left,right.right)&&IsSymmetric2(left.right,right.left);
        }
    }
}
