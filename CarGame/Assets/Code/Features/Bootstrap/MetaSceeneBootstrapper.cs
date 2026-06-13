using Core.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Core.Features
{
    public class MetaSceeneBootstrapper : IInitializable
    {
        private readonly ScreenService _screenService;
        private readonly MainMenuScreen _mainMenuScreen;

        public MetaSceeneBootstrapper(ScreenService screenService, MainMenuScreen mainMenuScreen)
        {
            _screenService = screenService;
            _mainMenuScreen = mainMenuScreen;
        }

        public void Initialize()
        {
            _screenService.Register(_mainMenuScreen);
            _screenService.Show<MainMenuScreen>();
        }
    }
}
