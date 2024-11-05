namespace PRM392_Backend.Service.Categories.DTO
{
	public record CategoryForUpdateDto
	{
		public string CategoryName { get; init; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; init; }
	}
}
