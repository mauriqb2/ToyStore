using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Data.Entities;
using ToysStoreAPI.Data.Repositories;
using ToysStoreAPI.Models;

namespace ToysStoreAPI.Services
{
    public class ToyService: IToyService
    {
        private List<string> allowedSortValues = new List<string>() { "id", "name", "enterprise", "quantity" };
        private IToyRepository repository;
        private IEnterpriseRepository enterpriseRepository;
        private IMapper mapper;

        public ToyService(IToyRepository repository, IEnterpriseRepository enterpriseRepository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.enterpriseRepository = enterpriseRepository;
        }

        public ToyModel CreateToy(ToyModel newToy)
        {
            var toyEntity = mapper.Map<ToyEntity>(newToy);
            var newToyEntity = repository.CreateToy(toyEntity); 
            var enterprise = enterpriseRepository.GetEnterprises("id").ToList().Find(x => x.Id == newToy.EnterpriseID);
            enterprise.Toys.Add(newToyEntity);
            enterpriseRepository.UpdateEnterprise(enterprise);
            return mapper.Map<ToyModel>(newToyEntity);
        }

        public bool DeleteToy(int id)
        {
            var actualToy = repository.GetToy(id);
            var enterprise = enterpriseRepository.GetEnterprises("id").ToList().Find(x => x.Id == actualToy.EnterpriseID);
            var toyToRemove = enterprise.Toys.Find(x => x.Id == actualToy.Id);
            enterprise.Toys.Remove(toyToRemove);
            enterpriseRepository.UpdateEnterprise(enterprise);
            repository.DeleteToy(id);
            return true;
        }

        public ToyModel GetToy(int id)
        {
            var toyEntity = repository.GetToy(id);
            if (toyEntity == null)
            {
                throw new Exceptions.NotFoundException($"the id :{id} not exist");
            }
            else
            {
                return mapper.Map<ToyModel>(toyEntity); ;
            }

        }

        public IEnumerable<ToyModel> GetToys(string orderBy)
        {
            if (!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new Exceptions.BadOperationRequest($"bad sort value: { orderBy } allowed values are: { String.Join(",", allowedSortValues)}");
            }
            var toyEntities = repository.GetToys(orderBy);
            return mapper.Map<IEnumerable<ToyModel>>(toyEntities);
        }

        public bool UpdateToy(int id, ToyModel toy)
        {
            var actualToy = repository.GetToy(id);
            var enterprise =enterpriseRepository.GetEnterprises("id").ToList().Find(x => x.Id == actualToy.EnterpriseID);
            var toyToRemove = enterprise.Toys.Find(x => x.Id == actualToy.Id);
            enterprise.Toys.Remove(toyToRemove);
            enterpriseRepository.UpdateEnterprise(enterprise);

            toy.Id = id;
            repository.UpdateToy(mapper.Map<ToyEntity>(toy));

            actualToy = repository.GetToy(id);
            enterprise = enterpriseRepository.GetEnterprises("id").ToList().Find(x => x.Id == actualToy.EnterpriseID);
            enterprise.Toys.Add(actualToy);
            enterpriseRepository.UpdateEnterprise(enterprise);

            return true;
        }
    }
}
