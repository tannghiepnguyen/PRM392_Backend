using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.PagedList;
using PRM392_Backend.Domain.Parameters;

namespace PRM392_Backend.Domain.Repository
{
	public interface IProductRepository
	{
		void CreateProduct(Product product);
		Task<IEnumerable<Product>> GetAllProducts(bool trackChange);

        Task<PagedList<Product>> GetProducts(ProductParameters productParameters, bool trackChange);
		Task<PagedList<Product>> GetActiveProducts(ProductParameters productParameters, bool trackChange);
		Task<Product?> GetProductById(Guid id, bool trackChange);
	}
}
