
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
    public class CommissionController : ApiController
    {
        // [Route("api/Commission")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Commission> Commissionlist = null;
                DataTable dtCommission = new DataTable();
                CommissionDL objRestaurantUserDL = new CommissionDL();
                RSession rs = new RSession();
                rs = (RSession)HttpContext.Current.Session["RSession"];
                objApiResponse = objRestaurantUserDL.GetCommission();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Commissionlist = ds.Tables[0].AsEnumerable().Select(x => new Commission
                    {
                        CommissionID = x.Field<Int32>("CommissionID"),
                        RoleID = x.Field<Int32>("RoleID"),
                        UserID = x.Field<Int32>("UserID"),
                        Percentage = x.Field<Decimal>("Percentage"),
                        Desc = x.Field<String>("Desc"),
                        RestaurantID = x.Field<Int32>("RestaurantID")
                    });
                    objApiResponse.Result = Commissionlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Commissionlist;
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

        // [Route("api/CommissionById")]	  

        [HttpGet]
        public ApiResponse CommissionById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Commission> Commissionlist = null;

                DataTable dtCommission = new DataTable();
                CommissionDL objRestaurantUserDL = new CommissionDL();

                objApiResponse = objRestaurantUserDL.GetCommissionById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Commissionlist = ds.Tables[0].AsEnumerable().Select(x => new Commission
                    {
                        CommissionID = x.Field<Int32>("CommissionID"),
                        RoleID = x.Field<Int32>("RoleID"),
                        UserID = x.Field<Int32>("UserID"),
                        Percentage = x.Field<Decimal>("Percentage"),
                        Desc = x.Field<String>("Desc"),
                        RestaurantID = x.Field<Int32>("RestaurantID")
                    });
                    objApiResponse.Result = Commissionlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Commissionlist;
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


        [Route("api/Commission/AddCommission")]
        [HttpPost]
        public ApiResponse AddCommission(Commission _Commission)
        {
            CommissionDL objCommissionDL = new CommissionDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Commission.CommissionID > 0)
                {
                    objApiResponse = objCommissionDL.UpdateCommission(_Commission);

                }
                else
                {
                    objApiResponse = objCommissionDL.AddCommission(_Commission);
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
        public ApiResponse DeleteCommission(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                CommissionDL objCommissionDL = new CommissionDL();
                objApiResponse = objCommissionDL.DeleteCommission(Convert.ToInt32(id));
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