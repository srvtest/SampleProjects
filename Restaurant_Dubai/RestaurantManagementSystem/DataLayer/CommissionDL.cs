
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
    public class CommissionDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddCommission(Commission para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[5];
            try
            {
                parameter[0] = new LbSprocParameter("@RoleID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RoleID);
                parameter[1] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.UserID);
                parameter[2] = new LbSprocParameter("@Percentage", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, para.Percentage);
                parameter[3] = new LbSprocParameter("@Desc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Desc);
                parameter[4] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCommission", parameter);


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
        public ApiResponse UpdateCommission(Commission para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[6];
            try
            {
                parameter[0] = new LbSprocParameter("@CommissionID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CommissionID);
                parameter[1] = new LbSprocParameter("@RoleID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RoleID);               
                parameter[2] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.UserID);
                parameter[3] = new LbSprocParameter("@Percentage", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.Percentage);
                parameter[4] = new LbSprocParameter("@Desc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Desc);
                parameter[5] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateCommission", parameter);
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
        public ApiResponse GetCommission()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            //parameter[0] = new LbSprocParameter("@RoleID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RoleID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result =ds = elHelper.ExecuteDataset("usp_GetCommission", parameter);
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
        public ApiResponse DeleteCommission(int CommissionID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CommissionID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CommissionID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteCommission", parameter);
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
        public ApiResponse GetCommissionById(int CommissionID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@CommissionID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CommissionID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result =ds = elHelper.ExecuteDataset("usp_GetCommissionById", parameter);
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
    }
}