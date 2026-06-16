namespace Core.Presentation
{
    public class CollectionCardViewData
    {
        public string InstanceId { get; }
        public string Name { get; }
        public string Rarity { get; }
        public string Position { get; }
        public int Power { get; }
        public string SellPriceText { get; }

        public CollectionCardViewData(
            string instanceId,
            string name,
            string rarity,
            string position,
            int power,
            string sellPriceText)
        {
            InstanceId = instanceId;
            Name = name;
            Rarity = rarity;
            Position = position;
            Power = power;
            SellPriceText = sellPriceText;
        }
    }
}
