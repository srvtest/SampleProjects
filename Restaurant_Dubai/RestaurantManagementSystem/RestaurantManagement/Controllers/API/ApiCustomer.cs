using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using RestaurantManagement.Models;
using ExceptionManager;
using Utility;

namespace RestaurantManagement.Controllers.API
{/****
    
     * upload user profile 
     * add on API too
     * *****/
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Customer> Customerlist = null;
                DataTable dtCustomer = new DataTable();
                CustomerDL objRestaurantUserDL = new CustomerDL();

                objApiResponse = objRestaurantUserDL.GetCustomerApi();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Customerlist = ds.Tables[0].AsEnumerable().Select(x => new Customer
                    {
                        CustomerID = x.Field<Int32>("CustomerID"),
                        Firstname = x.Field<String>("Firstname"),
                        LastName = x.Field<String>("LastName"),
                        Email = x.Field<String>("Email"),
                        password = x.Field<String>("password"),
                        Mobile = x.Field<String>("Mobile"),
                        Address = x.Field<String>("Address"),
                        OfficeAddress = x.Field<String>("OfficeAddress"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        IpAddress = x.Field<String>("IpAddress"),
                        CarRegistrationNo = x.Field<String>("CarRegistrationNo"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate"),
                        IsSocialLogin = x.Field<Boolean>("IsSocialLogin"),
                        SocialNetworkToken = x.Field<String>("SocialNetworkToken"),
                        ConfigurationTimestamp = x.Field<long>("IpAddress"),
                        ModelName = x.Field<String>("ModelName"),
                        OSVersion = x.Field<String>("OSVersion"),
                        PlatformName = x.Field<String>("PlatformName"),
                        AppVersion = x.Field<double>("AppVersion")
                    });
                    objApiResponse.Result = Customerlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Customerlist;
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

        [HttpGet]
        public ApiResponse CustomerById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<Customer> Customerlist = null;

                DataTable dtCustomer = new DataTable();
                CustomerDL objRestaurantUserDL = new CustomerDL();

                objApiResponse = objRestaurantUserDL.GetCustomerByIdApi(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Customerlist = ds.Tables[0].AsEnumerable().Select(x => new Customer
                    {
                        CustomerID = x.Field<Int32>("CustomerID"),
                        Firstname = x.Field<String>("Firstname"),
                        LastName = x.Field<String>("LastName"),
                        Email = x.Field<String>("Email"),
                        password = x.Field<String>("password"),
                        Mobile = x.Field<String>("Mobile"),
                        Address = x.Field<String>("Address"),
                        OfficeAddress = x.Field<String>("OfficeAddress"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        IpAddress = x.Field<String>("IpAddress"),
                        CarRegistrationNo = x.Field<String>("CarRegistrationNo"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate"),
                        IsSocialLogin = x.Field<Boolean>("IsSocialLogin"),
                        SocialNetworkToken = x.Field<String>("SocialNetworkToken"),
                        ConfigurationTimestamp = x.Field<long>("IpAddress"),
                        ModelName = x.Field<String>("ModelName"),
                        OSVersion = x.Field<String>("OSVersion"),
                        PlatformName = x.Field<String>("PlatformName"),
                        AppVersion = x.Field<double>("AppVersion")
                    });
                    objApiResponse.Result = Customerlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Customerlist;
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

        [HttpPost]
        public ApiResponse DeleteCustomer(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                CustomerDL objCustomerDL = new CustomerDL();
                objApiResponse = objCustomerDL.DeleteCustomerApi(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;
        }


        [Route("AddCustomer")]
        [HttpPost]
        public ApiResponse AddCustomer(Customer _Customer)
        {            
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Customer != null && !string.IsNullOrEmpty(Convert.ToString(_Customer.CustomerID)))
                {
                    CustomerDL objCustomerDL = new CustomerDL();
                    objApiResponse = objCustomerDL.AddCustomerApi(_Customer);
                }
                else
                {
                    objApiResponse = new ApiResponse(500, null, "Invalid Restaurant id. Please check.");
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

        [Route("UpdateCustomer")]
        [HttpPost]
        public ApiResponse UpdateCustomer(Customer _Customer)
        {
           
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_Customer != null && !string.IsNullOrEmpty(Convert.ToString(_Customer.CustomerID)))
                {
                    CustomerDL objCustomerDL = new CustomerDL();
                    objApiResponse = objCustomerDL.UpdateCustomerApi(_Customer);
                }
                else
                {
                    objApiResponse = new ApiResponse(500, null, "Invalid Customer ID. Please check.");
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
        [Route("Login")]
        public ApiResponse CustomerLogin(EntityLayer.CustomerLogin para)
        {
            ApiResponse objApiResponse;
            if (para != null && !string.IsNullOrEmpty(para.EmailID) && !string.IsNullOrEmpty(para.Password))
            {
                CustomerDL obj = new CustomerDL();

                objApiResponse = obj.Login(para);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the parameters for Customer (Email and Password)");

            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("ChangePassword")]
        public ApiResponse ChangePassword(EntityLayer.CustomerLogin para)
        {
            ApiResponse objApiResponse;
            if (para != null && !string.IsNullOrEmpty(Convert.ToString(para.CustomerID)) && !string.IsNullOrEmpty(para.NewPassword) && !string.IsNullOrEmpty(para.Password) && !string.IsNullOrEmpty(para.deviceDetail.DeviceToken))
            {
                CustomerDL obj = new CustomerDL();
                objApiResponse = obj.Changepassword(para);
                //string str = CommonEnums.SendEmail(lstcategory[0].Email, "Change Password successfully.", "Hi, <b>" + lstcategory[0].Name + "</b> <br>Password change Successfully.");
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the parameters for DeactivateBusinessUser (Id, Password and NewPassword)");
            }
            return objApiResponse;
        }

        [AllowAnonymous]
        [Route("ForgotPassword")]
        public ApiResponse ForgotPassword(EntityLayer.CustomerLogin para)
        {
            ApiResponse objApiResponse;
            if (para != null && !string.IsNullOrEmpty(para.EmailID))
            {
                CustomerDL obj = new CustomerDL();
                objApiResponse = obj.Forgetpassword(para);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the parameters for Customer (Email)");
            }
            return objApiResponse;
        }

        [AllowAnonymous]
        [Route("Logout")]
        public ApiResponse Logout(EntityLayer.CustomerLogin para)
        {
            ApiResponse objApiResponse;
            if (para != null && !string.IsNullOrEmpty(para.EmailID))
            {
                CustomerDL obj = new CustomerDL();
                objApiResponse = obj.Logout(para);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the parameters for Customer (Email)");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("GetNearBy")]
        public ApiResponse GetNearBy(EntityLayer.ViewModelRestaurantSearch para)
        {
            ApiResponse objApiResponse = new ApiResponse();
            List<EntityLayer.RestaurantSearch> lstRestaurantSearch = new List<RestaurantSearch>();
            if (para.Radius == 0)
                para.Radius = 2000;

            if (para != null && !string.IsNullOrEmpty(para.Lat) && !string.IsNullOrEmpty(para.Long))
            {
                RestaurantSearchDL obj = new RestaurantSearchDL();
                ApiResponse objAllRestaurantApiResponse = new ApiResponse();
                objAllRestaurantApiResponse = obj.GetAllRestaurant();
                if (objAllRestaurantApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objAllRestaurantApiResponse.Result;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string[] RestaurantLatLong = Convert.ToString(dr["MAP"]).Split(',');
                        double dblDist = Utility.CommonEnums.Distance(Convert.ToDouble(para.Lat), Convert.ToDouble(para.Long), Convert.ToDouble(RestaurantLatLong[0]), Convert.ToDouble(RestaurantLatLong[1]), "M");
                        if (dblDist < para.Radius)
                        {
                            RestaurantSearch objRestaurant = new RestaurantSearch();

                            objRestaurant.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                            objRestaurant.Name = Convert.ToString(dr["Name"]);
                            // objRestaurant.Logo = Convert.ToString("Logo");
                            objRestaurant.MAP = Convert.ToString(dr["MAP"]);
                            //objRestaurant.CuisineID = Convert.ToInt32(dr["CuisineID"]);
                            //objRestaurant.CuisineType = Convert.ToString(dr["CuisineType"]);
                            objRestaurant.Dist = dblDist;
                            lstRestaurantSearch.Add(objRestaurant);
                        }
                    }
                }
                objApiResponse.Message = objApiResponse.Message;
                objApiResponse.Result = lstRestaurantSearch.OrderBy(x => x.Dist).ToList();
                objApiResponse.StatusCode = objApiResponse.StatusCode;

            }
            else
            {
                //  objApiResponse.Message = "Please provide the parameters for get near by (Lat,Long,Id)";
                objApiResponse.Message = "Please provide the parameters for get near by (Lat,Long)";
                objApiResponse.StatusCode = 500;
            }
            return objApiResponse;
        }

        [HttpGet]
        [Route("CityandFoodCategoryList")]
        public ApiResponse GetCityAndFoodCatogoryList()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<City> Citylist = null;
                IEnumerable<Cuisine> Cuisinelist = null;
                CustomerDL objCustomerDL = new CustomerDL();

                objApiResponse = objCustomerDL.GetCityAndFoodCatogoryList();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            Citylist = ds.Tables[1].AsEnumerable().Select(x => new City
                            {
                                CityID = x.Field<int>("CityID"),
                                CityName = x.Field<string>("CityName"),
                                IsActive = x.Field<bool>("IsActive")
                            });
                        }

                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            Cuisinelist = ds.Tables[2].AsEnumerable().Select(x => new Cuisine
                            {
                                CuisineId = x.Field<Int32>("CuisineId"),
                                CuisineType = x.Field<String>("CuisineType"),
                                IsActive = x.Field<Boolean>("IsActive")

                            });
                        }
                    }
                }
                //else
                //{
                //    objApiResponse = new ApiResponse(500, null, "Please Check");
                //}
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
        [Route("TableNoByRestaurantId")]
        public ApiResponse TableNoByRestaurantId(TableNo objTableNo)
        {
            ApiResponse objApiResponse = new ApiResponse();

            try
            {
                if (objTableNo != null && !string.IsNullOrEmpty(Convert.ToString(objTableNo.RestaurantID)))

                {
                    TableNoDL objRestaurantDL = new TableNoDL();
                    objApiResponse = objRestaurantDL.GetTableNoByRestaurantId(objTableNo);

                }

                else
                {
                    objApiResponse = new ApiResponse(500, null, "Invalid Restaurant ID. Please check.");
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
        [Route("RestaurantReviewRating")]
        public ApiResponse GetRestaurantReviewRating(Customer objCustomer)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (objCustomer != null && !string.IsNullOrEmpty(Convert.ToString(objCustomer.RestaurantID)))
                {
                    CustomerDL objCustomerDL = new CustomerDL();
                    objApiResponse = objCustomerDL.GetRestaurantReviewRating(objCustomer.RestaurantID);
                }
                else
                {
                    objApiResponse = new ApiResponse(500, null, "Invalid Restaurant id. Please check.");
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
        [Route("GetRestaurantContactUs")]
        public ApiResponse RestaurantContactUs(Restaurant objRestaurant)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objRestaurant != null && (!string.IsNullOrEmpty(Convert.ToString(objRestaurant.RestaurantID))))
            {
                RestaurantDL objRestaurantDL = new RestaurantDL();
                objApiResponse = objRestaurantDL.GetRestaurantContactUs(objRestaurant);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the RestaurantID.");
            }
            return objApiResponse;
        }
        
        [HttpPost]
        [Route("GetRestaurantCMS")]
        public ApiResponse GetRestaurantCMS(CMS objCMS)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objCMS != null && (!string.IsNullOrEmpty(Convert.ToString(objCMS.RestaurantID)) && (!string.IsNullOrEmpty(Convert.ToString(objCMS.CMSTypeID)))))
                {
                RestaurantDL objRestaurantDL = new RestaurantDL();
                objApiResponse = objRestaurantDL.GetRestaurantCMS(objCMS);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the RestaurantID.");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("GetCustomerByIdApi")]
        public ApiResponse GetCustomerByIdApi(Customer _Customer)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (_Customer != null && (!string.IsNullOrEmpty(Convert.ToString(_Customer.CustomerID))))
            {
                CustomerDL objCustomerDL = new CustomerDL();
                objApiResponse = objCustomerDL.GetCustomerByIdApi(_Customer.CustomerID);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the CustomerID.");
            }
            return objApiResponse;
        }

        
        
        //[HttpPost]
        //[Route("GetOrderByCustomerID")]
        //public ApiResponse GetOrderByCustomerID(Order objOrder)
        //{
        //    ApiResponse objApiResponse = new ApiResponse();
        //    if (objOrder != null && (!string.IsNullOrEmpty(Convert.ToString(objOrder.CustomerID))))
        //    {
        //        OrderDL objOrderDL = new OrderDL();
        //        objApiResponse = objOrderDL.GetOrderByCustomerID(objOrder);
        //    }
        //    else
        //    {
        //        objApiResponse = new ApiResponse(500, null, "Please provide the CustomerID.");
        //    }
        //    return objApiResponse;
        //}
        [HttpPost]
        [Route("GetOrderDetailsByIdApi")]
        public ApiResponse GetOrderDetailsByIdApi(Customer _Customer)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (_Customer != null && (!string.IsNullOrEmpty(Convert.ToString(_Customer.TransID))))
            {
                CustomerDL objCustomerDL = new CustomerDL();
                objApiResponse = objCustomerDL.GetOrderDetailsByIdApi(_Customer.TransID);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the ID.");
            }
            return objApiResponse;
        }


        [HttpPost]
        [Route("GetOrderByCustomerID")]
        public ApiResponse GetOrderByCustomerID(Order objOrder)
        {
            ApiResponse objApiResponse = new ApiResponse();

            try
            {
                if (objOrder != null && (!string.IsNullOrEmpty(Convert.ToString(objOrder.CustomerID))))

                {
                    OrderDL objOrderDL = new OrderDL();
                    objApiResponse = objOrderDL.GetOrderByCustomerID(objOrder);

                }

                else
                {
                    objApiResponse = new ApiResponse(500, null, "Invalid Food CustomerID. Please check.");
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


        //[HttpPost]
        //[Route("api/Customer/GetRestaurantMenus")]
        //public ApiResponse RestaurantMenus(FoodCategory objRestaurant)
        //{
        //    ApiResponse objApiResponse = new ApiResponse();

        //    try
        //    {
        //        if (objRestaurant != null && !string.IsNullOrEmpty(Convert.ToString(objRestaurant.RestaurantID)))

        //        {
        //            TableNoDL objRestaurantDL = new TableNoDL();
        //            objApiResponse = objRestaurantDL.GetRestaurantMenus(objRestaurant);

        //        }

        //        else
        //        {
        //            objApiResponse = new ApiResponse(500, null, "Invalid Restaurant ID. Please check.");
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



        //[HttpPost]
        //[Route("GetRestaurantMenus")]
        //public ApiResponse RestaurantMenus(FoodCategory objRestaurant)
        //{
        //    ApiResponse objApiResponse = new ApiResponse();

        //    try
        //    {
        //        if (objRestaurant != null && !string.IsNullOrEmpty(Convert.ToString(objRestaurant.RestaurantID)))

        //        {
        //            FoodCategoryDL objRestaurantDL = new FoodCategoryDL();
        //            objApiResponse = objRestaurantDL.GetRestaurantMenus(objRestaurant);

        //        }

        //        else
        //        {
        //            objApiResponse = new ApiResponse(500, null, "Invalid Restaurant id. Please check.");
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

        //[HttpPost]
        //[Route("GetRestaurantRatingReviews")]
        //public ApiResponse RestaurantRatingReviews(ReviewRating objRestaurant)
        //{
        //    ApiResponse objApiResponse = new ApiResponse();

        //    try
        //    {
        //        if (objRestaurant != null && !string.IsNullOrEmpty(Convert.ToString(objRestaurant.RestaurantID)))

        //        {
        //            ReviewRatingDL objRestaurantDL = new ReviewRatingDL();
        //            objApiResponse = objRestaurantDL.GetRestaurantRatingReviews(objRestaurant);

        //        }

        //        else
        //        {
        //            objApiResponse = new ApiResponse(500, null, "Invalid Restaurant id. Please check.");
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

    }
}        

//[HttpPost]
//        //[Route("api/Customer/GetRestaurantMenus")]
//        //public ApiResponse RestaurantMenus(FoodCategory objRestaurant)
//        //{
//        //    ApiResponse objApiResponse = new ApiResponse();

//        //    try
//        //    {
//        //        if (objRestaurant != null && !string.IsNullOrEmpty(Convert.ToString(objRestaurant.RestaurantID)))

//        //        {
//        //            TableNoDL objRestaurantDL = new TableNoDL();
//        //            objApiResponse = objRestaurantDL.GetRestaurantMenus(objRestaurant);

//        //        }

//        //        else
//        //        {
//        //            objApiResponse = new ApiResponse(500, null, "Invalid Restaurant ID. Please check.");
//        //        }

//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        objApiResponse.Result = null;
//        //        objApiResponse.StatusCode = ex.HResult;
//        //        objApiResponse.Message = ex.Message;
//        //    }

//        //    return objApiResponse;
//        //}



//        //[HttpPost]
//        //[Route("GetRestaurantMenus")]
//        //public ApiResponse RestaurantMenus(FoodCategory objRestaurant)
//        //{
//        //    ApiResponse objApiResponse = new ApiResponse();

//        //    try
//        //    {
//        //        if (objRestaurant != null && !string.IsNullOrEmpty(Convert.ToString(objRestaurant.RestaurantID)))

//        //        {
//        //            FoodCategoryDL objRestaurantDL = new FoodCategoryDL();
//        //            objApiResponse = objRestaurantDL.GetRestaurantMenus(objRestaurant);

//        //        }

//        //        else
//        //        {
//        //            objApiResponse = new ApiResponse(500, null, "Invalid Restaurant id. Please check.");
//        //        }

//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        objApiResponse.Result = null;
//        //        objApiResponse.StatusCode = ex.HResult;
//        //        objApiResponse.Message = ex.Message;
//        //    }

//        //    return objApiResponse;
//        //}

//        //[HttpPost]
//        //[Route("GetRestaurantRatingReviews")]
//        //public ApiResponse RestaurantRatingReviews(ReviewRating objRestaurant)
//        //{
//        //    ApiResponse objApiResponse = new ApiResponse();

//        //    try
//        //    {
//        //        if (objRestaurant != null && !string.IsNullOrEmpty(Convert.ToString(objRestaurant.RestaurantID)))

//        //        {
//        //            ReviewRatingDL objRestaurantDL = new ReviewRatingDL();
//        //            objApiResponse = objRestaurantDL.GetRestaurantRatingReviews(objRestaurant);

//        //        }

//        //        else
//        //        {
//        //            objApiResponse = new ApiResponse(500, null, "Invalid Restaurant id. Please check.");
//        //        }

//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        objApiResponse.Result = null;
//        //        objApiResponse.StatusCode = ex.HResult;
//        //        objApiResponse.Message = ex.Message;
//        //    }

//        //    return objApiResponse;
//        //}

//    }
//}