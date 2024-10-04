using Microsoft.Extensions.DependencyInjection;

namespace PRM392_Backend.Service.Extension
{
	public static class ServiceExtension
	{
		public static void AddAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(ServiceExtension).Assembly);
		}
	}
}
