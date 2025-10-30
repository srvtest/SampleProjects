//using illumiyaAuthenticationConnector;
using illumiyaAuthenticationConnector;
using illumiyaCountryConnector;
using illumiyaSubjectConnector;
using illumiyaWorkflows.Authentication;
using illumiyaWorkflows.Countries;
using illumiyaWorkflows.Subjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaWorkflows
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddillumiyaWorkflows(this IServiceCollection services, IConfiguration configuration) {
            services.AddWorkflow();
            services.AddConnector(configuration);
            return services;
        }

        public static IServiceCollection AddWorkflow(this IServiceCollection services) {
            services.AddSingleton<IAuthenticationWorkflow, AuthenticationWorkflow>();
            services.AddSingleton<ICountriesWorkflow, CountriesWorkflow>();
            services.AddSingleton<ISubjectWorkflow, SubjectWorkflow>();
            return services;
        }

        private static IServiceCollection AddConnector(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthenticationConnector(configuration);
            services.AddCountriesConnector(configuration);
            services.AddSubjectConnector(configuration);
            return services;
        }
    }
}
