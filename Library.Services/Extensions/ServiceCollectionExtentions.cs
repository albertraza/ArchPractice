using Library.Data.Extentions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Services.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);

            services.ConfigureDataServices();

            return services;
        }
    }
}
