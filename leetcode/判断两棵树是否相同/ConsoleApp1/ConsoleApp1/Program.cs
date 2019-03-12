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
            TreeNode p = new TreeNode(1) {
                left = new TreeNode(2)
                
            };
            TreeNode q = new TreeNode(1)
            {
                left = null,
                
                right = new TreeNode(2)
            };

            solution solution = new solution();
            solution.IsSameTree(p, q);
        }
    }

    public class solution {
        public bool IsSameTree(TreeNode p, TreeNode q) {
            if (p == null && q == null)
                return true;
            if (p != null && q != null && p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
                return false;            
        }
    }
}
