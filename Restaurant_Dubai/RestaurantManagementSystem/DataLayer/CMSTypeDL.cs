using ELHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CMSTypeDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse GetCMSType()
        {

            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_GetCMSType", parameter);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    objApiResponse.Result = ds;
                }
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

        public ApiResponse AddCMSType(CMSType para)
        {

            LbSprocParameter[] parameter = new LbSprocParameter[3];
            try
            {
                parameter[0] = new LbSprocParameter("@CMSTypeName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CMSTypeName);
                parameter[1] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[2] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCMSType", parameter);
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

        public ApiResponse UpdateCMSType(CMSType para)
        {

            LbSprocParameter[] parameter = new LbSprocParameter[4];
            try
            {
                parameter[0] = new LbSprocParameter("@CMSTypeID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CMSTypeID);
                parameter[1] = new LbSprocParameter("@CMSTypeName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CMSTypeName);
                parameter[2] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[3] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateCMSType", parameter);
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

        public ApiResponse DeleteCMSType(int? id)
        {

            LbSprocParameter[] parameter = new LbSprocParameter[1];
            try
            {
                parameter[0] = new LbSprocParameter("@CMSTypeID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, id);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteCMSType", parameter);
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

        public ApiResponse GetCMSTypeById(int? id)
        {
            
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            try
            {
                parameter[0] = new LbSprocParameter("@CMSTypeID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, id);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_GetCMSTypeById", parameter);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    objApiResponse.Result = ds;
                }
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
