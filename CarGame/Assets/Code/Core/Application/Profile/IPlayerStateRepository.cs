using Core.Domain;

namespace Core.Application
{
    public interface IPlayerStateRepository
    {
        PlayerState Load();
        void Save(PlayerState state);
    }
}
