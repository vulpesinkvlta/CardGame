using Core.Presentation;
using System;
using UnityEngine.UI;
using UnityEngine;

namespace Core.Features
{
    public class MainMenuScreen : ScreenBase
    {
        [SerializeField] private Button _startFakeMatchButton;
        [SerializeField] private Button _collectionButton;
        [SerializeField] private Button _packsButton;
        [SerializeField] private Button _leaderBoardButton;

        private void OnEnable()
        {
            _startFakeMatchButton.onClick.AddListener(OnStartFakeMatchButtonClicked);
            _collectionButton.onClick.AddListener(OnCollectionButtonClicked);
            _packsButton.onClick.AddListener(OnPacksButtonClicked);
            _leaderBoardButton.onClick.AddListener(OnLeaderBoardButtonClicked);
        }

        private void OnStartFakeMatchButtonClicked()
        {
            Debug.Log("[MainMenuScreen] Start Fake Match clicked");
        }

        private void OnCollectionButtonClicked()
        {
            Debug.Log("[MainMenuScreen] Collection clicked");
        }

        private void OnPacksButtonClicked()
        {
            Debug.Log("[MainMenuScreen] Packs clicked");
        }

        private void OnLeaderBoardButtonClicked()
        {
            Debug.Log("[MainMenuScreen] Leaderboard clicked");
        }
    }
}
