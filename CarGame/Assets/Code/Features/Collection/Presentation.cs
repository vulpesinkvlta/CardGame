using Core.Application;
using Core.Domain;
using Core.Presentation;
using global::Features.Collection;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Features
{

    public class CollectionPresenter
    {
        private readonly CollectionScreen _screen;
        private readonly IScreenService _screenService;

        private readonly IPlayerStateService _playerStateService;
        private readonly IOpenPackUseCase _openPackUseCase;
        private readonly ISellCardUseCase _sellCardUseCase;

        private readonly ICardCatalog _cardCatalog;
        private readonly ICardSellPriceCalculator _sellPriceCalculator;

        public CollectionPresenter(
            CollectionScreen screen,
            IScreenService screenService,
            IPlayerStateService playerStateService,
            IOpenPackUseCase openPackUseCase,
            ISellCardUseCase sellCardUseCase,
            ICardCatalog cardCatalog,
            ICardSellPriceCalculator sellPriceCalculator)
        {
            _screen = screen;
            _screenService = screenService;
            _playerStateService = playerStateService;
            _openPackUseCase = openPackUseCase;
            _sellCardUseCase = sellCardUseCase;
            _cardCatalog = cardCatalog;
            _sellPriceCalculator = sellPriceCalculator;
        }

        public void Initialize()
        {
            _screen.OpenBasicPackClicked += OnOpenBasicPackClicked;
            _screen.BackClicked += OnBackClicked;
            _screen.SellCardClicked += OnSellCardClicked;

            Refresh();
        }

        public void Dispose()
        {
            _screen.OpenBasicPackClicked -= OnOpenBasicPackClicked;
            _screen.BackClicked -= OnBackClicked;
            _screen.SellCardClicked -= OnSellCardClicked;
        }

        public void Refresh()
        {
            PlayerState state = _playerStateService.GetState();

            _screen.RenderWallet(state.Wallet);
            _screen.RenderCards(CreateCardViewData(state.Collection));
        }

        private IReadOnlyList<CollectionCardViewData> CreateCardViewData(
            PlayerCollection collection)
        {
            List<CollectionCardViewData> viewData = new List<CollectionCardViewData>();

            foreach (CardInstance cardInstance in collection.Cards)
            {
                CardDefinition definition = _cardCatalog.GetById(cardInstance.DefinitionId);

                if (definition == null)
                    continue;

                CurrencyAmount sellPrice = _sellPriceCalculator.Calculate(definition);

                viewData.Add(new CollectionCardViewData(
                    instanceId: cardInstance.InstanceId,
                    name: definition.Name,
                    rarity: definition.Rarity.ToString(),
                    position: definition.Position.ToString(),
                    power: definition.Power,
                    sellPriceText: $"Sell: {sellPrice.Amount} {sellPrice.CurrencyType}"));
            }

            return viewData;
        }

        private void OnOpenBasicPackClicked()
        {
            PackOpeningResult result = _openPackUseCase.Execute("pack_basic");

            if (!result.IsSucces)
            {
                Debug.LogError($"[CollectionPresenter] Open pack failed: {result.Error}");
                return;
            }

            Debug.Log($"[CollectionPresenter] Opened basic pack. Cards: {result.Cards.Count}");

            Refresh();
        }

        private void OnSellCardClicked(string cardInstanceId)
        {
            SellCardUseCaseResult result = _sellCardUseCase.Execute(cardInstanceId);

            if (!result.IsSuccess)
            {
                Debug.LogError($"[CollectionPresenter] Sell card failed: {result.Error}");
                return;
            }

            Debug.Log(
                $"[CollectionPresenter] Sold card. Reward: {result.Reward.Amount} {result.Reward.CurrencyType}. Removed from decks: {result.RemovedFromDecksCount}");

            Refresh();
        }

        private void OnBackClicked()
        {
            _screenService.ShowOnly<MainMenuScreen>();
        }
    }
}
