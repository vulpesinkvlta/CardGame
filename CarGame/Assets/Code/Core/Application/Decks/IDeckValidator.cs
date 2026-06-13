using Core.Domain;
using Features.Collection;

namespace Core.Application
{
    public interface IDeckValidator
    {
        DeckValidationResult Validate(Deck deck, PlayerCollection collection);
    }
}
