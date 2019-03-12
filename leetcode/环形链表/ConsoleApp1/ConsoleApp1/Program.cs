using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode listNode = new ListNode(3);
            ListNode listNode2 = new ListNode(2);
            listNode.next = listNode2;
            listNode2.next = new ListNode(0).next = new ListNode(4).next = listNode2;
            Solution solution = new Solution();
            solution.HasCycle(listNode);
        }
    }
    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }
    }
}
