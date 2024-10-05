using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Domain.Repository
{
	public interface IProductRepository
	{
		void CreateProduct(Product product);
		Task<IEnumerable<Product>> GetProducts(bool trackChange);
		Task<IEnumerable<Product>> GetActiveProducts(bool trackChange);
		Task<Product?> GetProductById(Guid id, bool trackChange);
		Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId, bool trackChange);
	}
}
