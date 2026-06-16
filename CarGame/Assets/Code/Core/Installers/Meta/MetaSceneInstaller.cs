using Core.Features;
using Core.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Core.Installers
{
    public class MetaSceneInstaller : MonoInstaller
    {
        public MainMenuScreen MainMenuScreen;
        public CollectionScreen CollectionScreen;

        public override void InstallBindings()
        {
            BindScreens();
            BindPresenters();
            BindBootstrapper();
        }

        private void BindScreens()
        {
            Container.BindInterfacesAndSelfTo<ScreenService>()
                .AsSingle();

            Container.BindInstance(MainMenuScreen)
                .AsSingle();

            Container.BindInstance(CollectionScreen)
                .AsSingle();
        }

        private void BindPresenters()
        {
            Container.Bind<CollectionPresenter>()
                .AsSingle();
        }

        private void BindBootstrapper()
        {
            Container.BindInterfacesTo<MetaSceeneBootstrapper>()
                .AsSingle();
        }
    }
}
