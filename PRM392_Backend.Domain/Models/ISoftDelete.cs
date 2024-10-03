namespace PRM392_Backend.Domain.Models
{
	public interface ISoftDelete
	{
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }

	}
}
