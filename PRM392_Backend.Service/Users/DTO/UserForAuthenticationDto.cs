namespace PRM392_Backend.Service.Users.DTO
{
	public record UserForAuthenticationDto
	{
		public string UserName { get; init; }
		public string Password { get; init; }
	}
}
