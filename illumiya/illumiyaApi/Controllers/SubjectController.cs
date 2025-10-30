using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using illumiyaEntities.Subjects.Requests;
using illumiyaEntities.Subjects.Responses;
using illumiyaFramework.Helpers;
using illumiyaFramework.Responses;
using illumiyaWorkflows.Subjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace illumiyaApi.Controllers
{
    [Authorize]
    [Route("api/subject")]
    public class SubjectController : Controller
    {
        private readonly ISubjectWorkflow _workFlow;

        public SubjectController(ISubjectWorkflow workFlow)
        {
            _workFlow = workFlow;
        }

        #region Curd
        [HttpPost("save")]
        public async Task<SaveSubjectDetailsResponse> PostAsync([FromBody] SaveSubjectDetailsRequest request) {
            var response = ResponseHelper.GetResponse<SaveSubjectDetailsResponse>();
            try {
                if (ModelState.IsValid) {
                    response = await _workFlow.PostAsync(request, response);
                }
                else
                {
                    var errors = ModelState.Values.Select(x => x.Errors.Select(y => y.ErrorMessage));
                    response.Failed("");
                }
            }
            catch (Exception ex) {
                response.Failed(ex.Message);
            }
            return response;
        }

        [HttpPut("update")]
        public async Task<UpdateSubjectDetailsResponse> PutAsync([FromBody] UpdateSubjectDetailsRequest request)
        {
            var response = ResponseHelper.GetResponse<UpdateSubjectDetailsResponse>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = await _workFlow.PutAsync(request, response);
                }
                else
                {
                    var errors = ModelState.Values.Select(x => x.Errors.Select(y => y.ErrorMessage));
                    response.Failed("");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        [HttpDelete("delete/{id}")]
        public async Task<DeleteSubjectResponse> DeleteAsync(int? id)
        {
            var request = new DeleteSubjectRequest() { Id = id };
            var response = ResponseHelper.GetResponse<DeleteSubjectResponse>();
            try
            {
                if (id == null)
                {
                    response.Failed("Subject Id is null");
                }
                else
                {
                    response = await _workFlow.DeleteAsync(request, response);
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        [HttpGet("country/subject/{id}")]
        public async Task<GetSubjectsListByCountryResponse> GetSubjectsListByCountryAsync(int id) {
            var request = new GetSubjectsListByCountryRequest() { Id = id };
            var response = ResponseHelper.GetResponse<GetSubjectsListByCountryResponse>();
            try
            {
                response = await _workFlow.GetSubjectsListByCountryAsync(request, response);
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }
        #endregion

        #region Get Methods
        [HttpGet("all")]
        public async Task<GetSubjectsListResponse> GetAllAsync() {
            var response = ResponseHelper.GetResponse<GetSubjectsListResponse>();
            try
            {
                response = await _workFlow.GetAllAsync(response);
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        [HttpGet("get/{id}")]
        public async Task<GetSubjectDetailsResponse> GetAsync(int? id)
        {
            var request = new GetSubjectDetailsRequest() { Id = id };
            var response = ResponseHelper.GetResponse<GetSubjectDetailsResponse>();
            try
            {
                response = await _workFlow.GetAsync(request,response);
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }
        #endregion
    }
}
