using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.PagedList;
using PRM392_Backend.Domain.Parameters;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;

namespace PRM392_Backend.Infrastructure.Repository
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(DatabaseContext context) : base(context)
		{
		}

		public void CreateProduct(Product product) => Create(product);

		public async Task<PagedList<Product>> GetActiveProducts(ProductParameters productParameters, bool trackChange)
		{
			var products = productParameters.CategoryId == Guid.Empty ? FindByCondition(p => p.IsActive, trackChange).OrderBy(c => c.ProductName) : FindByCondition(p => p.IsActive && p.CategoryId == productParameters.CategoryId, trackChange).OrderBy(c => c.ProductName);

			return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
		}

		public async Task<Product?> GetProductById(Guid id, bool trackChange) => await FindByCondition(p => p.ID == id, trackChange).FirstOrDefaultAsync();

		public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters, bool trackChange)
		{
			var products = productParameters.CategoryId == Guid.Empty ? FindAll(trackChange).OrderBy(c => c.ProductName) : FindAll(trackChange).Where(p => p.CategoryId == productParameters.CategoryId).OrderBy(c => c.ProductName);

			return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
		}
	}
}
