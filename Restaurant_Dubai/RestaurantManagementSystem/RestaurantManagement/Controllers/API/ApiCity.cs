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
    //[RoutePrefix("api/customer")]
    public class CityController : ApiController
    {
        [Route("api/City")]
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<City> Citylist = null;
                DataTable dtCity = new DataTable();
                CityDL objRestaurantUserDL = new CityDL();

                objApiResponse = objRestaurantUserDL.GetCity();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Citylist = ds.Tables[0].AsEnumerable().Select(x => new City
                    {
                        CityID = x.Field<int>("CityID"),
                        CityName = x.Field<string>("CityName"),
                        CountryID = x.Field<int>("CountryID"),
                        StateID = x.Field<int>(" StateID"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                    objApiResponse.Result = Citylist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Citylist;
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

        // [Route("api/CityById")]
        //http://localhost:3125/api/city/CityById?id=1
        [HttpGet]
        public ApiResponse CityById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<City> Citylist = null;

                DataTable dtCity = new DataTable();
                CityDL objRestaurantUserDL = new CityDL();

                objApiResponse = objRestaurantUserDL.GetCityById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Citylist = ds.Tables[0].AsEnumerable().Select(x => new City
                    {
                        CityID = x.Field<int>("CityID"),
                        CityName = x.Field<string>("CityName"),
                        CountryID = x.Field<int>("CountryID"),
                        StateID = x.Field<int>(" StateID"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                    objApiResponse.Result = Citylist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Citylist;
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

        // insert and update
        // how to call

        //        {
        //  "cityID":"0",
        //  "cityName": "mycity",
        //  "isActive": "true"
        //}
        //[[Route("api/AjaxAPI/AjaxMethod")]]
        [Route("api/City/AddCity")]
        // [AcceptVerbs("POST")]
       [System.Web.Http.HttpPost]


        public ApiResponse AddCity(City _City)
        {
            //City ct = _City.ToMyCollection();
            CityDL objCityDL = new CityDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_City.CityID != null && _City.CityID > 0)
                {
                    objApiResponse = objCityDL.UpdateCity(_City);

                }
                else
                {
                    objApiResponse = objCityDL.AddCity(_City);
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

        //[Route("api/DeleteCity")]
        // how to call
        //http://localhost:3125/api/city/DeleteCity?id=21
        //[HttpPost]
        //public ApiResponse DeleteCity(int? id)
        //{
        //    ApiResponse objApiResponse = new ApiResponse();
        //    try
        //    {
        //        CityDL objCityDL = new CityDL();
        //        objApiResponse = objCityDL.DeleteCity(Convert.ToInt32(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = null;
        //        objApiResponse.StatusCode = ex.HResult;
        //        objApiResponse.Message = ex.Message;
        //    }
        //    return objApiResponse;
        //}
    }
}