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
    public class EnterpriseService: IEnterpriseService
    {
        private List<string> allowedSortValues = new List<string>() { "id", "name", "toys" };
        private IEnterpriseRepository repository;
        private IToyRepository toyRepository;
        private IMapper mapper;

        public EnterpriseService(IEnterpriseRepository repository, IToyRepository toyRepository, IMapper mapper)
        {
            this.repository = repository;
            this.toyRepository = toyRepository;
            this.mapper = mapper;
        }

        public EnterpriseModel CreateEnterprise(EnterpriseModel newEnterprise)
        {
            var enterpriseEntity = mapper.Map<EnterpriseEntity>(newEnterprise);
            var newEnterpriseEntity = repository.CreateEnterprise(enterpriseEntity);
            return mapper.Map<EnterpriseModel>(newEnterpriseEntity);
        }

        public bool DeleteEnterprise(int id)
        {
            repository.GetEnterprise(id).Toys.ForEach(toy =>
            {
                toyRepository.DeleteToy(toy.Id);
            });
            repository.DeleteEnterprise(id);
            return true;
        }

        public EnterpriseModel GetEnterprise(int id)
        {
            var EnterpriseEntity = repository.GetEnterprise(id);
            if (EnterpriseEntity == null)
            {
                throw new Exceptions.NotFoundException($"the id :{id} not exist");
            }
            else
            {
                return mapper.Map<EnterpriseModel>(EnterpriseEntity); ;
            }

        }

        public IEnumerable<EnterpriseModel> GetEnterprises(string orderBy)
        {
            if (!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new Exceptions.BadOperationRequest($"bad sort value: { orderBy } allowed values are: { String.Join(",", allowedSortValues)}");
            }
            var enterpriseEntities = repository.GetEnterprises(orderBy);
            return mapper.Map<IEnumerable<EnterpriseModel>>(enterpriseEntities);
        }

        public bool UpdateEnterprise(int id, EnterpriseModel enterprise)
        {
            GetEnterprise(id);
            enterprise.Id = id;

            repository.UpdateEnterprise(mapper.Map<EnterpriseEntity>(enterprise));
            return true;
        }
    }
}
