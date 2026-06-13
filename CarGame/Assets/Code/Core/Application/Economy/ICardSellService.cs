using Core.Domain;
using Features.Collection;

namespace Core.Application
{
    public interface ICardSellService
    {
        SellCardResult Sell(
             string cardInstanceId,
             PlayerCollection collection,
             CurrencyWallet wallet);
    }
}
