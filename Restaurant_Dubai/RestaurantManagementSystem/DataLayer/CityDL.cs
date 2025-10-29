
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
    public class CityDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddCity(City para)
        {

            LbSprocParameter[] parameter = new LbSprocParameter[4];
            try
            {
                // parameter[0] = new LbSprocParameter("@CityID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CityID);
                parameter[0] = new LbSprocParameter("@CityName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CityName);
                parameter[1] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CountryID);
                parameter[2] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StateID);
                parameter[3] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCity", parameter);
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
        public ApiResponse UpdateCity(City para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[5];
            try
            {
                parameter[0] = new LbSprocParameter("@CityID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CityID);
                parameter[1] = new LbSprocParameter("@CityName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CityName);
                parameter[2] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CountryID);
                parameter[3] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StateID);
                parameter[4] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateCity", parameter);
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
        public ApiResponse GetCity()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetCity", parameter);
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

        public ApiResponse DeleteCity(int CityID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CityID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CityID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteCity", parameter);
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

        public ApiResponse GetCityById(int CityID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CityID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CityID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetCityById", parameter);
                // return ds;
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

        //public void UpdateCity(City objCityModel)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddCity(City objCityModel)
        //{
        //    throw new NotImplementedException();
        //}

        public ApiResponse GetStateByCountryID(int CountryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CountryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetStateByCountryID", parameter);
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