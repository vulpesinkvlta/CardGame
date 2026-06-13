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

        public override void InstallBindings()
        {
            BindScreens();
        }

        private void BindScreens()
        {
            Container.BindInterfacesAndSelfTo<ScreenService>().AsSingle();
            Container.BindInstance(MainMenuScreen).AsSingle();
            Container.BindInterfacesTo<MetaSceeneBootstrapper>().AsSingle();
        }
    }
}
