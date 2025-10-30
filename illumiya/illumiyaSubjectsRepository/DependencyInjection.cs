using illumiyaFramework.Entities.Configurations;
using illumiyaSubjectsRepository.DataLayer;
using illumiyaSubjectsRepository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaSubjectsRepository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSubjectsRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureConnectionStrings(configuration);

            services.AddSingleton<ISubjectsDataLayer, SubjectsDataLayer>();

            services.AddSingleton<ISubjectsRepository, SubjectsRepository>();

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
