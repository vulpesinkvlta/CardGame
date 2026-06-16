namespace Core.Application
{
    public interface ICreateDeckUseCase
    {
        DeckOperationResult Execute(string deckName);
    }
}
