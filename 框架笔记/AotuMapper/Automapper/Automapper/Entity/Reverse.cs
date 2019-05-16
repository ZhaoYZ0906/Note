using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Entity
{
    public class Reverse
    {
        public decimal Total { get; set; }
        public Reverse_Customer customer { get; set; }
    }
    public class Reverse_Customer
    {
        public string Name { get; set; }
    }
}
