using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Models;

namespace ToysStoreAPI.Services
{
    public interface IToyService
    {
        ToyModel GetToy(int id);
        IEnumerable<ToyModel> GetToys(string orderBy = "id");
        ToyModel CreateToy(ToyModel newToy);
        bool UpdateToy(int id, ToyModel toy);
        bool DeleteToy(int id);
    }
}
