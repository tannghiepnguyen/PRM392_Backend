using Microsoft.AspNetCore.Identity;
using PRM392_Backend.Service.Users.DTO;

namespace PRM392_Backend.Service.Users
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
		Task<string> CreateToken();
	}
}
