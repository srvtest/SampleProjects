
using illumiyaEntities.Subjects.Requests;
using illumiyaEntities.Subjects.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaSubjectConnector
{
    public interface ISubjectConnector
    {
        #region Get Methods
        Task<GetSubjectsListResponse> GetAllAsync(GetSubjectsListResponse response);
        Task<GetSubjectDetailsResponse> GetAsync(GetSubjectDetailsRequest request, GetSubjectDetailsResponse response);
        Task<GetSubjectsListByCountryResponse> GetSubjectsListByCountryAsync(GetSubjectsListByCountryRequest request, GetSubjectsListByCountryResponse response);
        #endregion

        #region Curd
        Task<SaveSubjectDetailsResponse> PostAsync(SaveSubjectDetailsRequest request, SaveSubjectDetailsResponse response);
        Task<UpdateSubjectDetailsResponse> PutAsync(UpdateSubjectDetailsRequest request, UpdateSubjectDetailsResponse response);
        Task<DeleteSubjectResponse> DeleteAsync(DeleteSubjectRequest request, DeleteSubjectResponse response);
        #endregion
    }
}
