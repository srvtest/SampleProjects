
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
//    public class RoleAccessMasterController : ApiController
//    {
//        // [Route("api/RoleAccessMaster")]	  
//        public ApiResponse Get()
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                IEnumerable<RoleAccessMaster> RoleAccessMasterlist = null;
//                DataTable dtRoleAccessMaster = new DataTable();
//                RoleAccessMasterDL objRestaurantUserDL = new RoleAccessMasterDL();

//                objApiResponse = objRestaurantUserDL.GetRoleAccessMaster();

//                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
//                {
//                    DataSet ds = (DataSet)objApiResponse.Result;
//                    RoleAccessMasterlist = ds.Tables[0].AsEnumerable().Select(x => new RoleAccessMaster
//                    {
//                        RoleAccessMasterID = x.Field<Int32>("RoleAccessMasterID"),
//                        RoleID = x.Field<Int32>("RoleID"),
//                        RestaurentID = x.Field<Int32>("RestaurentID"),
//                        Descp = x.Field<String>("Descp"),
//                        CreatedBy = x.Field<Int32>("CreatedBy"),
//                        CreatedDate = x.Field<DateTime>("CreatedDate"),
//                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
//                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
//                    });
//                    objApiResponse.Result = RoleAccessMasterlist;
//                    objApiResponse.StatusCode = 0;
//                    objApiResponse.Message = "Data Received successfully";
//                }
//                else
//                {
//                    objApiResponse.Result = RoleAccessMasterlist;
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

//        // [Route("api/RoleAccessMasterById")]	  

//        [HttpGet]
//        public ApiResponse RoleAccessMasterById(int id)
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                IEnumerable<RoleAccessMaster> RoleAccessMasterlist = null;

//                DataTable dtRoleAccessMaster = new DataTable();
//                RoleAccessMasterDL objRestaurantUserDL = new RoleAccessMasterDL();

//                objApiResponse = objRestaurantUserDL.GetRoleAccessMasterById(id);

//                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
//                {
//                    DataSet ds = (DataSet)objApiResponse.Result;
//                    RoleAccessMasterlist = ds.Tables[0].AsEnumerable().Select(x => new RoleAccessMaster
//                    {
//                        RoleAccessMasterID = x.Field<Int32>("RoleAccessMasterID"),
//                        RoleID = x.Field<Int32>("RoleID"),
//                        RestaurentID = x.Field<Int32>("RestaurentID"),
//                        Descp = x.Field<String>("Descp"),
//                        CreatedBy = x.Field<Int32>("CreatedBy"),
//                        CreatedDate = x.Field<DateTime>("CreatedDate"),
//                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
//                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
//                    });
//                    objApiResponse.Result = RoleAccessMasterlist;
//                    objApiResponse.StatusCode = 1;
//                    objApiResponse.Message = "Data Received successfully";
//                }
//                else
//                {
//                    objApiResponse.Result = RoleAccessMasterlist;
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
//        public ApiResponse AddRoleAccessMaster(RoleAccessMaster _RoleAccessMaster)
//        {
//            RoleAccessMasterDL objRoleAccessMasterDL = new RoleAccessMasterDL();
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                if (_RoleAccessMaster.RoleAccessMasterID > 0)
//                {
//                    objApiResponse = objRoleAccessMasterDL.UpdateRoleAccessMaster(_RoleAccessMaster);

//                }
//                else
//                {
//                    objApiResponse = objRoleAccessMasterDL.AddRoleAccessMaster(_RoleAccessMaster);
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
//        public ApiResponse DeleteRoleAccessMaster(int? id)
//        {
//            ApiResponse objApiResponse = new ApiResponse();
//            try
//            {
//                RoleAccessMasterDL objRoleAccessMasterDL = new RoleAccessMasterDL();
//                objApiResponse = objRoleAccessMasterDL.DeleteRoleAccessMaster(Convert.ToInt32(id));
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