using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    public class Deck
    {
        private readonly List<string> _cardInstanceIds;

        public string Id { get; }
        public string Name { get; }

        public IReadOnlyList<string> CardInstanceIds => _cardInstanceIds;

        public Deck(string id, string name)
        {
            Id = id;
            Name = name;
            _cardInstanceIds = new List<string>();
        }

        public bool ContainsCard(string cardInstanceId)
        {
            return _cardInstanceIds.Contains(cardInstanceId);
        }

        public bool TryAddCard(string cardInstanceId)
        {
            if (string.IsNullOrWhiteSpace(cardInstanceId))
                return false;

            if (_cardInstanceIds.Count >= DeckConstants.MaxCardsInMatchDeck)
                return false;

            if (_cardInstanceIds.Contains(cardInstanceId))
                return false;

            _cardInstanceIds.Add(cardInstanceId);
            return true;
        }

        public bool TryRemoveCard(string cardInstanceId)
        {
            return _cardInstanceIds.Remove(cardInstanceId);
        }

        public void Clear()
        {
            _cardInstanceIds.Clear();
        }
    }
}
