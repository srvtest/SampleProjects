
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ELHelper;
using System.Data;
namespace DataLayer
{
    public class CountryDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddCountry(Country para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];
            try
            {
                parameter[0] = new LbSprocParameter("@CountryName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CountryName);
                parameter[1] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCountry", parameter);

                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                // throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse UpdateCountry(Country para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[3];
            try
            {
                parameter[0] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CountryID);
                parameter[1] = new LbSprocParameter("@CountryName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CountryName);
                parameter[2] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateCountry", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                // throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse GetCountry()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetCountry", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        public ApiResponse DeleteCountry(int CountryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CountryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteCountry", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        public ApiResponse GetCountryById(int CountryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CountryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetCountryById", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }
    }
}