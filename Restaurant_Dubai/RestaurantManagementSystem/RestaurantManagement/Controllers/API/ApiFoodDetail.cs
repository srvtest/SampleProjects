
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
    public class FoodDetailController : ApiController
    {
       // [Route("api/FoodDetail")]
        [Route("api/FoodDetail/GetFoodDetail")]
        [HttpPost]
        public ApiResponse GetFoodDetail(int Restaurant)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<FoodDetail> FoodDetaillist = null;
                DataTable dtFoodDetail = new DataTable();
                FoodDetailDL objRestaurantUserDL = new FoodDetailDL();

                objApiResponse = objRestaurantUserDL.GetFoodDetail(Restaurant);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    FoodDetaillist = ds.Tables[0].AsEnumerable().Select(x => new FoodDetail
                    {
                        FoodID = x.Field<Int32>("FoodID"),
                        Title = x.Field<String>("Title"),
                        Description = x.Field<String>("Description"),
                        Price = x.Field<Decimal>("Price"),
                        DiscountPrice = x.Field<Decimal>("DiscountPrice"),
                        FoodCategoryID = x.Field<Int32>("FoodCategoryID"),
                        Quantity = x.Field<Int32>("Quantity"),
                        FoodType = x.Field<String>("FoodType"),
                        //images = x.Field<String>("images"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        SearchTag = x.Field<String>("SearchTag"),
                       // SpecialFoodID = x.Field<Byte>("SpecialFoodID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                       // ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                       // CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = FoodDetaillist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = FoodDetaillist;
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


        [Route("api/FoodDetail/FoodDetailById")]
        [HttpGet]
        public ApiResponse FoodDetailById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<FoodDetail> FoodDetaillist = null;

                DataTable dtFoodDetail = new DataTable();
                FoodDetailDL objRestaurantUserDL = new FoodDetailDL();

                objApiResponse = objRestaurantUserDL.GetFoodDetailById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    FoodDetaillist = ds.Tables[0].AsEnumerable().Select(x => new FoodDetail
                    {
                        FoodID = x.Field<Int32>("FoodID"),
                        Title = x.Field<String>("Title"),
                        Description = x.Field<String>("Description"),
                        Price = x.Field<Decimal>("Price"),
                        DiscountPrice = x.Field<Decimal>("DiscountPrice"),
                        FoodCategoryID = x.Field<Int32>("FoodCategoryID"),
                        Quantity = x.Field<Int32>("Quantity"),
                        FoodType = x.Field<String>("FoodType"),
                        //images = x.Field<String>("images"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        SearchTag = x.Field<String>("SearchTag"),
                        SpecialFoodID = x.Field<Byte>("SpecialFoodID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = FoodDetaillist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = FoodDetaillist;
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


        [Route("api/FoodDetail/AddFoodDetail")]
        [HttpPost]
        public ApiResponse AddFoodDetail(FoodDetail _FoodDetail)
        {
            FoodDetailDL objFoodDetailDL = new FoodDetailDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_FoodDetail.FoodID > 0)
                {
                    objApiResponse = objFoodDetailDL.UpdateFoodDetail(_FoodDetail);

                }
                else
                {
                    objApiResponse = objFoodDetailDL.AddFoodDetail(_FoodDetail);
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


      
        [Route("api/FoodDetail/DeleteFoodDetail")]
        [HttpPost]
        public ApiResponse DeleteFoodDetail(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                FoodDetailDL objFoodDetailDL = new FoodDetailDL();
                objApiResponse = objFoodDetailDL.DeleteFoodDetail(Convert.ToInt32(id));
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