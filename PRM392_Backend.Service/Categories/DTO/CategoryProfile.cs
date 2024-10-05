using AutoMapper;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Service.Categories.DTO
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<CategoryForCreationDto, Category>();
			CreateMap<CategoryForUpdateDto, Category>();
			CreateMap<Category, CategoryForReturnDto>();
		}
	}
}
