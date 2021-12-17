using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Data.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LocalDb"));
            });

            return services;
        }

        public static IServiceCollection ConfigureDataServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
