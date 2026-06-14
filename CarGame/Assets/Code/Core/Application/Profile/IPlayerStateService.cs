using Core.Domain;

namespace Core.Application
{
    public interface IPlayerStateService
    {
        PlayerState GetState();
        void SaveState();
    }
}
