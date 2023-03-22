using JobSearchTracker.Data;
using JobSearchTracker.Interfaces;
using JobSearchTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace JobSearchTracker.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) {


			services.AddDbContext<DataContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("DefaultSQLConnection"));
			});

			services.AddCors();
			services.AddScoped<ITokenService, TokenService>();

			return services;
		}
	}
}
