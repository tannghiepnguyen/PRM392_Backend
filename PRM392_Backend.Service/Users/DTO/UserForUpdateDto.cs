namespace PRM392_Backend.Service.Users.DTO
{
	public record UserForUpdateDto
	{
		public string FullName { get; init; }
		public string Address { get; init; }
		public string Email { get; init; }
		public string PhoneNumber { get; init; }
		public bool IsActive { get; init; }
	}
}
