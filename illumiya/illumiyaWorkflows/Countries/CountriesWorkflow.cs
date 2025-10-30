using illumiyaCountryConnector;
using illumiyaEntities.Countries.Responses;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaWorkflows.Countries
{
    public class CountriesWorkflow : ICountriesWorkflow
    {
        private readonly ICountriesConnector _connector;

        public CountriesWorkflow(ICountriesConnector connector)
        {
            _connector = connector;
        }
        public async Task<GetCountriesListResponse> GetCountriesListAsync(GetCountriesListResponse response) {
            try
            {
                response = await _connector.GetCountriesListAsync(response);
            }
            catch (Exception ex)
            {
                response.Failed(ex);
            }
            return response;
        }
    }
}
