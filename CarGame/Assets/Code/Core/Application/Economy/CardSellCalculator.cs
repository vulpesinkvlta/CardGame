using Core.Domain;
using System;

namespace Core.Application
{
    public class CardSellCalculator : ICardSellPriceCalculator
    {
        public CurrencyAmount Calculate(CardDefinition cardDefinition)
        {
            if(cardDefinition == null)
                return new CurrencyAmount(CurrencyType.Coins, 0);

            if(ShouldSellForGems(cardDefinition.Rarity))
            {
                int gems = CalculateGemPrice(cardDefinition);
                return new CurrencyAmount(CurrencyType.Gems, gems);
            }

            int coins = CalculateCoinPrice(cardDefinition);
            return new CurrencyAmount(CurrencyType.Coins, coins);
        }

        private bool ShouldSellForGems(CardRarity rarity)
        {
            return rarity == CardRarity.Legendary ||
                   rarity == CardRarity.Icon;
        }

        private int CalculateCoinPrice(CardDefinition cardDefinition)
        {
            float multiplier = GetCoinMultiplier(cardDefinition.Rarity);
            float rawPrice = cardDefinition.Power * multiplier;

            return Math.Max(1, (int)Math.Round(rawPrice));
        }

        private int CalculateGemPrice(CardDefinition cardDefinition)
        {
            float multiplier = GetGemMultiplier(cardDefinition.Rarity);
            float rawPrice = cardDefinition.Power * multiplier;

            return Math.Max(1, (int)Math.Round(rawPrice));
        }

        private float GetCoinMultiplier(CardRarity rarity)
        {
            switch (rarity)
            {
                case CardRarity.Common:
                    return 1f;

                case CardRarity.Uncommon:
                    return 2f;

                case CardRarity.Rare:
                    return 4f;

                case CardRarity.Epic:
                    return 8f;

                default:
                    return 1f;
            }
        }

        private float GetGemMultiplier(CardRarity rarity)
        {
            switch (rarity)
            {
                case CardRarity.Legendary:
                    return 0.1f;

                case CardRarity.Icon:
                    return 0.16f;

                default:
                    return 0f;
            }
        }
    }
}
