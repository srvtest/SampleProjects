using illumiyaCountriesRepository.DataLayer;
using illumiyaCountriesRepository.Repository;
using illumiyaFramework.Entities.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaCountriesRepository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCountriesRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureConnectionStrings(configuration);

            services.AddSingleton<ICountriesDataLayer, CountriesDataLayer>();

            services.AddSingleton<ICountriesRepository, CountriesRepository>();

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
