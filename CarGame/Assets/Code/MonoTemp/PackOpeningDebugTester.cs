using Core.Application;
using Core.Domain;
using Features.Collection;
using UnityEngine;
using Zenject;

public class PackOpeningDebugTester : MonoBehaviour
{
    private IPackOpeningService _packOpeningService;
    private ICardCatalog _cardCatalog;

    [Inject]
    public void Construct(
        IPackOpeningService packOpeningService,
        ICardCatalog cardCatalog)
    {
        _packOpeningService = packOpeningService;
        _cardCatalog = cardCatalog;
    }

    private void Start()
    {
        PlayerCollection collection = new PlayerCollection();

        OpenPack("pack_basic", collection);
        OpenPack("pack_premium", collection);

        Debug.Log($"[PackOpeningDebugTester] Total cards in collection: {collection.Cards.Count}");
    }

    private void OpenPack(string packId, PlayerCollection collection)
    {
        Debug.Log($"[PackOpeningDebugTester] Opening pack: {packId}");

        PackOpeningResult result = _packOpeningService.Open(packId, collection);

        if (!result.IsSucces)
        {
            Debug.LogError($"[PackOpeningDebugTester] Pack opening failed: {result.Error}");
            return;
        }

        foreach (CardInstance cardInstance in result.Cards)
        {
            CardDefinition definition = _cardCatalog.GetById(cardInstance.DefinitionId);

            if (definition == null)
            {
                Debug.LogError(
                    $"[PackOpeningDebugTester] Card definition not found: {cardInstance.DefinitionId}");
                continue;
            }

            Debug.Log(
                $"[PackOpeningDebugTester] Dropped: {definition.Name} | {definition.Rarity} | {definition.Position} | Power: {definition.Power} | InstanceId: {cardInstance.InstanceId}");
        }
    }
}