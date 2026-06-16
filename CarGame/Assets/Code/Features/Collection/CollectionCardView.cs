using Core.Presentation;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Features
{
    public class CollectionCardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _rarityText;
        [SerializeField] private TMP_Text _positionText;
        [SerializeField] private TMP_Text _powerText;
        [SerializeField] private TMP_Text _sellPriceText;
        [SerializeField] private Button _sellButton;

        private string _cardInstanceId;
        private Action<string> _onSellClicked;

        public void Render(
            CollectionCardViewData viewData,
            Action<string> onSellClicked)
        {
            _cardInstanceId = viewData.InstanceId;
            _onSellClicked = onSellClicked;

            _nameText.text = viewData.Name;
            _rarityText.text = viewData.Rarity;
            _positionText.text = viewData.Position;
            _powerText.text = $"Power: {viewData.Power}";
            _sellPriceText.text = viewData.SellPriceText;
        }

        private void OnEnable()
        {
            _sellButton.onClick.AddListener(OnSellButtonClicked);
        }

        private void OnDisable()
        {
            _sellButton.onClick.RemoveListener(OnSellButtonClicked);
        }

        private void OnSellButtonClicked()
        {
            _onSellClicked?.Invoke(_cardInstanceId);
        }
    }
}
