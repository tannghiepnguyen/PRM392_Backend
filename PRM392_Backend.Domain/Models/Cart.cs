namespace PRM392_Backend.Domain.Models
{
	public class Cart : ISoftDelete
	{
		public Guid ID { get; set; }
		public string? UserID { get; set; }
		public User User { get; set; }
		public double TotalPrice { get; set; }
		public string Status { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
		public ICollection<CartItem> CartItems { get; set; }
		public Order Order { get; set; }
	}
}
