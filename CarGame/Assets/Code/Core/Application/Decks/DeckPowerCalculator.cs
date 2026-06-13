using Core.Domain;
using Features.Collection;
using System.Linq;

namespace Core.Application
{
    public class DeckPowerCalculator : IDeckPowerCalculator
    {
        private readonly ICardCatalog _cardCatalog;

        public DeckPowerCalculator(ICardCatalog cardCatalog)
        {
            _cardCatalog = cardCatalog;
        }

        public int Calculate(Deck deck, PlayerCollection collection)
        {
            if (deck == null || collection == null)
                return 0;

            int totalPower = 0;

            foreach (string cardInstanceId in deck.CardInstanceIds)
            {
                CardInstance cardInstance = collection.GetByInstanceId(cardInstanceId);

                if (cardInstance == null)
                    continue;

                CardDefinition cardDefinition = _cardCatalog.GetById(cardInstance.DefinitionId);

                if (cardDefinition == null)
                    continue;

                totalPower += cardDefinition.Power;
            }

            return totalPower;
        }
    }
}
