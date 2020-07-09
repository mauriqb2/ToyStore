using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Data.Entities;

namespace ToysStoreAPI.Data.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private List<EnterpriseEntity> enterprises = new List<EnterpriseEntity>();
        private List<ToyEntity> toys = new List<ToyEntity>();

        public EnterpriseRepository()
        {
            enterprises.Add(new EnterpriseEntity()
            {
                Id = 1,
                Name = "Mattel",
                Country = "China",
                Description = "Mattel is a leading global toy company and owner of one of the strongest catalogs of children's and family entertainment franchises in the world. We create innovative products and experiences that inspire, entertain and develop children through play.",
                Toys = new List<ToyEntity>()
            }); 
            enterprises.Add(new EnterpriseEntity()
            {
                Id = 2,
                Name = "Barbie",
                Country = "United States",
                Description = "Barbie, in full Barbara Millicent Roberts, an 11-inch- (29-cm-) tall plastic doll with the figure of an adult woman that was introduced on March 9, 1959, by Mattel, Inc., a southern California toy company. Ruth Handler, who cofounded Mattel with her husband, Elliot, spearheaded the introduction of the doll.",
                Toys = new List<ToyEntity>()
            });
            enterprises.Add(new EnterpriseEntity()
            {
                Id = 3,
                Name = "Hot Wheels",
                Country = "China",
                Description = "Hot Wheels is a brand of die-cast toy cars introduced by American toy maker Mattel in 1968. It was the primary competitor of Matchbox until 1997, when Mattel bought Tyco Toys, then-owner of Matchbox.",
                Toys = new List<ToyEntity>()
            });
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
            toys.ForEach(toy =>
            {
                enterprises.ForEach(x =>
                {
                    if (x.Id == toy.EnterpriseID)
                    {
                        x.Toys.Add(toy);
                    }
                });
            });
        }

        public EnterpriseEntity CreateEnterprise(EnterpriseEntity newEnterprise)
        {
            var newId = enterprises.OrderByDescending(r => r.Id).First().Id + 1;
            newEnterprise.Id = newId;
            enterprises.Add(newEnterprise);
            return newEnterprise;
        }

        public bool DeleteEnterprise(int id)
        {
            var enterpriseDelete = GetEnterprise(id);
            enterprises.Remove(enterpriseDelete);
            return true;
        }

        public EnterpriseEntity GetEnterprise(int id)
        {
            return enterprises.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<EnterpriseEntity> GetEnterprises(string orderBy)
        {
            switch (orderBy)
            {
                case "id":
                    return enterprises.OrderBy(r => r.Id);
                case "name":
                    return enterprises.OrderBy(r => r.Name);
                case "country":
                    return enterprises.OrderBy(r => r.Country);
                default:
                    return enterprises;
            }
        }

        public bool UpdateEnterprise(EnterpriseEntity enterprise)
        {
            var res = GetEnterprise(enterprise.Id);
            res.Name = enterprise.Name ?? res.Name;
            res.Country = enterprise.Country ?? res.Country;
            res.Description = enterprise.Description ?? res.Description;
            res.Toys = enterprise.Toys ?? res.Toys;
            return true;
        }
    }
}
