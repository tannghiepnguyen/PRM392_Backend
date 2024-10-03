namespace PRM392_Backend.Domain.Models
{
	public class Category : ISoftDelete
	{
		public Guid ID { get; set; }
		public string CategoryName { get; set; }
		public ICollection<Product> Products { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
