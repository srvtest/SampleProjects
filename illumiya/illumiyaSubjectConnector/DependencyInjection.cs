using illumiyaSubjectsRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaSubjectConnector
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSubjectConnector(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration);
            services.AddSingleton<ISubjectConnector, SubjectConnector>();

            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSubjectsRepository(configuration);
            return services;
        }
    }
}
