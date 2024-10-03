namespace PRM392_Backend.Domain.Models
{
	public class Notification : ISoftDelete
	{
		public Guid ID { get; set; }
		public string? UserID { get; set; }
		public User Users { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
