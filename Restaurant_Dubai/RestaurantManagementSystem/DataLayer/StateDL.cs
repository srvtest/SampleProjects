
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
    public class StateDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddState(State para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[3];
            try
            {
                parameter[0] = new LbSprocParameter("@StateName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.StateName);
                parameter[1] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CountryID);
                parameter[2] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertState", parameter);
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
        public ApiResponse UpdateState(State para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[4];
            try
            {
                parameter[0] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StateID);
                parameter[1] = new LbSprocParameter("@StateName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.StateName);
                parameter[2] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CountryID);
                parameter[3] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateState", parameter);
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
        public ApiResponse GetState()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetState", parameter);
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
        public ApiResponse DeleteState(int StateID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, StateID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteState", parameter);
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
        public ApiResponse GetStateById(int StateID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, StateID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetStateById", parameter);
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
    }
}