using Core.Domain;
using System;
namespace Core.Application
{

    public class CreateDeckUseCase : ICreateDeckUseCase
    {
        private readonly IPlayerStateService _playerStateService;

        public CreateDeckUseCase(IPlayerStateService playerStateService)
        {
            _playerStateService = playerStateService;
        }

        public DeckOperationResult Execute(string deckName)
        {
            if (string.IsNullOrWhiteSpace(deckName))
                return DeckOperationResult.Failure("Deck name is empty.");

            PlayerState state = _playerStateService.GetState();

            Deck deck = new Deck(
                id: Guid.NewGuid().ToString(),
                name: deckName);

            state.AddDeck(deck);
            _playerStateService.SaveState();

            return DeckOperationResult.Success(deck);
        }
    }
}
