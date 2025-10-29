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
    public class RoleAccessMasterDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddUpdateRoleAccessMaster(string para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            try
            {
                parameter[0] = new LbSprocParameter("@xmlData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, para);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertUpdateRoleAccessMaster", parameter);
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

        public ApiResponse GetRoleAccessMasterList(int RestaurentID)
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

        //public ApiResponse GetRolesAccess()
        //{
        //    LbSprocParameter[] parameter = new LbSprocParameter[0];
        //    try
        //    {
        //        ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
        //        DataSet ds = new DataSet();
        //        objApiResponse.Result = elHelper.ExecuteDataset("usp_GetRoleAccess", parameter);
        //        objApiResponse.Message = "";
        //        objApiResponse.StatusCode = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = ex.InnerException;
        //        objApiResponse.Message = ex.Message;
        //        objApiResponse.StatusCode = ex.HResult;
        //    }
        //    return objApiResponse;
        //}

        public ApiResponse DeleteRoleAccessMaster(int RoleAccessMasterId)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RoleAccessMasterId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RoleAccessMasterId);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteRoleAccessMaster", parameter);
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
        public ApiResponse GetRoleAccessMasterById(int RoleAccessMasterID)
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
