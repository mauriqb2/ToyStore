using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysStoreAPI.Data.Entities
{
    public class ToyEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int EnterpriseID { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
