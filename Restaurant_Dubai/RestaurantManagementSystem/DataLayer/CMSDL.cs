
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
    public class CMSDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddCMS(CMS para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[6];
            try
            {
                //parameter[0] = new LbSprocParameter("@CMSID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CMSID);
                parameter[0] = new LbSprocParameter("@Title", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Title);
                parameter[1] = new LbSprocParameter("@PageDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, !string.IsNullOrEmpty(para.PageDesc)?para.PageDesc:"");
                parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[3] = new LbSprocParameter("@CMSTypeID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CMSTypeID);
                parameter[4] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[5] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCMS", parameter);
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
        public ApiResponse UpdateCMS(CMS para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[7];
            try
            {
                parameter[0] = new LbSprocParameter("@CMSID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CMSID);
                parameter[1] = new LbSprocParameter("@Title", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Title);
                parameter[2] = new LbSprocParameter("@PageDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, !string.IsNullOrEmpty(para.PageDesc) ? para.PageDesc : "");
                parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[4] = new LbSprocParameter("@CMSTypeID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CMSTypeID);
                parameter[5] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[6] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateCMS", parameter);
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
        public ApiResponse GetCMS()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetCMS", parameter);
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
        public ApiResponse DeleteCMS(int CMSID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CMSID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CMSID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteCMS", parameter);
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
        public ApiResponse GetCMSById(int? CMSID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CMSID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CMSID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetCMSById", parameter);
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