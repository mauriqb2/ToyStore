using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Data.Entities;

namespace ToysStoreAPI.Data.Repositories
{
    public interface IToyRepository
    {
        ToyEntity GetToy(int id);
        IEnumerable<ToyEntity> GetToys(string orderBy);
        ToyEntity CreateToy(ToyEntity newToy);
        bool UpdateToy(ToyEntity toy);
        bool DeleteToy(int id);
    }
}
