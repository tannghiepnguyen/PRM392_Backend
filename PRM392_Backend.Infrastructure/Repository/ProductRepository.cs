using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
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

		public async Task<IEnumerable<Product>> GetActiveProducts(bool trackChange) => await FindByCondition(p => p.IsActive, trackChange).ToListAsync();

		public async Task<Product?> GetProductById(Guid id, bool trackChange) => await FindByCondition(p => p.ID == id, trackChange).FirstOrDefaultAsync();

		public async Task<IEnumerable<Product>> GetProducts(bool trackChange) => await FindAll(trackChange).ToListAsync();

		public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId, bool trackChange) => await FindByCondition(p => p.CategoryId == categoryId, trackChange).ToListAsync();
	}
}
