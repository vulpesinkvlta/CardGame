namespace Core.Domain
{
    public class CurrencyAmount
    {
        public CurrencyType CurrencyType { get; }
        public int Amount { get; }
        public CurrencyAmount(CurrencyType currencyType, int amount)
        {
            CurrencyType = currencyType;
            Amount = amount;
        }
    }
}
