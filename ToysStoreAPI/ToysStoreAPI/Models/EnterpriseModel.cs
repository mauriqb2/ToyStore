using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToysStoreAPI.Data.Entities;

namespace ToysStoreAPI.Models
{
    public class EnterpriseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public List<ToyEntity> Toys { get; set; }
    }
}
