﻿using Microsoft.AspNetCore.Mvc;
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
		public IActionResult Register([FromBody] UserForRegistrationDto userForRegistrationDTO)
		{
			var result = serviceManager.AuthenticationService.RegisterUser(userForRegistrationDTO);

			if (!result.Result.Succeeded)
			{
				foreach (var error in result.Result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return StatusCode(201);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDTO)
		{
			if (!await serviceManager.AuthenticationService.ValidateUser(userForAuthenticationDTO))
			{
				return Unauthorized();
			}

			var tokenDto = await serviceManager.AuthenticationService.CreateToken(true);

			return Ok(tokenDto);
		}
	}
}
