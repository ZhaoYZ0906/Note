using System;
using 简单工厂;

namespace 简单工厂
{
    class Program
    {
        static void Main(string[] args)
        {
            factory factory = new factory();
            Potato potato = factory.createPotato() as Potato;
            potato.print();
        }
    }
}
