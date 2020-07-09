using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysStoreAPI.Data.Entities
{
    public class EnterpriseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public List<ToyEntity> Toys { get; set; }
    }
}
