using illumiyaConnectorEntities.Subjects.Requests;
using illumiyaConnectorEntities.Subjects.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaSubjectsRepository.Repository
{
    public interface ISubjectsRepository
    {
        #region Get Methods
        Task<GetSubjectsListResponse> GetSubjectsListAsync(GetSubjectsListResponse response);
        Task<GetSubjectDetailsResponse> GetAsync(GetSubjectDetailsRequest request, GetSubjectDetailsResponse response);
        Task<CheckSubjectExistsResponse> CheckExistsAsync(CheckSubjectExistsRequest request, CheckSubjectExistsResponse response);
        Task<GetSubjectsListByCountryResponse> GetSubjectListByCountryAsync(GetSubjectsListByCountryRequest request, GetSubjectsListByCountryResponse response);
        #endregion

        #region Curd
        Task<SaveSubjectDetailsResponse> PostAsync(SaveSubjectDetailsRequest request, SaveSubjectDetailsResponse response);
        Task<UpdateSubjectDetailsResponse> PutAsync(UpdateSubjectDetailsRequest request, UpdateSubjectDetailsResponse response);
        Task<DeleteSubjectResponse> DeleteAsync(DeleteSubjectRequest request, DeleteSubjectResponse response);
        #endregion
    }
}
