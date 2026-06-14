using Features.Collection;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    public class PlayerState
    {
        private readonly List<Deck> _decks;

        public PlayerProfile Profile { get; }
        public PlayerCollection Collection { get; }
        public CurrencyWallet Wallet { get; }

        public IReadOnlyList<Deck> Decks => _decks;

        public PlayerState(
            PlayerProfile profile,
            PlayerCollection collection,
            CurrencyWallet wallet,
            List<Deck> decks)
        {
            Profile = profile;
            Collection = collection;
            Wallet = wallet;
            _decks = decks ?? new List<Deck>();
        }

        public Deck GetDeckById(string deckId)
        {
            return _decks.FirstOrDefault(deck => deck.Id == deckId);
        }

        public void AddDeck(Deck deck)
        {
            if (deck == null)
                return;

            if (_decks.Any(existingDeck => existingDeck.Id == deck.Id))
                return;

            _decks.Add(deck);
        }

        public bool RemoveDeck(string deckId)
        {
            Deck deck = GetDeckById(deckId);

            if (deck == null)
                return false;

            _decks.Remove(deck);
            return true;
        }
    }
}
