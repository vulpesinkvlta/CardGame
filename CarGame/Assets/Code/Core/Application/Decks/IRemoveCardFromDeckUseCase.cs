namespace Core.Application
{
    public interface IRemoveCardFromDeckUseCase
    {
        DeckOperationResult Execute(string deckId, string cardInstanceId);
    }
}
