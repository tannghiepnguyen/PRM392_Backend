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
			var products = FindByCondition(p => p.IsActive, trackChange);
			if (productParameters.CategoryId != Guid.Empty)
			{
				products = products.Where(p => p.CategoryId == productParameters.CategoryId);
			}
			if (!string.IsNullOrEmpty(productParameters.SearchTerm))
			{
				var lowerCaseTerm = productParameters.SearchTerm.Trim().ToLower();
				products = products.Where(p => p.ProductName.ToLower().Contains(lowerCaseTerm));
			}
			products = products.OrderBy(c => c.ProductName);

			return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
		}

        public async Task<Product?> GetProductById(Guid id, bool trackChange) => await FindByCondition(p => p.ID == id, trackChange).FirstOrDefaultAsync();

		public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters, bool trackChange)
		{
			var products = FindAll(trackChange)
				.Include(x => x.Category)
				.Include(x => x.Store) as IQueryable<Product>;

			if (productParameters.CategoryId != Guid.Empty)
			{
				products = products.Where(p => p.CategoryId == productParameters.CategoryId);
			}

            if (productParameters.StoreId != Guid.Empty)
            {
                products = products.Where(p => p.StoreId == productParameters.StoreId);
            }

            if (!string.IsNullOrEmpty(productParameters.SearchTerm))
			{
				var lowerCaseTerm = productParameters.SearchTerm.Trim().ToLower();
				products = products.Where(p => p.ProductName.ToLower().Contains(lowerCaseTerm));
			}
			products = products.OrderBy(c => c.ProductName);

			return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
		}
	}
}
