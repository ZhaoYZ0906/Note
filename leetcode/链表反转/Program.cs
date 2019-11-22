using System;

namespace 链表反转
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
        public ListNode ReverseList(ListNode head)
        {
            ListNode tmp = null;
            ListNode pre = null;
            ListNode cur = head;
            while (cur!=null)
            {
                tmp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = tmp;
            }
            return pre;
        }
    }

      public class ListNode
     {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
}
