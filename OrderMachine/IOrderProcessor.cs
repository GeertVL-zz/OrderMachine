namespace OrderMachine
{
    public interface IOrderProcessor
    {
        SuccessResult Process(Order order);
    }
}