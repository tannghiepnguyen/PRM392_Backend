using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Stores.DTO
{
    public class StoreResponse
    {
        public Guid ID { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
    }
}
