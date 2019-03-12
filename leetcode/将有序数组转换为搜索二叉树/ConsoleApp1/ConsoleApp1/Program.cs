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
            Solution solution = new Solution();
            int[] nums = { -10, -3, 0, 5, 9 };
            solution.SortedArrayToBST(nums);
        }
    }
    public class Solution {
        public TreeNode SortedArrayToBST(int[] nums) {
            if (nums == null || nums.Length == 0) {
                return null;
            }
            return A(nums, 0, nums.Length - 1);
        }
        private TreeNode A(int[] nums, int left, int right)
        {
            if (left > right) {
                return null;
            }
            if (left == right)
            {
                return new TreeNode(nums[left]);
            }
            int mid = (left + right) / 2;
            TreeNode tree = new TreeNode(nums[mid]);
            tree.left = A(nums, left, mid - 1);
            tree.right = A(nums, mid + 1, right);
            return tree;
        }
    }
}
