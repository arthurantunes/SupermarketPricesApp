using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupermarketPrices.Api.Infrastructure.Queries;
using SupermarketPrices.Domain.Handlers;
using SupermarketPrices.Domain.Repositories;
using SupermarketPrices.Infra.Context;
using SupermarketPrices.Infra.Repositories;
using System;
using System.Reflection;

namespace SupermarketPrices.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDatabaseContextInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //Configurando o acesso a dados
            services.AddDbContext<SupermarketPricesDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SupermarketPricesConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    }));
        }

        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {


            services.AddTransient<ISupermarketRepository, SupermarketRepository>();
            services.AddScoped<SupermarketHandler, SupermarketHandler>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<ProductHandler, ProductHandler>();
            services.AddTransient<IProductQuery, ProductQuery>();
            services.AddTransient<ISupermarketQuery, SupermarketQuery>();
            services.AddScoped<SupermarketProductHandler, SupermarketProductHandler>();
            services.AddTransient<ISupermarketProductRepository, SupermarketProductRepository>();
            services.AddTransient<ISupermarketProductQuery, SupermarketProductQuery>();

        }
    }
}
