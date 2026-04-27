using Core.Platform;
using Core.Presentation;
using System;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        BindPlatformServices();
        BindCurtain();
    }

    private void BindCurtain()
    {
        Container.BindInterfacesAndSelfTo<LoadingCurtain>().FromComponentInNewPrefabResource("Curtain").AsSingle();
        //Container.InstantiatePrefabForComponent<LoadingCurtain>(Resources.Load<GameObject>("Curtain"));
    }

    private void BindPlatformServices()
    {
        Container.Bind<IPlatformInitializer>().To<StubPlatformInitializer>().AsSingle();
        Container.Bind<IAuthService>().To<StubAuthService>().AsSingle();
        Container.Bind<ILeaderBoardService>().To<StubLeaderBoardService>().AsSingle();
        Container.Bind<ISaveService>().To<PlayerPrefsSaveService>().AsSingle();
    }
}