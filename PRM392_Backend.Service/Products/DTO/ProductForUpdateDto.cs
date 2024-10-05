using Microsoft.AspNetCore.Http;

namespace PRM392_Backend.Service.Products.DTO
{
	public record ProductForUpdateDto
	{
		public string ProductName { get; init; }
		public string BriefDescription { get; init; }
		public string FullDescription { get; init; }
		public string TechnicalSpecification { get; init; }
		public IFormFile File { get; init; }
		public double Price { get; init; }
		public Guid CategoryId { get; init; }
		public bool IsActive { get; init; }
	}
}
