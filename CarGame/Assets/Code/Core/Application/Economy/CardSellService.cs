using Core.Domain;
using Features.Collection;

namespace Core.Application
{
    public class CardSellService : ICardSellService
    {
        private readonly ICardCatalog _cardCatalog;
        private readonly ICardSellPriceCalculator _priceCalculator;

        public CardSellService(ICardCatalog cardCatalog, ICardSellPriceCalculator priceCalculator)
        {
            _cardCatalog = cardCatalog;
            _priceCalculator = priceCalculator;
        }
        public SellCardResult Sell(string cardInstanceId, PlayerCollection collection, CurrencyWallet wallet)
        {
            if (string.IsNullOrWhiteSpace(cardInstanceId))
                return SellCardResult.Failure("Card instance id is empty.");

            if (collection == null)
                return SellCardResult.Failure("Collection is null.");

            if (wallet == null)
                return SellCardResult.Failure("Wallet is null.");

            CardInstance cardInstance = collection.GetByInstanceId(cardInstanceId);

            if (cardInstance == null)
                return SellCardResult.Failure($"Card instance not found: {cardInstanceId}");

            CardDefinition cardDefinition = _cardCatalog.GetById(cardInstance.DefinitionId);

            if (cardDefinition == null)
                return SellCardResult.Failure($"Card definition not found: {cardInstance.DefinitionId}");

            CurrencyAmount reward = _priceCalculator.Calculate(cardDefinition);

            bool removed = collection.RemoveCard(cardInstanceId);

            if (!removed)
                return SellCardResult.Failure($"Failed to remove card from collection: {cardInstanceId}");

            wallet.Add(reward);

            return SellCardResult.Success(reward);
        }
    }
}
