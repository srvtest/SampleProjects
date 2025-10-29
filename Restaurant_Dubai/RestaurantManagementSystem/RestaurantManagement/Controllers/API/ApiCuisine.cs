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
    public class CuisineController : ApiController
    {
        //[Route("api/Cuisine")]
        //public ApiResponse Get()
        //{
        //    ApiResponse objApiResponse = new ApiResponse();
        //    try
        //    {
        //        IEnumerable<City> Citylist = null;
        //        DataTable dtCity = new DataTable();
        //        CityDL objRestaurantUserDL = new CityDL();

        //        objApiResponse = objRestaurantUserDL.GetCity();

        //        if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
        //        {
        //            DataSet ds = (DataSet)objApiResponse.Result;
        //            Citylist = ds.Tables[0].AsEnumerable().Select(x => new City
        //            {
        //                CityID = x.Field<int>("CityID"),
        //                CityName = x.Field<string>("CityName"),
        //                IsActive = x.Field<bool>("IsActive")
        //            });
        //            objApiResponse.Result = Citylist;
        //            objApiResponse.StatusCode = 0;
        //            objApiResponse.Message = "Data Received successfully";
        //        }
        //        else
        //        {
        //            objApiResponse.Result = Citylist;
        //            objApiResponse.StatusCode = 1;
        //            objApiResponse.Message = "Data Not found";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = null;
        //        objApiResponse.StatusCode = ex.HResult;
        //        objApiResponse.Message = ex.Message;
        //    }
        //    return objApiResponse;

        //}

        //// [Route("api/CuisineById")]
        ////http://localhost:3125/api/city/CityById?id=1
        //[HttpGet]
        //public ApiResponse CityById(int id)
        //{
        //    ApiResponse objApiResponse = new ApiResponse();
        //    try
        //    {
        //        IEnumerable<City> Citylist = null;

        //        DataTable dtCity = new DataTable();
        //        CityDL objRestaurantUserDL = new CityDL();

        //        objApiResponse = objRestaurantUserDL.GetCityById(id);

        //        if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
        //        {
        //            DataSet ds = (DataSet)objApiResponse.Result;
        //            Citylist = ds.Tables[0].AsEnumerable().Select(x => new City
        //            {
        //                CityID = x.Field<int>("CityID"),
        //                CityName = x.Field<string>("CityName"),
        //                IsActive = x.Field<bool>("IsActive")
        //            });
        //            objApiResponse.Result = Citylist;
        //            objApiResponse.StatusCode = 1;
        //            objApiResponse.Message = "Data Received successfully";
        //        }
        //        else
        //        {
        //            objApiResponse.Result = Citylist;
        //            objApiResponse.StatusCode = 1;
        //            objApiResponse.Message = "Data Not found";
        //        }

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