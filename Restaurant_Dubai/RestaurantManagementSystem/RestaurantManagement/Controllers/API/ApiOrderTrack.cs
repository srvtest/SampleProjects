
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
    public class OrderTrackController : ApiController
    {
        // [Route("api/OrderTrack")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<OrderTrack> OrderTracklist = null;
                DataTable dtOrderTrack = new DataTable();
                OrderTrackDL objRestaurantUserDL = new OrderTrackDL();

                objApiResponse = objRestaurantUserDL.GetOrderTrack();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    OrderTracklist = ds.Tables[0].AsEnumerable().Select(x => new OrderTrack
                    {
                        DeliveryID = x.Field<Int32>("DeliveryID"),
                        OrderID = x.Field<Int32>("OrderID"),
                        Packed = x.Field<Boolean>("Packed"),
                        DineIn = x.Field<String>("DineIn"),
                        DineInDate = x.Field<DateTime>("DineInDate"),
                        DineOut = x.Field<String>("DineOut"),
                        DineOutDate = x.Field<DateTime>("DineOutDate"),
                        Delivered = x.Field<String>("Delivered"),
                        DeliveryDate = x.Field<DateTime>("DeliveryDate"),
                        DeliveryDesc = x.Field<String>("DeliveryDesc"),
                        StaffID = x.Field<Int32>("StaffID"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        DeliveryCost = x.Field<decimal>("DeliveryCost"),
                        PaymentType = x.Field<Byte>("PaymentType"),
                        Amount = x.Field<Decimal>("Amount"),
                        Address = x.Field<String>("Address"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = OrderTracklist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = OrderTracklist;
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

        // [Route("api/OrderTrackById")]	  

        [HttpGet]
        public ApiResponse OrderTrackById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<OrderTrack> OrderTracklist = null;

                DataTable dtOrderTrack = new DataTable();
                OrderTrackDL objRestaurantUserDL = new OrderTrackDL();

                objApiResponse = objRestaurantUserDL.GetOrderTrackById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    OrderTracklist = ds.Tables[0].AsEnumerable().Select(x => new OrderTrack
                    {
                        DeliveryID = x.Field<Int32>("DeliveryID"),
                        OrderID = x.Field<Int32>("OrderID"),
                        Packed = x.Field<Boolean>("Packed"),
                        DineIn = x.Field<String>("DineIn"),
                        DineInDate = x.Field<DateTime>("DineInDate"),
                        DineOut = x.Field<String>("DineOut"),
                        DineOutDate = x.Field<DateTime>("DineOutDate"),
                        Delivered = x.Field<String>("Delivered"),
                        DeliveryDate = x.Field<DateTime>("DeliveryDate"),
                        DeliveryDesc = x.Field<String>("DeliveryDesc"),
                        StaffID = x.Field<Int32>("StaffID"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        DeliveryCost = x.Field<decimal>("DeliveryCost"),
                        PaymentType = x.Field<Byte>("PaymentType"),
                        Amount = x.Field<Decimal>("Amount"),
                        Address = x.Field<String>("Address"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = OrderTracklist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = OrderTracklist;
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


        [Route("api/OrderTrack/AddOrderTrack")]
        [HttpPost]
        public ApiResponse AddOrderTrack(OrderTrack _OrderTrack)
        {
            OrderTrackDL objOrderTrackDL = new OrderTrackDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_OrderTrack.DeliveryID > 0)
                {
                    objApiResponse = objOrderTrackDL.UpdateOrderTrack(_OrderTrack);

                }
                else
                {
                    objApiResponse = objOrderTrackDL.AddOrderTrack(_OrderTrack);
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
        public ApiResponse DeleteOrderTrack(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                OrderTrackDL objOrderTrackDL = new OrderTrackDL();
                objApiResponse = objOrderTrackDL.DeleteOrderTrack(Convert.ToInt32(id));
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