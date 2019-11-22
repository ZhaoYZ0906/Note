using System;

namespace 删除链表中指定val的元素
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list = new ListNode(1) {};
            var result= new Solution().RemoveElements(list, 1);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode header = new ListNode(-1);
            header.next = head;
            ListNode list = header;

            while (list.next!=null)
            {
                if (list.next.val == val)                                          
                {
                    list.next = list.next.next;
                }
                else
                {
                    list = list.next;
                }
            }
            return header.next;
            
        }
    }

    public class ListNode
    {
        public ListNode(int x)
        {
            val = x;
        }

        public int val { get; set; }
        public ListNode next { get; set; }
    }
}
