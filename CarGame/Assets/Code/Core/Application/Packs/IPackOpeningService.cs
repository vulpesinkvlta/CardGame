using Features.Collection;

namespace Core.Application
{
    public interface IPackOpeningService
    {
        PackOpeningResult Open(string packId, PlayerCollection collection);
    }
}
