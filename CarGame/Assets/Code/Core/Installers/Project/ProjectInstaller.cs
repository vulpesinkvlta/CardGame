using Core.Application;
using Core.Domain;
using Core.Domain.Factory;
using Core.Infrastructure;
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
        BindCardServices();
        BindDeckServices();
        BindEconomyServices();
        BindPackServices();
        BindSharedServices();
        BindPlayerStateServices();
        BindUseCases();
    }

    private void BindUseCases()
    {
        Container.Bind<IOpenPackUseCase>()
            .To<OpenPackUseCase>()
            .AsSingle();

        Container.Bind<ISellCardUseCase>()
            .To<SellCardUseCase>()
            .AsSingle();

        Container.Bind<ICreateDeckUseCase>()
            .To<CreateDeckUseCase>()
            .AsSingle();

        Container.Bind<IAddCardToDeckUseCase>()
            .To<AddCardToDeckUseCase>()
            .AsSingle();

        Container.Bind<IRemoveCardFromDeckUseCase>()
            .To<RemoveCardFromDeckUseCase>()
            .AsSingle();
    }

    private void BindPlayerStateServices()
    {
        Container.Bind<PlayerStateFactory>()
            .AsSingle();

        Container.Bind<IPlayerStateRepository>()
            .To<RuntimePlayerStateRepository>()
            .AsSingle();

        Container.Bind<IPlayerStateService>()
            .To<PlayerStateService>()
            .AsSingle();
    }

    private void BindSharedServices()
    {
        Container.Bind<IRandomService>()
            .To<SystemRandomService>()
            .AsSingle();
    }

    private void BindPackServices()
    {
        Container.Bind<IPackCatalog>()
            .To<TestPackCatalog>()
            .AsSingle();

        Container.Bind<IPackOpeningService>()
            .To<PackOpeningService>()
            .AsSingle();
    }

    private void BindEconomyServices()
    {
        Container.Bind<ICardSellPriceCalculator>()
            .To<CardSellCalculator>()
            .AsSingle();

        Container.Bind<ICardSellService>()
            .To<CardSellService>()
            .AsSingle();
    }

    private void BindDeckServices()
    {
        Container.Bind<IDeckValidator>()
            .To<DeckValidator>()
            .AsSingle();

        Container.Bind<IDeckPowerCalculator>()
            .To<DeckPowerCalculator>()
            .AsSingle();
    }

    private void BindCardServices()
    {
        Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
        Container.Bind<ICardCatalog>()
            .To<TestCardCatalog>()
            .AsSingle();
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