namespace PRM392_Backend.Service.Categories.DTO
{
	public record CategoryForReturnDto
	{
		public Guid ID { get; set; }
		public string CategoryName { get; set; }
		public bool IsActive { get; set; }
	}
}
