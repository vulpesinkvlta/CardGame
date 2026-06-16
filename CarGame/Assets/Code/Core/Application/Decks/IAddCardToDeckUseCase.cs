namespace Core.Application
{
    public interface IAddCardToDeckUseCase
    {
        DeckOperationResult Execute(string deckId, string cardInstanceId);
    }
}
