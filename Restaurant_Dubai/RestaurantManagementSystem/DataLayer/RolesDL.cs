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
    public class RolesDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddRoles(Role para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[5];

            try
            {
                parameter[0] = new LbSprocParameter("@RoleName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.RoleName);
                parameter[1] = new LbSprocParameter("@RoleDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.RoleDesc);
                parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[3] = new LbSprocParameter("@CreatedBy", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[4] = new LbSprocParameter("@CreatedDate", DbType.Date, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                //  parameter[4] = new LbSprocParameter("@msg", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertRole", parameter);
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


        public ApiResponse UpdateRoles(Role para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[5];

            try
            {
                parameter[0] = new LbSprocParameter("@RolesId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RolesID);
                parameter[1] = new LbSprocParameter("@RoleName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.RoleName);
                parameter[2] = new LbSprocParameter("@RoleDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.RoleDesc);
                parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[4] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateRole", parameter);
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

        public ApiResponse GetRoles()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetRoles", parameter);
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

        public ApiResponse DeleteRole(int RolesId)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RolesId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RolesId);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteRole", parameter);
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

        public ApiResponse GetRoleById(int RolesID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RolesID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RolesID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetRoleById", parameter);
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
