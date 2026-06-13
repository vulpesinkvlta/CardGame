using Core.Application;
using Core.Domain;
using Features.Collection;
using UnityEngine;
using Zenject;

public class SellCardDebugTester : MonoBehaviour
{
    private ICardFactory _cardFactory;
    private ICardSellService _cardSellService;
    private ICardCatalog _cardCatalog;

    [Inject]
    public void Construct(
        ICardFactory cardFactory,
        ICardSellService cardSellService,
        ICardCatalog cardCatalog)
    {
        _cardFactory = cardFactory;
        _cardSellService = cardSellService;
        _cardCatalog = cardCatalog;
    }

    private void Start()
    {
        PlayerCollection collection = new PlayerCollection();
        CurrencyWallet wallet = new CurrencyWallet();

        TestSellCard(
            definitionId: "card_bellingham_epic",
            collection: collection,
            wallet: wallet);

        TestSellCard(
            definitionId: "card_messi_icon",
            collection: collection,
            wallet: wallet);

        Debug.Log($"[SellCardDebugTester] Final Coins: {wallet.GetBalance(CurrencyType.Coins)}");
        Debug.Log($"[SellCardDebugTester] Final Gems: {wallet.GetBalance(CurrencyType.Gems)}");
        Debug.Log($"[SellCardDebugTester] Cards left in collection: {collection.Cards.Count}");
    }

    private void TestSellCard(
        string definitionId,
        PlayerCollection collection,
        CurrencyWallet wallet)
    {
        CardInstance cardInstance = _cardFactory.Create(definitionId);
        collection.AddCard(cardInstance);

        CardDefinition definition = _cardCatalog.GetById(definitionId);

        Debug.Log(
            $"[SellCardDebugTester] Added card: {definition.Name} | {definition.Rarity} | Power: {definition.Power}");

        SellCardResult result = _cardSellService.Sell(
            cardInstance.InstanceId,
            collection,
            wallet);

        if (!result.IsSuccess)
        {
            Debug.LogError($"[SellCardDebugTester] Sell failed: {result.Error}");
            return;
        }

        Debug.Log(
            $"[SellCardDebugTester] Sold card: {definition.Name}. Reward: {result.Reward.Amount} {result.Reward.CurrencyType}");
    }
}