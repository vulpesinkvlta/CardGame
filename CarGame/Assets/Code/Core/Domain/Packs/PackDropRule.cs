namespace Core.Domain
{
    public class PackDropRule
    {
        public CardRarity Rarity { get; }
        public int Weight { get; }

        public PackDropRule(CardRarity rarity, int weight)
        {
            Rarity = rarity;
            Weight = weight;
        }
    }
}
