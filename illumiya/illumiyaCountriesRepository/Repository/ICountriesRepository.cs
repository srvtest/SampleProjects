using illumiyaConnectorEntities.Countries.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaCountriesRepository.Repository
{
    public interface ICountriesRepository
    {
        Task<GetCountriesListResponse> GetCountriesListAsync(GetCountriesListResponse response);
    }
}
