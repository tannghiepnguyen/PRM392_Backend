namespace PRM392_Backend.Domain.Exceptions
{
	public class ProductNotFoundException : NotFoundException
	{
		public ProductNotFoundException(Guid productId) : base($"The product with id: {productId} doesn't exist in the database")
		{
		}
	}
}
