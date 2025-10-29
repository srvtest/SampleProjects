
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
    public class CountryController : ApiController
    {
        // [Route("api/Country")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Country> Countrylist = null;
                DataTable dtCountry = new DataTable();
                CountryDL objRestaurantUserDL = new CountryDL();

                objApiResponse = objRestaurantUserDL.GetCountry();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Countrylist = ds.Tables[0].AsEnumerable().Select(x => new Country
                    {
                        CountryID = x.Field<Int32>("CountryID"),
                        CountryName = x.Field<String>("CountryName"),
                        IsActive = x.Field<Boolean>("IsActive"),
                    });
                    objApiResponse.Result = Countrylist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Countrylist;
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

        // [Route("api/CountryById")]	  

        [HttpGet]
        public ApiResponse CountryById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Country> Countrylist = null;

                DataTable dtCountry = new DataTable();
                CountryDL objRestaurantUserDL = new CountryDL();

                objApiResponse = objRestaurantUserDL.GetCountryById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Countrylist = ds.Tables[0].AsEnumerable().Select(x => new Country
                    {
                        CountryID = x.Field<Int32>("CountryID"),
                        CountryName = x.Field<String>("CountryName"),
                        IsActive = x.Field<Boolean>("IsActive"),
                    });
                    objApiResponse.Result = Countrylist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Countrylist;
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


        [Route("api/Country/AddCountry")]
        [System.Web.Http.HttpPost]
        public ApiResponse AddCountry(Country _Country)
        {
            CountryDL objCountryDL = new CountryDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Country.CountryID > 0)
                {
                    objApiResponse = objCountryDL.UpdateCountry(_Country);

                }
                else
                {
                    objApiResponse = objCountryDL.AddCountry(_Country);
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
        public ApiResponse DeleteCountry(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                CountryDL objCountryDL = new CountryDL();
                objApiResponse = objCountryDL.DeleteCountry(Convert.ToInt32(id));
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