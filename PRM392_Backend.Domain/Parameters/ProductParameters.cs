namespace PRM392_Backend.Domain.Parameters
{
	public class ProductParameters : RequestParameters
	{
		public Guid CategoryId { get; set; }
		public Guid StoreId { get; set; }
		public string? SearchTerm { get; set; }
	}
}
