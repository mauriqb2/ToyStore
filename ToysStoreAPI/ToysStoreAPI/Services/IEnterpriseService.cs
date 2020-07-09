using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Models;

namespace ToysStoreAPI.Services
{
    public interface IEnterpriseService
    {
        EnterpriseModel GetEnterprise(int id);
        IEnumerable<EnterpriseModel> GetEnterprises(string orderBy = "id");
        EnterpriseModel CreateEnterprise(EnterpriseModel newEnterprise);
        bool UpdateEnterprise(int id, EnterpriseModel enterprise);
        bool DeleteEnterprise(int id);
    }
}
