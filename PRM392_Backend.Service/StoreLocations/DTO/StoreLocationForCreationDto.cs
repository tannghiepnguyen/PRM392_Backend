namespace PRM392_Backend.Service.StoreLocations.DTO
{
	public record StoreLocationForCreationDto
	{
		public string Address { get; init; }
		public double Latitude { get; init; }
		public double Longitude { get; init; }
	}
}
