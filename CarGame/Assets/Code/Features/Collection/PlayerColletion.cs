using Core.Domain;
using System.Collections.Generic;

namespace Features.Collection
{
    public class PlayerCollection
    {
        private readonly List<CardInstance> _cards;

        public IReadOnlyList<CardInstance> Cards => _cards;

        public PlayerCollection()
        {
            _cards = new List<CardInstance>();
        }

        public void AddCard(CardInstance card)
        {
            _cards.Add(card);
        }

        public bool RemoveCard(string instanceId)
        {
            CardInstance card = GetByInstanceId(instanceId);

            if (card == null)
                return false;

            _cards.Remove(card);
            return true;
        }

        public CardInstance GetByInstanceId(string instanceId)
        {
            return _cards.Find(card => card.InstanceId == instanceId);
        }

        public bool Contains(string instanceId)
        {
            return GetByInstanceId(instanceId) != null;
        }
    }
}
