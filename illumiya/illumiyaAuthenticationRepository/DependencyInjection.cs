using illumiyaAuthenticationRepository.DataLayer;
using illumiyaAuthenticationRepository.Repository;
using illumiyaFramework.Entities.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaAuthenticationRepository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureConnectionStrings(configuration);

            services.AddSingleton<IAuthenticationDataLayer, AuthenticationDataLayer>();
            
            services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
            
            return services;
        }

       
        private static IServiceCollection ConfigureConnectionStrings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DBConnectionOptions>(options =>
            {
                options.ConnectionString = configuration.GetSection("DB:ConnectionString").Value;
            });

            return services;
        }
    }
}
