using PRM392_Backend.Service.Categories.DTO;

namespace PRM392_Backend.Service.Categories
{
	public interface ICategoryService
	{
		Task<CategoryForReturnDto> CreateCategory(CategoryForCreationDto categoryForCreationDto);
		Task UpdateCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto, bool trackChange);
		Task<IEnumerable<CategoryForReturnDto>> GetAllCategories(bool trackChange);
		Task<IEnumerable<CategoryForReturnDto>> GetActiveCategories(bool trackChange);
		Task<CategoryForReturnDto?> GetCategory(Guid id, bool trackChange);
	}
}
