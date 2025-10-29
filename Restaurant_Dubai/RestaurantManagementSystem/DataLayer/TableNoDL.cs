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
    public class TableNoDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddTableNo(TableNo para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[9];
            try
            {
                parameter[0] = new LbSprocParameter("@TableNumber", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TableNumber);
                parameter[1] = new LbSprocParameter("@TableCapacity", DbType.Byte, LbSprocParameter.LbParameterDirection.INPUT, para.TableCapacity);
                parameter[2] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[3] = new LbSprocParameter("@IsBusy", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsBusy);
                parameter[4] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[5] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[6] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[7] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[8] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertTableNo", parameter);
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

        public ApiResponse UpdateTableNo(TableNo para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[10];
            try
            {
                parameter[0] = new LbSprocParameter("@TableNumberID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.TableNumberID);
                parameter[1] = new LbSprocParameter("@TableNumber", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TableNumber);
                parameter[2] = new LbSprocParameter("@TableCapacity", DbType.Byte, LbSprocParameter.LbParameterDirection.INPUT, para.TableCapacity);
                parameter[3] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[4] = new LbSprocParameter("@IsBusy", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsBusy);
                parameter[5] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[6] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[7] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[8] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[9] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateTableNo", parameter);
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

        public ApiResponse GetTableNo()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetTableNo", parameter);
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

        public ApiResponse DeleteTableNo(int TableNumberID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TableNumberID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TableNumberID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteTableNo", parameter);
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

        public ApiResponse GetTableNoById(int TableNumberID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TableNumberID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TableNumberID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds =elHelper.ExecuteDataset("usp_GetTableNoById", parameter);
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



        public ApiResponse GetTableNoByRestaurantId(TableNo objTableNo)
        {
            string ResponseMessage = string.Empty;
            int ResponseCode = 0;
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objTableNo.RestaurantID);

           try
            {

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                TableNoDL objRestaurantDL = new TableNoDL();


                int RestaurantID = 0;
                ds = elHelper.ExecuteDataset("usp_GetTableNoByRestaurantId", parameter);

                if (ds != null)
                {
                    if (ds.Tables.Count > 1)
                    {
                        

                        objApiResponse.Result = ds.Tables[1];
                    }
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
            }
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