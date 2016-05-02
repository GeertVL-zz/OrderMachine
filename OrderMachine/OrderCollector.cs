namespace OrderMachine
{
    public class OrderCollector : IOrderCollector
    {
        private readonly IUserContext _userContext;
        private readonly IRateExchange _exchange;
        private readonly IAccountsReceivable _receivable;

        public OrderCollector(IAccountsReceivable receivable, IRateExchange exchange, IUserContext userContext)
        {
            _receivable = receivable;
            _exchange = exchange;
            _userContext = userContext;
        }

        public void Collect(Order order)
        {
            User user = _userContext.GetCurrentUser();
            Price price = order.GetPrice(_exchange, _userContext);
            _receivable.Collect(user, price);
        }
    }
}