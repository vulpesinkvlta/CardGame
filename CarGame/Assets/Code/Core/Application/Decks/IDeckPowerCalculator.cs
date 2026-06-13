using Core.Domain;
using Features.Collection;

namespace Core.Application
{
    public interface IDeckPowerCalculator
    {
        int Calculate(Deck deck, PlayerCollection collection);
    }
}
