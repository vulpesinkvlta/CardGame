namespace Core.Domain
{
    public class CardDefinition
    {
        public string Id { get; }
        public string Name { get; }
        public CardRarity Rarity { get; }
        public PositionType Position { get; }

        public string Country { get; }
        public string Club { get; }

        public int Power { get; }

        public CardDefinition(
            string id,
            string name,
            CardRarity rarity,
            PositionType position,
            string country,
            string club,
            int power)
        {
            Id = id;
            Name = name;
            Rarity = rarity;
            Position = position;
            Country = country;
            Club = club;
            Power = power;
        }
    }
}
