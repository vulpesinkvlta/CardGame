using Core.Application;
using Core.Domain;
using UnityEngine;
using Zenject;

public class UseCasesDebugTester : MonoBehaviour
{
    private IPlayerStateService _playerStateService;
    private IOpenPackUseCase _openPackUseCase;
    private ISellCardUseCase _sellCardUseCase;
    private IAddCardToDeckUseCase _addCardToDeckUseCase;
    private ICardCatalog _cardCatalog;

    [Inject]
    public void Construct(
        IPlayerStateService playerStateService,
        IOpenPackUseCase openPackUseCase,
        ISellCardUseCase sellCardUseCase,
        IAddCardToDeckUseCase addCardToDeckUseCase,
        ICardCatalog cardCatalog)
    {
        _playerStateService = playerStateService;
        _openPackUseCase = openPackUseCase;
        _sellCardUseCase = sellCardUseCase;
        _addCardToDeckUseCase = addCardToDeckUseCase;
        _cardCatalog = cardCatalog;
    }

    private void Start()
    {
        PlayerState state = _playerStateService.GetState();

        Debug.Log("[UseCasesDebugTester] === BEFORE ===");
        LogState(state);

        PackOpeningResult packResult = _openPackUseCase.Execute("pack_basic");

        if (!packResult.IsSucces)
        {
            Debug.LogError($"[UseCasesDebugTester] Open pack failed: {packResult.Error}");
            return;
        }

        Debug.Log($"[UseCasesDebugTester] Opened pack. Cards dropped: {packResult.Cards.Count}");

        foreach (CardInstance card in packResult.Cards)
        {
            CardDefinition definition = _cardCatalog.GetById(card.DefinitionId);

            Debug.Log(
                $"[UseCasesDebugTester] Dropped: {definition.Name} | {definition.Rarity} | Power: {definition.Power}");
        }

        Deck defaultDeck = state.GetDeckById("deck_default");

        if (defaultDeck == null)
        {
            Debug.LogError("[UseCasesDebugTester] Default deck not found.");
            return;
        }

        CardInstance firstCard = packResult.Cards[0];

        DeckOperationResult addToDeckResult = _addCardToDeckUseCase.Execute(
            defaultDeck.Id,
            firstCard.InstanceId);

        if (!addToDeckResult.IsSuccess)
        {
            Debug.LogError($"[UseCasesDebugTester] Add to deck failed: {addToDeckResult.Error}");
            return;
        }

        Debug.Log(
            $"[UseCasesDebugTester] Added first dropped card to deck. Deck cards: {defaultDeck.CardInstanceIds.Count}");

        SellCardUseCaseResult sellResult = _sellCardUseCase.Execute(firstCard.InstanceId);

        if (!sellResult.IsSuccess)
        {
            Debug.LogError($"[UseCasesDebugTester] Sell failed: {sellResult.Error}");
            return;
        }

        Debug.Log(
            $"[UseCasesDebugTester] Sold card. Reward: {sellResult.Reward.Amount} {sellResult.Reward.CurrencyType}. Removed from decks: {sellResult.RemovedFromDecksCount}");

        Debug.Log("[UseCasesDebugTester] === AFTER ===");
        LogState(state);
    }

    private void LogState(PlayerState state)
    {
        Debug.Log($"[UseCasesDebugTester] Player: {state.Profile.PlayerName}");
        Debug.Log($"[UseCasesDebugTester] Cards: {state.Collection.Cards.Count}");
        Debug.Log($"[UseCasesDebugTester] Coins: {state.Wallet.GetBalance(CurrencyType.Coins)}");
        Debug.Log($"[UseCasesDebugTester] Gems: {state.Wallet.GetBalance(CurrencyType.Gems)}");

        foreach (Deck deck in state.Decks)
        {
            Debug.Log(
                $"[UseCasesDebugTester] Deck: {deck.Name} | Cards: {deck.CardInstanceIds.Count}");
        }
    }
}