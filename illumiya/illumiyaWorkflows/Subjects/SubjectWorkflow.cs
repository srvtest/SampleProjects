using illumiyaEntities.Subjects.Requests;
using illumiyaEntities.Subjects.Responses;
using illumiyaFramework.Responses;
using illumiyaSubjectConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaWorkflows.Subjects
{
    public class SubjectWorkflow : ISubjectWorkflow
    {
        private readonly ISubjectConnector _connector;

        public SubjectWorkflow(ISubjectConnector connector)
        {
            _connector = connector;
        }

        #region Get Methods
        public async Task<GetSubjectsListResponse> GetAllAsync(GetSubjectsListResponse response) {
            try {
                response = await _connector.GetAllAsync(response);
            }
            catch (Exception ex) {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<GetSubjectDetailsResponse> GetAsync(GetSubjectDetailsRequest request, GetSubjectDetailsResponse response) {
            try
            {
                response = await _connector.GetAsync(request,response);
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<GetSubjectsListByCountryResponse> GetSubjectsListByCountryAsync(GetSubjectsListByCountryRequest request, GetSubjectsListByCountryResponse response) {
            try
            {
                response = await _connector.GetSubjectsListByCountryAsync(request, response);
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }
        #endregion

        #region Curd
        public async Task<SaveSubjectDetailsResponse> PostAsync(SaveSubjectDetailsRequest request, SaveSubjectDetailsResponse response) {
            try
            {
                response = await _connector.PostAsync(request, response);
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<UpdateSubjectDetailsResponse> PutAsync(UpdateSubjectDetailsRequest request, UpdateSubjectDetailsResponse response) {
            try
            {
                response = await _connector.PutAsync(request, response);
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<DeleteSubjectResponse> DeleteAsync(DeleteSubjectRequest request, DeleteSubjectResponse response) {
            try
            {
                response = await _connector.DeleteAsync(request, response);
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
