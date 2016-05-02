namespace OrderMachine
{
    public interface IAccountsReceivable
    {
        void Collect(User user, Price price);
    }
}