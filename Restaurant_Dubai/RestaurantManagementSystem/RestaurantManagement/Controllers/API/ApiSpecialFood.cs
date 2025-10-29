
//using DataLayer;
//using EntityLayer;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.Http;

//namespace RestaurantManagement.Controllers.API
//{
//    public class SpecialFoodController : ApiController
//    {
//        // [Route("api/SpecialFood")]	  
//        public ApiResponse Get()
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                IEnumerable<SpecialFood> SpecialFoodlist = null;
//                DataTable dtSpecialFood = new DataTable();
//                SpecialFoodDL objRestaurantUserDL = new SpecialFoodDL();

//                objApiResponse = objRestaurantUserDL.GetSpecialFood();

//                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
//                {
//                    DataSet ds = (DataSet)objApiResponse.Result;
//                    SpecialFoodlist = ds.Tables[0].AsEnumerable().Select(x => new SpecialFood
//                    {
//                        SpecialFoodID = x.Field<Int32>("SpecialFoodID"),
//                        Name = x.Field<String>("Name"),
//                        Desc = x.Field<String>("Desc"),
//                        RestaurantID = x.Field<Int32>("RestaurantID"),
//                        CreatedBy = x.Field<Int32>("CreatedBy"),
//                        CreatedDate = x.Field<DateTime>("CreatedDate"),
//                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
//                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
//                    });
//                    objApiResponse.Result = SpecialFoodlist;
//                    objApiResponse.StatusCode = 0;
//                    objApiResponse.Message = "Data Received successfully";
//                }
//                else
//                {
//                    objApiResponse.Result = SpecialFoodlist;
//                    objApiResponse.StatusCode = 1;
//                    objApiResponse.Message = "Data Not found";
//                }

//            }
//            catch (Exception ex)
//            {
//                objApiResponse.Result = null;
//                objApiResponse.StatusCode = ex.HResult;
//                objApiResponse.Message = ex.Message;
//            }
//            return objApiResponse;

//        }

//        // [Route("api/SpecialFoodById")]	  

//        [HttpGet]
//        public ApiResponse SpecialFoodById(int id)
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                IEnumerable<SpecialFood> SpecialFoodlist = null;

//                DataTable dtSpecialFood = new DataTable();
//                SpecialFoodDL objRestaurantUserDL = new SpecialFoodDL();

//                objApiResponse = objRestaurantUserDL.GetSpecialFoodById(id);

//                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
//                {
//                    DataSet ds = (DataSet)objApiResponse.Result;
//                    SpecialFoodlist = ds.Tables[0].AsEnumerable().Select(x => new SpecialFood
//                    {
//                        SpecialFoodID = x.Field<Int32>("SpecialFoodID"),
//                        Name = x.Field<String>("Name"),
//                        Desc = x.Field<String>("Desc"),
//                        RestaurantID = x.Field<Int32>("RestaurantID"),
//                        CreatedBy = x.Field<Int32>("CreatedBy"),
//                        CreatedDate = x.Field<DateTime>("CreatedDate"),
//                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
//                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
//                    });
//                    objApiResponse.Result = SpecialFoodlist;
//                    objApiResponse.StatusCode = 1;
//                    objApiResponse.Message = "Data Received successfully";
//                }
//                else
//                {
//                    objApiResponse.Result = SpecialFoodlist;
//                    objApiResponse.StatusCode = 1;
//                    objApiResponse.Message = "Data Not found";
//                }

//            }
//            catch (Exception ex)
//            {
//                objApiResponse.Result = null;
//                objApiResponse.StatusCode = ex.HResult;
//                objApiResponse.Message = ex.Message;
//            }
//            return objApiResponse;

//        }



//        [HttpPost]
//        public ApiResponse AddSpecialFood(SpecialFood _SpecialFood)
//        {
//            SpecialFoodDL objSpecialFoodDL = new SpecialFoodDL();
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                if (_SpecialFood.SpecialFoodID > 0)
//                {
//                    objApiResponse = objSpecialFoodDL.UpdateSpecialFood(_SpecialFood);

//                }
//                else
//                {
//                    objApiResponse = objSpecialFoodDL.AddSpecialFood(_SpecialFood);
//                }

//            }
//            catch (Exception ex)
//            {
//                objApiResponse.Result = null;
//                objApiResponse.StatusCode = ex.HResult;
//                objApiResponse.Message = ex.Message;
//            }
//            return objApiResponse;

//        }


//        [HttpPost]
//        public ApiResponse DeleteSpecialFood(int? id)
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                SpecialFoodDL objSpecialFoodDL = new SpecialFoodDL();
//                objApiResponse = objSpecialFoodDL.DeleteSpecialFood(Convert.ToInt32(id));
//            }
//            catch (Exception ex)
//            {
//                objApiResponse.Result = null;
//                objApiResponse.StatusCode = ex.HResult;
//                objApiResponse.Message = ex.Message;
//            }
//            return objApiResponse;
//        }
//    }
//}