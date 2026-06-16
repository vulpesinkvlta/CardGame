using Core.Domain;
using TMPro;
using UnityEngine;

namespace Core.Features
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private TMP_Text _gemsText;

        public void Render(CurrencyWallet wallet)
        {
            if (wallet == null)
            {
                _coinsText.text = "Coins: 0";
                _gemsText.text = "Gems: 0";
                return;
            }

            int coins = wallet.GetBalance(CurrencyType.Coins);
            int gems = wallet.GetBalance(CurrencyType.Gems);

            _coinsText.text = $"Coins: {coins}";
            _gemsText.text = $"Gems: {gems}";
        }
    }
}
