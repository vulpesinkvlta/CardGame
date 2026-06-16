using Core.Presentation;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Features
{
    public class MainMenuScreen : ScreenBase
    {
        [SerializeField] private Button _startFakeMatchButton;
        [SerializeField] private Button _collectionButton;
        [SerializeField] private Button _packsButton;
        [SerializeField] private Button _leaderboardButton;

        private IScreenService _screenService;

        [Inject]
        public void Construct(IScreenService screenService)
        {
            _screenService = screenService;
        }

        private void OnEnable()
        {
            _startFakeMatchButton.onClick.AddListener(OnStartFakeMatchClicked);
            _collectionButton.onClick.AddListener(OnCollectionClicked);
            _packsButton.onClick.AddListener(OnPacksClicked);
            _leaderboardButton.onClick.AddListener(OnLeaderboardClicked);
        }

        private void OnDisable()
        {
            _startFakeMatchButton.onClick.RemoveListener(OnStartFakeMatchClicked);
            _collectionButton.onClick.RemoveListener(OnCollectionClicked);
            _packsButton.onClick.RemoveListener(OnPacksClicked);
            _leaderboardButton.onClick.RemoveListener(OnLeaderboardClicked);
        }

        private void OnStartFakeMatchClicked()
        {
            Debug.Log("[MainMenuScreen] Start Fake Match clicked");
        }

        private void OnCollectionClicked()
        {
            _screenService.ShowOnly<CollectionScreen>();
        }

        private void OnPacksClicked()
        {
            Debug.Log("[MainMenuScreen] Packs clicked");
        }

        private void OnLeaderboardClicked()
        {
            Debug.Log("[MainMenuScreen] Leaderboard clicked");
        }
    }
}
