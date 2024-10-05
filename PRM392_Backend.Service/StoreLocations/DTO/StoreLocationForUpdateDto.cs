namespace PRM392_Backend.Service.StoreLocations.DTO
{
	public record StoreLocationForUpdateDto
	{
		public string Address { get; init; }
		public double Latitude { get; init; }
		public double Longitude { get; init; }
		public bool IsActive { get; init; }
	}
}
