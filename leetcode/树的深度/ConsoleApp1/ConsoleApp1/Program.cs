using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            tree tree = new tree(1) { left = new tree(2) { left = new tree(3) { left = new tree(4), right = new tree(5) } }, right = new tree(6) { left = new tree(7), right = new tree(8) } };
            solution solution = new solution();

            Console.WriteLine(solution.MaxDepth(tree));
            Console.Read();
        }
    }
    public class tree{
        public int val;
        public tree left;
        public tree right;
        public tree(int x) {
            val = x;
        }
    }
    public class solution {
        public int MaxDepth(tree root)
        {

            return root == null ? 0 : (Math.Max(MaxDepth(root.left), MaxDepth(root.right))+1);
        }
    }
}
