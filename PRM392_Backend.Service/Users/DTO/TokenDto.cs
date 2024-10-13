namespace PRM392_Backend.Service.Users.DTO
{
	public record TokenDto
	{
		public string AccessToken { get; init; }
		public string RefreshToken { get; init; }
	}
}
