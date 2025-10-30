using illumiyaCountriesRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaCountryConnector
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCountriesConnector(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration);
            services.AddSingleton<ICountriesConnector, CountriesConnector>();

            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCountriesRepository(configuration);
            return services;
        }
    }
}
