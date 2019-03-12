using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Tree {
        public string value;
        public  Tree left;
        public Tree right;

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree() { value="a"};
            tree.left = new Tree() {
                value ="b",
                left =new Tree() {
                    value ="d",
                    left =new Tree() {
                        value ="g"
                    }
                } ,
                right =new Tree() {
                    value ="e",
                    right =new Tree() {
                        value ="h"
                    }
                }
            };
            tree.right = new Tree() {
                value ="c",
                right=new Tree() {
                    value ="f"
                }
            };
            new ss().Postorder(tree);
            Console.Read();

            
            

        }
        
    }
    public class ss {
        //先序遍历
        public string Preorder(Tree tree)
        {
            string str = "";
            Stack<Tree> stack = new Stack<Tree>();
            Tree node = tree;            
            while (node != null || stack.Any())
            {
                if (node != null)
                {
                    stack.Push(node);
                    Console.WriteLine(node.value);
                    node = node.left;
                }
                else
                {
                    var item = stack.Pop();
                    node = item.right;
                }
            }
            return str;
        }

        //中序遍历
        public void Sequential(Tree tree) {
            Stack<Tree> stack = new Stack<Tree>();
            Tree node = tree;
            while (node != null || stack.Any())
            {
                if (node != null)
                {
                    stack.Push(node);
                   
                    node = node.left;
                }
                else
                {
                    var item = stack.Pop();
                    Console.WriteLine(item.value);
                    node = item.right;
                }
            }
        }

        //后序遍历
        public void Postorder(Tree tree) {
            Stack<Tree> stack = new Stack<Tree>();
            Tree node = tree;
            HashSet<Tree> visited = new HashSet<Tree>();

            while (node != null || stack.Any()) {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else {
                    var item = stack.Peek();
                    if (item.right != null && !visited.Contains(item.right))
                    {
                        node = item.right;
                    }
                    else {
                        Console.WriteLine(item.value);
                        visited.Add(item);
                        stack.Pop();
                    }
                }
            }
        }
    }
}
