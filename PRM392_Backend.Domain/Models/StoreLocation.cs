using System.Text.Json.Serialization;

namespace PRM392_Backend.Domain.Models
{
	public class StoreLocation : ISoftDelete
	{
		public Guid ID { get; set; }

        [JsonIgnore]
        public Store Store { get; set; }
        public Guid StoreID { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public ICollection<Order> Orders { get; set; }
		public bool IsActive { get; set; }
	}
}
