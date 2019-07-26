using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者
{
    public class FallsIllEventArgs:EventArgs
    {
        public readonly string str;

        public FallsIllEventArgs (string str)
        {
            this.str = str;
        }
    }
}
