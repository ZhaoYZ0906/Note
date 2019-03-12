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
         public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list = new ListNode(0);

            ListNode head = new ListNode(-1);
            head.next = list;
            for (int i = 0; i < 6; i++) {
                list.next = new ListNode(i/2);
                list = list.next;
            }
            Solution solution = new Solution();
            solution.DeleteDuplicates(head);
        }
    }
    public class Solution{
        public ListNode DeleteDuplicates(ListNode head) {
            if (head == null)
                return head;
            ListNode list = head;
            while (list.next != null) {
                if (list.val == list.next.val)
                {
                    list.next = list.next.next;
                }
                else {
                    list = list.next;
                }
            }
            return head;
        }
    }
}
