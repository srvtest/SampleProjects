using illumiyaEntities.Countries.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaWorkflows.Countries
{
    public interface ICountriesWorkflow
    {
        Task<GetCountriesListResponse> GetCountriesListAsync(GetCountriesListResponse response);
    }
}
