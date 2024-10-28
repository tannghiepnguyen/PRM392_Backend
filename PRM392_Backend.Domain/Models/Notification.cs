using System;

namespace PRM392_Backend.Domain.Models
{
	public class Notification
	{
		public Guid NotificationID { get; set; }
		public string UserID { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }
		public DateTime CreatedAt { get; set; }
		public User User { get; set; }
	}
}
