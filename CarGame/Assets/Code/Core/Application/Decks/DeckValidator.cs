using Core.Domain;
using Features.Collection;
using System.Collections.Generic;
using System.Linq;


namespace Core.Application
{
    public class DeckValidator : IDeckValidator
    {
        public DeckValidationResult Validate(Deck deck, PlayerCollection collection)
        {
            DeckValidationResult result = new DeckValidationResult();

            if (deck == null)
            {
                result.AddError("Deck is null.");
                return result;
            }

            if (collection == null)
            {
                result.AddError("Collection is null.");
                return result;
            }

            ValidateCardsCount(deck, result);
            ValidateDuplicates(deck, result);
            ValidateCardsExistInCollection(deck, collection, result);

            return result;
        }

        private void ValidateCardsCount(Deck deck, DeckValidationResult result)
        {
            int cardsCount = deck.CardInstanceIds.Count;

            if (cardsCount < DeckConstants.MinCardsInMatchDeck)
            {
                result.AddError(
                    $"Deck must contain at least {DeckConstants.MinCardsInMatchDeck} card.");
            }

            if (cardsCount > DeckConstants.MaxCardsInMatchDeck)
            {
                result.AddError(
                    $"Deck cannot contain more than {DeckConstants.MaxCardsInMatchDeck} cards.");
            }
        }

        private void ValidateDuplicates(Deck deck, DeckValidationResult result)
        {
            HashSet<string> uniqueIds = new HashSet<string>();

            foreach (string cardInstanceId in deck.CardInstanceIds)
            {
                if (!uniqueIds.Add(cardInstanceId))
                {
                    result.AddError($"Duplicate card in deck: {cardInstanceId}");
                }
            }
        }

        private void ValidateCardsExistInCollection(
            Deck deck,
            PlayerCollection collection,
            DeckValidationResult result)
        {
            foreach (string cardInstanceId in deck.CardInstanceIds)
            {
                bool existsInCollection = collection.Contains(cardInstanceId);

                if (!existsInCollection)
                {
                    result.AddError(
                        $"Card does not exist in player collection: {cardInstanceId}");
                }
            }
        }
    }
}
