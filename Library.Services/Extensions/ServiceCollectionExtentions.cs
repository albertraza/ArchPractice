﻿using Library.Data.Extentions;
using Library.Domain.Entities;
using Library.Services.Bussiness;
using Library.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Services.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IService<Author>, BaseService<Author>>();
            services.AddScoped<IService<AuthorBook>, BaseService<AuthorBook>>();
            services.AddScoped<IService<Book>, BaseService<Book>>();
            services.AddScoped<IService<State>, BaseService<State>>();

            services.ConfigureDbContext(configuration);

            services.ConfigureDataServices();

            return services;
        }
    }
}
