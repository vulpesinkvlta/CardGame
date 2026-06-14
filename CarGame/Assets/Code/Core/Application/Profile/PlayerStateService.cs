using Core.Domain;

namespace Core.Application
{
    public class PlayerStateService : IPlayerStateService
    {
        private readonly IPlayerStateRepository _repository;

        private PlayerState _state;

        public PlayerStateService(IPlayerStateRepository repository)
        {
            _repository = repository;
        }

        public PlayerState GetState()
        {
            if (_state == null)
                _state = _repository.Load();

            return _state;
        }

        public void SaveState()
        {
            if (_state == null)
                return;

            _repository.Save(_state);
        }
    }
}
