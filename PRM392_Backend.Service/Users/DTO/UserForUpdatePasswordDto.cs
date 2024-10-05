namespace PRM392_Backend.Service.Users.DTO
{
	public record UserForUpdatePasswordDto
	{
		public string OldPassword { get; init; }
		public string NewPassword { get; init; }
	}
}
