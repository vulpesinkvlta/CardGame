using Core.Domain;

namespace Core.Application
{
    public class RemoveCardFromDeckUseCase : IRemoveCardFromDeckUseCase
    {
        private readonly IPlayerStateService _playerStateService;
        private readonly IDeckValidator _deckValidator;

        public RemoveCardFromDeckUseCase(
            IPlayerStateService playerStateService,
            IDeckValidator deckValidator)
        {
            _playerStateService = playerStateService;
            _deckValidator = deckValidator;
        }

        public DeckOperationResult Execute(
            string deckId,
            string cardInstanceId)
        {
            if (string.IsNullOrWhiteSpace(deckId))
                return DeckOperationResult.Failure("Deck id is empty.");

            if (string.IsNullOrWhiteSpace(cardInstanceId))
                return DeckOperationResult.Failure("Card instance id is empty.");

            PlayerState state = _playerStateService.GetState();

            Deck deck = state.GetDeckById(deckId);

            if (deck == null)
                return DeckOperationResult.Failure($"Deck not found: {deckId}");

            bool removed = deck.TryRemoveCard(cardInstanceId);

            if (!removed)
                return DeckOperationResult.Failure($"Card not found in deck: {cardInstanceId}");

            DeckValidationResult validationResult = _deckValidator.Validate(
                deck,
                state.Collection);

            if (!validationResult.IsValid)
            {
                string error = string.Join("; ", validationResult.Errors);
                return DeckOperationResult.Failure(error);
            }

            _playerStateService.SaveState();

            return DeckOperationResult.Success(deck);
        }
    }
}
