using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Data.Entities;

namespace ToysStoreAPI.Data.Repositories
{
    public class ToyRepository: IToyRepository
    {
        private List<ToyEntity> toys = new List<ToyEntity>();

        public ToyRepository()
        {
            toys.Add(new ToyEntity()
            {
                Id = 1,
                Name = "Spiderman",
                EnterpriseID = 1,
                Category = "Super hero",
                Quantity = 5,
                Price = 12.80,
                CreatedDate = new DateTime(1997, 2, 17),
            });

            toys.Add(new ToyEntity()
            {
                Id = 2,
                Name = "Barbie",
                EnterpriseID = 2,
                Category = "Doll",
                Quantity = 10,
                Price = 14.90,
                CreatedDate = new DateTime(1999, 3, 20),
            });

            toys.Add(new ToyEntity()
            {
                Id = 3,
                Name = "Volksvagen Car",
                EnterpriseID = 3,
                Category = "Cars",
                Quantity = 9,
                Price = 200.45,
                CreatedDate = new DateTime(2018, 2, 17),
            });

            toys.Add(new ToyEntity()
            {
                Id = 4,
                Name = "Monster",
                EnterpriseID = 3,
                Category = "Cars",
                Quantity = 2,
                Price = 22.40,
                CreatedDate = new DateTime(2017, 2, 17),
            });

        }

        public ToyEntity CreateToy(ToyEntity newToy)
        {
            var newId = toys.OrderByDescending(r => r.Id).First().Id + 1;
            newToy.Id = newId;
            toys.Add(newToy);
            return newToy;
        }

        public bool DeleteToy(int id)
        {
            var toyDelete = GetToy(id);
            toys.Remove(toyDelete);
            return true;
        }

        public ToyEntity GetToy(int id)
        {
            return toys.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<ToyEntity> GetToys(string orderBy)
        {
            switch (orderBy)
            {
                case "id":
                    return toys.OrderBy(r => r.Id);
                case "name":
                    return toys.OrderBy(r => r.Name);
                case "enterprise":
                    return toys.OrderBy(r => r.EnterpriseID);
                default:
                    return toys;
            }
        }

        public bool UpdateToy(ToyEntity toy)
        {
            var res = GetToy(toy.Id);
            res.Name = toy.Name ?? res.Name;
            res.EnterpriseID = toy.EnterpriseID;
            res.Category = toy.Category ?? res.Category;
            res.Quantity = toy.Quantity;
            res.Price = toy.Price;
            res.CreatedDate = toy.CreatedDate ?? res.CreatedDate;
            return true;
        }
    }
}
