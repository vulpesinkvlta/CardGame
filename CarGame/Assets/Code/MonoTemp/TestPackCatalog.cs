using Core.Application;
using Core.Domain;
using System.Collections.Generic;
using System.Linq;

public class TestPackCatalog : IPackCatalog
{
    private readonly List<PackDefinition> _packs;

    public TestPackCatalog()
    {
        _packs = new List<PackDefinition>
        {
            new PackDefinition(
                id: "pack_basic",
                name: "Basic Pack",
                cardsCount: 5,
                dropRules: new List<PackDropRule>
                {
                    new PackDropRule(CardRarity.Common, 60),
                    new PackDropRule(CardRarity.Uncommon, 25),
                    new PackDropRule(CardRarity.Rare, 10),
                    new PackDropRule(CardRarity.Epic, 4),
                    new PackDropRule(CardRarity.Legendary, 1),
                    new PackDropRule(CardRarity.Icon, 0)
                }),

            new PackDefinition(
                id: "pack_premium",
                name: "Premium Pack",
                cardsCount: 5,
                dropRules: new List<PackDropRule>
                {
                    new PackDropRule(CardRarity.Common, 35),
                    new PackDropRule(CardRarity.Uncommon, 30),
                    new PackDropRule(CardRarity.Rare, 20),
                    new PackDropRule(CardRarity.Epic, 10),
                    new PackDropRule(CardRarity.Legendary, 4),
                    new PackDropRule(CardRarity.Icon, 1)
                }),

            new PackDefinition(
                id: "pack_legendary",
                name: "Legendary Pack",
                cardsCount: 3,
                dropRules: new List<PackDropRule>
                {
                    new PackDropRule(CardRarity.Common, 0),
                    new PackDropRule(CardRarity.Uncommon, 0),
                    new PackDropRule(CardRarity.Rare, 40),
                    new PackDropRule(CardRarity.Epic, 35),
                    new PackDropRule(CardRarity.Legendary, 20),
                    new PackDropRule(CardRarity.Icon, 5)
                })
        };
    }

    public PackDefinition GetById(string packId)
    {
        return _packs.FirstOrDefault(pack => pack.Id == packId);
    }

    public IReadOnlyList<PackDefinition> GetAll()
    {
        return _packs;
    }
}