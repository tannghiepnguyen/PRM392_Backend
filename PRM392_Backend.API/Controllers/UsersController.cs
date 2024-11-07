using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Constant;
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
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> GetUsers()
		{
			var users = await serviceManager.AuthenticationService.GetUsers();
			return Ok(users);
		}

        [HttpGet]
        [Route("current")]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var users = await serviceManager.AuthenticationService.GetCurrentUser();
            return Ok(users);
        }

        [HttpGet("{id}")]
		[Authorize(Roles = Roles.Customer)]
		public async Task<IActionResult> GetUserById(string id)
		{
			var user = await serviceManager.AuthenticationService.GetUserById(id);
			return Ok(user);
		}

		[HttpPut("{userId}")]
		[Authorize(Roles = Roles.Customer)]
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
		[Authorize(Roles = Roles.Customer)]
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
