
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
    public class RestaurantController : ApiController
    {
        // [Route("api/Restaurant")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Restaurant> Restaurantlist = null;
                DataTable dtRestaurant = new DataTable();
                RestaurantDL objRestaurantUserDL = new RestaurantDL();

                objApiResponse = objRestaurantUserDL.GetRestaurant();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Restaurantlist = ds.Tables[0].AsEnumerable().Select(x => new Restaurant
                    {
                        RestaurantID = x.Field<Int32>("RestaurantId"),
                        Name = x.Field<String>("Name"),
                        Logo = x.Field<String>("Logo"),
                        MAP = x.Field<String>("MAP"),
                        Address = x.Field<String>("Address"),
                        Contact = x.Field<String>("Contact"),
                        Policy = x.Field<String>("Policy"),
                        Email = x.Field<String>("email"),
                        CityID = x.Field<Int32>("CityID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = Restaurantlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Restaurantlist;
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

        // [Route("api/RestaurantById")]	  

        [HttpGet]
        public ApiResponse RestaurantById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Restaurant> Restaurantlist = null;

                DataTable dtRestaurant = new DataTable();
                RestaurantDL objRestaurantUserDL = new RestaurantDL();

                objApiResponse = objRestaurantUserDL.GetRestaurantById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Restaurantlist = ds.Tables[0].AsEnumerable().Select(x => new Restaurant
                    {
                        RestaurantID = x.Field<Int32>("RestaurantId"),
                        Name = x.Field<String>("Name"),
                        Logo = x.Field<String>("Logo"),
                        MAP = x.Field<String>("MAP"),
                        Address = x.Field<String>("Address"),
                        Contact = x.Field<String>("Contact"),
                        Policy = x.Field<String>("Policy"),
                        Email = x.Field<String>("email"),
                        CityID = x.Field<Int32>("CityID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = Restaurantlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Restaurantlist;
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


        [Route("api/Restaurant/AddRestaurant")]
        [HttpPost]
        public ApiResponse AddRestaurant(Restaurant _Restaurant)
        {
            RestaurantDL objRestaurantDL = new RestaurantDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Restaurant.RestaurantID > 0)
                {
                    objApiResponse = objRestaurantDL.UpdateRestaurant(_Restaurant);

                }
                else
                {
                    objApiResponse = objRestaurantDL.AddRestaurant(_Restaurant);
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
        public ApiResponse DeleteRestaurant(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                RestaurantDL objRestaurantDL = new RestaurantDL();
                objApiResponse = objRestaurantDL.DeleteRestaurant(Convert.ToInt32(id));
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