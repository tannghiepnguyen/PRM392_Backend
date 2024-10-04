using PRM392_Backend.Service.Users;

namespace PRM392_Backend.Service.IService
{
	public interface IServiceManager
	{
		IAuthenticationService AuthenticationService { get; }
	}
}
