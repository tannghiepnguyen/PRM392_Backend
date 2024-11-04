namespace PRM392_Backend.Domain.Models
{
	public class Product : ISoftDelete
	{
		public Guid ID { get; set; }
		public string ProductName { get; set; }
		public string BriefDescription { get; set; }
		public string FullDescription { get; set; }
		public string TechnicalSpecification { get; set; }
		public string ImageURL { get; set; }
		public double Price { get; set; }
		public Guid? CategoryId { get; set; }
		public Category Category { get; set; }
		public Guid? StoreId { get; set; }
		public Store Store { get; set; }	
		public ICollection<CartItem> CartItem { get; set; }
		public bool IsActive { get; set; }
	}
}
