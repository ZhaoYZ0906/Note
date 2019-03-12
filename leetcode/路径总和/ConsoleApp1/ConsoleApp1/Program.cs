using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode(5)
            {
                left = new TreeNode(4) {
                    left = new TreeNode(11) {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8) {
                    left = new TreeNode(13),
                    right = new TreeNode(4) {
                        right = new TreeNode(1)
                    }
                }
            };

            solution solution = new solution();
            solution.HasPathSum(treeNode, 22);

        }
    }
    public class solution {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null) {
                return (root.val == sum);
            }
            return HasPathSum(root.left,sum-root.val)||HasPathSum(root.right,sum-root.val);
        }
    }
}
