namespace OrderMachine
{
    /// <summary>
    /// Example of template method pattern
    /// </summary>
    public abstract class RateExchange : IRateExchange
    {
        private readonly IUserContext _userContext;
        protected abstract double GetExchangeRate(Currency origin, Currency destination);
        protected abstract double Round(double amount);

        public RateExchange(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public int Convert(int cents, Currency currency)
        {
            var exchangeRate = GetExchangeRate(_userContext.GetSelectedCurrency(_userContext.GetCurrentUser()), currency);
            if (exchangeRate.Equals(0.0))
                return cents;

            return (int) (cents * Round(exchangeRate));
        }
    }
}