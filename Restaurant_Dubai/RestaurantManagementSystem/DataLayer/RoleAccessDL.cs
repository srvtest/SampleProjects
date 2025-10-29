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
    public class RoleAccessDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddRolesAccess(string para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            try
            {
                parameter[0] = new LbSprocParameter("@xmlData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, para);
                //parameter[1] = new LbSprocParameter("@RolesID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RolesID);
                //parameter[2] = new LbSprocParameter("@Desc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Desc);
                //parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                //parameter[4] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertRoleAccess", parameter);

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


        public ApiResponse UpdateRolesAccess(RoleAccess para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[3];

            try
            {
                parameter[0] = new LbSprocParameter("@UserRoleAccessID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.UserRoleAccessID);
                parameter[0] = new LbSprocParameter("@AccessID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.AccessID);
                parameter[1] = new LbSprocParameter("@RolesID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RolesID);
                //parameter[2] = new LbSprocParameter("@Desc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Desc);
                //parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                //parameter[4] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteNonQuery("usp_UpdateRoleAccess", parameter);
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



        public ApiResponse GetRoleAccessList(int RestaurentID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RestaurentID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurentID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetRoleAccessList", parameter);
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

        public ApiResponse GetRolesAccess()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetRoleAccess", parameter);
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

        public ApiResponse DeleteRoleAccess(int RolesId)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RolesId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RolesId);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteRoleAccess", parameter);
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
        /// <summary>
        /// RiteshV Created the method.
        /// </summary>
        /// <param name="RoleAccessMasterID"></param>
        /// <returns></returns>
        public ApiResponse GetRoleAccessById(int RoleAccessMasterID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RoleAccessMasterID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RoleAccessMasterID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetRoleAccessById", parameter);
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
