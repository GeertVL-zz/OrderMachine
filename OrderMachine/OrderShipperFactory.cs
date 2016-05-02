using System;

namespace OrderMachine
{
    public class OrderShipperFactory
    {
        public static Func<IOrderShipper> CreationClosure;
        public IOrderShipper GetDefault()
        {
            return CreationClosure();//executes closure
        }
    }
}