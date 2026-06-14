using Core.Application;
using Core.Domain;
using Core.Platform;

namespace Core.Infrastructure
{
    public class RuntimePlayerStateRepository : IPlayerStateRepository
    {
        private readonly PlayerStateFactory _playerStateFactory;
        private readonly IAuthService _authService;

        private PlayerState _cachedState;

        public RuntimePlayerStateRepository(
            PlayerStateFactory playerStateFactory,
            IAuthService authService)
        {
            _playerStateFactory = playerStateFactory;
            _authService = authService;
        }

        public PlayerState Load()
        {
            if (_cachedState != null)
                return _cachedState;

            string playerId = _authService.PlayerId;
            string playerName = _authService.PlayerName;

            _cachedState = _playerStateFactory.CreateNew(playerId, playerName);

            return _cachedState;
        }

        public void Save(PlayerState state)
        {
            _cachedState = state;
        }
    }
}
