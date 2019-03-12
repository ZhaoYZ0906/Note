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
            TreeNode treeNode = new TreeNode(1) {
                left = new TreeNode(2) {
                    left = new TreeNode(3) {
                        left=new TreeNode(4)
                    }

                },
                right = new TreeNode(2) {
                    right = new TreeNode(3)
                    {
                        right = new TreeNode(4)
                    }
                }
            };

            solution solution = new solution();
            solution.IsBalanced(treeNode);

        }
    }
    public class solution {
        public bool IsBalanced(TreeNode root) {
            if (root == null)
                return true;
            if (Math.Abs(number(root.left) - number(root.right)) > 1)
            {
                return false;
            }
            else {
                if (IsBalanced(root.left) && IsBalanced(root.right))
                {
                    return true;
                }
                else
                    return false;
            }

        }
        public int number(TreeNode root) {

            if (root == null) {
                return 0;
            }
            return 1+Math.Max(number(root.left),number(root.right));
        }
    }
}
