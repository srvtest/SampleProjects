using illumiyaConnectorEntities.Subjects.Requests;
using illumiyaConnectorEntities.Subjects.Responses;
using illumiyaFramework.Responses;
using illumiyaSubjectsRepository.DataLayer;
using illumiyaSubjectsRepository.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaSubjectsRepository.Repository
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly ISubjectsDataLayer _dataLayer;

        public SubjectsRepository(ISubjectsDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        #region Get Methods
        public async Task<GetSubjectsListResponse> GetSubjectsListAsync(GetSubjectsListResponse response) {
            try {
                var subjects = await _dataLayer.GetSubjectsListAsync();
                if (subjects != null)
                {
                    response.SubjectList = subjects.Map();
                    response.Success("SubjectsRepository > GetSubjectsListAsync");
                }
                else
                {
                    response.Failed("SubjectsRepository > GetSubjectsListAsync");
                }
            }
            catch (Exception ex) {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<GetSubjectDetailsResponse> GetAsync(GetSubjectDetailsRequest request, GetSubjectDetailsResponse response) {
            try
            {
                var subject = await _dataLayer.GetSubjectAsync(request.Id);
                if (subject != null)
                {
                    response.SubjectDetails = subject.MapToSubject();
                    response.Success("SubjectsRepository > GetSubjectsListAsync");
                }
                else
                {
                    response.Failed("SubjectsRepository > GetSubjectsListAsync");
                }
            }
            catch (Exception ex)
            {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<CheckSubjectExistsResponse> CheckExistsAsync(CheckSubjectExistsRequest request, CheckSubjectExistsResponse response) {
            try {
                var id = await _dataLayer.CheckExistsAsync(request.CountryId, request.Name);
                response.SubjectId = id;
                response.Success("SubjectsRepository > CheckExistsAsync");
            }
            catch (Exception ex) {
                response.Failed("SubjectsRepository > CheckExistsAsync");
            }
            return response;
        }

        public async Task<GetSubjectsListByCountryResponse> GetSubjectListByCountryAsync(GetSubjectsListByCountryRequest request, GetSubjectsListByCountryResponse response) {
            try
            {
                var subjects = await _dataLayer.GetSubjectsListByCountryAsync(request.Id);
                response.Subjects = subjects.Map();
                response.Success("SubjectsRepository > GetSubjectListByCountryAsync");
            }
            catch (Exception ex)
            {
                response.Failed("SubjectsRepository > GetSubjectListByCountryAsync");
            }
            return response;
        }
        #endregion

        #region Curd
        public async Task<SaveSubjectDetailsResponse> PostAsync(SaveSubjectDetailsRequest request, SaveSubjectDetailsResponse response) {
            try {
                var result = await _dataLayer.PostAsync(request.SubjectDetails.CountryId, request.SubjectDetails.Name, request.SubjectDetails.IsActive, request.SubjectDetails.CreatedBy);
                if (result > 0)
                {
                    response.SubjectId = result;
                    response.Success("SubjectsRepository > PostAsync");
                }
                else
                {
                    response.Failed("SubjectsRepository > PostAsync");
                }
            }
            catch (Exception ex) {
                response.Failed(ex.Message);
            }
            return response;
        }

        public async Task<UpdateSubjectDetailsResponse> PutAsync(UpdateSubjectDetailsRequest request, UpdateSubjectDetailsResponse response) {
            try
            {
                var result = await _dataLayer.PutAsync(request.SubjectDetails.Id, request.SubjectDetails.CountryId, request.SubjectDetails.Name, request.SubjectDetails.IsActive, request.SubjectDetails.ModifiedBy);
                if (result)
                {
                    response.IsUpdated = result;
                    response.Success("SubjectsRepository > PutAsync");
                }
                else
                {
                    response.Failed("SubjectsRepository > PutAsync");
                }
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
                var result = await _dataLayer.DeleteAsync(request.Id);
                if (result)
                {
                    response.IsDeleted = result;
                    response.Success("SubjectsRepository > DeleteAsync");
                }
                else
                {
                    response.Failed("SubjectsRepository > DeleteAsync");
                }
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
