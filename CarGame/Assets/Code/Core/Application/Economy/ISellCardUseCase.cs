namespace Core.Application
{
    public interface ISellCardUseCase
    {
        SellCardUseCaseResult Execute(string cardInstanceId);
    }
}
