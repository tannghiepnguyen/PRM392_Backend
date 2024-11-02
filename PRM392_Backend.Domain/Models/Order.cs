using System.Text.Json.Serialization;

namespace PRM392_Backend.Domain.Models
{
	public class Order
	{
		public Guid ID { get; set; }
		public Payment Payment { get; set; }
		public string BillingAddress { get; set; }
		public Guid? CartID { get; set; }
        [JsonIgnore]
        public Cart Cart { get; set; }
		public string? UserID { get; set; }
		public User User { get; set; }
		public Guid? StoreLocationID { get; set; }
		public StoreLocation StoreLocation { get; set; }
		public DateTime OrderDate { get; set; }

		//[JsonConverter(typeof(JsonStringEnumConverter))]
		//public PaymentMethod PaymentMethod { get; set; }
		public string PaymentMethod { get; set; }

		//[JsonConverter(typeof(JsonStringEnumConverter))]
		//public OrderStatus OrderStatus { get; set; }
		public string OrderStatus { get; set; }
	}
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum PaymentMethod
	{
		VNPay,
		ZaloPay,
		PayPal,
		Momo
	}
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum OrderStatus
	{
		Pending,
		Processing,
		Shipped,
		Delivered,
		Cancel
	}
}
