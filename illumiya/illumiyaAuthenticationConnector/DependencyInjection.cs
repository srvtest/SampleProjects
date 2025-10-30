using illumiyaAuthenticationRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaAuthenticationConnector
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationConnector(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration);
            services.AddSingleton<IAuthenticationConnector, AuthenticationConnector>();

            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthenticationRepository(configuration);
            return services;
        }
    }
}
