namespace OrderMachine
{
    public interface IOrderShipperFactory
    {
        IOrderShipper Create();
    }
}