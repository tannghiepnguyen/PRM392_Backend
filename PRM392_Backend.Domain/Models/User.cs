using Microsoft.AspNetCore.Identity;

namespace PRM392_Backend.Domain.Models
{
	public class User : IdentityUser, ISoftDelete
	{
		public string FullName { get; set; }
		public string Address { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
		public ICollection<Cart> Carts { get; set; }
		public ICollection<Order> Orders { get; set; }
		public ICollection<Notification> Notifications { get; set; }
		public ICollection<ChatMessage> ChatMessages { get; set; }
		public bool IsActive { get; set; }
	}
}
