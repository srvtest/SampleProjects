
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
    public class TableReservationDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddTableReservation(TableReservation para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[9];
            try
            {
                parameter[0] = new LbSprocParameter("@TableNumberID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.TableNumberID);
                parameter[1] = new LbSprocParameter("@BookStartTime", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.BookStartTime);
               // parameter[2] = new LbSprocParameter("@BookEndTime", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.BookEndTime);
                parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[3] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[4] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[5] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[6] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[7] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                parameter[8] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertTableReservation", parameter);
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

        public ApiResponse UpdateTableReservation(TableReservation para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[10];
            try
            {
                parameter[0] = new LbSprocParameter("@TableReservationID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.TableReservationID);
                parameter[1] = new LbSprocParameter("@TableNumberID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.TableNumberID);
                parameter[2] = new LbSprocParameter("@BookStartTime", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.BookStartTime);
               // parameter[3] = new LbSprocParameter("@BookEndTime", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.BookEndTime);
                parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[4] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[5] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[6] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[7] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[8] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                parameter[9] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateTableReservation", parameter);
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

        public ApiResponse GetTableReservation()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetTableReservation", parameter);
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

        public ApiResponse DeleteTableReservation(int TableReservationID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TableReservationID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TableReservationID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteTableReservation", parameter);
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

        public ApiResponse GetTableReservationById(int TableReservationID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TableReservationID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TableReservationID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetTableReservationById", parameter);
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