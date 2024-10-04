namespace PRM392_Backend.Service.Users.DTO
{
	public record UserForRegistrationDto
	{
		public string FullName { get; init; }
		public string UserName { get; init; }
		public string Email { get; init; }
		public string Password { get; init; }
		public string PhoneNumber { get; init; }
		public string Address { get; init; }
	}
}
