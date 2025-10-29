
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
    public class ReviewRatingController : ApiController
    {
        // [Route("api/ReviewRating")]	  
        [Route("api/ReviewRating/GetReviewRating")]
        [HttpPost]
        public ApiResponse GetReviewRating(int RestaurantID)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<ReviewRating> ReviewRatinglist = null;
                DataTable dtReviewRating = new DataTable();
                ReviewRatingDL objRestaurantUserDL = new ReviewRatingDL();

                objApiResponse = objRestaurantUserDL.GetReviewRating(RestaurantID);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    ReviewRatinglist = ds.Tables[0].AsEnumerable().Select(x => new ReviewRating
                    {
                        ReviewRatingID = x.Field<Int32>("ReviewRatingID"),
                        Rating = x.Field<Int32>("Rating"),
                        Review = x.Field<String>("Review"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = ReviewRatinglist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = ReviewRatinglist;
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

        // [Route("api/ReviewRatingById")]	  

        [HttpGet]
        public ApiResponse ReviewRatingById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<ReviewRating> ReviewRatinglist = null;

                DataTable dtReviewRating = new DataTable();
                ReviewRatingDL objRestaurantUserDL = new ReviewRatingDL();

                objApiResponse = objRestaurantUserDL.GetReviewRatingById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    ReviewRatinglist = ds.Tables[0].AsEnumerable().Select(x => new ReviewRating
                    {
                        ReviewRatingID = x.Field<Int32>("ReviewRatingID"),
                        Rating = x.Field<Int32>("Rating"),
                        Review = x.Field<String>("Review"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = ReviewRatinglist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = ReviewRatinglist;
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


        [Route("api/ReviewRating/AddReviewRating")]
        [HttpPost]
        public ApiResponse AddReviewRating(ReviewRating _ReviewRating)
        {
            ReviewRatingDL objReviewRatingDL = new ReviewRatingDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_ReviewRating.ReviewRatingID > 0)
                {
                    objApiResponse = objReviewRatingDL.UpdateReviewRating(_ReviewRating);

                }
                else
                {
                    objApiResponse = objReviewRatingDL.AddReviewRating(_ReviewRating);
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
        public ApiResponse DeleteReviewRating(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                ReviewRatingDL objReviewRatingDL = new ReviewRatingDL();
                objApiResponse = objReviewRatingDL.DeleteReviewRating(Convert.ToInt32(id));
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