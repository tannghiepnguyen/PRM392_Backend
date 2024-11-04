using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Models
{
    public class Store : ISoftDelete
    {
        public Guid ID { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
