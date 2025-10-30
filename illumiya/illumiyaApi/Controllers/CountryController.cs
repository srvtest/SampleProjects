using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using illumiyaEntities.Countries.Responses;
using illumiyaFramework.Helpers;
using illumiyaFramework.Responses;
using illumiyaWorkflows.Countries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace illumiyaApi.Controllers
{
    [Authorize]
    [Route("api/country")]
    public class CountryController : Controller
    {
        private readonly ICountriesWorkflow _workflow;

        public CountryController(ICountriesWorkflow workflow)
        {
            _workflow = workflow;
        }


        [HttpGet]
        [Route("list")]
        public async Task<GetCountriesListResponse> GetListAsync() {
            var response = ResponseHelper.GetResponse<GetCountriesListResponse>();

            try {
                response = await _workflow.GetCountriesListAsync(response);
                if (!response.IsSuccess) {
                    response.Failed("CountryController > GetListAsync");
                }
            }
            catch (Exception ex) {
                response.Failed(ex);
            }
            return response;
        }
    }
}
