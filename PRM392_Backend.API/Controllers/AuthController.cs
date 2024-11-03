using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Users.DTO;

namespace PRM392_Backend.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public AuthController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistrationDTO)
		{
            var (tokenDto, result) = await serviceManager.AuthenticationService.RegisterUser(userForRegistrationDTO);

            if (!result.Succeeded)
            {
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

            return StatusCode(201, tokenDto);
        }

		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDTO)
		{
			if (!await serviceManager.AuthenticationService.ValidateUser(userForAuthenticationDTO))
			{
				return Unauthorized();
			}

            var user = await serviceManager.AuthenticationService.FindUserByUsername(userForAuthenticationDTO.UserName);

            var tokenDto = await serviceManager.AuthenticationService.CreateToken(user, true);

			return Ok(tokenDto);
		}
	}
}
