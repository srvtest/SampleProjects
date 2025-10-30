using illumiyaFramework.Responses;
using illumiyaModels.Countries;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaEntities.Countries.Responses
{
    public class GetCountriesListResponse : BaseResponse
    {
        public IEnumerable<Country> CountryList { get; set; }
    }
}
