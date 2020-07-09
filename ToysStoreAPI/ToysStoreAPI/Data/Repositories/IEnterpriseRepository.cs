using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Data.Entities;

namespace ToysStoreAPI.Data.Repositories
{
    public interface IEnterpriseRepository
    {
        EnterpriseEntity GetEnterprise(int id);
        IEnumerable<EnterpriseEntity> GetEnterprises(string orderBy);
        EnterpriseEntity CreateEnterprise(EnterpriseEntity newEnterprise);
        bool UpdateEnterprise(EnterpriseEntity enterprise);
        bool DeleteEnterprise(int id);
    }
}
