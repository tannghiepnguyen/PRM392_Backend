using AutoMapper;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Service.StoreLocations.DTO
{
	public class StoreLocationProfile : Profile
	{
		public StoreLocationProfile()
		{
			CreateMap<StoreLocationForCreationDto, StoreLocation>();
			CreateMap<StoreLocationForUpdateDto, StoreLocation>();
			CreateMap<StoreLocation, StoreLocationForReturnDto>();
		}
	}
}
