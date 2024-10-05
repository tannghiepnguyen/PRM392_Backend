using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;

namespace PRM392_Backend.Infrastructure.Repository
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(DatabaseContext context) : base(context)
		{
		}

		public void CreateCategory(Category category) => Create(category);

		public async Task<IEnumerable<Category>> GetActiveCategories(bool trackChange) => await FindByCondition(x => x.IsActive, trackChange).ToListAsync();

		public async Task<IEnumerable<Category>> GetCategories(bool trackChange) => await FindAll(trackChange).ToListAsync();

		public async Task<Category?> GetCategoryById(Guid id, bool trackChange) => await FindByCondition(x => x.ID == id, trackChange).SingleOrDefaultAsync();
	}
}
