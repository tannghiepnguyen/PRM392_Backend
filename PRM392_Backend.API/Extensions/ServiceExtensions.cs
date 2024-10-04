using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using PRM392_Backend.Infrastructure.Repository;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Service;

namespace PRM392_Backend.API.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
			});
		}

		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("Db")));
		}

		public static void ConfigureIdentity(this IServiceCollection services)
		{
			services.AddIdentity<User, IdentityRole>(o =>
			{
				o.Password.RequireDigit = false;
				o.Password.RequireLowercase = true;
				o.Password.RequireUppercase = false;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequiredLength = 5;
				o.User.RequireUniqueEmail = true;
			})
				.AddEntityFrameworkStores<DatabaseContext>()
				.AddDefaultTokenProviders();
		}

		public static void AddManager(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddScoped<IRepositoryManager, RepositoryManager>();
		}
	}
}
