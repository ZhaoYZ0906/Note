using _net_core一个接口多种注入的实现.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _net_core一个接口多种注入的实现.service
{
    public class BService : IDemo
    {
        public string gethello()
        {
            return "This is from BService";
        }
    }
}
