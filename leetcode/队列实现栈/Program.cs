using System;
using System.Collections.Generic;

namespace 队列实现栈
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MyStack
    {
        private Queue<int> ts = new Queue<int>();
        //压入元素
        public void Push(int x)
        {
            int i = ts.Count,j=0;
            ts.Enqueue(x);
            while (j < i) {
                ts.Enqueue(ts.Dequeue());
                j++;
            }
        }

        //弹出元素
        public int Pop()
        {
            return ts.Dequeue();
        }

        //获取顶端元素
        public int Top()
        {
            return ts.Peek();
        }

        //空判断
        public bool Empty()
        {
            return ts.Count == 0 ? true : false;
        }
    }
}
