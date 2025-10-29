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
    public class CuisineDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddCuisine(Cuisine para)
        {

            LbSprocParameter[] parameter = new LbSprocParameter[3];
            try
            {
               // parameter[0] = new LbSprocParameter("@CuisineId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CuisineId);
                parameter[0] = new LbSprocParameter("@CuisineType", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CuisineType);
                parameter[1] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[2] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
               // parameter[3] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCuisine", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
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

        public ApiResponse UpdateCuisine(Cuisine para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[4];
            try
            {
                parameter[0] = new LbSprocParameter("@CuisineId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CuisineId);
                parameter[1] = new LbSprocParameter("@CuisineType", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CuisineType);
                parameter[2] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[3] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                //parameter[4] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateCuisine", parameter);
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

        public ApiResponse GetCuisine()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetCuisine", parameter);
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

        public ApiResponse DeleteCuisine(int CuisineId)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CuisineId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CuisineId);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteCuisine", parameter);
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

        public ApiResponse GetCuisineById(int CuisineId)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CuisineId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CuisineId);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetCuisineById", parameter);
                // return ds;
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
    }
}
