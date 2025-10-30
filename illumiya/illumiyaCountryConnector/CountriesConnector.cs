using AutoMapper;
using illumiyaCountriesRepository.Repository;
using illumiyaEntities.Countries.Responses;
using illumiyaFramework.Helpers;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaCountryConnector
{
    public class CountriesConnector : ICountriesConnector
    {
        private IMapper _mapper;
        private readonly ICountriesRepository _repository;

        public CountriesConnector(IMapper mapper, ICountriesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetCountriesListResponse> GetCountriesListAsync(GetCountriesListResponse response) {
            try {
                var serviceResponse = ResponseHelper.GetResponse<illumiyaConnectorEntities.Countries.Responses.GetCountriesListResponse>();
                serviceResponse = await _repository.GetCountriesListAsync(serviceResponse);
                if (serviceResponse.IsSuccess)
                {
                    response.CountryList = serviceResponse.CountryList;
                    response.Success("CountriesConnector > GetCountriesListAsync");
                }
                else {
                    response.Failed("CountriesConnector > GetCountriesListAsync");
                }
            }
            catch (Exception ex) {
                response.Failed(ex.Message);
            }
            return response;
        }


    }
}
