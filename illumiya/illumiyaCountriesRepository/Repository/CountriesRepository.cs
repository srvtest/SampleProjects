using illumiyaConnectorEntities.Countries.Responses;
using illumiyaCountriesRepository.DataLayer;
using illumiyaCountriesRepository.Mappers;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaCountriesRepository.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ICountriesDataLayer _dataLayer;

        public CountriesRepository(ICountriesDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public async Task<GetCountriesListResponse> GetCountriesListAsync(GetCountriesListResponse response) {
            try
            {
                var countries = await _dataLayer.GetCountriesListAsync();
                if (countries != null)
                {
                    response.CountryList = countries.Map();
                    response.Success("CountriesRepository > GetCountriesListAsync");
                }
                else {
                    response.Failed("CountriesRepository > GetCountriesListAsync");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex);
            }
            return response;
        }
    }
}
