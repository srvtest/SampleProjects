
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
    public class ReviewRatingDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddReviewRating(ReviewRating para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[6];
            try
            {
                parameter[0] = new LbSprocParameter("@Rating", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.Rating);
                parameter[1] = new LbSprocParameter("@Review", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Review);
                parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[3] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[4] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[5] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertReviewRating", parameter);
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
        public ApiResponse UpdateReviewRating(ReviewRating para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[7];
            try
            {
                parameter[0] = new LbSprocParameter("@ReviewRatingID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ReviewRatingID);
                parameter[1] = new LbSprocParameter("@Rating", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.Rating);
                parameter[2] = new LbSprocParameter("@Review", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Review);
                parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[4] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[5] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[6] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateReviewRating", parameter);
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
        public ApiResponse GetReviewRating(int RestaurantID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
            try
            {
                //
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetReviewRating", parameter);
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
        public ApiResponse DeleteReviewRating(int ReviewRatingID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@ReviewRatingID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, ReviewRatingID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteReviewRating", parameter);
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
        public ApiResponse GetReviewRatingById(int ReviewRatingID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@ReviewRatingID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, ReviewRatingID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetReviewRatingById", parameter);
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

        public ApiResponse GetRestaurantRatingReviews(ReviewRating objRestaurant)
        {
            string ResponseMessage = string.Empty;
            int ResponseCode = 0;
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurant.RestaurantID);

            try
            {

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ReviewRatingDL objRestaurantDL = new ReviewRatingDL();


                int RestaurantID = 0;
                ds = elHelper.ExecuteDataset("usp_GetRestaurantRatingReviews", parameter);

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