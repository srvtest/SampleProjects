using EntityLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELHelper;
using System.Data;
using System;

namespace DataLayer
{
    public class RestaurantUserDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddRestaurantUser(RestaurantUser para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[13];
            try
            {

                parameter[0] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Firstname);
                parameter[1] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.LastName);
                parameter[2] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Gender);
                parameter[3] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[4] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[5] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[6] = new LbSprocParameter("@OfficeAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OfficeAddress);
                parameter[7] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[8] = new LbSprocParameter("@IpAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.IpAddress);
                parameter[9] = new LbSprocParameter("@RolesID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RolesID);
                parameter[10] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[11] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[12] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Password);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertRestaurantUser", parameter);
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

        public ApiResponse UpdateRestaurantUser(RestaurantUser para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[14];

            try
            {
                parameter[0] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.UserID);
                parameter[1] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Firstname);
                parameter[2] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.LastName);
                parameter[3] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Gender);
                parameter[4] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[5] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[6] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[7] = new LbSprocParameter("@OfficeAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OfficeAddress);
                parameter[8] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[9] = new LbSprocParameter("@IpAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.IpAddress);
                parameter[10] = new LbSprocParameter("@RolesID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RolesID);
                parameter[11] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[12] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[13] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Password);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateRestaurantUser", parameter);
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

        public ApiResponse GetRestaurantUser()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetRestaurantUser", parameter);
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


        public ApiResponse DeleteRestaurantUser(int UserID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, UserID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteRestaurantUser", parameter);
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

        public ApiResponse GetRestaurantUserById(int UserID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, UserID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetRestaurantUserById", parameter);
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

        /// <summary>
        /// Method for user login
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="RestaurantID"></param>
        /// <returns></returns>
        public ApiResponse LoginUser(string Email, string Password, bool isApi = false)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Email);
            parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Password);
            //parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
            //parameter[2] = new LbSprocParameter("@ErrorCode", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, 0);
            //parameter[3] = new LbSprocParameter("@ErrorMsg", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, string.Empty);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_LoginUser", parameter);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if(isApi)
                    {
                        if (ds.Tables.Count >1)
                        objApiResponse.Result = ds.Tables[1];
                    }
                    else
                    {
                        objApiResponse.Result = ds;
                    }
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
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
        /// <summary>
        /// Method for user foretpassword
        /// </summary>
        /// <param name="Email"></param>

        /// <returns></returns>
        public ApiResponse Forgetpassword(string Email)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Email);
            //parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Password);
            ////parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
           // parameter[1] = new LbSprocParameter("@ErrorCode", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, 0);
            //parameter[2] = new LbSprocParameter("@ErrorMsg", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, string.Empty);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_Forgetpassword", parameter);
                if(ds != null && ds.Tables.Count > 0)
                {
                    if(ds.Tables.Count > 1)
                         objApiResponse.Result = ds.Tables[1];
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
                
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

        /// <summary>
        /// Method for user login
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="RestaurantID"></param>
        /// <returns></returns>
        public ApiResponse Changepassword(string Email, string oldPassword, string Password)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[3];
            parameter[0] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Email);
            parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Password);
            parameter[2] = new LbSprocParameter("@oldPassword", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, oldPassword);
            //parameter[2] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
            //parameter[2] = new LbSprocParameter("@ErrorCode", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, 0);
            //parameter[3] = new LbSprocParameter("@ErrorMsg", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, string.Empty);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                 ds = elHelper.ExecuteDataset("usp_ChangePassword", parameter);
                if(ds != null && ds.Tables.Count > 0)
                {
                    if(ds.Tables.Count > 1)
                        objApiResponse.Result = ds.Tables[1];
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
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

        public ApiResponse ResetPassword(int userid,string pass)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userid);
            parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, pass);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                ds = elHelper.ExecuteDataset("usp_ResetPassword", parameter);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 1)
                        objApiResponse.Result = ds.Tables[1];
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        public ApiResponse LoginAdmin(string Email, string Password, bool isApi = false)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Email);
            parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Password);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_LoginAdmin", parameter);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (isApi)
                    {
                        objApiResponse.Result = ds.Tables[1];
                    }
                    else
                    {
                        objApiResponse.Result = ds;
                    }
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
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



        
         public ApiResponse GetUserbyid(RestaurantUser objRestaurantUser)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[11];

            parameter[0] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.UserID);
            parameter[1] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Firstname);
            parameter[2] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.LastName);
            parameter[3] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Gender);
            parameter[4] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Email);
            parameter[5] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Mobile);
            parameter[6] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Address);
            parameter[7] = new LbSprocParameter("@OfficeAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.OfficeAddress);
            parameter[8] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.IsActive);
            parameter[9] = new LbSprocParameter("@RolesID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.RolesID);
            parameter[10] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.RestaurantID);
            
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetUserbyid", parameter);
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

        public ApiResponse UpdateRestaurantUserAPI(RestaurantUser objRestaurantUser)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[14];

            try
            {
                parameter[0] = new LbSprocParameter("@UserID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.UserID);
                parameter[1] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Firstname);
                parameter[2] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.LastName);
                parameter[3] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Gender);
                parameter[4] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Email);
                parameter[5] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Mobile);
                parameter[6] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Address);
                parameter[7] = new LbSprocParameter("@OfficeAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.OfficeAddress);
                parameter[8] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.IsActive);
                parameter[9] = new LbSprocParameter("@IpAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.IpAddress);
                parameter[10] = new LbSprocParameter("@RolesID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.RolesID);
                parameter[11] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.RestaurantID);
                parameter[12] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.ModifiedBy);
                parameter[13] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRestaurantUser.Password);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateRestaurantUserAPI", parameter);
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

    }

}
