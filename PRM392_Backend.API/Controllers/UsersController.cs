using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Users.DTO;

namespace PRM392_Backend.API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public UsersController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var users = await serviceManager.AuthenticationService.GetUsers();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserById(string id)
		{
			var user = await serviceManager.AuthenticationService.GetUserById(id);
			return Ok(user);
		}

		[HttpPut("{userId}")]
		public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] UserForUpdateDto userForRegistrationDTO)
		{
			var result = await serviceManager.AuthenticationService.UpdateUser(userId, userForRegistrationDTO);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return NoContent();
		}

		[HttpPut("{userId}/password")]
		public async Task<IActionResult> UpdateUserPassword([FromRoute] string userId, [FromBody] UserForUpdatePasswordDto userForUpdatePasswordDto)
		{
			var result = await serviceManager.AuthenticationService.UpdateUserPassword(userId, userForUpdatePasswordDto);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return NoContent();
		}

	}
}
