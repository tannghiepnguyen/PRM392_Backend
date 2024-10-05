using Microsoft.AspNetCore.Identity;
using PRM392_Backend.Service.Users.DTO;

namespace PRM392_Backend.Service.Users
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
		Task<string> CreateToken();
		Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdateDto);
		Task<UserForReturnDto> GetUserById(string userId);
		Task<IEnumerable<UserForReturnDto>> GetUsers();
		Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto);
	}
}
