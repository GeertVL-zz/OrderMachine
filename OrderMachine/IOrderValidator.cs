namespace OrderMachine
{
    public interface IOrderValidator
    {
        bool Validate(Order order);
    }
}