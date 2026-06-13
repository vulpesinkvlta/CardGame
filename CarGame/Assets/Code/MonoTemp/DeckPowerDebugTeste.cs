using Core.Application;
using Core.Domain;
using Features.Collection;
using UnityEngine;
using Zenject;

public class DeckPowerDebugTester : MonoBehaviour
{
    private ICardFactory _cardFactory;
    private IDeckValidator _deckValidator;
    private IDeckPowerCalculator _deckPowerCalculator;

    [Inject]
    public void Construct(
        ICardFactory cardFactory,
        IDeckValidator deckValidator,
        IDeckPowerCalculator deckPowerCalculator)
    {
        _cardFactory = cardFactory;
        _deckValidator = deckValidator;
        _deckPowerCalculator = deckPowerCalculator;
    }

    private void Start()
    {
        PlayerCollection collection = new PlayerCollection();
        Deck deck = new Deck("deck_001", "Test Deck");

        AddCardToCollectionAndDeck(
            definitionId: "card_messi_icon",
            collection: collection,
            deck: deck);

        AddCardToCollectionAndDeck(
            definitionId: "card_mbappe_legendary",
            collection: collection,
            deck: deck);

        AddCardToCollectionAndDeck(
            definitionId: "card_bellingham_epic",
            collection: collection,
            deck: deck);

        DeckValidationResult validationResult = _deckValidator.Validate(deck, collection);

        Debug.Log($"[DeckPowerDebugTester] Deck valid: {validationResult.IsValid}");

        foreach (string error in validationResult.Errors)
        {
            Debug.LogError($"[DeckPowerDebugTester] Validation error: {error}");
        }

        int deckPower = _deckPowerCalculator.Calculate(deck, collection);

        Debug.Log($"[DeckPowerDebugTester] Deck power: {deckPower}");
    }

    private void AddCardToCollectionAndDeck(
        string definitionId,
        PlayerCollection collection,
        Deck deck)
    {
        CardInstance cardInstance = _cardFactory.Create(definitionId);

        collection.AddCard(cardInstance);
        deck.TryAddCard(cardInstance.InstanceId);

        Debug.Log(
            $"[DeckPowerDebugTester] Added card instance {cardInstance.InstanceId} with definition {definitionId}");
    }
}