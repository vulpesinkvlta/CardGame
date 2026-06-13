namespace Core.Domain
{
    public interface ICardFactory
    {
        CardInstance Create(string definitionId);
    }
}
