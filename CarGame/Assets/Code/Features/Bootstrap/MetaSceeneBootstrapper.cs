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
        private readonly IScreenService _screenService;

        private readonly MainMenuScreen _mainMenuScreen;
        private readonly CollectionScreen _collectionScreen;

        private readonly CollectionPresenter _collectionPresenter;

        public MetaSceeneBootstrapper(
            IScreenService screenService,
            MainMenuScreen mainMenuScreen,
            CollectionScreen collectionScreen,
            CollectionPresenter collectionPresenter)
        {
            _screenService = screenService;
            _mainMenuScreen = mainMenuScreen;
            _collectionScreen = collectionScreen;
            _collectionPresenter = collectionPresenter;
        }

        public void Initialize()
        {
            _screenService.Register(_mainMenuScreen);
            _screenService.Register(_collectionScreen);

            _collectionPresenter.Initialize();

            _screenService.ShowOnly<MainMenuScreen>();
        }
    }
}
