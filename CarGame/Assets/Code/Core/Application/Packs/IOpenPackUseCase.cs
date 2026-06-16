namespace Core.Application
{
    public interface IOpenPackUseCase
    {
        PackOpeningResult Execute(string packId);
    }
}
