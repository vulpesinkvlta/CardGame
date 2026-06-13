using Core.Application;
using Core.Domain;
using UnityEngine;
using Zenject;

public class CardCatalogDebugTester : MonoBehaviour
{
    private ICardCatalog _cardCatalog;

    [Inject]
    public void Construct(ICardCatalog cardCatalog)
    {
        _cardCatalog = cardCatalog;
    }

    private void Start()
    {
        Debug.Log("[CardCatalogDebugTester] All cards in catalog:");

        foreach (CardDefinition card in _cardCatalog.GetAll())
        {
            Debug.Log(
                $"[CardCatalogDebugTester] {card.Id} | {card.Name} | {card.Rarity} | {card.Position} | {card.Country} | {card.Club} | Power: {card.Power}");
        }

        CardDefinition messi = _cardCatalog.GetById("card_messi_icon");

        if (messi != null)
        {
            Debug.Log($"[CardCatalogDebugTester] Found card: {messi.Name}, Power: {messi.Power}");
        }
        else
        {
            Debug.LogError("[CardCatalogDebugTester] Messi card not found.");
        }
    }
}