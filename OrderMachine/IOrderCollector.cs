namespace OrderMachine
{
    public interface IOrderCollector
    {
        void Collect(Order order);
    }
}