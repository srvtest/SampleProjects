using illumiyaEntities.Countries.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaCountryConnector
{
    public interface ICountriesConnector
    {
        Task<GetCountriesListResponse> GetCountriesListAsync(GetCountriesListResponse response);
    }
}
