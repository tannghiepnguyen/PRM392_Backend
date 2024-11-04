using PRM392_Backend.Service.Categories.DTO;
using PRM392_Backend.Service.Stores.DTO;

namespace PRM392_Backend.Service.Products.DTO
{
	public record ProductForReturnDto
	{
		public Guid ID { get; init; }
		public string ProductName { get; init; }
		public string BriefDescription { get; init; }
		public string FullDescription { get; init; }
		public string TechnicalSpecification { get; init; }
		public string ImageURL { get; init; }
		public double Price { get; init; }
        public CategoryForReturnDto Category { get; set; }	
		public StoreResponse Store { get; set; }
        public bool IsActive { get; init; }
	}
}
