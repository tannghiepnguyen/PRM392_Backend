using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Users;

namespace PRM392_Backend.Service.Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IAuthenticationService> authenticationService;

		public ServiceManager(IRepositoryManager repositoryManager, UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
		{
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, mapper, configuration));
		}
		public IAuthenticationService AuthenticationService => authenticationService.Value;
	}
}
