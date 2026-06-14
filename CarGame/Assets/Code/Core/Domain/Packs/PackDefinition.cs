using System.Collections.Generic;

namespace Core.Domain
{
    public class PackDefinition
    {
        private readonly List<PackDropRule> _dropRules;

        public string Id { get; }
        public string Name { get; }
        public int CardsCount { get; }

        public IReadOnlyList<PackDropRule> DropRules => _dropRules;
    
        public PackDefinition(string id, string name, int cardsCount, List<PackDropRule> dropRules)
        {
            Id = id;
            Name = name;
            CardsCount = cardsCount;
            _dropRules = dropRules ?? new List<PackDropRule>();
        }
    }
}
