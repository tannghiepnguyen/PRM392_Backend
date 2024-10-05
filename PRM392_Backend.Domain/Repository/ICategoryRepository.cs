using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Domain.Repository;

public interface ICategoryRepository
{
	void CreateCategory(Category category);
	Task<IEnumerable<Category>> GetCategories(bool trackChange);
	Task<IEnumerable<Category>> GetActiveCategories(bool trackChange);
	Task<Category?> GetCategoryById(Guid id, bool trackChange);

}
