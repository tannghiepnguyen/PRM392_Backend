using Microsoft.AspNetCore.Identity;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Users.DTO;

namespace PRM392_Backend.Service.Users
{
	public interface IAuthenticationService
	{
        Task<(TokenDto tokenDto, IdentityResult result)> RegisterUser(UserForRegistrationDto userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
		Task<TokenDto> CreateToken(User user, bool populateExp);
		Task<TokenDto> RefreshToken(TokenDto tokenDto);
		Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdateDto);
		Task<UserForReturnDto> GetUserById(string userId);
		Task<User> FindUserByUsername(string username);
        Task<IEnumerable<UserForReturnDto>> GetUsers();
		Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto);
	}
}
