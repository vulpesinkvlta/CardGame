using Core.Application;
using Core.Domain;
using UnityEngine;
using Zenject;

public class PlayerStateDebugTester : MonoBehaviour
{
    private IPlayerStateService _playerStateService;
    private IPackOpeningService _packOpeningService;
    private ICardSellService _cardSellService;
    private ICardCatalog _cardCatalog;

    [Inject]
    public void Construct(
        IPlayerStateService playerStateService,
        IPackOpeningService packOpeningService,
        ICardSellService cardSellService,
        ICardCatalog cardCatalog)
    {
        _playerStateService = playerStateService;
        _packOpeningService = packOpeningService;
        _cardSellService = cardSellService;
        _cardCatalog = cardCatalog;
    }

    private void Start()
    {
        PlayerState state = _playerStateService.GetState();

        Debug.Log($"[PlayerStateDebugTester] Player: {state.Profile.PlayerName}");
        Debug.Log($"[PlayerStateDebugTester] PlayerId: {state.Profile.PlayerId}");
        Debug.Log($"[PlayerStateDebugTester] Rating: {state.Profile.Rating}");
        Debug.Log($"[PlayerStateDebugTester] Coins: {state.Wallet.GetBalance(CurrencyType.Coins)}");
        Debug.Log($"[PlayerStateDebugTester] Gems: {state.Wallet.GetBalance(CurrencyType.Gems)}");
        Debug.Log($"[PlayerStateDebugTester] Decks count: {state.Decks.Count}");
        Debug.Log($"[PlayerStateDebugTester] Cards before pack: {state.Collection.Cards.Count}");

        OpenPack(state);
        SellFirstCard(state);

        _playerStateService.SaveState();

        Debug.Log($"[PlayerStateDebugTester] Cards after sell: {state.Collection.Cards.Count}");
        Debug.Log($"[PlayerStateDebugTester] Final Coins: {state.Wallet.GetBalance(CurrencyType.Coins)}");
        Debug.Log($"[PlayerStateDebugTester] Final Gems: {state.Wallet.GetBalance(CurrencyType.Gems)}");
    }

    private void OpenPack(PlayerState state)
    {
        PackOpeningResult result = _packOpeningService.Open("pack_basic", state.Collection);

        if (!result.IsSucces)
        {
            Debug.LogError($"[PlayerStateDebugTester] Pack opening failed: {result.Error}");
            return;
        }

        Debug.Log($"[PlayerStateDebugTester] Opened pack. Dropped cards: {result.Cards.Count}");

        foreach (CardInstance cardInstance in result.Cards)
        {
            CardDefinition definition = _cardCatalog.GetById(cardInstance.DefinitionId);

            Debug.Log(
                $"[PlayerStateDebugTester] Dropped: {definition.Name} | {definition.Rarity} | Power: {definition.Power}");
        }
    }

    private void SellFirstCard(PlayerState state)
    {
        if (state.Collection.Cards.Count == 0)
        {
            Debug.LogWarning("[PlayerStateDebugTester] No cards to sell.");
            return;
        }

        CardInstance cardToSell = state.Collection.Cards[0];
        CardDefinition definition = _cardCatalog.GetById(cardToSell.DefinitionId);

        SellCardResult result = _cardSellService.Sell(
            cardToSell.InstanceId,
            state.Collection,
            state.Wallet);

        if (!result.IsSuccess)
        {
            Debug.LogError($"[PlayerStateDebugTester] Sell failed: {result.Error}");
            return;
        }

        Debug.Log(
            $"[PlayerStateDebugTester] Sold: {definition.Name}. Reward: {result.Reward.Amount} {result.Reward.CurrencyType}");
    }
}