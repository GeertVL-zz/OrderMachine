namespace OrderMachine
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderShipper _shipper;
        private readonly IOrderCollector _collector;

        public OrderProcessor(IOrderValidator validator, IOrderShipper shipper, IOrderCollector collector)
        {
            _validator = validator;
            _shipper = shipper;
            _collector = collector;
        }

        public SuccessResult Process(Order order)
        {
            bool isValid = _validator.Validate(order);
            if (isValid)
            {
                Collect(order);
                var shipper = new OrderShipperFactory().GetDefault();
                shipper.Ship(order);
            }

            return CreateStatus(isValid);
        }

        private void Collect(Order order)
        {
            _collector.Collect(order);
        }

        private SuccessResult CreateStatus(bool isValid)
        {
            return isValid ? SuccessResult.Success : SuccessResult.Failed;
        }
    }
}
