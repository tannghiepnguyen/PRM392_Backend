using AutoMapper;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Service.Products.DTO
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductForCreationDto, Product>().ForMember(x => x.ImageURL, opt => opt.Ignore());
			CreateMap<ProductForUpdateDto, Product>().ForMember(x => x.ImageURL, opt => opt.Ignore());
			CreateMap<Product, ProductForReturnDto>();
		}
	}
}
