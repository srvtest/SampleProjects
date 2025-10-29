using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ELHelper;
using System.Data;
using Utility;

namespace DataLayer
{
    public class OrderDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddUpdateOrder(Order para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[12];
            parameter[0] = new LbSprocParameter("@TransID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.TransID);
            parameter[1] = new LbSprocParameter("@OrderNumber", DbType.Int64, LbSprocParameter.LbParameterDirection.INPUT, para.OrderNumber);
            parameter[2] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
            parameter[3] = new LbSprocParameter("@TableID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.TableID);
            parameter[4] = new LbSprocParameter("@NumOfPerson", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.NumOfPerson);
            parameter[5] = new LbSprocParameter("@TimeOfArrival", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TimeOfArrival);
            parameter[6] = new LbSprocParameter("@OrderServeTime", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OrderServeTime);
            parameter[7] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
            parameter[8] = new LbSprocParameter("@OrderDetailXML", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, CommonEnums.GetXMLFromObject(para.lstOrderDetails));
            parameter[9] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
            parameter[10] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
            parameter[11] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                ds = elHelper.ExecuteDataset("usp_InsertOrder", parameter);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 1)
                        objApiResponse.Result = ds.Tables[1];
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
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
        //public ApiResponse UpdateOrder(Order para)
        //{
        //    LbSprocParameter[] parameter = new LbSprocParameter[0];
        //    try
        //    {
        //        ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
        //        objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateOrder", parameter);
        //        objApiResponse.Message = "";
        //        objApiResponse.StatusCode = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = ex.InnerException;
        //        objApiResponse.Message = ex.Message;
        //        objApiResponse.StatusCode = ex.HResult;
        //        //throw ex;
        //    }
        //    return objApiResponse;
        //}
        public ApiResponse GetOrder()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetOrder", parameter);
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
        public ApiResponse DeleteOrder(int TransID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TransID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TransID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteOrder", parameter);
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
        public ApiResponse GetOrderById(int TransID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TransID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TransID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetOrderById", parameter);
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

        public ApiResponse GetPrice(int foodId)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@FoodID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, foodId);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetFoodPriceById", parameter);
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

        //public ApiResponse GetOrderByCustomerID(Order objOrder)
        //{
        //    LbSprocParameter[] parameter = new LbSprocParameter[1];

        //    try
        //    {
        //        parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objOrder.CustomerID);
               
        //        ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
        //        objApiResponse.Result = elHelper.ExecuteScalar("usp_GetOrderByCustomerID", parameter);
        //        objApiResponse.Message = "";
        //        objApiResponse.StatusCode = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = ex.InnerException;
        //        objApiResponse.Message = ex.Message;
        //        objApiResponse.StatusCode = ex.HResult;
        //        // throw ex;
        //    }
        //    return objApiResponse;
        //}


        public ApiResponse GetOrderByCustomerID(Order objOrder)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objOrder.CustomerID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                ds = elHelper.ExecuteDataset("usp_GetOrderByCustomerID", parameter);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    }
                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            objApiResponse.Result = ds.Tables[1];
                        }
                        else
                        {
                            objApiResponse.Message = "No record Found.";
                            objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                        }

                    }
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