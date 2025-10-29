
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
    public class AccessController : ApiController
    {
        // [Route("api/Access")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Access> Accesslist = null;
                DataTable dtAccess = new DataTable();
                AccessDL objRestaurantUserDL = new AccessDL();

                objApiResponse = objRestaurantUserDL.GetAccess();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Accesslist = ds.Tables[0].AsEnumerable().Select(x => new Access
                    {
                        AccessID = x.Field<Int32>("AccessID"),
                        AccessName = x.Field<String>("AccessName"),
                        AccessDesc = x.Field<String>("AccessDesc"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = Accesslist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Accesslist;
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

        // [Route("api/AccessById")]	  

        [HttpGet]
        public ApiResponse AccessById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Access> Accesslist = null;

                DataTable dtAccess = new DataTable();
                AccessDL objRestaurantUserDL = new AccessDL();

                objApiResponse = objRestaurantUserDL.GetAccessById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Accesslist = ds.Tables[0].AsEnumerable().Select(x => new Access
                    {
                        AccessID = x.Field<Int32>("AccessID"),
                        AccessName = x.Field<String>("AccessName"),
                        AccessDesc = x.Field<String>("AccessDesc"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = Accesslist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Accesslist;
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


        [Route("api/Access/AddAccess")]
        [HttpPost]
        public ApiResponse AddAccess(Access _Access)
        {
            AccessDL objAccessDL = new AccessDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Access.AccessID > 0)
                {
                    objApiResponse = objAccessDL.UpdateAccess(_Access);

                }
                else
                {
                    objApiResponse = objAccessDL.AddAccess(_Access);
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
        public ApiResponse DeleteAccess(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                AccessDL objAccessDL = new AccessDL();
                objApiResponse = objAccessDL.DeleteAccess(Convert.ToInt32(id));
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