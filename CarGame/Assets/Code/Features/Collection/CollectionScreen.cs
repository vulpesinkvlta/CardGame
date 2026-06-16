using Core.Domain;
using Core.Presentation;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Features
{
    public class CollectionScreen : ScreenBase
    {
        [SerializeField] private WalletView _walletView;

        [SerializeField] private Button _openBasicPackButton;
        [SerializeField] private Button _backButton;

        [SerializeField] private TMP_Text _cardsCountText;
        [SerializeField] private Transform _cardsContainer;
        [SerializeField] private CollectionCardView _cardViewPrefab;

        public event Action OpenBasicPackClicked;
        public event Action BackClicked;
        public event Action<string> SellCardClicked;

        private readonly List<CollectionCardView> _spawnedCards = new();

        private void OnEnable()
        {
            _openBasicPackButton.onClick.AddListener(OnOpenBasicPackButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnDisable()
        {
            _openBasicPackButton.onClick.RemoveListener(OnOpenBasicPackButtonClicked);
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        public void RenderWallet(CurrencyWallet wallet)
        {
            _walletView.Render(wallet);
        }

        public void RenderCards(IReadOnlyList<CollectionCardViewData> cards)
        {
            ClearCards();

            _cardsCountText.text = $"Cards: {cards.Count}";

            foreach (CollectionCardViewData cardViewData in cards)
            {
                CollectionCardView cardView = Instantiate(
                    _cardViewPrefab,
                    _cardsContainer);

                cardView.Render(cardViewData, OnSellCardClicked);

                _spawnedCards.Add(cardView);
            }
        }

        private void ClearCards()
        {
            foreach (CollectionCardView cardView in _spawnedCards)
            {
                if (cardView != null)
                    Destroy(cardView.gameObject);
            }

            _spawnedCards.Clear();
        }

        private void OnOpenBasicPackButtonClicked()
        {
            OpenBasicPackClicked?.Invoke();
        }

        private void OnBackButtonClicked()
        {
            BackClicked?.Invoke();
        }

        private void OnSellCardClicked(string cardInstanceId)
        {
            SellCardClicked?.Invoke(cardInstanceId);
        }
    }
}
