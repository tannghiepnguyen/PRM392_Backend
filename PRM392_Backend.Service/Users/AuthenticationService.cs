using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Users.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PRM392_Backend.Service.Users
{
	internal sealed class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;
        private readonly IRepositoryManager repositoryManager;
        private User? user;

		public AuthenticationService(UserManager<User> userManager, IMapper mapper, IConfiguration configuration, IRepositoryManager repositoryManager)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.configuration = configuration;
            this.repositoryManager = repositoryManager;
        }
		public async Task<TokenDto> CreateToken(User user, bool populateExp)
		{
            this.user = user; 
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(); 
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

			this.user.RefreshToken = refreshToken;

			if (populateExp)
			{
				this.user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
			}

			await userManager.UpdateAsync(this.user);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return new TokenDto()
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken
			};
		}

		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
		{
			var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            var user = await userManager.FindByNameAsync(principal.FindFirstValue("Username"));
            if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            this.user = user;

            return await CreateToken(user, false);
        }

		private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secret"])),
				ValidateLifetime = true,
				ValidIssuer = jwtSettings["validIssuer"],
				ValidAudience = jwtSettings["validAudience"]
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken securityToken;
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

			var jwtSecurityToken = securityToken as JwtSecurityToken;
			if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new SecurityTokenException("Invalid token");
			}
			return principal;
		}

		private SecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			var tokenOptions = new JwtSecurityToken(
				issuer: jwtSettings.GetSection("validIssuer").Value,
				audience: jwtSettings.GetSection("validAudience").Value,
				claims: claims,
				signingCredentials: signingCredentials,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value))
			);
			return tokenOptions;
		}

		private async Task<List<Claim>> GetClaims()
		{
			var claims = new List<Claim>
			{
				new Claim("Username", user.UserName)
			};
			var roles = await userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}
			claims.Add(new Claim("Fullname", user.FullName));
			claims.Add(new Claim("Id", user.Id));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
			claims.Add(new Claim("Email", user.Email));
			claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
			return claims;
		}

		private SigningCredentials GetSigningCredentials()
		{
			var key = Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings").GetSection("secret").Value);
			var secret = new SymmetricSecurityKey(key);
			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

        public async Task<(TokenDto tokenDto, IdentityResult result)> RegisterUser(UserForRegistrationDto userForRegistration)
		{
			var user = mapper.Map<User>(userForRegistration);
			user.IsActive = true;

			var result = await userManager.CreateAsync(user, userForRegistration.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Customer);

                var welcomeNotification = new Notification
                {
                    ID = Guid.NewGuid(),
                    UserID = user.Id,
                    Message = "Welcome to the Deliveroo App! We hope you have an exciting first experience. If you have any questions, please feel free to share your feedback with us!",
                    IsActive = true,
					IsRead = false,
                    CreatedAt = DateTime.Now
                };

                repositoryManager.NotificationRepository.CreateNotification(welcomeNotification);
                await repositoryManager.Save();

                var tokenDto = await CreateToken(user, true); 
                return (tokenDto, result);
            }

            return (null, result);
        }

		public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
		{
			user = await userManager.FindByNameAsync(userForAuthentication.UserName);

			return (user != null && await userManager.CheckPasswordAsync(user, userForAuthentication.Password) && user.IsActive);
		}

		public async Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdateDto)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			mapper.Map(userForUpdateDto, user);

			return await userManager.UpdateAsync(user);
		}

		public async Task<UserForReturnDto> GetUserById(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user is null) throw new UserNotFoundException(userId);

			return mapper.Map<UserForReturnDto>(user);
		}

        public async Task<User> FindUserByUsername(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<IEnumerable<UserForReturnDto>> GetUsers()
		{
			var users = await userManager.Users.ToListAsync();
			return mapper.Map<IEnumerable<UserForReturnDto>>(users);
		}

		public async Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			return await userManager.ChangePasswordAsync(user, userForUpdatePasswordDto.OldPassword, userForUpdatePasswordDto.NewPassword);
		}
	}
}
