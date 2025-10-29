
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
//    public class RegisterController : ApiController
//    {
//        // [Route("api/Register")]	  
//        public ApiResponse Get()
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                IEnumerable<Register> Registerlist = null;
//                DataTable dtRegister = new DataTable();
//                RegisterDL objRestaurantUserDL = new RegisterDL();

//                objApiResponse = objRestaurantUserDL.GetRegister();

//                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
//                {
//                    DataSet ds = (DataSet)objApiResponse.Result;
//                    Registerlist = ds.Tables[0].AsEnumerable().Select(x => new Register
//                    {
//                        RegisterID = x.Field<Int32>("RegisterID"),
//                        Username = x.Field<String>("Username"),
//                        Password = x.Field<String>("Password"),
//                    });
//                    objApiResponse.Result = Registerlist;
//                    objApiResponse.StatusCode = 0;
//                    objApiResponse.Message = "Data Received successfully";
//                }
//                else
//                {
//                    objApiResponse.Result = Registerlist;
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

//        // [Route("api/RegisterById")]	  

//        [HttpGet]
//        public ApiResponse RegisterById(int id)
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                IEnumerable<Register> Registerlist = null;

//                DataTable dtRegister = new DataTable();
//                RegisterDL objRestaurantUserDL = new RegisterDL();

//                objApiResponse = objRestaurantUserDL.GetRegisterById(id);

//                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
//                {
//                    DataSet ds = (DataSet)objApiResponse.Result;
//                    Registerlist = ds.Tables[0].AsEnumerable().Select(x => new Register
//                    {
//                        RegisterID = x.Field<Int32>("RegisterID"),
//                        Username = x.Field<String>("Username"),
//                        Password = x.Field<String>("Password"),
//                    });
//                    objApiResponse.Result = Registerlist;
//                    objApiResponse.StatusCode = 1;
//                    objApiResponse.Message = "Data Received successfully";
//                }
//                else
//                {
//                    objApiResponse.Result = Registerlist;
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
//        public ApiResponse AddRegister(Register _Register)
//        {
//            RegisterDL objRegisterDL = new RegisterDL();
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                if (_Register.RegisterID > 0)
//                {
//                    objApiResponse = objRegisterDL.UpdateRegister(_Register);

//                }
//                else
//                {
//                    objApiResponse = objRegisterDL.AddRegister(_Register);
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
//        public ApiResponse DeleteRegister(int? id)
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                RegisterDL objRegisterDL = new RegisterDL();
//                objApiResponse = objRegisterDL.DeleteRegister(Convert.ToInt32(id));
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