
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
    public class TaxDL
    {
        ApiResponse objApiResponse = new ApiResponse();

        public ApiResponse AddTax(Tax para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[5];
            try
            {
                parameter[0] = new LbSprocParameter("@TaxInPercentage", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, para.TaxInPercentage);
                //parameter[1] = new LbSprocParameter("@Amount", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, para.Amount);
                parameter[1] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[2] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[3] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[4] = new LbSprocParameter("@TaxName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TaxName);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertTax", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        public ApiResponse UpdateTax(Tax para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[6];
            try
            {
                parameter[0] = new LbSprocParameter("@TaxID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.TaxID);
                parameter[1] = new LbSprocParameter("@TaxInPercentage", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.TaxInPercentage);
                //parameter[2] = new LbSprocParameter("@Amount", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.Amount);
                parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[3] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[4] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[5] = new LbSprocParameter("@TaxName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TaxName);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result=elHelper.ExecuteScalar("usp_UpdateTax", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }
        public ApiResponse GetTax()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetTax", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        public ApiResponse DeleteTax(int TaxID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TaxID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TaxID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteTax", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        public ApiResponse GetTaxById(int TaxID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@TaxID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TaxID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds =elHelper.ExecuteDataset("usp_GetTaxById", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

    }
}