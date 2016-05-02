using System;

namespace OrderMachine
{
    public class LazyOrderShipper : IOrderShipper
    {
        private readonly IOrderShipperFactory _factory;
        private IOrderShipper _shipper;

        public LazyOrderShipper(IOrderShipperFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _factory = factory;
        }

        public void Ship(Order order)
        {
            if (_shipper == null)
            {
                _shipper = _factory.Create();
            }
            _shipper.Ship(order);
        }
    }
}