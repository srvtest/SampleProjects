using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illumiyaApi
{
    public static class AutoMapperDependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                //Map Here
                ConfigureRequests(cfg);
                ConfigureResponses(cfg);
            });

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
            services.AddAutoMapper(typeof(Startup));
        }

        private static void ConfigureRequests(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<illumiyaEntities.Authentication.Requests.AuthenticationRequest, illumiyaConnectorEntities.Authentication.Requests.AuthenticationRequest>();
            
            cfg.CreateMap<illumiyaEntities.Subjects.Requests.DeleteSubjectRequest, illumiyaConnectorEntities.Subjects.Requests.DeleteSubjectRequest>();
            cfg.CreateMap<illumiyaEntities.Subjects.Requests.GetSubjectDetailsRequest, illumiyaConnectorEntities.Subjects.Requests.GetSubjectDetailsRequest>();
            cfg.CreateMap<illumiyaEntities.Subjects.Requests.SaveSubjectDetailsRequest, illumiyaConnectorEntities.Subjects.Requests.SaveSubjectDetailsRequest>();
            cfg.CreateMap<illumiyaEntities.Subjects.Requests.UpdateSubjectDetailsRequest, illumiyaConnectorEntities.Subjects.Requests.UpdateSubjectDetailsRequest>();
            cfg.CreateMap<illumiyaEntities.Subjects.Requests.GetSubjectsListByCountryRequest, illumiyaConnectorEntities.Subjects.Requests.GetSubjectsListByCountryRequest>();

        }

        private static void ConfigureResponses(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<illumiyaEntities.Authentication.Responses.AuthenticationResponse, illumiyaConnectorEntities.Authentication.Responses.AuthenticationResponse>();
            cfg.CreateMap<illumiyaEntities.Countries.Responses.GetCountriesListResponse, illumiyaConnectorEntities.Countries.Responses.GetCountriesListResponse>();

            cfg.CreateMap<illumiyaEntities.Subjects.Responses.DeleteSubjectResponse, illumiyaConnectorEntities.Subjects.Responses.DeleteSubjectResponse>();
            cfg.CreateMap<illumiyaEntities.Subjects.Responses.GetSubjectDetailsResponse, illumiyaConnectorEntities.Subjects.Responses.GetSubjectDetailsResponse>();
            cfg.CreateMap<illumiyaEntities.Subjects.Responses.GetSubjectsListResponse, illumiyaConnectorEntities.Subjects.Responses.GetSubjectsListResponse>();
            cfg.CreateMap<illumiyaEntities.Subjects.Responses.SaveSubjectDetailsResponse, illumiyaConnectorEntities.Subjects.Responses.SaveSubjectDetailsResponse>();
            cfg.CreateMap<illumiyaEntities.Subjects.Responses.UpdateSubjectDetailsResponse, illumiyaConnectorEntities.Subjects.Responses.UpdateSubjectDetailsResponse>();
            cfg.CreateMap<illumiyaEntities.Subjects.Responses.GetSubjectsListByCountryResponse, illumiyaConnectorEntities.Subjects.Responses.GetSubjectsListByCountryResponse>();
        }
    }
}
