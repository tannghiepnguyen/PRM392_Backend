using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Users.DTO;

namespace PRM392_Backend.API.Controllers
{
	[Route("api/tokens")]
	[ApiController]
	public class TokensController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public TokensController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost]
		[Authorize(Roles = Roles.Customer)]
		public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
		{
			var tokenDtoToReturn = await this.serviceManager.AuthenticationService.RefreshToken(tokenDto);

			return Ok(tokenDtoToReturn);
		}
	}
}
