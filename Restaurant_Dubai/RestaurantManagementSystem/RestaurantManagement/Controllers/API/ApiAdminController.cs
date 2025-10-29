using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantManagement.Controllers.API
{
    [RoutePrefix("api/Admin")]
    public class ApiAdminController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public ApiResponse Login(RestaurantLogin objRestaurant)
        {
            ApiResponse objApiResponse;
            if (objRestaurant != null && !string.IsNullOrEmpty(objRestaurant.EmailID) && !string.IsNullOrEmpty(objRestaurant.Password))
            {
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                objApiResponse = objRestaurantUserDL.LoginUser(objRestaurant.EmailID, Utility.CryptoEngine.Encrypt(objRestaurant.Password), true);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the parameters for Restaurant User (Email and Password)");

            }
            return objApiResponse;
        }
        /// <summary>
        [HttpPost]
        [Route("ChangePassword")]
        public ApiResponse ChangePassword(RestaurantLogin objRestaurant)
        {
            ApiResponse objApiResponse;
            if (objRestaurant != null && !string.IsNullOrEmpty(Convert.ToString(objRestaurant.EmailID)) && !string.IsNullOrEmpty(objRestaurant.Password) && !string.IsNullOrEmpty(objRestaurant.NewPassword))
            {
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                objApiResponse = objRestaurantUserDL.Changepassword(objRestaurant.EmailID, Utility.CryptoEngine.Encrypt(objRestaurant.Password), Utility.CryptoEngine.Encrypt(objRestaurant.NewPassword));
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide email and password for changes password");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public ApiResponse ForgotPassword(RestaurantLogin objRestaurant)
        {
            ApiResponse objApiResponse;
            if (objRestaurant != null && !string.IsNullOrEmpty(objRestaurant.EmailID))
            {
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                objApiResponse = objRestaurantUserDL.Forgetpassword(objRestaurant.EmailID);
                if (objApiResponse != null && objApiResponse.StatusCode == 200)
                {
                    string userid = string.Empty;
                    DataTable dt = (DataTable)objApiResponse.Result;
                    if (dt != null && dt.Rows.Count > 0)
                        userid = Convert.ToString(dt.Rows[0]["UserID"]);
                    string baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                    string subject = "Reset Password";
                    string body = "Hi,<br/><br/>We got a request to reset your account password. Please click on the link below to reset your password" +
                         "<br/><br/><a href=" + baseUrl + "/RestaurantUser/ResetPassword?prm=" + Utility.CryptoEngine.Encrypt(userid) + " > Reset Password link</a>";

                    Utility.CommonEnums.SendEmail(objRestaurant.EmailID, subject, body);
                }
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the parameters for Restaurant User (Email)");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("GetCategory")]
        public ApiResponse GetCategory(RestaurantLogin objRestaurant)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objRestaurant != null && objRestaurant.RestaurantID > 0)
            {
                FoodCategoryDL objFoodCategoryDL = new FoodCategoryDL();
                objApiResponse = objFoodCategoryDL.GetFoodCategoryByRestaurantIDAPI(objRestaurant);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the Restaurant Id");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("FoodDetailByCategoryId")]
        public ApiResponse FoodDetailByCategoryId(FoodDetail objFoodDetail)
        {
            ApiResponse objApiResponse = new ApiResponse();

            try
            {
                if (objFoodDetail != null && !string.IsNullOrEmpty(Convert.ToString(objFoodDetail.FoodCategoryID)))

                {
                    FoodDetailDL objRestaurantDL = new FoodDetailDL();
                    objApiResponse = objRestaurantDL.GetFoodDetailByCategoryId(objFoodDetail);

                }

                else
                {
                    objApiResponse = new ApiResponse(500, null, "Invalid Food Category id. Please check.");
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
        [Route("FoodDetailByName")]
        public ApiResponse FoodDetailByName(FoodDetail objFoodDetail)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objFoodDetail != null && !string.IsNullOrEmpty(objFoodDetail.Title) && !string.IsNullOrEmpty(Convert.ToString(objFoodDetail.RestaurantID)))
            {
                FoodDetailDL objFoodCategoryDL = new FoodDetailDL();
                objApiResponse = objFoodCategoryDL.GetFoodDetailByName(objFoodDetail);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the Restaurant Id & FoodName");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public ApiResponse CreateOrder(Order objOrder)
        {
            ApiResponse objApiResponse = new ApiResponse();
            //RSession rs = new RSession();
            //rs = (RSession)Session["RSession"];
            if (objOrder != null)
            {
                OrderDL objOrderDL = new OrderDL();
                try
                {
                    objApiResponse = objOrderDL.AddUpdateOrder(objOrder);
                    if (objApiResponse.StatusCode == 200)
                    {
                        //Order successfully.
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
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide email and password for changes password");
            }

            return objApiResponse;
        }

        [HttpPost]
        [Route("SearchCustomer")]
        public ApiResponse SearchCustomer(Customer objCustomer)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objCustomer != null && (!string.IsNullOrEmpty(objCustomer.Mobile) || !string.IsNullOrEmpty(objCustomer.CarRegistrationNo)))
            {
                CustomerDL objCustomerDL = new CustomerDL();
                objApiResponse = objCustomerDL.SearchCustomer(objCustomer);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide the mobile no or car registration no.");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public ApiResponse CreateCustomer(Customer objCustomer)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objCustomer != null && !string.IsNullOrEmpty(objCustomer.Firstname) && !string.IsNullOrEmpty(objCustomer.LastName) && !string.IsNullOrEmpty(objCustomer.Email) && !string.IsNullOrEmpty(objCustomer.password) && !string.IsNullOrEmpty(objCustomer.CarRegistrationNo) && !string.IsNullOrEmpty(objCustomer.Mobile) && !string.IsNullOrEmpty(Convert.ToString(objCustomer.Gender)))
            {
                CustomerDL objCustomerDL = new CustomerDL();
                objApiResponse = objCustomerDL.CreateCustomer(objCustomer);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide all required parameters (Firstname, LastName, Email, Password, CarRegistrationNo and Mobile).");
            }
            return objApiResponse;
        }


        [HttpPost]
        [Route("GetUserbyid")]
        public ApiResponse GetUserbyid(RestaurantUser objRestaurantUser)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objRestaurantUser != null && (!string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.UserID)) && !string.IsNullOrEmpty(objRestaurantUser.Firstname) && !string.IsNullOrEmpty(objRestaurantUser.LastName) && !string.IsNullOrEmpty(objRestaurantUser.Email) && !string.IsNullOrEmpty(objRestaurantUser.Mobile) && !string.IsNullOrEmpty(objRestaurantUser.Address) && !string.IsNullOrEmpty(objRestaurantUser.OfficeAddress) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.Gender)) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.IsActive)) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.RolesID)) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.RestaurantID))))
            {
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                objApiResponse = objRestaurantUserDL.GetUserbyid(objRestaurantUser);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide all required parameters (UserID, Firstname, LastName, Gender, Email, Mobile, Address, OfficeAddress, IsActive, RolesID, RestaurantID).");
            }
            return objApiResponse;
        }

        [HttpPost]
        [Route("UpdateRestaurantUserAPI")]
        public ApiResponse UpdateRestaurantUserAPI(RestaurantUser objRestaurantUser)
        {
            ApiResponse objApiResponse = new ApiResponse();
            if (objRestaurantUser != null && (!string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.UserID)) && !string.IsNullOrEmpty(objRestaurantUser.Firstname) && !string.IsNullOrEmpty(objRestaurantUser.LastName) && !string.IsNullOrEmpty(objRestaurantUser.Email) && !string.IsNullOrEmpty(objRestaurantUser.Mobile) && !string.IsNullOrEmpty(objRestaurantUser.IpAddress) && !string.IsNullOrEmpty(objRestaurantUser.Password) && !string.IsNullOrEmpty(objRestaurantUser.Address) && !string.IsNullOrEmpty(objRestaurantUser.OfficeAddress) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.Gender)) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.IsActive)) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.RolesID)) && !string.IsNullOrEmpty(Convert.ToString(objRestaurantUser.RestaurantID))))

            {
                    RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                objApiResponse = objRestaurantUserDL.UpdateRestaurantUserAPI(objRestaurantUser);
            }
            else
            {
                objApiResponse = new ApiResponse(500, null, "Please provide all required parameters (UserID, Firstname, LastName, Gender, Email, Mobile, Address, OfficeAddress, IsActive, RolesID, RestaurantID, Password).");
            }
            return objApiResponse;
        }
    }
}
