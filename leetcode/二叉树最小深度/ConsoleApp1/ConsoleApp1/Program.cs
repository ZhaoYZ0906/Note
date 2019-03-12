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
        public TreeNode(int x) {
            val = x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3) {
                left = new TreeNode(9),
                right = new TreeNode(20) {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            solution solution = new solution();
            solution.MinDepth(root);

        }
    }

    public class solution {
        public int MinDepth(TreeNode root) {

            if (root == null) {
                return 0;
            }
            if (root.left == null) {
                return MinDepth(root.right)+1;
            }
            if (root.right == null) {

                return MinDepth(root.left)+1;
            }
            return Math.Min(MinDepth(root.left),MinDepth(root.right))+1;
        }
    }
}
