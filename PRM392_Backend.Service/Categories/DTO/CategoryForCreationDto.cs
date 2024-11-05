namespace PRM392_Backend.Service.Categories.DTO
{
	public record CategoryForCreationDto
	{
		public string CategoryName { get; init; }
        public string ImageUrl { get; set; }
    }
}
