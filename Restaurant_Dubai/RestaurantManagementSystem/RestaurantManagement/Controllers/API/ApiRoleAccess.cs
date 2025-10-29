
using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RestaurantManagement.Controllers.API
{
    public class RoleAccessController : ApiController
    {
        // [Route("api/RoleAccess")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<RoleAccess> RoleAccesslist = null;
                DataTable dtRoleAccess = new DataTable();
                RoleAccessDL objRestaurantUserDL = new RoleAccessDL();

                objApiResponse = objRestaurantUserDL.GetRolesAccess();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    RoleAccesslist = ds.Tables[0].AsEnumerable().Select(x => new RoleAccess
                    {
                        UserRoleAccessID = x.Field<Int32>("UserRoleAccessID"),
                        AccessID = x.Field<Int32>("AccessID"),
                        RoleAccessMasterID = x.Field<Int32>("RoleAccessMasterID")
                    });
                    objApiResponse.Result = RoleAccesslist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = RoleAccesslist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Not found";
                }

            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;

        }

        // [Route("api/RoleAccessById")]	  

        [HttpGet]
        public ApiResponse RoleAccessById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<RoleAccess> RoleAccesslist = null;

                DataTable dtRoleAccess = new DataTable();
                RoleAccessDL objRestaurantUserDL = new RoleAccessDL();

                objApiResponse = objRestaurantUserDL.GetRoleAccessById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    RoleAccesslist = ds.Tables[0].AsEnumerable().Select(x => new RoleAccess
                    {
                        UserRoleAccessID = x.Field<Int32>("UserRoleAccessID"),
                        AccessID = x.Field<Int32>("AccessID"),
                        RoleAccessMasterID = x.Field<Int32>("RoleAccessMasterID")
                    });
                    objApiResponse.Result = RoleAccesslist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = RoleAccesslist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Not found";
                }

            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;

        }


        [Route("api/RoleAccess/AddRoleAccess")]
        [HttpPost]
        public ApiResponse AddRoleAccess(RoleAccess _RoleAccess)
        {
            RoleAccessDL objRoleAccessDL = new RoleAccessDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_RoleAccess.UserRoleAccessID > 0)
                {
                    objApiResponse = objRoleAccessDL.UpdateRolesAccess(_RoleAccess);

                }
                else
                {// neet work on this
                    objApiResponse = objRoleAccessDL.AddRolesAccess(":_RoleAccess");
                }

            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;

        }


        [HttpPost]
        public ApiResponse DeleteRoleAccess(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                RoleAccessDL objRoleAccessDL = new RoleAccessDL();
                objApiResponse = objRoleAccessDL.DeleteRoleAccess(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;
        }
    }
}