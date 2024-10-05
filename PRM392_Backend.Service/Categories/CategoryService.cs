using AutoMapper;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Categories.DTO;

namespace PRM392_Backend.Service.Categories
{
	internal sealed class CategoryService : ICategoryService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}
		public async Task<CategoryForReturnDto> CreateCategory(CategoryForCreationDto categoryForCreationDto)
		{
			var category = mapper.Map<Category>(categoryForCreationDto);
			category.ID = Guid.NewGuid();
			category.IsActive = true;

			repositoryManager.CategoryRepository.CreateCategory(category);
			await repositoryManager.Save();

			return mapper.Map<CategoryForReturnDto>(category);
		}

		public async Task<IEnumerable<CategoryForReturnDto>> GetActiveCategories(bool trackChange)
		{
			var activeCategories = await repositoryManager.CategoryRepository.GetActiveCategories(trackChange);
			return mapper.Map<IEnumerable<CategoryForReturnDto>>(activeCategories);
		}

		public async Task<IEnumerable<CategoryForReturnDto>> GetAllCategories(bool trackChange)
		{
			var categories = await repositoryManager.CategoryRepository.GetCategories(trackChange);
			return mapper.Map<IEnumerable<CategoryForReturnDto>>(categories);
		}

		public async Task<CategoryForReturnDto?> GetCategory(Guid id, bool trackChange)
		{
			var category = await repositoryManager.CategoryRepository.GetCategoryById(id, trackChange);
			if (category == null) throw new CategoryNotFoundException(id);
			return mapper.Map<CategoryForReturnDto>(category);
		}

		public async Task UpdateCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto, bool trackChange)
		{
			var category = await repositoryManager.CategoryRepository.GetCategoryById(id, trackChange);
			if (category == null) throw new CategoryNotFoundException(id);

			mapper.Map(categoryForUpdateDto, category);
			await repositoryManager.Save();
		}
	}
}
