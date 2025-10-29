
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
    public class OrderController : ApiController
    {
        // [Route("api/Order")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Order> Orderlist = null;
                DataTable dtOrder = new DataTable();
                OrderDL objRestaurantUserDL = new OrderDL();

                objApiResponse = objRestaurantUserDL.GetOrder();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Orderlist = ds.Tables[0].AsEnumerable().Select(x => new Order
                    {
                        TransID = x.Field<Int32>("TransID"),
                        OrderNumber = x.Field<Int32>("OrderNumber"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        TableID = x.Field<Int32>("TableID"),
                        NumOfPerson = x.Field<Int32>("NumOfPerson"),
                        TimeOfArrival = x.Field<string>("TimeOfArrival"),
                        OrderServeTime = x.Field<string>("OrderServeTime"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                    });
                    objApiResponse.Result = Orderlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Orderlist;
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

        // [Route("api/OrderById")]	  

        [HttpGet]
        public ApiResponse OrderById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Order> Orderlist = null;

                DataTable dtOrder = new DataTable();
                OrderDL objRestaurantUserDL = new OrderDL();

                objApiResponse = objRestaurantUserDL.GetOrderById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Orderlist = ds.Tables[0].AsEnumerable().Select(x => new Order
                    {
                        TransID = x.Field<Int32>("TransID"),
                        OrderNumber = x.Field<Int32>("OrderNumber"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        TableID = x.Field<Int32>("TableID"),
                        NumOfPerson = x.Field<Int32>("NumOfPerson"),
                        TimeOfArrival = x.Field<string>("TimeOfArrival"),
                        OrderServeTime = x.Field<string>("OrderServeTime"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                    });
                    objApiResponse.Result = Orderlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Orderlist;
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


        //[Route("api/Order/AddOrder")]
        //[HttpPost]
        //public ApiResponse AddOrder(Order _Order)
        //{
        //    OrderDL objOrderDL = new OrderDL();
        //    ApiResponse objApiResponse = new ApiResponse();
        //    try
        //    {
        //        if (_Order.TransID > 0)
        //        {
        //            objApiResponse = objOrderDL.UpdateOrder(_Order);

        //        }
        //        else
        //        {
        //            objApiResponse = objOrderDL.AddOrder(_Order);
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


        [HttpPost]
        public ApiResponse DeleteOrder(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                OrderDL objOrderDL = new OrderDL();
                objApiResponse = objOrderDL.DeleteOrder(Convert.ToInt32(id));
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