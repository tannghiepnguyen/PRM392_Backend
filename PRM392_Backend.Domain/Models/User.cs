using Microsoft.AspNetCore.Identity;

namespace PRM392_Backend.Domain.Models
{
	public class User : IdentityUser
	{
		public string FullName { get; set; }
		public string Address { get; set; }
		public bool IsActived { get; set; }
		public ICollection<Cart> Carts { get; set; }
		public ICollection<Order> Orders { get; set; }
		public ICollection<Notification> Notifications { get; set; }
		public ICollection<ChatMessage> ChatMessages { get; set; }
	}
}
