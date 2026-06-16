using Core.Domain;

namespace Core.Application
{
    public class AddCardToDeckUseCase : IAddCardToDeckUseCase
    {
        private readonly IPlayerStateService _playerStateService;
        private readonly IDeckValidator _deckValidator;

        public AddCardToDeckUseCase(
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

            if (!state.Collection.Contains(cardInstanceId))
                return DeckOperationResult.Failure($"Card not found in collection: {cardInstanceId}");

            bool added = deck.TryAddCard(cardInstanceId);

            if (!added)
                return DeckOperationResult.Failure("Failed to add card to deck.");

            DeckValidationResult validationResult = _deckValidator.Validate(
                deck,
                state.Collection);

            if (!validationResult.IsValid)
            {
                deck.TryRemoveCard(cardInstanceId);

                string error = string.Join("; ", validationResult.Errors);
                return DeckOperationResult.Failure(error);
            }

            _playerStateService.SaveState();

            return DeckOperationResult.Success(deck);
        }
    }
}
