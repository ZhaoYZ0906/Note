using System;
using System.Collections.Generic;
using System.Text;

namespace 抽象工厂
{
    public class sdFatory : fatory
    {
        public override food GetPotato()
        {
            Console.WriteLine("这里是山东土豆！");
            return new Tomatoes();
        }

        public override food GetTomatoes()
        {
            Console.WriteLine("这里是山东西红柿！");
            return new Potato();
        }
    }
}
