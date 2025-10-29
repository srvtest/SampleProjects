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
    public class AccessDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddAccess(Access para)
        {

            LbSprocParameter[] parameter = new LbSprocParameter[5];
            try
            {
                parameter[0] = new LbSprocParameter("@AccessName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AccessName);
                parameter[1] = new LbSprocParameter("@AccessDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AccessDesc);
                parameter[2] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[3] = new LbSprocParameter("@BaseAccessID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.BaseAccessID);
                parameter[4] = new LbSprocParameter("@PageURL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.PageURL);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertAccess", parameter);
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


        public ApiResponse UpdateAccess(Access para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[6];

            try
            {
                parameter[0] = new LbSprocParameter("@AccessID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.AccessID);
                parameter[1] = new LbSprocParameter("@AccessName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AccessName);
                parameter[2] = new LbSprocParameter("@AccessDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AccessDesc);
                parameter[3] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[4] = new LbSprocParameter("@BaseAccessID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.BaseAccessID);
                parameter[5] = new LbSprocParameter("@PageURL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.PageURL);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateAccess", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse GetAccess()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetAccess", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse DeleteAccess(int AccessID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@AccessID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, AccessID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteAccess", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse GetAccessById(int AccessID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@AccessID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, AccessID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetAccessById", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }


    }
}
