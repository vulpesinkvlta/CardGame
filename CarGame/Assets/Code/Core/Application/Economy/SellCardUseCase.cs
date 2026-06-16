using Core.Domain;

namespace Core.Application
{
    public class SellCardUseCase : ISellCardUseCase
    {
        private readonly IPlayerStateService _playerStateService;
        private readonly ICardSellService _cardSellService;

        public SellCardUseCase(
            IPlayerStateService playerStateService,
            ICardSellService cardSellService)
        {
            _playerStateService = playerStateService;
            _cardSellService = cardSellService;
        }

        public SellCardUseCaseResult Execute(string cardInstanceId)
        {
            PlayerState state = _playerStateService.GetState();

            SellCardResult sellResult = _cardSellService.Sell(
                cardInstanceId,
                state.Collection,
                state.Wallet);

            if (!sellResult.IsSuccess)
                return SellCardUseCaseResult.Failure(sellResult.Error);

            int removedFromDecksCount = RemoveCardFromAllDecks(
                cardInstanceId,
                state);

            _playerStateService.SaveState();

            return SellCardUseCaseResult.Success(
                sellResult.Reward,
                removedFromDecksCount);
        }

        private int RemoveCardFromAllDecks(
            string cardInstanceId,
            PlayerState state)
        {
            int removedCount = 0;

            foreach (Deck deck in state.Decks)
            {
                bool removed = deck.TryRemoveCard(cardInstanceId);

                if (removed)
                    removedCount++;
            }

            return removedCount;
        }
    }
}
