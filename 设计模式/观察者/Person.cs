using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者
{
    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void OnFallsIll()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs("China Beijing"));
        }

    }
}
