using Core.Domain;
using Features.Collection;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application
{
    public class PackOpeningService : IPackOpeningService
    {
        private readonly IPackCatalog _packCatalog;
        private readonly ICardCatalog _cardCatalog;
        private readonly ICardFactory _cardFactory;
        private readonly IRandomService _randomService;

        public PackOpeningService(
            IPackCatalog packCatalog,
            ICardCatalog cardCatalog,
            ICardFactory cardFactory,
            IRandomService randomService)
        {
            _packCatalog = packCatalog;
            _cardCatalog = cardCatalog;
            _cardFactory = cardFactory;
            _randomService = randomService;
        }

        public PackOpeningResult Open(string packId, PlayerCollection collection)
        {
            if (string.IsNullOrWhiteSpace(packId))
                return PackOpeningResult.Failure("Pack id is empty.");

            if (collection == null)
                return PackOpeningResult.Failure("Collection is null.");

            PackDefinition pack = _packCatalog.GetById(packId);

            if (pack == null)
                return PackOpeningResult.Failure($"Pack not found: {packId}");

            if (pack.CardsCount <= 0)
                return PackOpeningResult.Failure($"Pack cards count is invalid: {pack.CardsCount}");

            if (pack.DropRules == null || pack.DropRules.Count == 0)
                return PackOpeningResult.Failure($"Pack has no drop rules: {packId}");

            List<CardInstance> openedCards = new List<CardInstance>();

            for (int i = 0; i < pack.CardsCount; i++)
            {
                CardRarity rarity = RollRarity(pack.DropRules);
                CardDefinition cardDefinition = RollCardDefinition(rarity);

                if (cardDefinition == null)
                {
                    return PackOpeningResult.Failure(
                        $"No card definitions found for rarity: {rarity}");
                }

                CardInstance cardInstance = _cardFactory.Create(cardDefinition.Id);

                collection.AddCard(cardInstance);
                openedCards.Add(cardInstance);
            }

            return PackOpeningResult.Success(openedCards);
        }

        private CardRarity RollRarity(IReadOnlyList<PackDropRule> dropRules)
        {
            int totalWeight = dropRules.Sum(rule => rule.Weight);

            if (totalWeight <= 0)
                return CardRarity.Common;

            int roll = _randomService.Range(0, totalWeight);
            int currentWeight = 0;

            foreach (PackDropRule rule in dropRules)
            {
                if (rule.Weight <= 0)
                    continue;

                currentWeight += rule.Weight;

                if (roll < currentWeight)
                    return rule.Rarity;
            }

            return CardRarity.Common;
        }

        private CardDefinition RollCardDefinition(CardRarity rarity)
        {
            List<CardDefinition> candidates = _cardCatalog
                .GetAll()
                .Where(card => card.Rarity == rarity)
                .ToList();

            if (candidates.Count == 0)
                return null;

            int index = _randomService.Range(0, candidates.Count);
            return candidates[index];
        }
    }
}
