using System.Text.Json.Serialization;

namespace PRM392_Backend.Domain.Models
{
	public class Cart : ISoftDelete
	{
		public Guid ID { get; set; }
		public string? UserID { get; set; }
		public User User { get; set; }
		public double TotalPrice { get; set; }
		public string Status { get; set; }

        [JsonIgnore]
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        [JsonIgnore]
        public Order Order { get; set; }
		public bool IsActive { get; set; }
	}

	public enum CartStatus
	{
		Unpaid,
		Paid,
		Completed,
	}
}
