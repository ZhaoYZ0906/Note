using System;
using System.Collections.Generic;
using System.Text;

namespace 简单工厂
{
    public class factory
    {
        public food createPotato() {
            return new Potato();
        }
        public food createTomato()
        {
            return new Tomato();
        }
    }
}
