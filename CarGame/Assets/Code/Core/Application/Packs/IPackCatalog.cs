using Core.Domain;
using System.Collections.Generic;

namespace Core.Application
{
    public interface IPackCatalog
    {
        PackDefinition GetById(string packId);
        IReadOnlyList<PackDefinition> GetAll(); 
    }
}
