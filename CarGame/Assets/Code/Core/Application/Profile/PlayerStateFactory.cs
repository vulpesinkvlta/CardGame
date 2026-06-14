using Core.Domain;
using Features.Collection;
using System.Collections.Generic;

namespace Core.Application
{
    public class PlayerStateFactory
    {
        public PlayerState CreateNew(string playerId, string playerName)
        {
            PlayerProfile profile = new PlayerProfile(
                playerId: playerId,
                playerName: playerName,
                rating: 0);

            PlayerCollection collection = new PlayerCollection();
            CurrencyWallet wallet = new CurrencyWallet();

            wallet.Add(new CurrencyAmount(CurrencyType.Coins, 1000));
            wallet.Add(new CurrencyAmount(CurrencyType.Gems, 10));

            List<Deck> decks = new List<Deck>
        {
            new Deck("deck_default", "Default Deck")
        };

            return new PlayerState(
                profile,
                collection,
                wallet,
                decks);
        }
    }
}
