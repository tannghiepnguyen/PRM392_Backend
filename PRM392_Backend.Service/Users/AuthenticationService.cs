using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Users.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PRM392_Backend.Service.Users
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;
		private User? user;

		public AuthenticationService(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.configuration = configuration;
		}
		public async Task<string> CreateToken()
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims();
			var token = GenerateTokenOptions(signingCredentials, claims);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private SecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			var tokenOptions = new JwtSecurityToken(
				issuer: jwtSettings.GetSection("validIssuer").Value,
				audience: jwtSettings.GetSection("validAudience").Value,
				claims: claims,
				signingCredentials: signingCredentials
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
				claims.Add(new Claim("Roles", role));
			}
			claims.Add(new Claim("Fullname", user.FullName));
			claims.Add(new Claim("Id", user.Id));
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

		public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
		{
			var user = mapper.Map<User>(userForRegistration);
			user.IsActived = true;

			var result = await userManager.CreateAsync(user, userForRegistration.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, Roles.Customer);
			}

			return result;
		}

		public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
		{
			user = await userManager.FindByNameAsync(userForAuthentication.UserName);

			var result = (user != null && await userManager.CheckPasswordAsync(user, userForAuthentication.Password));

			return result;
		}
	}
}
