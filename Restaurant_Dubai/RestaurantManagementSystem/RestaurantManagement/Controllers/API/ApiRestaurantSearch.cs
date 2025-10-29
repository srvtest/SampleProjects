
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
    public class RestaurantSearchController : ApiController
    {
        [Route("api/RestaurantSearch/GetCuisine")]
        public ApiResponse GetCuisine()
        {
            ApiResponse objApiResponse= new ApiResponse();
            try
            {
                CuisineDL obj = new CuisineDL();
                objApiResponse = obj.GetCuisine();
            }
            catch (Exception ex)
            {
                objApiResponse.Message = ex.InnerException + "" + ex.Message + "" + ex.StackTrace;
            }
            return objApiResponse;
        }

      
    }
}