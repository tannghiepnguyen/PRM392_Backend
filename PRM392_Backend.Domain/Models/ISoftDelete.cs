namespace PRM392_Backend.Domain.Models
{
	public interface ISoftDelete
	{
		public bool IsActive { get; set; }
	}
}
