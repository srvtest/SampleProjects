
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
    public class EmailTemplateDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddEmailTemplate(EmailTemplate para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[4];
            try
            {
                parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[1] = new LbSprocParameter("@Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Name);
                parameter[2] = new LbSprocParameter("@EmailBody", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.EmailBody);
                parameter[3] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertEmailTemplate", parameter);
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

        public ApiResponse UpdateEmailTemplate(EmailTemplate para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[5];
            try
            {
                parameter[0] = new LbSprocParameter("@EmailTemplateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.EmailTemplateID);
                parameter[1] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[2] = new LbSprocParameter("@Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Name);
                parameter[3] = new LbSprocParameter("@EmailBody", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.EmailBody);
                parameter[4] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateEmailTemplate", parameter);
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

        public ApiResponse GetEmailTemplate()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetEmailTemplate", parameter);
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

        public ApiResponse DeleteEmailTemplate(int EmailTemplateID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@EmailTemplateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, EmailTemplateID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteEmailTemplate", parameter);
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

        public ApiResponse GetEmailTemplateById(int EmailTemplateID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@EmailTemplateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, EmailTemplateID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetEmailTemplateById", parameter);
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