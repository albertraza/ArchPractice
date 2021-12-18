using Library.Data.DataAccess.Core;
using Library.Data.DataAccess.Core.Contracts;
using Library.Data.DataAccess.Persistence;
using Library.Data.DataAccess.Persistence.Repositories;
using Library.Domain.Entities;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<Author>, BaseRepository<Author>>();
            services.AddScoped<IRepository<AuthorBook>, BaseRepository<AuthorBook>>();
            services.AddScoped<IRepository<Book>, BaseRepository<Book>>();
            services.AddScoped<IRepository<State>, BaseRepository<State>>();

            return services;
        }
    }
}
