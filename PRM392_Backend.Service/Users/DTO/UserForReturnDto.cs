namespace PRM392_Backend.Service.Users.DTO
{
	public record UserForReturnDto
	{
		public string Id { get; init; }
		public string FullName { get; init; }
		public string Address { get; init; }
        public string ImageUrl { get; set; }
        public string Email { get; init; }
		public string UserName { get; init; }
		public string PhoneNumber { get; init; }
		public bool IsActive { get; init; }
	}
}
