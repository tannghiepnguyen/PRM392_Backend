namespace PRM392_Backend.Domain.Models
{
	public class Order
	{
		public Guid ID { get; set; }
		public Payment Payment { get; set; }
		public Guid? CartID { get; set; }
		public Cart Cart { get; set; }
		public string? UserID { get; set; }
		public User User { get; set; }
		public Guid? StoreLocationID { get; set; }
		public StoreLocation StoreLocation { get; set; }
		public DateTime OrderDate { get; set; }
		public string PaymentMethod { get; set; }
		public string OrderStatus { get; set; }

	}
}
