using System;

namespace Core.Domain.Factory
{
    public class CardFactory : ICardFactory
    {
        public CardInstance Create(string definitionId)
        {
            return new CardInstance(
                Guid.NewGuid().ToString(),
                definitionId);
        }
    }
}
