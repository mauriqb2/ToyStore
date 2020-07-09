using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Data.Entities;
using ToysStoreAPI.Models;

namespace ToysStoreAPI.Data
{
    public class ToyProfile: Profile
    {
        public ToyProfile()
        {
            this.CreateMap<ToyEntity, ToyModel>()
                .ReverseMap();
            this.CreateMap<EnterpriseEntity, EnterpriseModel>()
                .ReverseMap();
        }
    }
}
