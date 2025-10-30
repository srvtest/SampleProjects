using illumiyaSubjectsRepository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaSubjectsRepository.DataLayer
{
    public interface ISubjectsDataLayer
    {
        #region Get Methods
        Task<IEnumerable<SubjectList>> GetSubjectsListAsync();
        Task<Subject> GetSubjectAsync(int? id);
        Task<int> CheckExistsAsync(int countryId, string name);
        Task<IEnumerable<Subject>> GetSubjectsListByCountryAsync(int? countryId);
        #endregion

        #region Curd
        Task<int> PostAsync(int countryId, string name, bool isActive, int? createdBy);
        Task<bool> PutAsync(int? id, int countryId, string name, bool isActive, int? modifiedBy);
        Task<bool> DeleteAsync(int? id);
        #endregion
    }
}
