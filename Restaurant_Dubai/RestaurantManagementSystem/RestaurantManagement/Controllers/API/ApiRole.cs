
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
    public class RoleController : ApiController
    {
        // [Route("api/Role")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Role> Rolelist = null;
                DataTable dtRole = new DataTable();
                RolesDL objRestaurantUserDL = new RolesDL();

                objApiResponse = objRestaurantUserDL.GetRoles();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Rolelist = ds.Tables[0].AsEnumerable().Select(x => new Role
                    {
                        RolesID = x.Field<Int32>("RolesId"),
                        RoleName = x.Field<String>("RoleName"),
                        RoleDesc = x.Field<String>("RoleDesc"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                        // AspNetRoleID = x.Field<String>("AspNetRoleID"),
                    });
                    objApiResponse.Result = Rolelist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Rolelist;
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

        // [Route("api/RoleById")]	  

        [HttpGet]
        public ApiResponse RoleById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Role> Rolelist = null;

                DataTable dtRole = new DataTable();
                RolesDL objRestaurantUserDL = new RolesDL();

                objApiResponse = objRestaurantUserDL.GetRoleById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Rolelist = ds.Tables[0].AsEnumerable().Select(x => new Role
                    {
                        RolesID = x.Field<Int32>("RolesId"),
                        RoleName = x.Field<String>("RoleName"),
                        RoleDesc = x.Field<String>("RoleDesc"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                        // AspNetRoleID = x.Field<String>("AspNetRoleID"),
                    });
                    objApiResponse.Result = Rolelist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Rolelist;
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


        [Route("api/Role/AddRole")]
        [HttpPost]
        public ApiResponse AddRole(Role _Role)
        {
            RolesDL objRoleDL = new RolesDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Role.RolesID > 0)
                {
                    objApiResponse = objRoleDL.UpdateRoles(_Role);

                }
                else
                {
                    objApiResponse = objRoleDL.AddRoles(_Role);
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
        public ApiResponse DeleteRole(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                RolesDL objRoleDL = new RolesDL();
                objApiResponse = objRoleDL.DeleteRole(Convert.ToInt32(id));
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