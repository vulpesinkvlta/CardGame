using Core.Application;
using Core.Domain;
using Features.Collection;
using UnityEngine;
using Zenject;

public class DeckDebugTester : MonoBehaviour
{
    private ICardFactory _cardFactory;
    private IDeckValidator _deckValidator;

    [Inject]
    public void Construct(
        ICardFactory cardFactory,
        IDeckValidator deckValidator)
    {
        _cardFactory = cardFactory;
        _deckValidator = deckValidator;
    }

    private void Start()
    {
        PlayerCollection collection = new PlayerCollection();
        Deck deck = new Deck("deck_001", "Test Deck");

        CardInstance firstCard = _cardFactory.Create("card_test_001");
        CardInstance secondCard = _cardFactory.Create("card_test_002");

        collection.AddCard(firstCard);
        collection.AddCard(secondCard);

        deck.TryAddCard(firstCard.InstanceId);
        deck.TryAddCard(secondCard.InstanceId);

        DeckValidationResult result = _deckValidator.Validate(deck, collection);

        Debug.Log($"[DeckDebugTester] Deck valid: {result.IsValid}");

        foreach (string error in result.Errors)
        {
            Debug.LogError($"[DeckDebugTester] {error}");
        }
    }
}