using AutoMapper;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Service.Users.DTO
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserForRegistrationDto, User>();
			CreateMap<UserForUpdateDto, User>();
			CreateMap<User, UserForReturnDto>();
		}
	}
}
