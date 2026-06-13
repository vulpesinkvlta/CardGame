using Core.Domain;
using System.Collections.Generic;

namespace Core.Application
{
    public interface ICardCatalog
    {
        CardDefinition GetById(string cardId);
        IReadOnlyList<CardDefinition> GetAll();
    }
}
