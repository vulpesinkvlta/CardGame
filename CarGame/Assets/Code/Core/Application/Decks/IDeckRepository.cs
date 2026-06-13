using Core.Domain;
using System.Collections.Generic;

namespace Core.Application
{
    public interface IDeckRepository
    {
        IReadOnlyList<Deck> GetAll();
        Deck GetById(string deckId);
        void Save(Deck deck);
        void Delete(string deckId);
    }
}
