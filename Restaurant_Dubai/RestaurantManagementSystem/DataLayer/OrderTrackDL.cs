
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ELHelper;
using System.Data;
namespace DataLayer
{
    public class OrderTrackDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddOrderTrack(OrderTrack para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[20];
            try
            {
                parameter[0] = new LbSprocParameter("@OrderID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.OrderID);
                parameter[1] = new LbSprocParameter("@Packed", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.Packed);
                parameter[2] = new LbSprocParameter("@DineIn", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DineIn);
                parameter[3] = new LbSprocParameter("@DineInDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.DineInDate);
                parameter[4] = new LbSprocParameter("@DineOut", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DineOut);
                parameter[5] = new LbSprocParameter("@DineOutDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.DineOutDate);
                parameter[6] = new LbSprocParameter("@Delivered", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Delivered);
                parameter[7] = new LbSprocParameter("@DeliveryDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.DeliveryDate);
                parameter[8] = new LbSprocParameter("@DeliveryDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DeliveryDesc);
                parameter[9] = new LbSprocParameter("@StaffID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StaffID);
                parameter[10] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[11] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[12] = new LbSprocParameter("@DeliveryCost", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.DeliveryCost);
                parameter[13] = new LbSprocParameter("@PaymentType", DbType.Byte, LbSprocParameter.LbParameterDirection.INPUT, para.PaymentType);
                parameter[14] = new LbSprocParameter("@Amount", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.Amount);
                parameter[15] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[16] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[17] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[18] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[19] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertOrderTrack", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse UpdateOrderTrack(OrderTrack para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[21];
            try
            {
                parameter[0] = new LbSprocParameter("@DeliveryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.DeliveryID);
                parameter[1] = new LbSprocParameter("@OrderID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.OrderID);
                parameter[2] = new LbSprocParameter("@Packed", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.Packed);
                parameter[3] = new LbSprocParameter("@DineIn", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DineIn);
                parameter[4] = new LbSprocParameter("@DineInDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.DineInDate);
                parameter[5] = new LbSprocParameter("@DineOut", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DineOut);
                parameter[6] = new LbSprocParameter("@DineOutDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.DineOutDate);
                parameter[7] = new LbSprocParameter("@Delivered", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Delivered);
                parameter[8] = new LbSprocParameter("@DeliveryDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.DeliveryDate);
                parameter[9] = new LbSprocParameter("@DeliveryDesc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DeliveryDesc);
                parameter[10] = new LbSprocParameter("@StaffID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StaffID);
                parameter[11] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[12] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[13] = new LbSprocParameter("@DeliveryCost", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.DeliveryCost);
                parameter[14] = new LbSprocParameter("@PaymentType", DbType.Byte, LbSprocParameter.LbParameterDirection.INPUT, para.PaymentType);
                parameter[15] = new LbSprocParameter("@Amount", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.Amount);
                parameter[16] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[17] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[18] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[19] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[20] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateOrderTrack", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse GetOrderTrack()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetOrderTrack", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
               // return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                // throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse DeleteOrderTrack(int DeliveryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@DeliveryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, DeliveryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteOrderTrack", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse GetOrderTrackById(int DeliveryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@DeliveryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, DeliveryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds =elHelper.ExecuteDataset("usp_GetOrderTrackById", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }
    }
}