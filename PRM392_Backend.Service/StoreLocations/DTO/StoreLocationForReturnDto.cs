namespace PRM392_Backend.Service.StoreLocations.DTO
{
	public class StoreLocationForReturnDto
	{
		public Guid ID { get; set; }
		public string Address { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public bool IsActive { get; set; }
	}
}
