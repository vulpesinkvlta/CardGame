using Core.Domain;

namespace Core.Application
{
    public interface ICardSellPriceCalculator
    {
        CurrencyAmount Calculate(CardDefinition cardDefinition);
    }
}
