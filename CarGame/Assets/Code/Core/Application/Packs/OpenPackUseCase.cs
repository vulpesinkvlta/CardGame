using Core.Domain;

namespace Core.Application
{
    public class OpenPackUseCase : IOpenPackUseCase
    {
        private readonly IPlayerStateService _playerStateService;
        private readonly IPackOpeningService _packOpeningService;

        public OpenPackUseCase(
            IPlayerStateService playerStateService,
            IPackOpeningService packOpeningService)
        {
            _playerStateService = playerStateService;
            _packOpeningService = packOpeningService;
        }

        public PackOpeningResult Execute(string packId)
        {
            PlayerState state = _playerStateService.GetState();

            PackOpeningResult result = _packOpeningService.Open(
                packId,
                state.Collection);

            if (result.IsSucces)
                _playerStateService.SaveState();

            return result;
        }
    }
}
