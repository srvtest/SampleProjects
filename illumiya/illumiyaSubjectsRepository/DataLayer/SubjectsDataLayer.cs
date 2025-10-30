using illumiyaFramework.Entities;
using illumiyaFramework.Entities.Configurations;
using illumiyaSubjectsRepository.Entities.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using illumiyaFramework.Log;
using illumiyaSubjectsRepository.Mappers;

namespace illumiyaSubjectsRepository.DataLayer
{
    public class SubjectsDataLayer : BaseRepository, ISubjectsDataLayer
    {
        public SubjectsDataLayer(IOptions<DBConnectionOptions> setting)
           : base(setting) { }

        #region Get Methods
        public async Task<IEnumerable<SubjectList>> GetSubjectsListAsync()
        {
            IEnumerable<SubjectList> response = null;
            try
            {
                var result = await _db.QueryAsync<Entities.DB.SubjectList>($"SELECT sub.Id, sub.Name, sub.IsActive, country.Id as CountryId, country.Name as CountryName FROM `tblsubjects` sub inner join `tblcountries` country on sub.CountryId = country.Id and sub.IsDeleted = false order by sub.Id desc");

                if (result != null)
                    response = result.Map();
                else
                    Logger.Error("GetSubjectsListAsync > result is null");
            }
            catch (Exception ex)
            {
                Logger.Error("SubjectsDataLayer => Error get countries list", ex);
            }
            return response;
        }

        public async Task<Subject> GetSubjectAsync(int? id)
        {
            Subject response = null;
            try
            {
                var result = await _db.QueryFirstOrDefaultAsync<Entities.DB.Subject>($"select * from tblsubjects where Id = {id} and IsDeleted = false");

                if (result != null)
                    response = result.MapToSubject();
                else
                    Logger.Error("GetSubjectAsync > result is null");
            }
            catch (Exception ex)
            {
                Logger.Error("SubjectsDataLayer => Error get country", ex);
            }
            return response;
        }

        public async Task<int> CheckExistsAsync(int countryId, string name) {
            int id = 0;
            try {
                var result = await _db.QueryFirstOrDefaultAsync<int>($"select Id from tblsubjects where CountryId = {countryId} and Name = '{name}' and IsDeleted = false");
                if (result > 0) {
                    id = result;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return id;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsListByCountryAsync(int? countryId) {
            IEnumerable<Subject> response = null;
            try
            {
                var result = await _db.QueryAsync<Entities.DB.Subject>($"select * from tblsubjects where CountryId = {countryId} and IsDeleted = false and IsActive = true");

                if (result != null)
                    response = result.Map();
                else
                    Logger.Error("GetSubjectsListAsync > result is null");
            }
            catch (Exception ex)
            {
                Logger.Error("SubjectsDataLayer => Error get countries list", ex);
            }
            return response;
        }
        #endregion

        #region Curd
        public async Task<int> PostAsync(int countryId, string name, bool isActive, int? createdBy) {
            int result = 0;
            string date = System.DateTime.Now.ToString("yyyy-dd-mm");
            try {
                var query = $"insert into tblsubjects (CountryId, Name, IsActive, CreatedBy, CreatedOn) values ({countryId}, '{name}', {isActive}, {createdBy},'{date}');  SELECT LAST_INSERT_ID()";
                var id = _db.ExecuteScalar(query);
                result = Convert.ToInt32(id);
            }
            catch (Exception ex) {
                Logger.Error("SubjectsDataLayer => Error post country", ex);
            }
            return result;
        }

        public async Task<bool> PutAsync(int? id,int countryId, string name, bool isActive, int? modifiedBy)
        {
            bool isUpdated = false;
            string date = System.DateTime.Now.ToString("yyyy-dd-mm");
            try
            {
                var query = $"update tblsubjects set CountryId = {countryId}, Name = '{name}', IsActive = {isActive}, ModifiedBy = {modifiedBy}, ModifiedOn = '{date}' where Id = {id}";
                var result = await _db.ExecuteAsync(query);
                if (result > 0) {
                    isUpdated = true;
                }

            }
            catch (Exception ex)
            {
                Logger.Error("SubjectsDataLayer => Error post country", ex);
            }
            return isUpdated;
        }

        public async Task<bool> DeleteAsync(int? id) {
            bool isDeleted = false;

            try {
                var query = $"update tblsubjects set IsDeleted = true where Id = {id}";
                var result = await _db.ExecuteAsync(query);
                if (result > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception ex) {
                Logger.Error("SubjectsDataLayer => Error post country", ex);
            }
            return isDeleted;
        }
        #endregion
    }
}
