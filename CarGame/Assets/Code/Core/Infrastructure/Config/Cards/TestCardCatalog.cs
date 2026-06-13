using Core.Application;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class TestCardCatalog : ICardCatalog
    {
        private readonly List<CardDefinition> _cards;

        public TestCardCatalog()
        {
            _cards = new List<CardDefinition>
        {
            new CardDefinition(
                id: "card_messi_icon",
                name: "Lionel Messi",
                rarity: CardRarity.Icon,
                position: PositionType.FWD,
                country: "Argentina",
                club: "Inter Miami",
                power: 95),

            new CardDefinition(
                id: "card_ronaldo_icon",
                name: "Cristiano Ronaldo",
                rarity: CardRarity.Icon,
                position: PositionType.FWD,
                country: "Portugal",
                club: "Al Nassr",
                power: 94),

            new CardDefinition(
                id: "card_mbappe_legendary",
                name: "Kylian Mbappe",
                rarity: CardRarity.Legendary,
                position: PositionType.FWD,
                country: "France",
                club: "Real Madrid",
                power: 92),

            new CardDefinition(
                id: "card_haaland_legendary",
                name: "Erling Haaland",
                rarity: CardRarity.Legendary,
                position: PositionType.FWD,
                country: "Norway",
                club: "Manchester City",
                power: 91),

            new CardDefinition(
                id: "card_bellingham_epic",
                name: "Jude Bellingham",
                rarity: CardRarity.Epic,
                position: PositionType.MID,
                country: "England",
                club: "Real Madrid",
                power: 89),

            new CardDefinition(
                id: "card_van_dijk_epic",
                name: "Virgil van Dijk",
                rarity: CardRarity.Epic,
                position: PositionType.DEF,
                country: "Netherlands",
                club: "Liverpool",
                power: 88),

            new CardDefinition(
                id: "card_de_bruyne_rare",
                name: "Kevin De Bruyne",
                rarity: CardRarity.Rare,
                position: PositionType.MID,
                country: "Belgium",
                club: "Manchester City",
                power: 87),

            new CardDefinition(
                id: "card_neuer_rare",
                name: "Manuel Neuer",
                rarity: CardRarity.Rare,
                position: PositionType.GK,
                country: "Germany",
                club: "Bayern Munich",
                power: 86),

            new CardDefinition(
                id: "card_saka_uncommon",
                name: "Bukayo Saka",
                rarity: CardRarity.Uncommon,
                position: PositionType.FWD,
                country: "England",
                club: "Arsenal",
                power: 82),

            new CardDefinition(
                id: "card_test_common",
                name: "Test Common Player",
                rarity: CardRarity.Common,
                position: PositionType.MID,
                country: "Test Country",
                club: "Test Club",
                power: 60)
        };
        }

        public CardDefinition GetById(string cardId)
        {
            return _cards.FirstOrDefault(card => card.Id == cardId);
        }

        public IReadOnlyList<CardDefinition> GetAll()
        {
            return _cards;
        }
    }
}
