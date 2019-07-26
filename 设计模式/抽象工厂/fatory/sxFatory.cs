using System;
using System.Collections.Generic;
using System.Text;

namespace 抽象工厂
{
    public class sxFatory : fatory
    {
        public override food GetPotato()
        {
            Console.WriteLine("这里是山西土豆！");
            return new Tomatoes();
        }

        public override food GetTomatoes()
        {
            Console.WriteLine("这里是山西西红柿！");
            return new Potato();
        }
    }
}
