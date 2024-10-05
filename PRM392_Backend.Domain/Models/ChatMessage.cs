namespace PRM392_Backend.Domain.Models
{
	public class ChatMessage : ISoftDelete
	{
		public Guid ID { get; set; }
		public string? UserID { get; set; }
		public User User { get; set; }
		public string Message { get; set; }
		public DateTime SentdAt { get; set; }
		public bool IsActive { get; set; }
	}
}
