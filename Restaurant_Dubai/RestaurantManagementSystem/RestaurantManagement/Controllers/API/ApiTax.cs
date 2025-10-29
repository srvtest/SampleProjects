
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
    public class TaxController : ApiController
    {
        // [Route("api/Tax")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Tax> Taxlist = null;
                DataTable dtTax = new DataTable();
                TaxDL objRestaurantUserDL = new TaxDL();

                objApiResponse = objRestaurantUserDL.GetTax();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Taxlist = ds.Tables[0].AsEnumerable().Select(x => new Tax
                    {
                        TaxID = x.Field<Int32>("TaxID"),
                        TaxInPercentage = x.Field<Decimal>("TaxInPercentage"),
                        Amount = x.Field<Decimal>("Amount"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = Taxlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Taxlist;
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

        // [Route("api/TaxById")]	  

        [HttpGet]
        public ApiResponse TaxById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Tax> Taxlist = null;

                DataTable dtTax = new DataTable();
                TaxDL objRestaurantUserDL = new TaxDL();

                objApiResponse = objRestaurantUserDL.GetTaxById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Taxlist = ds.Tables[0].AsEnumerable().Select(x => new Tax
                    {
                        TaxID = x.Field<Int32>("TaxID"),
                        TaxInPercentage = x.Field<Decimal>("TaxInPercentage"),
                        Amount = x.Field<Decimal>("Amount"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = Taxlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Taxlist;
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


        [Route("api/Tax/AddTax")]
        [HttpPost]
        public ApiResponse AddTax(Tax _Tax)
        {
            TaxDL objTaxDL = new TaxDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Tax.TaxID > 0)
                {
                    objApiResponse = objTaxDL.UpdateTax(_Tax);

                }
                else
                {
                    objApiResponse = objTaxDL.AddTax(_Tax);
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
        public ApiResponse DeleteTax(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                TaxDL objTaxDL = new TaxDL();
                objApiResponse = objTaxDL.DeleteTax(Convert.ToInt32(id));
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