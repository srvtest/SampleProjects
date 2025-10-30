//using ELHelper;
using Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class LoginDL
    {
        private static string _EncryptionKey;
        public static string EncryptionKey
        {
            get
            {
                if (_EncryptionKey == null || _EncryptionKey == string.Empty)
                {
                    _EncryptionKey = "H0t3l!Gu35t";
                }
                return _EncryptionKey;
            }
        }
        private int idUsr
        {
            get
            {
                int id = 0;
                //try
                //{
                //    id = HttpContext.Current.ApplicationInstance.Session.Count > 0 ? Convert.ToInt32(HttpContext.Current.ApplicationInstance.Session["UserId"]) : 0;
                //}
                //catch (Exception)
                //{
                //}

                return id;
            }

        }
        public ResponseDto ValidateUserLogin(UserDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                string sUsername = para.Username.Encrypt(EncryptionKey, true);
                string sPassword = para.password.Encrypt(EncryptionKey, true);

                UserDto userDetails = new UserDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("Username", sUsername);
                parameter[1] = new SqlParameter("password", sPassword);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "USP_ValidateUserLogin", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new UserDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, userDetails, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto ForgotPassword(UserDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                string sUsername = para.Username.Encrypt(EncryptionKey, true);

                UserDto userDetails = new UserDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("userName", sUsername);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "ForgotPassword",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_UserForgotPassword",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_UserForgotPassword", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new UserDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, userDetails, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto ResetPassword(UserDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                int idUsr = para.idUser;
                string spassword = para.password.Encrypt(EncryptionKey, true);
                string sNewpassword = para.Newpassword.Encrypt(EncryptionKey, true); ;

                UserDto userDetails = new UserDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[3];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("idUser", idUsr);
                parameter[1] = new SqlParameter("Password", spassword);
                parameter[2] = new SqlParameter("NewPassword", sNewpassword);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "ResetPassword",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_UserChangePassword",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_UserChangePassword", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new UserDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, userDetails, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto SetOTP(string sMobileNo, string OTP, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                HotelMasterDto hotelMasterDto = new HotelMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("MobileNo", sMobileNo);
                parameter[1] = new SqlParameter("OTP", OTP);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "SetOTP",
                    Parameter = parameter.ToXML(),
                    ProcName = "USP_SetOTPHotel",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "USP_SetOTPHotel", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            hotelMasterDto = new HotelMasterDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, hotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto ValidateHotelLogin(string sMobileNo, string OTP, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                HotelMasterDto hotelMasterDto = new HotelMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("MobileNo", sMobileNo);
                parameter[1] = new SqlParameter("OTP", OTP);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_ValidateHotelLogin", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            hotelMasterDto = new HotelMasterDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, hotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }

        public ResponseDto ValidateSignUpOTP(string sMobileNo, string OTP, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                HotelMasterDto hotelMasterDto = new HotelMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("MobileNo", sMobileNo);
                parameter[1] = new SqlParameter("OTP", OTP);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_ValidateSignUpOTP", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            hotelMasterDto = new HotelMasterDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, hotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }

        public ResponseDto ValidatePoliceStationLogin(string sMobileNo, string OTP, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                UserDto userDetails = new UserDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("MobileNo", sMobileNo);
                parameter[1] = new SqlParameter("OTP", OTP);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_ValidatePoliceStationLogin", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new UserDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, userDetails, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto SetPoliceOTP(string sMobileNo, string OTP, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("MobileNo", sMobileNo);
                parameter[1] = new SqlParameter("OTP", OTP);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "SetPoliceOTP",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_SetOTPPolice",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_SetOTPPolice", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                }
                ResponseDto response = new ResponseDto(ResponseCode, null, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }

        public ResponseDto ValidateSubcription(int HotelId, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                TokenExpireForSubcriptionDto Dto = new TokenExpireForSubcriptionDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("HotelId", HotelId);
                //parameter[1] = new SqlParameter("ValidExpire", DateTime.Now);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_ValidateSubcription", parameter);
                //DateTime ValidExpire = new DateTime();
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            Dto = new TokenExpireForSubcriptionDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, Dto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
    }
}
