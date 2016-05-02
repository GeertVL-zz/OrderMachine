namespace OrderMachine
{
    /// <summary>
    /// Example of template method pattern
    /// </summary>
    public class StockRateExchange : RateExchange
    {
        public StockRateExchange(IUserContext userContext) : base(userContext)
        {
        }

        protected override double GetExchangeRate(Currency origin, Currency destination)
        {
            // context the stock exchange REST API
            return 0;
        }

        protected override double Round(double amount)
        {
            // Write a rounding algorithm
            return amount;
        }
    }
}