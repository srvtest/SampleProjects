
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
    
    public class FoodCategoryController : ApiController
    {
        // [Route("api/FoodCategory")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<FoodCategory> FoodCategorylist = null;
                DataTable dtFoodCategory = new DataTable();
                FoodCategoryDL objRestaurantUserDL = new FoodCategoryDL();

                objApiResponse = objRestaurantUserDL.GetFoodCategory();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    FoodCategorylist = ds.Tables[0].AsEnumerable().Select(x => new FoodCategory
                    {
                        FoodCategoryID = x.Field<Int32>("FoodCategoryID"),
                        CategoryTitle = x.Field<String>("CategoryTitle"),
                        Description = x.Field<String>("Description"),
                        Images = x.Field<string>("Images"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = FoodCategorylist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = FoodCategorylist;
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

        // [Route("api/FoodCategoryById")]	  

        [HttpGet]
        public ApiResponse FoodCategoryById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<FoodCategory> FoodCategorylist = null;

                DataTable dtFoodCategory = new DataTable();
                FoodCategoryDL objRestaurantUserDL = new FoodCategoryDL();

                objApiResponse = objRestaurantUserDL.GetFoodCategoryById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    FoodCategorylist = ds.Tables[0].AsEnumerable().Select(x => new FoodCategory
                    {
                        FoodCategoryID = x.Field<Int32>("FoodCategoryID"),
                        CategoryTitle = x.Field<String>("CategoryTitle"),
                        Description = x.Field<String>("Description"),
                        Images = x.Field<string>("Images"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = FoodCategorylist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = FoodCategorylist;
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

        //[HttpGet]
        //public ApiResponse FoodCategoryById(int id)
        //{
        //    ApiResponse objApiResponse = new ApiResponse();
        //    try
        //    {
        //        IEnumerable<FoodCategory> FoodCategorylist = null;

        //        DataTable dtFoodCategory = new DataTable();
        //        FoodCategoryDL objRestaurantUserDL = new FoodCategoryDL();

        //        objApiResponse = objRestaurantUserDL.GetFoodCategoryById(id);

        //        if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
        //        {
        //            DataSet ds = (DataSet)objApiResponse.Result;
        //            FoodCategorylist = ds.Tables[0].AsEnumerable().Select(x => new FoodCategory
        //            {
        //                FoodCategoryID = x.Field<Int32>("FoodCategoryID"),
        //                CategoryTitle = x.Field<String>("CategoryTitle"),
        //                Description = x.Field<String>("Description"),
        //                Images = x.Field<string>("Images"),
        //                RestaurantID = x.Field<Int32>("RestaurantID"),
        //                ModifiedBy = x.Field<Int32>("ModifiedBy"),
        //                ModifiedDate = x.Field<DateTime>("ModifiedDate"),
        //                CreatedBy = x.Field<Int32>("CreatedBy"),
        //                CreatedDate = x.Field<DateTime>("CreatedDate")
        //            });
        //            objApiResponse.Result = FoodCategorylist;
        //            objApiResponse.StatusCode = 1;
        //            objApiResponse.Message = "Data Received successfully";
        //        }
        //        else
        //        {
        //            objApiResponse.Result = FoodCategorylist;
        //            objApiResponse.StatusCode = 1;
        //            objApiResponse.Message = "Data Not found";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = null;
        //        objApiResponse.StatusCode = ex.HResult;
        //        objApiResponse.Message = ex.Message;
        //    }
        //    return objApiResponse;

        //}

        [Route("api/FoodCategory/AddFoodCategory")]
        [HttpPost]
        public ApiResponse AddFoodCategory(FoodCategory _FoodCategory)
        {
            FoodCategoryDL objFoodCategoryDL = new FoodCategoryDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_FoodCategory.FoodCategoryID > 0)
                {
                    objApiResponse = objFoodCategoryDL.UpdateFoodCategory(_FoodCategory);

                }
                else
                {
                    objApiResponse = objFoodCategoryDL.AddFoodCategory(_FoodCategory);
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
        public ApiResponse DeleteFoodCategory(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                FoodCategoryDL objFoodCategoryDL = new FoodCategoryDL();
                objApiResponse = objFoodCategoryDL.DeleteFoodCategory(Convert.ToInt32(id));
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