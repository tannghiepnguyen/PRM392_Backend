using System.Text.Json.Serialization;

namespace PRM392_Backend.Domain.Models
{
	public class CartItem
	{
		public Guid ID { get; set; } 
		public Guid? CartID { get; set; }
		[JsonIgnore]
		public Cart Cart { get; set; }
		public Guid? ProductID { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
	}
}
