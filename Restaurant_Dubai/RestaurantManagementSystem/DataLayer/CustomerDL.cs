using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

using ELHelper;
using System.Data;
using System.Xml.Serialization;
using System.IO;

namespace DataLayer
{
    public class CustomerDL
    {
        ApiResponse objApiResponse = new ApiResponse();

        public ApiResponse AddCustomer(Customer para)
        {

            LbSprocParameter[] parameter = new LbSprocParameter[15];
            try
            {
                parameter[0] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Firstname);
                parameter[1] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.LastName);
                parameter[2] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Gender);
                parameter[3] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[4] = new LbSprocParameter("@password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.password);
                parameter[5] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[6] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[7] = new LbSprocParameter("@OfficeAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OfficeAddress);
                parameter[8] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[9] = new LbSprocParameter("@IpAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.IpAddress);
                parameter[10] = new LbSprocParameter("@CarRegistrationNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CarRegistrationNo);
                parameter[11] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[12] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[13] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[14] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);

                //parameter[14] = new LbSprocParameter("@IsSocialLogin", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsSocialLogin);
                //parameter[15] = new LbSprocParameter("@SocialNetworkToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SocialNetworkToken);
                //parameter[16] = new LbSprocParameter("@ConfigurationTimestamp", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ConfigurationTimestamp);
                //parameter[17] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ModelName);
                //parameter[18] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OSVersion);
                //parameter[19] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.PlatformName);
                //parameter[20] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AppVersion);



                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCustomer", parameter);
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

        public ApiResponse UpdateCustomer(Customer para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[16];
            try
            {
                parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[1] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Firstname);
                parameter[2] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.LastName);
                parameter[3] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Gender);
                parameter[4] = new LbSprocParameter("@EmaiL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[5] = new LbSprocParameter("@password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.password);
                parameter[6] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[7] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[8] = new LbSprocParameter("@OfficeAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OfficeAddress);
                parameter[9] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[10] = new LbSprocParameter("@IpAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.IpAddress);
                parameter[11] = new LbSprocParameter("@CarRegistrationNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CarRegistrationNo);
                parameter[12] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[13] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
                parameter[14] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[15] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);


                //parameter[15] = new LbSprocParameter("@IsSocialLogin", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsSocialLogin);
                //parameter[16] = new LbSprocParameter("@SocialNetworkToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SocialNetworkToken);
                //parameter[17] = new LbSprocParameter("@ConfigurationTimestamp", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ConfigurationTimestamp);
                //parameter[18] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ModelName);
                //parameter[19] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OSVersion);
                //parameter[20] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.PlatformName);
                //parameter[21] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AppVersion);


                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateCustomer", parameter);
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

        public ApiResponse GetCustomer()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetCustomer", parameter);
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

        public ApiResponse DeleteCustomer(int CustomerID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CustomerID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteCustomer", parameter);
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

        public ApiResponse GetCustomerById(int CustomerID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CustomerID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetCustomerById", parameter);
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

        public ApiResponse AddCustomerApi(Customer para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[14];
            try
            {
                parameter[0] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Firstname);
                parameter[1] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.LastName);
                parameter[2] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Gender);
                parameter[3] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[4] = new LbSprocParameter("@password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.password);
                parameter[5] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[6] = new LbSprocParameter("@CarRegistrationNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CarRegistrationNo);
                parameter[7] = new LbSprocParameter("@IsSocialLogin", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsSocialLogin);
                parameter[8] = new LbSprocParameter("@SocialNetworkToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SocialNetworkToken);
                parameter[9] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.ModelName);
                parameter[10] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.OSVersion);
                parameter[11] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.PlatformName);
                parameter[12] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.AppVersion);
                parameter[13] = new LbSprocParameter("@DeviceToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DeviceToken);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                //objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCustomerAPI", parameter);

                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_InsertCustomerAPI", parameter);
                objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
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

        public ApiResponse UpdateCustomerApi(Customer para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[18];
            try
            {
                parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
                parameter[1] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Firstname);
                parameter[2] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.LastName);
                parameter[3] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Gender);
                parameter[4] = new LbSprocParameter("@EmaiL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[5] = new LbSprocParameter("@password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.password);
                parameter[6] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[7] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[8] = new LbSprocParameter("@CarRegistrationNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CarRegistrationNo);
                parameter[9] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[10] = new LbSprocParameter("@IsSocialLogin", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsSocialLogin);
                parameter[11] = new LbSprocParameter("@SocialNetworkToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SocialNetworkToken);
                parameter[12] = new LbSprocParameter("@ConfigurationTimestamp", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ConfigurationTimestamp);
                parameter[13] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ModelName);
                parameter[14] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OSVersion);
                parameter[15] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.PlatformName);
                parameter[16] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AppVersion);
                parameter[17] = new LbSprocParameter("@DeviceToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DeviceToken);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_UpdateCustomerAPI", parameter);
                objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
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

        public ApiResponse GetCustomerApi()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetCustomerApi", parameter);
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

        public ApiResponse DeleteCustomerApi(int CustomerID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CustomerID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_DeleteCustomerApi", parameter);
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

        public ApiResponse GetCustomerByIdApi(int CustomerID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CustomerID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_GetCustomerByIdApi", parameter);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 1)
                    {
                        objApiResponse.Result = ds.Tables[0];
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[1].Rows[0]["ResponseCode"]);
                        objApiResponse.Message = Convert.ToString(ds.Tables[1].Rows[0]["ResponseMessage"]);
                    }
                    else
                    {
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                        objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    }
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

        public ApiResponse Login(EntityLayer.CustomerLogin para)
        {
            //ApiResponse objApiResponse;
            string ResponseMessage = string.Empty;
            int ResponseCode = 0;
            List<CustomerLoginResponse> objCustomerLoginResponse = new List<CustomerLoginResponse>();
            LbSprocParameter[] parameter = new LbSprocParameter[9];
            parameter[0] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.EmailID);
            parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Password);
            parameter[2] = new LbSprocParameter("@IsSocialLogin", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsSocialLogin);
            parameter[3] = new LbSprocParameter("@SocialNetworkToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SocialNetworkToken);
            parameter[4] = new LbSprocParameter("@ConfigurationTimestamp", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ConfigurationTimestamp);
            parameter[5] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.ModelName);
            parameter[6] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.OSVersion);
            parameter[7] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.PlatformName);
            parameter[8] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.AppVersion);
            ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
            DataSet ds = new DataSet();
            ds = elHelper.ExecuteDataset("usp_CustomerLogin", parameter);
            if (ds != null)
            {
                if (ds.Tables.Count > 1)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        objCustomerLoginResponse.Add(new CustomerLoginResponse(dr));
                    }
                }
                ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
            }
            ApiResponse response = new ApiResponse(ResponseCode, objCustomerLoginResponse, ResponseMessage);
            return response;
        }

        public ApiResponse Forgetpassword(EntityLayer.CustomerLogin para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[7];
            parameter[0] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.EmailID);
            parameter[1] = new LbSprocParameter("@ConfigurationTimestamp", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ConfigurationTimestamp);
            parameter[2] = new LbSprocParameter("@DeviceToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.DeviceToken);
            parameter[3] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.ModelName);
            parameter[4] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.OSVersion);
            parameter[5] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.PlatformName);
            parameter[6] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.AppVersion);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_CustomerForgetpassword", parameter);
                objApiResponse.StatusCode = 0;
                objApiResponse.Message = "";
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

        public ApiResponse Changepassword(EntityLayer.CustomerLogin para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[4];
            //parameter[0] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Email);
            parameter[0] = new LbSprocParameter("@CustomerID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CustomerID);
            parameter[1] = new LbSprocParameter("@NewPassword", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.NewPassword);
            parameter[2] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Password);
            parameter[3] = new LbSprocParameter("@DeviceToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.DeviceToken);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                ds = elHelper.ExecuteDataset("usp_CustomerChangesPassword", parameter);
                if (ds != null)
                {
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0 && Convert.ToInt32(ds.Tables[1].Rows[0]["IsEmailSend"]) < 1)
                    {
                        //Send mail
                    }
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
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

        public ApiResponse Logout(EntityLayer.CustomerLogin para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[6];
            parameter[0] = new LbSprocParameter("@UserAuthToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.UserAuthToken);
            parameter[1] = new LbSprocParameter("@DeviceToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.DeviceToken);
            parameter[2] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.ModelName);
            parameter[3] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.OSVersion);
            parameter[4] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.PlatformName);
            parameter[5] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.deviceDetail.AppVersion);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_CustomerLogout", parameter);
                objApiResponse.StatusCode = 0;
                objApiResponse.Message = "";
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

        public ApiResponse SearchCustomer(Customer para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];
            try
            {
                parameter[0] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[1] = new LbSprocParameter("@CarRegistrationNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CarRegistrationNo);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                //objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertCustomerAPI", parameter);

                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_SearchCustomer", parameter);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                        objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    }
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        objApiResponse.Result = ds.Tables[1];
                    }
                    else
                    {
                        objApiResponse.Message = "No record found.";
                    }

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

        public ApiResponse CreateCustomer(Customer para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[14];
            try
            {
                parameter[0] = new LbSprocParameter("@Firstname", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Firstname);
                parameter[1] = new LbSprocParameter("@LastName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.LastName);
                parameter[2] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[3] = new LbSprocParameter("@password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Utility.CryptoEngine.Encrypt(para.password));
                parameter[4] = new LbSprocParameter("@Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Mobile);
                parameter[5] = new LbSprocParameter("@CarRegistrationNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CarRegistrationNo);
                parameter[6] = new LbSprocParameter("@IsSocialLogin", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsSocialLogin);
                parameter[7] = new LbSprocParameter("@SocialNetworkToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SocialNetworkToken);
                parameter[8] = new LbSprocParameter("@ModelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ModelName);
                parameter[9] = new LbSprocParameter("@OSVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.OSVersion);
                parameter[10] = new LbSprocParameter("@PlatformName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.PlatformName);
                parameter[11] = new LbSprocParameter("@AppVersion", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.AppVersion);
                parameter[12] = new LbSprocParameter("@DeviceToken", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.DeviceToken);
                parameter[13] = new LbSprocParameter("@Gender", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Gender);



                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_CreateCustomer", parameter);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                        objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    }
                    if (objApiResponse.StatusCode != 500)
                    {
                        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            objApiResponse.Result = ds.Tables[1];
                        }
                        else
                        {
                            objApiResponse.Message = "No record found.";
                        }
                    }

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

        public ApiResponse GetCityAndFoodCatogoryList()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_GetCity&FoodCatogoryList", parameter);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        objApiResponse.Result = ds;
                    }

                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
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

        public ApiResponse GetRestaurantReviewRating(int RestaurantID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_GetRestaurantReviewRating", parameter);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        objApiResponse.Result = ds;
                    }
                    Offers objCoupon = new Offers();
                    if (ds.Tables.Count > 1)
                    {
                        objApiResponse.Result = ds;
                    }
                    else
                    {
                        objApiResponse.Message = "No record found.";
                    }
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

        public ApiResponse GetOrderDetailsByIdApi(int TransID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@TransID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, TransID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                ds = elHelper.ExecuteDataset("usp_GetOrderDetailByIdApi", parameter);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 1)
                    {
                        objApiResponse.Result = ds.Tables[0];
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[1].Rows[0]["ResponseCode"]);
                        objApiResponse.Message = Convert.ToString(ds.Tables[1].Rows[0]["ResponseMessage"]);
                    }
                    else
                    {
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                        objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    }
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