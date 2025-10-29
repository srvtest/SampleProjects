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
    public class RestaurantUserController : ApiController
    {
        // [Route("api/RestaurantUser")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<RestaurantUser> RestaurantUserlist = null;
                DataTable dtRestaurantUser = new DataTable();
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();

                objApiResponse = objRestaurantUserDL.GetRestaurantUser();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    RestaurantUserlist = ds.Tables[0].AsEnumerable().Select(x => new RestaurantUser
                    {
                        UserID = x.Field<Int32>("UserID"),
                        Firstname = x.Field<String>("Firstname"),
                        LastName = x.Field<String>("LastName"),
                        Gender = x.Field<int>("Gender"),
                        Email = x.Field<String>("Email"),
                        Mobile = x.Field<String>("Mobile"),
                        Address = x.Field<String>("Address"),
                        OfficeAddress = x.Field<String>("OfficeAddress"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        IpAddress = x.Field<String>("IpAddress"),
                        RolesID = x.Field<Int32>("RolesID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                        //AspNetUserID = x.Field<String>("AspNetUserID"),
                        //  Password = x.Field<String>("Password"),
                    });
                    objApiResponse.Result = RestaurantUserlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = RestaurantUserlist;
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

        // [Route("api/RestaurantUserById")]	  

        [HttpGet]
        public ApiResponse RestaurantUserById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<RestaurantUser> RestaurantUserlist = null;

                DataTable dtRestaurantUser = new DataTable();
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();

                objApiResponse = objRestaurantUserDL.GetRestaurantUserById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    RestaurantUserlist = ds.Tables[0].AsEnumerable().Select(x => new RestaurantUser
                    {
                        UserID = x.Field<Int32>("UserID"),
                        Firstname = x.Field<String>("Firstname"),
                        LastName = x.Field<String>("LastName"),
                        Gender = x.Field<int>("Gender"),
                        Email = x.Field<String>("Email"),
                        Mobile = x.Field<String>("Mobile"),
                        Address = x.Field<String>("Address"),
                        OfficeAddress = x.Field<String>("OfficeAddress"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        IpAddress = x.Field<String>("IpAddress"),
                        RolesID = x.Field<Int32>("RolesID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                        //AspNetUserID = x.Field<String>("AspNetUserID"),
                        // Password = x.Field<String>("Password"),
                    });
                    objApiResponse.Result = RestaurantUserlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = RestaurantUserlist;
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


        [Route("api/RestaurantUser/AddRestaurantUser")]
        [HttpPost]
        public ApiResponse AddRestaurantUser(RestaurantUser _RestaurantUser)
        {
            RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_RestaurantUser.UserID > 0)
                {
                    objApiResponse = objRestaurantUserDL.UpdateRestaurantUser(_RestaurantUser);

                }
                else
                {
                    objApiResponse = objRestaurantUserDL.AddRestaurantUser(_RestaurantUser);
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
        public ApiResponse DeleteRestaurantUser(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                objApiResponse = objRestaurantUserDL.DeleteRestaurantUser(Convert.ToInt32(id));
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