using PRM392_Backend.Service.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Stores.DTO
{
    public class GetProductByStoreIdResponse
    {
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public int Rating { get; set; }
        public List<ProductResponse> Products { get; set; }
    }

    public class ProductResponse
    {
        public Guid ID { get; init; }
        public string ProductName { get; init; }
        public string BriefDescription { get; init; }
        public string FullDescription { get; init; }
        public string TechnicalSpecification { get; init; }
        public string ImageURL { get; init; }
        public double Price { get; init; }
        public CategoryForReturnDto Category { get; set; }
        public bool IsActive { get; init; }
    } 
}
